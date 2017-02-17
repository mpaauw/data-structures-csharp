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
            // arrange
            foreach(int value in this.testDriver.elements)
            {
                this.bst.insert(value);
            }
            int expectedTraversalSize = this.testDriver.elements.Length;
            // act
            int[] traversalOrder = this.bst.traverse();
            // assert
            Assert.AreEqual(expectedTraversalSize, traversalOrder.Length);
            foreach(int value in this.testDriver.elements)
            {
                Assert.IsTrue(traversalOrder.Contains(value));
            }
        }

        [TestMethod]
        public void insertTest()
        {
            // arrange
            int expectedSize = bst.getSize();
            // act / assert
            foreach(int value in testDriver.elements)
            {
                bst.insert(value);
                expectedSize++;
                Assert.IsTrue(bst.search(value));
                Assert.AreEqual(expectedSize, bst.getSize());
            }
        }

        [TestMethod]
        public void deleteTest()
        {
            // arrange
            foreach(int value in this.testDriver.elements)
            {
                bst.insert(value);
            }
            int expectedSize = bst.getSize();
            // act / assert
            foreach(int value in this.testDriver.elements)
            {
                Assert.IsTrue(bst.search(value));
                bst.delete(value);
                expectedSize--;
                Assert.IsFalse(bst.search(value));
                Assert.AreEqual(expectedSize, bst.getSize());
            }
        }
    }
}