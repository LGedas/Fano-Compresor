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
        private const int byteSize = 8;
        private readonly int bitsWordSize;
        private int _bitLocation;    
        private readonly string path;
        
        public Parser(string path, int bitsWordSize)
        {
            this.path = path;
            this.bitsWordSize = bitsWordSize;
            bitWord = new WordFrequency(bitsWordSize);
            frequencies = new List<WordFrequency>();
        }

        public int BitLocation
        {
            get { return _bitLocation; }
        }

        public void SetBitLocation()
        {
            _bitLocation = (_bitLocation + 1) % bitsWordSize;
        }

        public bool GetBit(byte byteFromFile, int position)
        {
            return Convert.ToBoolean((Convert.ToInt32(byteFromFile) >> (byteSize - 1 - position)) & 1);
        }

        public void InsertBit(byte byteFromFile, int position)
        {
            bitWord.Word[BitLocation] = GetBit(byteFromFile, position);
            SetBitLocation();
        }
        public BitArray GetRemainingBits()
        {
            bitWord.Word.Length = BitLocation;

            return bitWord.Word;
        }

        public void TryInsertWord()
        {
            WordFrequency word = frequencies.FirstOrDefault(word => Utilities.IsSequenceEqual(word, bitWord));

            if (word != null)
            {
                word.IncrementFrequency();
                return;
            }

            frequencies.Add(new WordFrequency(bitWord.Word));
        }

        public void ParseByte(byte byteFromFile)
        {
            for (int i = 0; i < byteSize; i++)
            {
                InsertBit(byteFromFile, i);

                if (BitLocation == 0)
                {
                    TryInsertWord();
                }
            }
        }

        public List<WordFrequency> GetFrequencyTable()
        {
            using (var file = new FileReader(path))
            {
                byte[] bytes = file.Read();

                while(bytes.Any())
                {
                    foreach (byte byteFromFile in bytes)
                    {
                        ParseByte(byteFromFile);
                    }

                    bytes = file.Read();
                }
            }

            frequencies.Sort(Comparison);

            return frequencies;            
        }

        public int Comparison(WordFrequency frequency1, WordFrequency frequency2)
        {
            if (frequency1.Frequency == frequency2.Frequency)
            {
                return 0;
            }

            return frequency1.Frequency < frequency2.Frequency ?  1 : -1;  
        }
    }
}
