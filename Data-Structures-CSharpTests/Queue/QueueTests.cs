using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data_Structures_CSharp.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Structures_CSharp.Shared;

namespace Data_Structures_CSharp.Queue.Tests
{
    [TestClass]
    public class QueueTests
    {
        private const int TEST_BREADTH = 20;

        private const int TEST_DEPTH = 100;

        private TestEngine testDriver;

        private Queue<int> queue;

        public QueueTests()
        {
            this.testDriver = new TestEngine(TEST_BREADTH, TEST_DEPTH);
            this.queue = new Queue<int>(this.testDriver.generateRandomElement());
        }

        [TestMethod]
        public void getSizeTest()
        {
        }

        [TestMethod()]
        public void enqueueTest()
        {
        }

        [TestMethod()]
        public void dequeueTest()
        {
        }

        [TestMethod()]
        public void isEmptyTest()
        {
        }
    }
}