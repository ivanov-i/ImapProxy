using System;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ServerTest
    {
        [TestMethod]
        public void StartsWorker()
        {
            var workDone = false;
            var server = new Server(item =>
            {
                workDone = true;
            });
            server.Serve(null);
            Assert.IsTrue(workDone);
        }
    }
}
