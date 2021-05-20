using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;

namespace Fano.Tests
{
    [TestClass]
    public class Parser
    {
        private const string path = @"C:\Users\Gedas\Desktop\GitProject\Fano\TestingFiles\test1.txt";

        [TestMethod]
        public void Constructor_FilePath_NotNull()
        {
            const int bitsWordLenght = 3;

            Fano.Parser readableFile = new Fano.Parser(path, bitsWordLenght);

            Assert.IsNotNull(readableFile);
        }       
    }
}
