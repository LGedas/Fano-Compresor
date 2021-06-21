using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Fano
{
    public class FanoAlgorithm
    {
        private readonly List<WordFrequency> wordFrequency;
        private Dictionary<int, BitArray> _bitsByInt;
        private readonly int[] keys;

        public FanoAlgorithm(List<WordFrequency> wordFrequency)
        {
            this.wordFrequency = wordFrequency;
            _bitsByInt = new Dictionary<int, BitArray>();
            keys = new int [wordFrequency.Count];

            _bitsByInt = Enumerable.Range(0, wordFrequency.Count).ToDictionary(x => GetIntFromBitArray(x), x => (BitArray)null);
            keys = Enumerable.Range(0, wordFrequency.Count).Select(x => GetIntFromBitArray(x)).ToArray();         
        }

        //TO DO: write a better name.
        public void Start() => GetBitsByInt(0, _bitsByInt.Count - 1);

        public void GetBitsByInt(int left, int right)
        {
            if (left == right)
            {
                return;
            }

            int index = SplitIndex(left, right);

            AddBits(left, index, right);

            GetBitsByInt(left, index);
            GetBitsByInt(index + 1, right);
        }

        //TO DO: needs a better name.
        public void AddBits(int left, int index, int right)
        {  
            for (int i = left; i <= right; i++)
            {
                bool value = (i <= index) ? false : true;
                CodeAppendBit(i, value);                 
            }
        }

        //TO DO: needs a better name.
        public void CodeAppendBit(int index, bool value)
        {
            if (_bitsByInt[keys[index]] == null)
            {
                _bitsByInt[keys[index]] = new BitArray(new[] { value });
                return;
            }

            _bitsByInt[keys[index]].Length++;
            _bitsByInt[keys[index]].Set(_bitsByInt[keys[index]].Length - 1, value);
        }

        public int SplitIndex(int left, int right)
        {
            int maxArraySum = TotalFrequency(left, right);

            int index = left;
            int arraySum = 0;
            int nextArraySum = 0;
            int difference = 0;
            int nextDifference = 0;

            do
            {
                arraySum += wordFrequency[index].Frequency;
                nextArraySum = arraySum + wordFrequency[index + 1].Frequency;

                difference = Math.Abs(arraySum - (maxArraySum - arraySum));
                nextDifference = Math.Abs(nextArraySum - (maxArraySum - nextArraySum));

                index++;
            } while (nextDifference < difference);

            return index - 1;
        }

        public int TotalFrequency(int left, int right)
        {
            int sum = 0;

            for (int i = left; i <= right; i++)
            {
                sum += wordFrequency[i].Frequency;
            }

            return sum;
        }

        //TO DO: needs a better name.
        public int GetIntFromBitArray(int index)
        {
            int sum = 0;

            foreach (bool bit in wordFrequency[index].Word)
            {
                sum = sum * 2 + (bit ? 1 : 0);
            }

            return sum;
        }  

        public Dictionary<int, BitArray> BitsByInt => _bitsByInt;        
    }
}