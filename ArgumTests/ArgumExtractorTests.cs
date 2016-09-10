using ArgumTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Argum.Tests
{
    [TestClass()]
    public class ArgumExtractorTests : ArgumExtractorTestBase
    {

        [TestMethod()]
        public void SetupArgum_CorrectSettings_ShouldPass()
        {
            // Arrange
            var argum = GenerateArgumExtractor<ConsoleTestApp>();
            
            // Act
            argum.Setup();

            // Assert
            Assert.AreEqual(ConsoleTestApp.Boolean, inputArgs[BoolKey]);
            Assert.AreEqual(ConsoleTestApp.Char, inputArgs[CharKey]);
            Assert.AreEqual(ConsoleTestApp.DateTime, inputArgs[DateTimeKey]);
            Assert.AreEqual(ConsoleTestApp.Double, inputArgs[DoubleKey]);
            Assert.AreEqual(ConsoleTestApp.Float, inputArgs[FloatKey]);
            Assert.AreEqual(ConsoleTestApp.Integer, inputArgs[IntKey]);
            Assert.AreEqual(ConsoleTestApp.String, inputArgs[StringKey]);
            CollectionAssert.AreEqual(ConsoleTestApp.BoolArray, (bool[])inputArgs[BoolArrayKey]);

            CollectionAssert.AreEqual(ConsoleTestApp.CharArray, (char[])inputArgs[CharArrayKey]);
            CollectionAssert.AreEqual(ConsoleTestApp.DateTimeArray, (DateTime[])inputArgs[DateTimeArrayKey]);
            CollectionAssert.AreEqual(ConsoleTestApp.DoubleArray, (double[])inputArgs[DoubleArrayKey]);
            CollectionAssert.AreEqual(ConsoleTestApp.FloatArray, (float[])inputArgs[FloatArrayKey]);
            CollectionAssert.AreEqual(ConsoleTestApp.IntArray, (int[])inputArgs[IntArrayKey]);
            CollectionAssert.AreEqual(ConsoleTestApp.StringArray, (string[])inputArgs[StringArrayKey]);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumException))]
        public void SetupArgum_InvalidDataType_ShouldFail()
        {
            // Arrange
            var argum = GenerateArgumExtractor<InvalidDataTypeConsoleTestApp>();

            // Act
            argum.Setup();

            // Assert
        }

        private class InvalidDataTypeConsoleTestApp
        {
            [ArgumAttribute(name: BoolKey)]
            public static int Integer { get; set; }
        }

        [TestMethod()]
        public void SetupArgum_CorrectSettings_MixedCaseKey_ShouldPass()
        {
            // Arrange
            var argum = GenerateArgumExtractor<MixedCaseKeyConsoleTestApp>();
            
            // Act
            argum.Setup();

            // Assert
            Assert.AreEqual(MixedCaseKeyConsoleTestApp.Boolean, inputArgs[BoolKey]);
        }

        private class MixedCaseKeyConsoleTestApp
        {
            [ArgumAttribute(name: "BoOl")]
            public static bool Boolean { get; set; }
        }

        [TestMethod()]
        public void SetupArgum_DuplicatedKey_ShouldPass()
        {
            // Arrange
            var argum = GenerateArgumExtractor<DuplicatedKeyConsoleTestApp>();

            // Act
            argum.Setup();

            // Assert
            Assert.AreEqual(DuplicatedKeyConsoleTestApp.Double1, inputArgs[DoubleKey]);
            Assert.AreEqual(DuplicatedKeyConsoleTestApp.Double2, inputArgs[DoubleKey]);
        }

        private class DuplicatedKeyConsoleTestApp
        {
            [ArgumAttribute(name: DoubleKey)]
            public static double Double1 { get; set; }
            [ArgumAttribute(name: DoubleKey)]
            public static double Double2 { get; set; }
        }

        [TestMethod()]
        public void SetupArgum_MissingKeyNonMandatory_ShouldPass()
        {
            // Arrange
            var argum = GenerateArgumExtractor<MissingKeyConsoleTestApp>();

            // Act
            argum.Setup();

            // Assert
            Assert.AreEqual(MissingKeyConsoleTestApp.String, null);
        }

        private class MissingKeyConsoleTestApp
        {
            [ArgumAttribute(name: "MissingKey")]
            public static string String { get; set; }
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumException))]
        public void SetupArgum_MissingKeyMandatory_ShouldFail()
        {
            // Arrange
            var argum = GenerateArgumExtractor<MissingMandatoryKeyConsoleTestApp>();

            // Act
            argum.Setup();

            // Assert
            Assert.AreEqual(MissingKeyConsoleTestApp.String, null);
        }

        private class MissingMandatoryKeyConsoleTestApp
        {
            [ArgumAttribute(name: "MissingKey", isMandatory: true)]
            public static string String { get; set; }
        }

        [TestMethod()]
        public void SetupArgum_GenerateHelp_ShouldBeNotNull()
        {
            // Arrange
            var argum = GenerateArgumExtractor<ConsoleTestApp>();

            // Act
            argum.Setup();
            var helpMesage = argum.GetHelpMessage();

            // Assert
            Assert.IsNotNull(helpMesage);
        }

        [TestMethod()]
        public void SetupArgum_UseCustomKeyPrefix_ShouldPass()
        {
            // Arrange
            var keyprefix = "@";
            var argum = GenerateArgumExtractor<ConsoleTestApp>(GenerateInput(keyPrefix: keyprefix));
            argum.KeyPrefix = keyprefix;

            // Act
            argum.Setup();

            // Assert
            Assert.AreEqual(ConsoleTestApp.Boolean, inputArgs[BoolKey]);
            Assert.AreEqual(ConsoleTestApp.Char, inputArgs[CharKey]);
            Assert.AreEqual(ConsoleTestApp.DateTime, inputArgs[DateTimeKey]);
            Assert.AreEqual(ConsoleTestApp.Double, inputArgs[DoubleKey]);
            Assert.AreEqual(ConsoleTestApp.Float, inputArgs[FloatKey]);
            Assert.AreEqual(ConsoleTestApp.Integer, inputArgs[IntKey]);
            Assert.AreEqual(ConsoleTestApp.String, inputArgs[StringKey]);
            CollectionAssert.AreEqual(ConsoleTestApp.BoolArray, (bool[])inputArgs[BoolArrayKey]);

            CollectionAssert.AreEqual(ConsoleTestApp.CharArray, (char[])inputArgs[CharArrayKey]);
            CollectionAssert.AreEqual(ConsoleTestApp.DateTimeArray, (DateTime[])inputArgs[DateTimeArrayKey]);
            CollectionAssert.AreEqual(ConsoleTestApp.DoubleArray, (double[])inputArgs[DoubleArrayKey]);
            CollectionAssert.AreEqual(ConsoleTestApp.FloatArray, (float[])inputArgs[FloatArrayKey]);
            CollectionAssert.AreEqual(ConsoleTestApp.IntArray, (int[])inputArgs[IntArrayKey]);
            CollectionAssert.AreEqual(ConsoleTestApp.StringArray, (string[])inputArgs[StringArrayKey]);
        }

        [TestMethod()]
        public void SetupArgum_UseCustomKeyPostfix_ShouldPass()
        {
            // Arrange
            var postfix = "|";
            var argum = GenerateArgumExtractor<ConsoleTestApp>(GenerateInput(keyPostfix: postfix));
            argum.KeyPostfix = postfix;

            // Act
            argum.Setup();

            // Assert
            Assert.AreEqual(ConsoleTestApp.Boolean, inputArgs[BoolKey]);
            Assert.AreEqual(ConsoleTestApp.Char, inputArgs[CharKey]);
            Assert.AreEqual(ConsoleTestApp.DateTime, inputArgs[DateTimeKey]);
            Assert.AreEqual(ConsoleTestApp.Double, inputArgs[DoubleKey]);
            Assert.AreEqual(ConsoleTestApp.Float, inputArgs[FloatKey]);
            Assert.AreEqual(ConsoleTestApp.Integer, inputArgs[IntKey]);
            Assert.AreEqual(ConsoleTestApp.String, inputArgs[StringKey]);
            CollectionAssert.AreEqual(ConsoleTestApp.BoolArray, (bool[])inputArgs[BoolArrayKey]);

            CollectionAssert.AreEqual(ConsoleTestApp.CharArray, (char[])inputArgs[CharArrayKey]);
            CollectionAssert.AreEqual(ConsoleTestApp.DateTimeArray, (DateTime[])inputArgs[DateTimeArrayKey]);
            CollectionAssert.AreEqual(ConsoleTestApp.DoubleArray, (double[])inputArgs[DoubleArrayKey]);
            CollectionAssert.AreEqual(ConsoleTestApp.FloatArray, (float[])inputArgs[FloatArrayKey]);
            CollectionAssert.AreEqual(ConsoleTestApp.IntArray, (int[])inputArgs[IntArrayKey]);
            CollectionAssert.AreEqual(ConsoleTestApp.StringArray, (string[])inputArgs[StringArrayKey]);
        }
    }
}