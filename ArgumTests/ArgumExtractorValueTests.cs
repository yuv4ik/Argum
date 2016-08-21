using ArgumTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Argum.Tests
{
    [TestClass()]
    public class ArgumExtractorValueTests : ArgumExtractorTests
    {
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
        public void GetFloatArgumentTest()
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
        public void GetCharArgumentTest()
        {
            // Arrange
            var argum = GenerateArgumExtractor(GenerateInput());
            var argKey = "char";

            // Act
            var res = argum.GetArgument<char>(argKey);

            // Assert
            Assert.AreEqual(res, inputArgs[argKey]);
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
    }
}