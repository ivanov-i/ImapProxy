using System;
using System.Threading;
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

        [TestMethod]
        public void StartsWorkerAsync()
        {
            var workerWaits = new AutoResetEvent(false);
            var workerWorked = new AutoResetEvent(false);
            var server = new Server(item =>
            {
                Assert.IsTrue(workerWaits.WaitOne(1000));
                workerWorked.Set();
            });
            server.Serve(null);
            workerWaits.Set();
            Assert.IsTrue(workerWorked.WaitOne(1000));
        }
    }
}
