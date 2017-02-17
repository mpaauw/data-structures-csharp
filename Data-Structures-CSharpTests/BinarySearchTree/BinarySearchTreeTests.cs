using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data_Structures_CSharp.BinarySearchTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Structures_CSharp.Shared;

namespace Data_Structures_CSharp.BinarySearchTree.Tests
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        private const int TEST_BREADTH = 200;

        private const int TEST_DEPTH = 50000;

        private TestEngine testDriver;

        private BinarySearchTree<int> bst;

        public BinarySearchTreeTests()
        {
            this.testDriver = new TestEngine(TEST_BREADTH, TEST_DEPTH);
            bst = new BinarySearchTree<int>(this.testDriver.generateRandomElement());
        }

        [TestMethod]
        public void searchTest()
        {
            // arrange
            foreach (int value in this.testDriver.elements)
            {
                this.bst.insert(value);
            }
            int nonExistentValue;
            do
            {
                nonExistentValue = this.testDriver.generateRandomElement();
            } while (testDriver.elements.Contains(nonExistentValue));
            // act / assert
            Assert.IsFalse(bst.search(nonExistentValue));
            foreach(int value in this.testDriver.elements)
            {
                Assert.IsTrue(bst.search(value));
            }
        }

        [TestMethod]
        public void findMinimumTest()
        {
            // arrange
            foreach (int value in this.testDriver.elements)
            {
                this.bst.insert(value);
            }
            int expectedMinimum = this.testDriver.elements.Min();
            // act
            int actualMinimum = this.bst.findMinimum();
            // assert
            Assert.AreEqual(expectedMinimum, actualMinimum);
        }

        [TestMethod]
        public void findMaximumTest()
        {
            // arrange
            foreach(int value in this.testDriver.elements)
            {
                this.bst.insert(value);
            }
            int expectedMaximum = this.testDriver.elements.Max();
            // act
            int actualMaximum = this.bst.findMaximum();
            // assert
            Assert.AreEqual(expectedMaximum, actualMaximum);
        }

        [TestMethod]
        public void traverseTest()
        {
        }

        [TestMethod]
        public void insertTest()
        {
        }

        [TestMethod]
        public void deleteTest()
        {
        }

        [TestMethod]
        public void balanceTest()
        {
        }

        [TestMethod]
        public void getHeightTest()
        {
        }
    }
}