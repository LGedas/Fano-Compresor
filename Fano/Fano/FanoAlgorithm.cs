using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Fano
{
    public class FanoAlgorithm
    {
        private readonly List<WordFrequency> table;
        private Dictionary<int, BitArray> codes;

        public FanoAlgorithm(List<WordFrequency> table)
        {
            this.table = table;
            codes = new Dictionary<int, BitArray>();

            InitializeDictionary();
        }

        public void Start(int left, int right)
        {              
            if (left == right)
            {
                return;
            }             

            if (left == right - 1)
            {
                CodeAppendBit(left, false);
                CodeAppendBit(right, true);

                return;
            }

            int index = SplitIndex(left, right);

            for (int i = left; i <= index; i++)
            {
                CodeAppendBit(i, false);
            }

            for (int i = index + 1; i <= right; i++)
            {
                CodeAppendBit(right, true);
            }          

            Start(left, index);
            Start(index + 1, right);
        }

        public int TotalFrequency(int left, int right)
        {
            int sum = 0;

            for (int i = left; i <= right; i++)
            {
                sum += table[i].Frequency;
            }
            
            return sum;
        }

        public int SplitIndex(int left, int right)
        {
            int maxArraySum = TotalFrequency(left, right);

            int index = left;

            int arraySum = 0;
            int nextArraySum, difference, nextDifference;

            do
            {
                arraySum += table[index].Frequency;
                nextArraySum = arraySum + table[index + 1].Frequency;

                difference = Math.Abs(arraySum - (maxArraySum - arraySum));
                nextDifference = Math.Abs(nextArraySum - (maxArraySum - nextArraySum));

                index++;
            } while (nextDifference < difference);

            return index - 1;
        }

        private void InitializeDictionary()
        {
            for (int i = 0; i < table.Count; i++)
            {
                codes.Add(GetIntFromBitArray(i), null);
            } 
        }

        public int GetIntFromBitArray(int index)
        {            
            int sum = 0;

            foreach (bool bit in table[index].Word)
            {
                sum = sum * 2 + (bit ? 1 : 0);
            }

            return sum;
        }

        public void CodeAppendBit(int index, bool value)
        {
            codes[GetIntFromBitArray(index)].Length++;
            codes[GetIntFromBitArray(index)].Set(codes[GetIntFromBitArray(index)].Length - 1, value);
        }
    }
}