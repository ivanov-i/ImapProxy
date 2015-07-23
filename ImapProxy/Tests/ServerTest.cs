using System;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ServerTest
    {
        [TestMethod]
        public void Constructor()
        {
            var server = new Server(10);
        }
    }
}
