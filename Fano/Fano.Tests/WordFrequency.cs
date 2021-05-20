using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;


namespace Fano.Tests
{
    [TestClass]
    public class WordFrequency
    {
        [TestMethod]
        public void Constructor_WordSizeEquals3_setsCorrectWordLength()
        {
            const int bitsWordLenght = 3;
            Fano.WordFrequency frequency = new Fano.WordFrequency(bitsWordLenght);
            const string errorMessage = @"WordFrequency_Constructor: word lenght is not equal to given parameter";

            Assert.AreEqual(frequency.Word.Length, bitsWordLenght, errorMessage);
        }

        [TestMethod]
        public void Constructor_BitWord101_SetsCorectProperty()
        {
            BitArray expectedBits = new BitArray(values: new[] { true, false, true }); 
            Fano.WordFrequency frequency = new Fano.WordFrequency(new BitArray(values: new[] { true, false, true }));

            Assert.AreEqual(frequency.Word[0], expectedBits[0]);
            Assert.AreEqual(frequency.Word[1], expectedBits[1]);
            Assert.AreEqual(frequency.Word[2], expectedBits[2]);
        }

        //test method writing practice, can be deleted.
        [TestMethod]
        public void Constructor_FrequencyEquals0_GetsCorrectProperty()
        {
            int expected = 0;
            const int bitsWordLenght = 3;
            Fano.WordFrequency frequency = new Fano.WordFrequency(bitsWordLenght);
            string errorMessage = @"WordFrequency_Constructor: Frequency default value is not 0";
            
            Assert.AreEqual(frequency.Frequency, expected, errorMessage);
        }

        //test method writing practice, can be deleted.
        [TestMethod]
        public void IncrementFrequency_CalledOnce_setsCorrectProperty()
        {
            const int expected = 1;
            const int bitsWordLenght = 3;
            Fano.WordFrequency frequency = new Fano.WordFrequency(bitsWordLenght);
            string errorMessage = @"WordFrequency.IncrementFrequency: Frequency is not 1";

            frequency.IncrementFrequency();

            Assert.AreEqual(frequency.Frequency, expected, errorMessage);
        }      

    }
}
