using System.IO;
using System.Linq;
using System;
using System.ComponentModel;


namespace Fano
{
    public class FileReader : IDisposable
    {
        private FileStream readableFile;
        private const int bufferSize = 1024;
        private byte[] buffer = new byte[bufferSize];
        private int bytesRead;

        public FileReader(string path)
        {
            readableFile = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        }

        public byte[] Read()
        {
            bytesRead = readableFile.Read(buffer, 0, buffer.Length);
            return buffer.Take(bytesRead).ToArray();
        }

        public void Dispose() 
        {
            readableFile.Close();
        }
    }
}
