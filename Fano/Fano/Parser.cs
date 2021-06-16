using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Fano
{
    public class Parser
    {        
        private List<WordFrequency> frequencies;
        private WordFrequency bitWord;
        private BitArray remainder;
        private const int byteSize = 8;
        private readonly int bitsWordSize;
        private int bitLocation;    
        private readonly string path;

        public Parser(string path, int bitsWordSize)
        {
            this.path = path;
            this.bitsWordSize = bitsWordSize;
            bitWord = new WordFrequency(bitsWordSize);
            frequencies = new List<WordFrequency>();
        }

        public BitArray Remainder => remainder;

        public List<WordFrequency> GetFrequencyTable() => frequencies;

        public void SetFrequencyTable()
        {
            using (var file = new FileReader(path))
            {
                byte[] bytes = file.Read();

                while (bytes.Any())
                {
                    foreach (byte byteFromFile in bytes)
                    {
                        ParseByte(byteFromFile);
                    }

                    bytes = file.Read();
                }
            }

            frequencies.Sort(Comparison);

            SetRemainder();
        }

        private void SetRemainder()
        {
            remainder = bitWord.Word;
            remainder.Length = bitLocation;
        }

        private int Comparison(WordFrequency frequency1, WordFrequency frequency2)
        {
            if (frequency1.Frequency == frequency2.Frequency)
            {
                return 0;
            }

            return frequency1.Frequency < frequency2.Frequency ? 1 : -1;
        }

        private void ParseByte(byte byteFromFile)
        {
            for (int i = 0; i < byteSize; i++)
            {
                InsertBit(byteFromFile, i);

                if (bitLocation == 0)
                {
                    TryInsertWord();
                }
            }
        }

        private void InsertBit(byte byteFromFile, int position)
        {
            bitWord.Word[bitLocation] = GetBit(byteFromFile, position);

            SetBitLocation();
        }

        private void TryInsertWord()
        {
            WordFrequency word = frequencies.FirstOrDefault(word => Utilities.IsSequenceEqual(word, bitWord));

            if (word != null)
            {
                word.IncrementFrequency();
                return;
            }

            frequencies.Add(new WordFrequency(bitWord.Word));
        }

        private void SetBitLocation() => bitLocation = (bitLocation + 1) % bitsWordSize;

        private bool GetBit(byte byteFromFile, int position) => Convert.ToBoolean((byteFromFile >> (byteSize - 1 - position)) & 1);        
    }
}
