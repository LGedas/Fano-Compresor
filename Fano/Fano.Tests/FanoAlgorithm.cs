using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;

namespace Fano.Tests
{
    [TestClass]
    public class FanoAlgorithmTest
    {
        private Parser parser;
        
        [TestInitialize]
        public void TestInitialize()
        {
            TestFileUtilities.MakeFile("aaaabbbbccccddee");

            int bitsWordLenght = 3;
            parser = new Parser(TestFileUtilities.path, bitsWordLenght);
        }

        [TestCleanup]
        public void TestClean() => TestFileUtilities.DeleteFile();

        [TestMethod]
        public void TotalFrequency_Table9866643_CorrectSum()
        {
            var expected = new int[] { 23, 18, 13, 42, 19, 7, 18 };

            parser.SetFrequencyTable();
            FanoAlgorithm fano = new FanoAlgorithm(parser.GetFrequencyTable());           

            Assert.AreEqual(expected[0], fano.TotalFrequency(0, 2));
            Assert.AreEqual(expected[1], fano.TotalFrequency(2, 4));
            Assert.AreEqual(expected[2], fano.TotalFrequency(4, 6));
            Assert.AreEqual(expected[3], fano.TotalFrequency(0, 6));
            Assert.AreEqual(expected[4], fano.TotalFrequency(3, 6));
            Assert.AreEqual(expected[5], fano.TotalFrequency(5, 6));
            Assert.AreEqual(expected[6], fano.TotalFrequency(2, 4));
        }

        [TestMethod]
        public void SplitIndex_Table9866643_CorrectIndex()
        {
            var expected = new int[] { 2, 0, 4, 1, 3, 5 };

            parser.SetFrequencyTable();
            FanoAlgorithm fano = new FanoAlgorithm(parser.GetFrequencyTable());
  
            Assert.AreEqual(expected[0], fano.SplitIndex(0, 6));
            Assert.AreEqual(expected[1], fano.SplitIndex(0, 2));
            Assert.AreEqual(expected[2], fano.SplitIndex(3, 6));
            Assert.AreEqual(expected[3], fano.SplitIndex(1, 2));
            Assert.AreEqual(expected[4], fano.SplitIndex(3, 4));                 
            Assert.AreEqual(expected[5], fano.SplitIndex(5, 6));
        }

        [TestMethod]
        public void GetIntFroomBitArray_FrequencyTable_CorrectConversion()
        {            
            var expected = new int[] { 1, 3, 0, 6, 4, 2, 5 };

            parser.SetFrequencyTable();
            FanoAlgorithm fano = new FanoAlgorithm(parser.GetFrequencyTable());

            Assert.AreEqual(expected[0], fano.GetIntFromBitArray(0));
            Assert.AreEqual(expected[1], fano.GetIntFromBitArray(1));
            Assert.AreEqual(expected[2], fano.GetIntFromBitArray(2));
            Assert.AreEqual(expected[3], fano.GetIntFromBitArray(3));
            Assert.AreEqual(expected[4], fano.GetIntFromBitArray(4));
            Assert.AreEqual(expected[5], fano.GetIntFromBitArray(5));
            Assert.AreEqual(expected[6], fano.GetIntFromBitArray(6));
        }

        [TestMethod]
        public void Start_FrequencyTable_CorrectDictionary()
        {
            var expectedCount = 7;
            var expectedLenght = new int[] { 3, 2, 3, 3, 3, 3, 3 };

            //TO DO: Assert for values, clean unnecesary Assert lines.
            var expectedsBits = new List<BitArray>() 
            { 
                new BitArray(new[] { false, false }),
                new BitArray(new[] { false, true, false }),
                new BitArray(new[] { false, true, true }),
                new BitArray(new[] { true, false, false }),
                new BitArray(new[] { true, false, true }),
                new BitArray(new[] { true, true, false }),
                new BitArray(new[] { true, true, true })
            };

            parser.SetFrequencyTable();
            FanoAlgorithm fano = new FanoAlgorithm(parser.GetFrequencyTable());
            fano.Start();

            Assert.AreEqual(expectedCount, fano.BitsByInt.Count);
            Assert.IsTrue(fano.BitsByInt.ContainsKey(0));
            Assert.IsTrue(fano.BitsByInt.ContainsKey(1));
            Assert.IsTrue(fano.BitsByInt.ContainsKey(2));
            Assert.IsTrue(fano.BitsByInt.ContainsKey(3));
            Assert.IsTrue(fano.BitsByInt.ContainsKey(4));
            Assert.IsTrue(fano.BitsByInt.ContainsKey(5));
            Assert.IsTrue(fano.BitsByInt.ContainsKey(6));

            Assert.AreEqual(expectedLenght[0], fano.BitsByInt[0].Count);
            Assert.AreEqual(expectedLenght[1], fano.BitsByInt[1].Count);
            Assert.AreEqual(expectedLenght[2], fano.BitsByInt[2].Count);
            Assert.AreEqual(expectedLenght[3], fano.BitsByInt[3].Count);
            Assert.AreEqual(expectedLenght[4], fano.BitsByInt[4].Count);
            Assert.AreEqual(expectedLenght[5], fano.BitsByInt[5].Count);
            Assert.AreEqual(expectedLenght[6], fano.BitsByInt[6].Count);
        }
    }
}