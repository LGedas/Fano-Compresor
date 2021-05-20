using System.Collections;


namespace Fano
{
    public class WordFrequency
    {      
        private BitArray _word;
        private int _frequency = 0;

        public WordFrequency(int bitsWordSize)
        {
            //bitsWordSize value between 2 and 16 to work properly.
            _word = new BitArray(bitsWordSize);
        }

        public WordFrequency(BitArray bitWord)
        {
            //bitsWordSize value between 2 and 16 to work properly.
            _word = new BitArray(bitWord);
            IncrementFrequency();            
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
