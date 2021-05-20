using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;

namespace Fano.Tests
{
    [TestClass]
    class Utilities
    {
        [TestMethod]
        public void IsSequenceEqual_TwoSameArrays_ReturnsTrue()
        {
            const int bitsWordLenght = 3;

            var frequencies = new List<Fano.WordFrequency>
            {
                new Fano.WordFrequency(bitsWordLenght) {Word = new BitArray(values : new[] { true, true, false })},
                new Fano.WordFrequency(bitsWordLenght) {Word = new BitArray(values : new[] { true, true, false })},
            };

            Assert.IsTrue(Fano.Utilities.IsSequenceEqual(frequencies[0], frequencies[1]));
        }
    }
}
