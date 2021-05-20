using System.IO;
using System.Collections.Generic;

namespace Fano
{
    public class Parser
    {
        private readonly FileStream readableFile;
        private List<WordFrequency> frequencyList;
        private readonly int wordSizeInBits;

        public Parser(string path, int wordSizeInBits)
        {
            readableFile = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);

            this.wordSizeInBits = wordSizeInBits;
        }

        //separate buffer from parser?
        private int _bytesRead;
        private const int bufferSize = 1024;
        private byte[] buffer = new byte[bufferSize];

        public int BytesRead
        {
            get { return _bytesRead; }
        }

        public void ReadBuffer()
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

        public void ParseFile()
        {
            frequencyList = new List<WordFrequency>();
            frequencyList.Add(new WordFrequency(wordSizeInBits));

            ReadBuffer();
            while (BytesRead > 0)
            {
                for (int i=0; i < BytesRead; i++)                {
                                   
                     
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
