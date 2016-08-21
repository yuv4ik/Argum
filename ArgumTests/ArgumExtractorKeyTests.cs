using Argum;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArgumTests
{
    [TestClass]
    public class ArgumExtractorKeyTests : ArgumExtractorTests
    {

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
        public void GetCaseInsensitiveArgumentTest()
        {
            // Arrange
            var argum = GenerateArgumExtractor(GenerateInput());
            argum.IsCaseInsensitive = true;
            var argKey = "float";

            // Act
            var res = argum.GetArgument<float>(argKey.ToUpperInvariant());

            // Assert
            Assert.AreEqual(res, inputArgs[argKey]);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumException))]
        public void GetCaseSensitiveArgumentTest()
        {
            // Arrange
            var argum = GenerateArgumExtractor(GenerateInput());
            var argKey = "float";

            // Act
            var res = argum.GetArgument<float>(argKey.ToUpperInvariant());

            // Assert
        }

        [TestMethod()]
        public void GetCustomKeyPrefixArgumentTest()
        {
            // Arrange
            var customKeyPrefix = "@";
            var argum = GenerateArgumExtractor(GenerateInput(keyPrefix: customKeyPrefix));
            argum.KeyPrefix = customKeyPrefix;
            
            var argKey = "float";

            // Act
            var res = argum.GetArgument<float>(argKey);

            // Assert
            Assert.AreEqual(res, inputArgs[argKey]);
        }

        [TestMethod()]
        public void GetCustomKeyPostfixArgumentTest()
        {
            // Arrange
            var customKeyPostfix = ">";
            var argum = GenerateArgumExtractor(GenerateInput(keyPostfix: customKeyPostfix));
            argum.KeyPostfix = customKeyPostfix;

            var argKey = "float";

            // Act
            var res = argum.GetArgument<float>(argKey);

            // Assert
            Assert.AreEqual(res, inputArgs[argKey]);
        }

    }
}
