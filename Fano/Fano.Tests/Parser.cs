using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;

namespace Fano.Tests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void getFrequencyTable_File_abcde()
        {
            TestFileManager.MakeFile("aaaabbbbccccddee");
            int bitsWordLenght = 8;
            var parser = new Parser(TestFileManager.path, bitsWordLenght);

            var expected = new List<WordFrequency>
            {
                new WordFrequency(new BitArray(new [] { false, true, true, false, false, false, false, true })),
                new WordFrequency(new BitArray(new [] { false, true, true, false, false, false, true, false })),
                new WordFrequency(new BitArray(new [] { false, true, true, false, false, false, true, true })),
                new WordFrequency(new BitArray(new [] { false, true, true, false, false, true, false, false })),
                new WordFrequency(new BitArray(new [] { false, true, true, false, false, true, false, true })),
            };

            List<WordFrequency> frequencies = parser.getFrequencyTable();

            TestFileManager.DeleteFile();

            Assert.IsTrue(Utilities.IsSequenceEqual(expected[0], frequencies[0]));
            Assert.IsTrue(Utilities.IsSequenceEqual(expected[1], frequencies[1]));
            Assert.IsTrue(Utilities.IsSequenceEqual(expected[2], frequencies[2]));
            Assert.IsTrue(Utilities.IsSequenceEqual(expected[3], frequencies[3]));
            Assert.IsTrue(Utilities.IsSequenceEqual(expected[4], frequencies[4]));
        }

        [TestMethod]
        public void getFrequencyTable_File_44422()
        {
            TestFileManager.MakeFile("aaaabbbbccccddee");
            int bitsWordLenght = 8;
            var parser = new Parser(TestFileManager.path, bitsWordLenght);
            int[] expected = new int[] { 4, 4, 4, 2, 2 };

            List<WordFrequency> frequencies = parser.getFrequencyTable();

            TestFileManager.DeleteFile();

            Assert.AreEqual(expected[0], frequencies[0].Frequency);
            Assert.AreEqual(expected[1], frequencies[1].Frequency);
            Assert.AreEqual(expected[2], frequencies[2].Frequency);
            Assert.AreEqual(expected[3], frequencies[3].Frequency);
            Assert.AreEqual(expected[4], frequencies[4].Frequency);          
        }
    }
}
