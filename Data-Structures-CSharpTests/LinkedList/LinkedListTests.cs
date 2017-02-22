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
        private const int TEST_BREADTH = 200;

        private const int TEST_DEPTH = 50000;

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
                linkedList.insert(value);
            }
            int expectedSize = this.testDriver.elements.Length + 1;
            int actualSize = linkedList.getSize();
            Assert.AreEqual(expectedSize, actualSize);
        }

        /// <summary>
        /// Tests if the LinkedList class is inserting items and incrementing it's size correctly.
        /// </summary>
        [TestMethod]
        public void insertTest()
        {
            int expectedSize = linkedList.getSize();
            foreach(int value in testDriver.elements)
            {
                linkedList.insert(value);
                expectedSize++;
                Assert.IsTrue(linkedList.search(value));
                Assert.AreEqual(expectedSize, linkedList.getSize());             
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
                linkedList.insert(value);
            }
            int expectedSize = linkedList.getSize();
            foreach(int value in this.testDriver.elements)
            {
                Assert.IsTrue(linkedList.search(value));
                linkedList.delete(value);
                expectedSize--;
                Assert.IsFalse(linkedList.search(value));
                Assert.AreEqual(expectedSize, linkedList.getSize());
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
                linkedList.insert(value);
            }
            int nonExistentValue;
            do
            {
                nonExistentValue = this.testDriver.generateRandomElement();
            } while (testDriver.elements.Contains(nonExistentValue));
            Assert.IsFalse(linkedList.search(nonExistentValue));
            foreach (int value in this.testDriver.elements)
            {
                Assert.IsTrue(linkedList.search(value));
            }
        }
    }
}