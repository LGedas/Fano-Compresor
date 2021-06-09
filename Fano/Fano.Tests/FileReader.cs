using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Linq;

namespace Fano.Tests
{
    [TestClass]
    public class FileReaderTests
    {
        [TestCleanup]
        public void TestClean()
        {
            TestFileUtilities.DeleteFile();
        }

        [TestMethod]
        public void Constructor_FilePath_NotNull()
        {
            TestFileUtilities.MakeFile("a");

            using (var file = new FileReader(TestFileUtilities.path)) 
            {
                Assert.IsNotNull(file);
            }               
        }

        [TestMethod]
        public void Read_File_16Symbols()
        {
            byte[] expexted = Encoding.UTF8.GetBytes("aaaabbbbccccddff");

            TestFileUtilities.MakeFile("aaaabbbbccccddff");            

            using (var file = new FileReader(TestFileUtilities.path))
            {
                byte[] buffer = file.Read();

                Assert.IsTrue(expexted.SequenceEqual(buffer));
            }                         
        }
    }
}
