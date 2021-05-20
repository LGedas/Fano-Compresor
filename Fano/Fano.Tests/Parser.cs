using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fano.Tests
{
    [TestClass]
    public class Parser
    {
        private readonly string path = @"C:\Users\Gedas\Desktop\GitProject\Fano\TestingFiles\test1.txt";
        private readonly int wordSizeInBits = 3;

        [TestMethod]
        public void FanoParser()
        {
           FanoParser readableFile = new FanoParser(path, wordSizeInBits);          
           Assert.IsNotNull(readableFile);
        }


  
    }
}
