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
            // arrange
            foreach(int value in this.testDriver.elements)
            {
                linkedList.insert(value);
            }
            int expectedSize = this.testDriver.elements.Length + 1;
            // act
            int actualSize = linkedList.getSize();
            // assert
            Assert.AreEqual(expectedSize, actualSize);
        }

        /// <summary>
        /// Tests if the LinkedList class is inserting items and incrementing it's size correctly.
        /// </summary>
        [TestMethod]
        public void insertTest()
        {
            // arrange
            int expectedSize = linkedList.getSize();
            // act / assert
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
            // arrange
            foreach(int value in this.testDriver.elements)
            {
                linkedList.insert(value);
            }
            int expectedSize = linkedList.getSize();
            // act / assert
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
            // arrange
            int nonExistentValue = 321;
            foreach (int value in this.testDriver.elements)
            {
                linkedList.insert(value);
            }
            // act / assert
            Assert.IsFalse(linkedList.search(nonExistentValue));
            foreach (int value in this.testDriver.elements)
            {
                Assert.IsTrue(linkedList.search(value));
            }
        }
    }
}