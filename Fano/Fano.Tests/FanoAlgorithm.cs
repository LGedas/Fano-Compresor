using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fano.Tests
{
    [TestClass]
    public class FanoAlgorithmTest
    {
        [TestCleanup]
        public void TestClean() => TestFileUtilities.DeleteFile();

        [TestMethod]
        public void TotalFrequency_Table9866643_CorrectSum()
        {
            TestFileUtilities.MakeFile("aaaabbbbccccddee");

            int bitsWordLenght = 3;
            var parser = new Parser(TestFileUtilities.path, bitsWordLenght);
            //{ 9, 8, 6, 6, 6, 4, 3 };


            parser.SetFrequencyTable();
            FanoAlgorithm fano = new FanoAlgorithm(parser.GetFrequencyTable());           

            Assert.AreEqual(23, fano.TotalFrequency(0, 2));
            Assert.AreEqual(18, fano.TotalFrequency(2, 4));
            Assert.AreEqual(13, fano.TotalFrequency(4, 6));
            Assert.AreEqual(42, fano.TotalFrequency(0, 6));
            Assert.AreEqual(19, fano.TotalFrequency(3, 6));
            Assert.AreEqual(7, fano.TotalFrequency(5, 6));
            Assert.AreEqual(18, fano.TotalFrequency(2, 4));
        }

        [TestMethod]
        public void SplitIndex_Table9866643_CorrectIndex()
        {
            TestFileUtilities.MakeFile("aaaabbbbccccddee");
            
            int bitsWordLenght = 3;
            var parser = new Parser(TestFileUtilities.path, bitsWordLenght);
            //Frequencies { 9, 8, 6, 6, 6, 4, 3 };

            parser.SetFrequencyTable();
            FanoAlgorithm fano = new FanoAlgorithm(parser.GetFrequencyTable());
  
            Assert.AreEqual(2, fano.SplitIndex(0, 6));
            Assert.AreEqual(4, fano.SplitIndex(3, 6));
            Assert.AreEqual(5, fano.SplitIndex(5, 6));
            Assert.AreEqual(2, fano.SplitIndex(2, 4));
        }
    }
}
