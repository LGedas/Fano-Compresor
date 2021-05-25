using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;

namespace Fano.Tests
{
    [TestClass]
    public class ParserTests
    {
        private const string path = @"C:\Users\Gedas\Desktop\GitProject\Fano\TestingFiles\test1.txt";

        [TestMethod]
        public void getFrequencyTable_File_abcde()
        {
            int bitsWordLenght = 8;
            Parser parser = new Parser(path, bitsWordLenght);

            List<WordFrequency> expected = new List<WordFrequency>
            {
                new WordFrequency(new BitArray(new [] { false, true, true, false, false, false, false, true })),
                new WordFrequency(new BitArray(new [] { false, true, true, false, false, false, true, false })),
                new WordFrequency(new BitArray(new [] { false, true, true, false, false, false, true, true })),
                new WordFrequency(new BitArray(new [] { false, true, true, false, false, true, false, false })),
                new WordFrequency(new BitArray(new [] { false, true, true, false, false, true, false, true })),
            };

            List<WordFrequency> frequencies = parser.getFrequencyTable();

            Assert.IsTrue(Utilities.IsSequenceEqual(expected[0], frequencies[0]));
            Assert.IsTrue(Utilities.IsSequenceEqual(expected[1], frequencies[1]));
            Assert.IsTrue(Utilities.IsSequenceEqual(expected[2], frequencies[2]));
            Assert.IsTrue(Utilities.IsSequenceEqual(expected[3], frequencies[3]));
            Assert.IsTrue(Utilities.IsSequenceEqual(expected[4], frequencies[4]));
        }


    }
}
