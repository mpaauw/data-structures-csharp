using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data_Structures_CSharp.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Structures_CSharp.Shared;

namespace Data_Structures_CSharp.LinkedList.Tests
{
    /// <summary>
    /// Unit test class that tests all methods of the LinkedList class.
    /// </summary>
    [TestClass]
    public class LinkedListTests
    {
        private const int TEST_BREADTH = 20;

        private const int TEST_DEPTH = 100;

        private TestEngine testDriver;

        private LinkedList<int> linkedList;

        /// <summary>
        /// Default constructor.
        /// Initializes all class-wide test-dependent members.
        /// </summary>
        public LinkedListTests()
        {
            this.testDriver = new TestEngine(TEST_BREADTH, TEST_DEPTH);
            linkedList = new LinkedList<int>(this.testDriver.generateRandomElement());
        }

        /// <summary>
        /// Tests if the LinkedList class is properly tracking the size of it's underlying list object.
        /// </summary>
        [TestMethod]
        public void getSizeTest()
        {
            foreach(int value in this.testDriver.elements)
            {
                this.linkedList.insert(value);
            }
            int expectedSize = this.testDriver.elements.Length + 1;
            int actualSize = this.linkedList.getSize();
            Assert.AreEqual(expectedSize, actualSize);
        }

        /// <summary>
        /// Tests if the LinkedList class is inserting items and incrementing it's size correctly.
        /// </summary>
        [TestMethod]
        public void insertTest()
        {
            int expectedSize = this.linkedList.getSize();
            foreach(int value in testDriver.elements)
            {
                this.linkedList.insert(value);
                expectedSize++;
                Assert.IsTrue(this.linkedList.search(value));
                Assert.AreEqual(expectedSize, this.linkedList.getSize());             
            }
        }

        /// <summary>
        /// Tests if the LinkedList class is deleting items and decrementing it's size correctly.
        /// </summary>
        [TestMethod]
        public void deleteTest()
        {
            foreach(int value in this.testDriver.elements)
            {
                this.linkedList.insert(value);
            }
            int expectedSize = this.linkedList.getSize();
            foreach(int value in this.testDriver.elements)
            {
                Assert.IsTrue(this.linkedList.search(value));
                this.linkedList.delete(value);
                expectedSize--;
                Assert.IsFalse(this.linkedList.search(value));
                Assert.AreEqual(expectedSize, this.linkedList.getSize());
            }
        }

        /// <summary>
        /// Tests if the LinkedList class is properly searching for values within it's underlying list object.
        /// </summary>
        [TestMethod]
        public void searchTest()
        {
            foreach (int value in this.testDriver.elements)
            {
                this.linkedList.insert(value);
            }
            int nonExistentValue;
            do
            {
                nonExistentValue = this.testDriver.generateRandomElement();
            } while (this.testDriver.elements.Contains(nonExistentValue));
            Assert.IsFalse(this.linkedList.search(nonExistentValue));
            foreach (int value in this.testDriver.elements)
            {
                Assert.IsTrue(this.linkedList.search(value));
            }
        }

        /// <summary>
        /// Tests if the LinkedList class is able to correctly return a particular item at a given index:
        /// </summary>
        [TestMethod]
        public void getElementAtTest()
        {
            foreach (int value in this.testDriver.elements)
            {
                linkedList.insert(value);
            }
            int expectedValueIndex;
            do
            {
                expectedValueIndex = this.testDriver.generateRandomElement();
            } while (expectedValueIndex < 0 | expectedValueIndex >= this.testDriver.elements.Length);
            int expectedValue = this.testDriver.elements[expectedValueIndex];
            int actualValue = this.linkedList.getElementAt((this.linkedList.getSize() - 2) - expectedValueIndex); // look at end of linked list, since elements are first added to front
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}