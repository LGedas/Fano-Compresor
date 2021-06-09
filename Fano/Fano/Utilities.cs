namespace Fano
{
    public static class Utilities
    {
        public static bool IsSequenceEqual(WordFrequency bitArray1, WordFrequency bitArray2)
        {
            if (bitArray1.Word.Length != bitArray2.Word.Length)
            {
                return false;
            }
           
            for (int i = 0; i < bitArray1.Word.Length; i++)
            {
                if (bitArray1.Word[i] != bitArray2.Word[i])
                {
                    return false;
                }
            } 

            return true;
        }
    }
}
