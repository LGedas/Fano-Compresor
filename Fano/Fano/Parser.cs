using System;
using System.IO;
using System.Collections.Generic;

namespace Fano
{
    public class Parser
    {
        private readonly FileStream readableFile;
        private const int bufferSize = 1024;
        private byte[] buffer = new byte[bufferSize];
        private int _bitLocation;
        private readonly int wordSizeInBits;
        private List<WordFrequency> frequencies;
        private WordFrequency bitWord;
        private int _bytesRead;
        const int bitsInByte = 8;

        public Parser(string path, int wordSizeInBits)
        {
            readableFile = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);

            this.wordSizeInBits = wordSizeInBits;
            bitWord = new WordFrequency(wordSizeInBits);
        }

        public int BytesRead
        {
            get { return _bytesRead; }
        }

        public void ReadBuffer()
        {
            _bytesRead = readableFile.Read(buffer, 0, buffer.Length);        
        }

        public void GetBit(byte symbol, int position)
        {
            bitWord.Word[BitLocation] = Convert.ToBoolean((Convert.ToInt32(symbol) >> (bitsInByte - 1 - position)) & 1);
            SetBitLocation();
        }

        public void InsertWord()
        {
            if (frequencies.Count == 0)
            {
                frequencies.Add(new WordFrequency(bitWord.Word));
                return;
            }

            int wordIndex = 0;
            foreach (WordFrequency word in frequencies)
            {
                if (Utilities.IsSequenceEqual(word, bitWord))
                {
                    word.IncrementFrequency();
                    break;
                }

                if (wordIndex == frequencies.Count)
                {
                    frequencies.Add(new WordFrequency(bitWord.Word));
                }

                wordIndex++;
            }
        }

        public void ParseByte(byte symbol)
        {
            for (int i = 0; i < bitsInByte; i++)
            {
                GetBit(symbol, i);

                if (BitLocation == 0)
                {
                    InsertWord();
                }
            }
        }

        public void SetBitLocation()
        {
            _bitLocation = (wordSizeInBits + _bitLocation - 1) % wordSizeInBits;
        }

        public int BitLocation
        {            
            get { return _bitLocation;  }
        }

        public void ParseFile()
        {                     
            ReadBuffer();
            while (BytesRead > 0)
            {
                for (int i=0; i < BytesRead; i++)
                {
                    //Bit procesor, segment everything into 2-16 bits chunks.
                    ParseByte(buffer[i]);                    

                    //From bit Proscesor take wordSize bits
                    //(Add new word and frequency++) or (frequency++).

                    //Remainder size < K; set aside for later encryption.
                }
                ReadBuffer();
            }
        } 
    }
}
