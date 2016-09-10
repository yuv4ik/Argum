using Argum;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ArgumTests
{
    public abstract class ArgumExtractorTestBase
    {

        protected const string StringKey = "string";
        protected const string IntKey = "int";
        protected const string DoubleKey = "double";
        protected const string BoolKey = "bool";
        protected const string DateTimeKey = "dateTime";
        protected const string FloatKey = "float";
        protected const string CharKey = "char";
        protected const string StringArrayKey = "stringArray";
        protected const string IntArrayKey = "intArray";
        protected const string DoubleArrayKey = "doubleArray";
        protected const string BoolArrayKey = "boolArray";
        protected const string DateTimeArrayKey = "dateTimeArray";
        protected const string FloatArrayKey = "floatArray";
        protected const string CharArrayKey = "charArray";

        protected IDictionary<string, object> inputArgs = new Dictionary<string, object>
        {
            { StringKey, "one" },
            { IntKey, 1 },
            { DoubleKey, 1.3 },
            { BoolKey, true },
            { DateTimeKey, DateTime.Parse("02/09/1988") },
            { FloatKey, 1.3f },
            { CharKey, 'C' },
            { StringArrayKey, new string[] { "a", "b", "c" }},
            { IntArrayKey, new int[] { 1, 2, 3 }},
            { DoubleArrayKey, new double[] {1.5, 2.5, 3.5 } },
            { BoolArrayKey, new bool[] { true, false, true } },
            { DateTimeArrayKey, new DateTime[] { DateTime.Parse("1-sep-16"), DateTime.Parse("2-sep-16"), DateTime.Parse("3-sep-16") } },
            { FloatArrayKey, new float[] { 0.1f, 0.4f , 0.7f } },
            { CharArrayKey, new char[] { 'a', 'b', 'c' } }
        };
        
        protected string[] GenerateInput(string keyPrefix = "--", string keyPostfix = "=")
        {
            var result = new List<string>();
            inputArgs.ToList().ForEach(p => {
                if(p.Value is Array)
                {
                    var strings = ((IEnumerable)p.Value).Cast<object>()
                                   .Select(x => x == null ? x : x.ToString())
                                   .ToArray();
                    result.Add($"{keyPrefix}{p.Key}{keyPostfix}{string.Join(",", strings)}");
                }
                else
                    result.Add($"{keyPrefix}{p.Key}{keyPostfix}{p.Value}");
            });
            return result.ToArray();
        }

        protected ArgumExtractor<T> GenerateArgumExtractor<T>() => new ArgumExtractor<T>(GenerateInput());
        protected ArgumExtractor<T> GenerateArgumExtractor<T>(string[] args) => new ArgumExtractor<T>(args);

        protected class ConsoleTestApp
        {
            [ArgumAttribute(name: StringKey, description: "text")]
            public static string String { get; set; }
            [ArgumAttribute(name: IntKey, description: "number")]
            public static int Integer { get; set; }
            [ArgumAttribute(name: DoubleKey, description: "number")]
            public static double Double { get; set; }
            [ArgumAttribute(name: BoolKey, description: "boolean")]
            public static bool Boolean { get; set; }
            [ArgumAttribute(name: DateTimeKey, description: "date & time")]
            public static DateTime DateTime { get; set; }
            [ArgumAttribute(name: FloatKey, description: "number")]
            public static float Float { get; set; }
            [ArgumAttribute(name: CharKey, description: "character")]
            public static char Char { get; set; }
            [ArgumAttribute(name: StringArrayKey, description: "string[]")]
            public static string[] StringArray { get; set; }
            [ArgumAttribute(name: IntArrayKey, description: "int[]")]
            public static int[] IntArray { get; set; }
            [ArgumAttribute(name: DoubleArrayKey, description: "double[]")]
            public static double[] DoubleArray { get; set; }
            [ArgumAttribute(name: BoolArrayKey, description: "bool[]")]
            public static bool[] BoolArray { get; set; }
            [ArgumAttribute(name: DateTimeArrayKey, description: "DateTime[]")]
            public static DateTime[] DateTimeArray { get; set; }
            [ArgumAttribute(name: FloatArrayKey, description: "float[]")]
            public static float[] FloatArray { get; set; }
            [ArgumAttribute(name: CharArrayKey, description: "char[]")]
            public static char[] CharArray { get; set; }
        }
    }
}
