using System;
using System.Linq;

namespace Argum
{
    /// <summary>
    /// <para>Responsible for extracting arguments from given input.</para>
    /// </summary>
    public class ArgumExtractor
    {

        private string[] input;

        /// <summary>
        /// </summary>
        /// <param name="args">Expects the input in the next format: --arg1=val1 --arg2=val2</param>
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
                var argKey = $"--{arg}=";
                var argVal = input.First(x => x.StartsWith(argKey));
                return (T)Convert.ChangeType(argVal.Replace(argKey, string.Empty), typeof(T));
            }
            catch (Exception ex)
            {
                throw new ArgumException($"GetArgument {arg} is failed with:", ex);
            }
        }
    }

    public class ArgumException : Exception
    {
        public ArgumException(string message, Exception innerException) : base(message, innerException) { }
    }
}

