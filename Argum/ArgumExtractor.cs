using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Argum
{
    public class ArgumExtractor<T>
    {
        /// <summary>
        /// <para>Argument key prefix.</para>
        /// <para>'--' by default.</para>
        /// </summary>
        public string KeyPrefix { get; set; } = "--";
        /// <summary>
        /// <para>Argument key postfix.</para>
        /// <para>'=' by default.</para>
        /// </summary>
        public string KeyPostfix { get; set; } = "=";
        /// <summary>
        /// <para>Input command line arguments.</para>
        /// <para>By default expects: --arg1=val1 --arg2=val2</para>
        /// </summary>
        private string[] input;
        private IDictionary<string, object> arguments;

        public ArgumExtractor(string[] args)
        {
            arguments = new Dictionary<string, object>();
            input = args;
        }

        /// <summary>
        /// <para>Maps user input to ArgumAttributes.</para>
        /// </summary>
        public void Setup()
        {
            try
            {
                ParseUserInput();
                Map();
            }
            catch (ArgumException ex) { throw ex; }
            catch (Exception ex)
            {
                throw new ArgumException("Argum setup failed.", ex);
            }
        }

        /// <summary>
        /// <para>Returns an auto-generated help message.</para>
        /// </summary>
        /// <returns></returns>
        public string GetHelpMessage()
        {
            var help = new StringBuilder();
            GetProperties().ToList().ForEach(prop =>
            {
                var attr = GetArgumAttribute(prop);
                help.AppendLine($"{attr}");
            });
            return help.ToString();
        }

        private void ParseUserInput()
        {
            input.ToList().ForEach(arg =>
            {
                arguments.Add(ExtractArgumentKey(arg), ExtractArgumentValue(arg));
            });
        }

        private string ExtractArgumentValue(string arg)
        {
            var startIndex = arg.LastIndexOf(KeyPostfix) + 1;
            return arg.Substring(startIndex);
        }

        private string ExtractArgumentKey(string arg)
        {
            var startIndex = arg.LastIndexOf(KeyPrefix) + KeyPrefix.Length;
            var endIndex = arg.LastIndexOf(KeyPostfix) - KeyPostfix.Length - 1;
            return arg.Substring(startIndex, endIndex).ToLowerInvariant();
        }

        private void Map()
        {
            GetProperties().ForEach(prop =>
            {
                var attr = GetArgumAttribute(prop);
                var attributeName = attr.Name.ToLowerInvariant();

                if (arguments.ContainsKey(attributeName))
                    prop.SetValue(null, ArgumValueConverter.ConvertValue(arguments[attributeName], prop.PropertyType));
                else if (attr.IsMandatory)
                    throw new ArgumException($"Argument {attr.Name} is mandatory.", new ArgumentNullException());
            });
        }

        private List<PropertyInfo> GetProperties() =>  typeof(T).GetProperties().ToList();

        private ArgumAttribute GetArgumAttribute(PropertyInfo prop) => ((ArgumAttribute[])prop.GetCustomAttributes(typeof(ArgumAttribute), false)).FirstOrDefault();

    }

    public class ArgumException : Exception
    {
        public ArgumException(string message, Exception innerException) : base(message, innerException) { }
    }
}
