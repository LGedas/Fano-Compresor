using System.Collections;

namespace Fano
{
    public class WordFrequency
    {      
        private BitArray _word;
        private int _frequency = 0;

        public WordFrequency(int wordSizeInBits)
        {
            if ((2 <= wordSizeInBits) && (wordSizeInBits <= 16))
            {               
                _word = new BitArray(wordSizeInBits);
            }
            //write throw exception.
        }

        public void IncrementFrequency()
        {
            _frequency++;
        }

        public int Frequency
        { 
            get { return _frequency; }            
        }
 
        public BitArray Word
        {
            get { return _word; }
            set { _word = value; }
        }
        
    }
}
