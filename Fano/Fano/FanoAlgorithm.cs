using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Fano
{
    public class FanoAlgorithm
    {
        private readonly List<WordFrequency> wordFrequency;
        private Dictionary<int, BitArray> bitsByInt;
        private readonly int[] keys;

        public FanoAlgorithm(List<WordFrequency> wordFrequency)
        {
            this.wordFrequency = wordFrequency;
            bitsByInt = new Dictionary<int, BitArray>();            

            bitsByInt = Enumerable.Range(0, wordFrequency.Count).ToDictionary(x => GetIntFromBitArray(x), x => (BitArray)null); 
            keys = bitsByInt.Select(x => x.Key).ToArray();
        }
       
        public Dictionary<int, BitArray> GetBitsByInt() 
        {
            GenerateBitsByInt(0, bitsByInt.Count - 1);
            return bitsByInt;
        }

        private void GenerateBitsByInt(int left, int right)
        {
            if (left == right)
            {
                return;
            }

            int index = SplitIndex(left, right);

            AddBits(left, index, right);

            GenerateBitsByInt(left, index);
            GenerateBitsByInt(index + 1, right);
        }

        private void AddBits(int left, int index, int right)
        {  
            for (int i = left; i <= right; i++)
            {
                bool value = i <= index ? false : true;
                AddBit(i, value);                 
            }
        }

        private void AddBit(int index, bool value)
        {
            if (bitsByInt[keys[index]] == null)
            {
                bitsByInt[keys[index]] = new BitArray(new[] { value });
                return;
            }

            bitsByInt[keys[index]].Length++;
            bitsByInt[keys[index]].Set(bitsByInt[keys[index]].Length - 1, value);
        }

        private int SplitIndex(int left, int right)
        {
            int maxArraySum = TotalFrequency(left, right);
            int arraySum = 0;

            for (int index = left; index < right; index++)
            {
                arraySum += wordFrequency[index].Frequency;
                int nextArraySum = arraySum + wordFrequency[index + 1].Frequency;

                int difference = Math.Abs(arraySum - (maxArraySum - arraySum));
                int nextDifference = Math.Abs(nextArraySum - (maxArraySum - nextArraySum));

                if (difference <= nextDifference)
                {
                    return index;
                }
            }

            //did not found split index
            throw new Exception();
        }

        private int TotalFrequency(int left, int right)
        {
            int sum = 0;

            for (int i = left; i <= right; i++)
            {
                sum += wordFrequency[i].Frequency;
            }

            return sum;
        }

        private int GetIntFromBitArray(int index)
        {
            int sum = 0;

            foreach (bool bit in wordFrequency[index].Word)
            {
                sum = sum * 2 + (bit ? 1 : 0);
            }

            return sum;
        } 
    }
}