using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;

namespace Fano.Tests
{
    [TestClass]
    public class UtilitiesTest
    {
        [TestMethod]
        public void IsSequenceEqual_TwoSameListArrays_ReturnsTrue()
        {
            var frequencies = new List<WordFrequency>
            {
                new WordFrequency(new BitArray(new[] { true, true, false })),
                new WordFrequency(new BitArray(new[] { true, true, false })),
            };

            Assert.IsTrue(Fano.Utilities.IsSequenceEqual(frequencies[0], frequencies[1]));
        }

        [TestMethod]
        public void IsSequenceEqual_TwoSameArrays_ReturnsTrue()
        {
            var frequencies1 = new List<WordFrequency> { new WordFrequency(new BitArray(new[] { true, true, false })) };
            var frequencies2 = new List<WordFrequency> { new WordFrequency(new BitArray(new[] { true, true, false })) };

            Assert.IsTrue(Fano.Utilities.IsSequenceEqual(frequencies1[0], frequencies2[0]));
        }
    }
}
