using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

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
        public void Start_FrequencyTable_CorrectDictionary()
        {            
            var expectedKeys = new int[] { 1, 3, 0, 6, 4, 2, 5 };
            var expectedBits = new List<BitArray>
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
            Dictionary<int, BitArray> bitsByInt = fano.GetBitsByInt();

            Assert.AreEqual(expectedKeys.Count(), bitsByInt.Count);

            Assert.IsTrue(bitsByInt.ContainsKey(expectedKeys[0]));
            Assert.IsTrue(bitsByInt.ContainsKey(expectedKeys[1]));
            Assert.IsTrue(bitsByInt.ContainsKey(expectedKeys[2]));
            Assert.IsTrue(bitsByInt.ContainsKey(expectedKeys[3]));
            Assert.IsTrue(bitsByInt.ContainsKey(expectedKeys[4]));
            Assert.IsTrue(bitsByInt.ContainsKey(expectedKeys[5]));
            Assert.IsTrue(bitsByInt.ContainsKey(expectedKeys[6]));

            Assert.IsTrue(TestUtils.AreBitArraysEqual(expectedBits[0], bitsByInt[expectedKeys[0]]));
            Assert.IsTrue(TestUtils.AreBitArraysEqual(expectedBits[1], bitsByInt[expectedKeys[1]]));
            Assert.IsTrue(TestUtils.AreBitArraysEqual(expectedBits[2], bitsByInt[expectedKeys[2]]));
            Assert.IsTrue(TestUtils.AreBitArraysEqual(expectedBits[3], bitsByInt[expectedKeys[3]]));
            Assert.IsTrue(TestUtils.AreBitArraysEqual(expectedBits[4], bitsByInt[expectedKeys[4]]));
            Assert.IsTrue(TestUtils.AreBitArraysEqual(expectedBits[5], bitsByInt[expectedKeys[5]]));
            Assert.IsTrue(TestUtils.AreBitArraysEqual(expectedBits[6], bitsByInt[expectedKeys[6]]));
        }
    }
}