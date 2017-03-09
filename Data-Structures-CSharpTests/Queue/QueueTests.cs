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
            int expectedSize = this.queue.getSize();
            foreach(int value in this.testDriver.elements)
            {
                this.queue.enqueue(value);
                expectedSize++;
                Assert.AreEqual(expectedSize, this.queue.getSize());
            }
            while (!this.queue.isEmpty())
            {
                this.queue.dequeue();
                expectedSize--;
                Assert.AreEqual(expectedSize, this.queue.getSize());
            }
        }

        [TestMethod()]
        public void enqueueTest()
        {
            int expectedSize = this.queue.getSize();
            foreach(int value in this.testDriver.elements)
            {
                this.queue.enqueue(value);
                int enqueuedValue = this.queue.dequeue();
                Assert.AreEqual(value, enqueuedValue);
            }
        }

        [TestMethod()]
        public void dequeueTest()
        {
            foreach(int value in this.testDriver.elements)
            {
                this.queue.enqueue(value);
            }
            foreach(int value in this.testDriver.elements)
            {
                int dequeuedValue = this.queue.dequeue();
                Assert.AreEqual(value, dequeuedValue);
            }
        }

        [TestMethod()]
        public void isEmptyTest()
        {
            Assert.IsFalse(this.queue.isEmpty());
            this.queue.dequeue();
            Assert.IsTrue(this.queue.isEmpty());
            this.queue.enqueue(this.testDriver.generateRandomElement());
            Assert.IsFalse(this.queue.isEmpty());
            this.queue.dequeue();
            Assert.IsTrue(this.queue.isEmpty());
        }
    }
}