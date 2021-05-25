using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Linq;

namespace Fano.Tests
{
    class FileReaderTests
    {
        private const string path = @"C:\Users\Gedas\Desktop\GitProject\Fano\TestingFiles\test1.txt";

        [TestMethod]
        public void Constructor_FilePath_NotNull()
        {
            FileReader file = new FileReader(path);

            Assert.IsNotNull(file);
        }

        [TestMethod]
        public void Read_File_16Symbols()
        {    
            byte[] buffer;
            byte[] expexted = Encoding.UTF8.GetBytes("aaaabbbbccccddff");
            FileReader file = new FileReader(path);

            buffer = file.Read();

            Assert.IsTrue(expexted.SequenceEqual(buffer));
        }
    }
}
