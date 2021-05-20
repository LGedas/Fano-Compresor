using System;
using System.Collections;

namespace Fano
{
    class Program
    {
        //Program parameters. 
        private static readonly string path = @"C:\Users\Gedas\Desktop\GitProject\Fano\TestingFiles\test1.txt";
        private const int wordSize = 16;

        static void Main(string[] args)
        {                     
            FanoParser parser = new FanoParser(path, wordSize);

            parser.ParseFile();
            for(int i=0; i<8; i++)
            {
                parser.SetBitLocation();
                Console.WriteLine(parser.BitLocationInArray);
            }
            for (int i = 0; i < 8; i++)
            {
                parser.SetBitLocation();
                Console.WriteLine(parser.BitLocationInArray );
            }
        }
    }
}
