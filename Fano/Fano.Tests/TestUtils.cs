using System.Collections.Generic;
using System.Collections;

namespace Fano.Tests
{
    public static class TestUtils
    {
        public static bool AreFrequenciesEqual(List<WordFrequency> frequencies, int[] expected)
        {
            if (frequencies.Count != expected.Length)
            {
                return false;
            }

            for (int i = 0; i < frequencies.Count; i++)
            {
                if (frequencies[i].Frequency != expected[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool AreWordsEqual(List<WordFrequency> frequencies, List<WordFrequency> expected)
        {
            if (frequencies.Count != expected.Count)
            {
                return false;
            }

            for (int i = 0; i < frequencies.Count; i++)
            {
                if (!Utilities.IsSequenceEqual(frequencies[i], expected[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
