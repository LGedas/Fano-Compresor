﻿using System;
using System.Collections;

namespace Fano
{
    class Program
    {
        //Program parameters. 
        private static readonly string path = @"C:\Users\Gedas\Desktop\GitProject\Fano\TestingFiles\test1.txt";
        //bitsWordLenght between 2 and 16.
        private const int bitsWordLenght = 16;
        //mode: decode or encode.

        static void Main(string[] args)
        {                     
            Parser parser = new Parser(path, bitsWordLenght);           
            
        }
    }
}
