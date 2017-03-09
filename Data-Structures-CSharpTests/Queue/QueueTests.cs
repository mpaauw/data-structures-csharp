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
    /// <summary>
    /// Unit test class that tests all methods of the Queue class.
    /// </summary>
    [TestClass]
    public class QueueTests
    {
        private const int TEST_BREADTH = 20;

        private const int TEST_DEPTH = 100;

        private TestEngine testDriver;

        private Queue<int> queue;

        /// <summary>
        /// Default constructor.
        /// Initializes all class-wide test-dependent members.
        /// </summary>
        public QueueTests()
        {
            this.testDriver = new TestEngine(TEST_BREADTH, TEST_DEPTH);
            this.queue = new Queue<int>(this.testDriver.generateRandomElement());
        }

        /// <summary>
        /// Tests if the Queue class is properly incrementing/decrementing it's size.
        /// </summary>
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

        /// <summary>
        /// Tests if the Queue class is inserting items correctly.
        /// </summary>
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

        /// <summary>
        /// Tests if the Queue class is deleting items correctly.
        /// </summary>
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

        /// <summary>
        /// Tests whether or not the Queue class can properly determine if it's underlying data structure is empty.
        /// </summary>
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