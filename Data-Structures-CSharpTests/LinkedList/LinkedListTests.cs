using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data_Structures_CSharp.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_CSharp.LinkedList.Tests
{
    /// <summary>
    /// Unit test class that tests all methods of the LinkedList class.
    /// </summary>
    [TestClass]
    public class LinkedListTests
    {
        private int initialValue = 101;
        private int[] listValues = { 25, 1337, 23, 100000, -7, 0 };
        private LinkedList<int> linkedList;

        /// <summary>
        /// Default constructor.
        /// Initializes all class-wide test-dependent members.
        /// </summary>
        public LinkedListTests()
        {
            linkedList = new LinkedList<int>(initialValue);
        }

        /// <summary>
        /// Tests if the LinkedList class is properly tracking the size of it's underlying list object.
        /// </summary>
        [TestMethod]
        public void getSizeTest()
        {
            // arrange
            foreach(int value in listValues)
            {
                linkedList.insert(value);
            }
            int expectedSize = listValues.Length + 1;
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
            foreach(int value in listValues)
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
            foreach( int value in listValues)
            {
                linkedList.insert(value);
            }
            int expectedSize = linkedList.getSize();
            // act / assert
            foreach(int value in listValues)
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
            foreach (int value in listValues)
            {
                linkedList.insert(value);
            }
            // act / assert
            Assert.IsFalse(linkedList.search(nonExistentValue));
            foreach (int value in listValues)
            {
                Assert.IsTrue(linkedList.search(value));
            }
        }
    }
}