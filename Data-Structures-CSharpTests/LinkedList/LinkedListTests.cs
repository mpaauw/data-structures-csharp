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
        private int initialValue = 23;
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
            int expectedSize = listValues.Length + 1; // account for initial value
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
                bool containsValue = linkedList.search(value);
                int actualSize = linkedList.getSize();
                Assert.IsTrue(containsValue);
                Assert.AreEqual(expectedSize, actualSize);             
            }
        }

        [TestMethod]
        public void deleteTest()
        {
            //Assert.Fail();
        }

        [TestMethod]
        public void searchTest()
        {
            //Assert.Fail();
        }
    }
}