using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;

namespace Fano.Tests
{
    [TestClass]
    public class ParserTests
    {        
        [TestCleanup]
        public void TestClean()
        {
            TestFileUtilities.DeleteFile();
        }

        [TestMethod]
        public void getFrequencyTable_wordSize8_CorrectTable()
        {
            TestFileUtilities.MakeFile("aaaabbbbccccddee");

            int bitsWordLenght = 8;
            var parser = new Parser(TestFileUtilities.path, bitsWordLenght);
            var expected = new int[] { 4, 4, 4, 2, 2 };

            var expectedBits = new List<WordFrequency>
            {
                new WordFrequency(new BitArray(new [] { false, true, true, false, false, false, false, true })),
                new WordFrequency(new BitArray(new [] { false, true, true, false, false, false, true, false })),
                new WordFrequency(new BitArray(new [] { false, true, true, false, false, false, true, true })),
                new WordFrequency(new BitArray(new [] { false, true, true, false, false, true, false, false })),
                new WordFrequency(new BitArray(new [] { false, true, true, false, false, true, false, true }))
            };

            List<WordFrequency> frequencies = parser.GetFrequencyTable();

            Assert.IsTrue(TestUtils.AreWordsEqual(frequencies, expectedBits));
            Assert.IsTrue(TestUtils.AreFrequenciesEqual(frequencies, expected));
        }

        [TestMethod]
        public void getFrequencyTable_wordSize4_CorrectTable()
        {
            TestFileUtilities.MakeFile("aaaabbbbccccddee");

            int bitsWordLenght = 4;
            var parser = new Parser(TestFileUtilities.path, bitsWordLenght);
            var expected = new int[] { 16, 4, 4, 4, 2, 2 };

            var expectedBits = new List<WordFrequency>
            {
                new WordFrequency(new BitArray(new [] { false, true, true, false})),
                new WordFrequency(new BitArray(new [] { false, false, false, true })),
                new WordFrequency(new BitArray(new [] { false, false, true, false })),
                new WordFrequency(new BitArray(new [] { false, false, true, true })),
                new WordFrequency(new BitArray(new [] { false, true, false, false })),
                new WordFrequency(new BitArray(new [] { false, true, false, true }))
            };

            List<WordFrequency> frequencies = parser.GetFrequencyTable();

            Assert.IsTrue(TestUtils.AreWordsEqual(frequencies, expectedBits));
            Assert.IsTrue(TestUtils.AreFrequenciesEqual(frequencies, expected));
        }

        [TestMethod]
        public void getFrequencyTable_wordSize3_CorrectTable()
        {
            TestFileUtilities.MakeFile("aaaabbbbccccddee");

            int bitsWordLenght = 3;
            var parser = new Parser(TestFileUtilities.path, bitsWordLenght);
            var expectedFrequencies = new int[] { 9, 8, 6, 6, 6, 4, 3 };
            var expectedRemainder = new BitArray(new[] { false, true });

            var expectedBits = new List<WordFrequency>
            {
                new WordFrequency(new BitArray(new [] { false, false, true })),
                new WordFrequency(new BitArray(new [] { false, true, true })),
                new WordFrequency(new BitArray(new [] { false, false, false })),
                new WordFrequency(new BitArray(new [] { true, true, false })),
                new WordFrequency(new BitArray(new [] { true, false, false })),
                new WordFrequency(new BitArray(new [] { false, true, false })),
                new WordFrequency(new BitArray(new [] { true, false, true })),
            };

            List<WordFrequency> frequencies = parser.GetFrequencyTable();

            BitArray remaider = parser.GetRemainingBits();

            Assert.AreEqual(remaider.Length, expectedRemainder.Length);
            Assert.IsTrue((remaider[0] == expectedRemainder[0]) & (remaider[1] == expectedRemainder[1]));
            Assert.IsTrue(TestUtils.AreFrequenciesEqual(frequencies, expectedFrequencies));
            Assert.IsTrue(TestUtils.AreWordsEqual(frequencies, expectedBits));
        }
    }
}
