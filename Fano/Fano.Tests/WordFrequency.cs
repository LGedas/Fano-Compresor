using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace Fano.Tests
{
    [TestClass]
    public class WordFrequencyTests
    {
        [TestMethod]
        public void Constructor_WordSizeEquals3_setsCorrectWordLength()
        {
            const int bitsWordLenght = 3;
            var frequency = new WordFrequency(bitsWordLenght);
            const string errorMessage = @"WordFrequency_Constructor: word lenght is not equal to given parameter";

            Assert.AreEqual(frequency.Word.Length, bitsWordLenght, errorMessage);
        }

        [TestMethod]
        public void Constructor_BitWord101_SetsCorectProperty()
        {
            const int bitsWordSize = 3;
            var expected = new WordFrequency(bitsWordSize);
            expected.Word = new BitArray(new[] { true, false, true });                      

            var frequency = new WordFrequency(new BitArray(new[] { true, false, true }));

            Assert.IsTrue(Fano.Utilities.IsSequenceEqual(frequency, expected));
        }

        //test method writing practice, can be deleted.
        [TestMethod]
        public void Constructor_FrequencyEquals0_GetsCorrectProperty()
        {
            const int expected = 0;
            const int bitsWordLenght = 3;
            var frequency = new WordFrequency(bitsWordLenght);
            string errorMessage = @"WordFrequency_Constructor: Frequency default value is not 0";
            
            Assert.AreEqual(frequency.Frequency, expected, errorMessage);
        }

        //test method writing practice, can be deleted.
        [TestMethod]
        public void IncrementFrequency_CalledOnce_setsCorrectProperty()
        {
            const int expected = 1;
            const int bitsWordLenght = 3;
            var frequency = new WordFrequency(bitsWordLenght);
            string errorMessage = @"WordFrequency.IncrementFrequency: Frequency is not 1";

            frequency.IncrementFrequency();

            Assert.AreEqual(frequency.Frequency, expected, errorMessage);
        }      
    }
}
