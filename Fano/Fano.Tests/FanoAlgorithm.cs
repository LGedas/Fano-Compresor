using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var expected = new int[] { 2, 4, 5, 2 };

            parser.SetFrequencyTable();
            FanoAlgorithm fano = new FanoAlgorithm(parser.GetFrequencyTable());
  
            Assert.AreEqual(expected[0], fano.SplitIndex(0, 6));
            Assert.AreEqual(expected[1], fano.SplitIndex(3, 6));
            Assert.AreEqual(expected[2], fano.SplitIndex(5, 6));
            Assert.AreEqual(expected[3], fano.SplitIndex(2, 4));
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
    }
}