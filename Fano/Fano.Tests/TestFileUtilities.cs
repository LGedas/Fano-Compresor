using System.Text;
using System.IO;
using System;

namespace Fano.Tests
{
    public static class TestFileUtilities
    {
        public const string path = @"C:\Users\Gedas\Desktop\GitProject\Fano\Fano.Tests\TempFiles\Temp_File.txt";

        public static void MakeFile(string fileText)
        { 
            FileStream testFile = File.Create(path);

            testFile.Write(Encoding.ASCII.GetBytes(fileText));           
            
            testFile.Close();
        }

        public static void DeleteFile()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }            
        }
    }
}
