using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Linq;

namespace Fano.Tests
{
    [TestClass]
    public class FileReaderTests
    {
        [TestMethod]
        public void Constructor_FilePath_NotNull()
        {
            TestFileManager.MakeFile("a");

            using (var file = new FileReader(TestFileManager.path)) 
            {
                Assert.IsNotNull(file);
            }   

            TestFileManager.DeleteFile();
        }

        [TestMethod]
        public void Read_File_16Symbols()
        {
            byte[] expexted = Encoding.UTF8.GetBytes("aaaabbbbccccddff");

            TestFileManager.MakeFile("aaaabbbbccccddff");            

            using (var file = new FileReader(TestFileManager.path))
            {
                byte[] buffer = file.Read();

                Assert.IsTrue(expexted.SequenceEqual(buffer));
            }            

            TestFileManager.DeleteFile();            
        }
    }
}
