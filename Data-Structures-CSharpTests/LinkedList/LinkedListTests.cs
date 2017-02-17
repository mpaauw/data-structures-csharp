using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data_Structures_CSharp.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_CSharp.LinkedList.Tests
{
    [TestClass]
    public class LinkedListTests
    {
        private int initialValue = 101;
        private int[] listValues = { 25, 1337, 23, 100000, -7, 0 };
        private LinkedList<int> linkedList;

        public LinkedListTests()
        {
            linkedList = new LinkedList<int>(initialValue);
        }

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