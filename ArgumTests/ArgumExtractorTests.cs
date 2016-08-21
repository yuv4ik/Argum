using Argum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArgumTests
{
    public abstract class ArgumExtractorTests
    {

        protected IDictionary<string, object> inputArgs = new Dictionary<string, object>
        {
            { "string", "one" },
            { "int", 1 },
            { "double", 1.3 },
            { "bool", bool.TrueString },
            { "dateTime", DateTime.Parse("02/09/1988") },
            { "float", 1.3f },
            { "char", 'C' }
        };
        
        protected string[] GenerateInput(string keyPrefix = "--", string keyPostfix = "=")
        {
            var result = new List<string>();
            inputArgs.ToList().ForEach(p => result.Add($"{keyPrefix}{p.Key}{keyPostfix}{p.Value}"));
            return result.ToArray();
        }
        
        protected ArgumExtractor GenerateArgumExtractor(string[] args) => new ArgumExtractor(args);
    }
}
