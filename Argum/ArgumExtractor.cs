using System;
using System.Linq;

namespace Argum
{
    /// <summary>
    /// <para>Responsible for extracting arguments from given input.</para>
    /// </summary>
    public class ArgumExtractor
    {
        /// <summary>
        /// <para>Case insensitive flag.</para>
        /// <para>False by default.</para>
        /// </summary>
        public bool IsCaseInsensitive { get; set; }
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

        public ArgumExtractor(string[] args)
        {
            input = args;
        }

        /// <summary>
        /// <para>Returns an argument value with appropriate type.</para>
        /// <para>Throws ArgumException.</para>
        /// </summary>
        /// <typeparam name="T">Output type</typeparam>
        /// <param name="arg">Argument key</param>
        /// <returns></returns>
        public T GetArgument<T>(string arg)
        {
            try
            {
                var argKey = GenerateArgumentKey(arg);
                var argVal = GetArgumentValueByKey(argKey);
                return (T)Convert.ChangeType(argVal, typeof(T));
            }
            catch (Exception ex)
            {
                throw new ArgumException($"GetArgument {arg} is failed with:", ex);
            }
        }

        /// <summary>
        /// <para>Returns a command line parameter key.</para>
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private string GenerateArgumentKey(string arg)
        {
            var argKey = $"{KeyPrefix}{arg}{KeyPostfix}";
            if (IsCaseInsensitive)
                argKey = argKey.ToLowerInvariant();
            return argKey;
        }

        /// <summary>
        /// <para>Returns a command line parameter value by key.</para>
        /// </summary>
        /// <param name="argKey"></param>
        /// <returns></returns>
        private string GetArgumentValueByKey(string argKey)
        {
            var argVal = input.First(x => x.StartsWith(argKey));
            return argVal.Replace(argKey, string.Empty);
        }
    }

    public class ArgumException : Exception
    {
        public ArgumException(string message, Exception innerException) : base(message, innerException) { }
    }
}

