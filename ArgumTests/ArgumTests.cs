using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Argum.Tests
{
    [TestClass()]
    public class ArgumTests
    {
        private IDictionary<string, object> inputArgs = new Dictionary<string, object>
        {
            { "string", "one" },
            { "int", 1 },
            { "double", 1.3 },
            { "bool", bool.TrueString },
            { "dateTime", DateTime.Parse("02/09/1988") },
            { "float", 1.3f }
        };

        [TestMethod()]
        public void GetStringArgumentTest()
        {
            // Arrange
            var argum = GenerateArgumExtractor(GenerateInput());
            var argKey = "string";

            // Act
            var res = argum.GetArgument<string>(argKey);

            // Assert
            Assert.AreEqual(res, inputArgs[argKey]);
        }

        [TestMethod()]
        public void GetIntArgumentTest()
        {
            // Arrange
            var argum = GenerateArgumExtractor(GenerateInput());
            var argKey = "int";

            // Act
            var res = argum.GetArgument<int>(argKey);

            // Assert
            Assert.AreEqual(res, inputArgs[argKey]);
        }

        [TestMethod()]
        public void GetDoubleArgumentTest()
        {
            // Arrange
            var argum = GenerateArgumExtractor(GenerateInput());
            var argKey = "double";

            // Act
            var res = argum.GetArgument<double>(argKey);

            // Assert
            Assert.AreEqual(res, inputArgs[argKey]);
        }

        [TestMethod()]
        public void GetBooleanArgumentTest()
        {
            // Arrange
            var argum = GenerateArgumExtractor(GenerateInput());

            // Act
            var res = argum.GetArgument<bool>("bool");

            // Assert
            Assert.IsTrue(res);
        }

        [TestMethod()]
        public void GetDateTimeArgumentTest()
        {
            // Arrange
            var argum = GenerateArgumExtractor(GenerateInput());
            var argKey = "dateTime";

            // Act
            var res = argum.GetArgument<DateTime>(argKey);

            // Assert
            Assert.AreEqual(res, inputArgs[argKey]);
        }

        [TestMethod()]
        public void GeFloatArgumentTest()
        {
            // Arrange
            var argum = GenerateArgumExtractor(GenerateInput());
            var argKey = "float";

            // Act
            var res = argum.GetArgument<float>(argKey);

            // Assert
            Assert.AreEqual(res, inputArgs[argKey]);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumException))]
        public void GetUnknowsArgumentTest()
        {
            // Arrange
            var argum = GenerateArgumExtractor(GenerateInput());

            // Act
            var res = argum.GetArgument<bool>("non-existing-element");

            // Assert
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumException))]
        public void GetWrongTypeArgumentTest()
        {
            // Arrange
            var argum = GenerateArgumExtractor(GenerateInput());

            // Act
            var res = argum.GetArgument<bool>("int");

            // Assert
        }

        private string[] GenerateInput()
        {
            var result = new List<string>();
            inputArgs.ToList().ForEach(p => result.Add($"--{p.Key}={p.Value}"));

            return result.ToArray();
        }

        private ArgumExtractor GenerateArgumExtractor(string[] args) => new ArgumExtractor(args);
    }
}