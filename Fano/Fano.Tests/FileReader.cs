using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Linq;

namespace Fano.Tests
{
    class FileReaderTests
    {
        [TestMethod]
        public void Constructor_FilePath_NotNull()
        {
            FileReader file = new FileReader(TestFileManager.path);

            Assert.IsNotNull(file);
        }

        [TestMethod]
        public void Read_File_16Symbols()
        {
            TestFileManager.MakeFile("aaaabbbbccccddff");
            byte[] expexted = Encoding.UTF8.GetBytes("aaaabbbbccccddff");
            var file = new FileReader(TestFileManager.path);

            byte[] buffer = file.Read();

            file.CloseFile();
            TestFileManager.DeleteFile();
            
            Assert.IsTrue(expexted.SequenceEqual(buffer));
        }
    }
}
