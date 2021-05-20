using System;
using System.IO;
using System.Collections.Generic;

namespace Fano
{
    public class FanoParser
    {
        private FileStream readableFile;
        private List<WordFrequency> frequencyList;
        private int wordSizeInBits;

        public FanoParser(string path, int wordSizeInBits)
        {
            readableFile = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            
            if ((2 <= wordSizeInBits) && (wordSizeInBits <= 16))
            {
                this.wordSizeInBits = wordSizeInBits;
            }
        }

        //separate buffer from parser?
        private int _bytesRead;
        private const int bufferSize = 1024;
        private byte[] buffer = new byte[bufferSize];

        public int BytesRead
        {
            get { return _bytesRead; }
        }

        public void ReadChunk()
        {
            _bytesRead = readableFile.Read(buffer, 0, buffer.Length);        
        }

        public void ParseByte(byte symbol)
        {            
            for (int j = 0; j < wordSizeInBits; j++)
            {
                //  X & 1 >> n 
            }
        }

        private int _bitLocationInArray ;

        public void SetBitLocation()
        {
            _bitLocationInArray = (wordSizeInBits + _bitLocationInArray - 1) % wordSizeInBits;
        }

        public int BitLocationInArray
        {            
            get { return _bitLocationInArray;  }
        }

        public bool CompareBits(WordFrequency bitArray1, WordFrequency bitArray2)
        {
            bool isEqual = true;

            for (int i = 0; i < wordSizeInBits; i++)
            {
                if (bitArray1.Word[i] != bitArray2.Word[i])
                {
                    isEqual = false;
                    break;
                }
            }

            return isEqual;
        }

        public void ParseFile()
        {
            frequencyList = new List<WordFrequency>();
            frequencyList.Add(new WordFrequency(wordSizeInBits));           

            ReadChunk();
            while (BytesRead > 0)
            {
                for (int i=0; i < BytesRead; i++)                {
                                   
                     
                    //Bit procesor, segment everything into 2-16 bits chunks.                    
                    ParseByte(buffer[i]);                    

                    //From bit Proscesor take wordSize bits
                    //(Add new word and frequency++) or (frequency++).

                    //Remainder size < K; set aside for later encryption.              
                }
                ReadChunk();

            }
            

        }     
        
    }
}
