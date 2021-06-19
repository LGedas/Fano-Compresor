using System;
using System.Collections.Generic;
using System.Linq;

namespace Fano
{
    public class FanoAlgorithm
    {
       private List<WordFrequency> table;

        public FanoAlgorithm(List<WordFrequency> table)
        {
            this.table = table;
        }

        public void Start(int left, int right)
        {
            int index = SplitIndex(left, right);            

            if (left == right)
            {
                return;
            }

            //generating word - coders dictionary;

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

            int index = left - 1;

            int arraySum = 0;
            int nextArraySum, difference, nextDifference;

            do
            {
                index++;

                arraySum += table[index].Frequency;
                nextArraySum = arraySum + table[index + 1].Frequency;

                difference = Math.Abs(arraySum - (maxArraySum - arraySum));
                nextDifference = Math.Abs(nextArraySum - (maxArraySum - nextArraySum));                
            } while (nextDifference < difference);

            return index;
        }
    }
}