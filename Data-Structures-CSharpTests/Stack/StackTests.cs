using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data_Structures_CSharp.Stack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Structures_CSharp.Shared;

namespace Data_Structures_CSharp.Stack.Tests
{
    /// <summary>
    /// Unit test class that tests all methods of the Stack class.
    /// </summary>
    [TestClass]
    public class StackTests
    {
        private const int TEST_BREADTH = 20;

        private const int TEST_DEPTH = 100;

        private TestEngine testDriver;

        private Stack<int> stack;

        /// <summary>
        /// Default constructor.
        /// Initializes all calss-wide test-dependent members.
        /// </summary>
        public StackTests()
        {
            this.testDriver = new TestEngine(TEST_BREADTH, TEST_DEPTH);
            stack = new Stack<int>(this.testDriver.generateRandomElement());
        }

        /// <summary>
        /// Tests if the Stack class is inserting items and incrementing it's size correctly.
        /// </summary>
        [TestMethod]
        public void pushTest()
        {
            int expectedSize = this.stack.getSize();
            foreach(int value in this.testDriver.elements)
            {
                this.stack.push(value);
                expectedSize++;
                int pushedValue = this.stack.pop();
                Assert.AreEqual(value, pushedValue);
                Assert.AreEqual(expectedSize, this.stack.getSize());
            }
        }

        /// <summary>
        /// Tests if the Stack class is deleting items and decrementing it's size correctly.
        /// </summary>
        [TestMethod]
        public void popTest()
        {
            foreach(int value in this.testDriver.elements)
            {
                this.stack.push(value);
            }
            int expectedSize = this.stack.getSize();
            for(int i = this.testDriver.elements.Length - 1; i >= 0; i--)
            {
                int poppedValue = this.stack.pop();
                expectedSize--;
                Assert.AreEqual(this.testDriver.elements[i], poppedValue);
                Assert.AreEqual(expectedSize, this.stack.getSize());
            }
        }

        /// <summary>
        /// Tests whether or not the Stack class can properly determine if it's underlying data structure is empty.
        /// </summary>
        [TestMethod]
        public void isEmptyTest()
        {
            Assert.IsFalse(this.stack.isEmpty());
            this.stack.pop();
            Assert.IsTrue(this.stack.isEmpty());
            this.stack.push(this.testDriver.generateRandomElement());
            Assert.IsFalse(this.stack.isEmpty());
            this.stack.pop();
            Assert.IsTrue(this.stack.isEmpty());
        }
    }
}