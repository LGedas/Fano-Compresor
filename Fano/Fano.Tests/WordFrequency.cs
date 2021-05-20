using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace Fano.Tests
{
    [TestClass]
    public class WordFrequency
    {
        [TestMethod]
        public void Constructor_whenWordSizeEquals3_setsCorrectWordLength()
        {
            const int wordSize = 3;
            Fano.WordFrequency wordFrequency = new Fano.WordFrequency(wordSize);
            const string errorMessage = @"WordFrequency_Constructor: word lenght is not equal to given parameter";

            Assert.AreEqual(wordFrequency.Word.Length, wordSize, errorMessage);
        }

        //test method writing practice, can be deleted.
        [TestMethod]
        public void Constructor_whenFrequencyEquals0_GetsCorrectProperty()
        {
            const int wordSize = 3;
            Fano.WordFrequency wordFrequency = new Fano.WordFrequency(wordSize);
            string errorMessage = @"WordFrequency_Constructor: Frequency default value is not 0";

            int expectedFreequency = 0;

            Assert.AreEqual(wordFrequency.Frequency, expectedFreequency, errorMessage);
        }

        //test method writing practice, can be deleted.
        [TestMethod]
        public void IncrementFrequency_whenCalledOnce_setsCorrectProperty()
        {
            const int expectedFreequency = 1;
            const int wordSize = 3;
            Fano.WordFrequency wordFrequency = new Fano.WordFrequency(wordSize);
            string errorMessage = @"WordFrequency.IncrementFrequency: Frequency is not 1";

            wordFrequency.IncrementFrequency();

            Assert.AreEqual(wordFrequency.Frequency, expectedFreequency);
        }

    }
}
