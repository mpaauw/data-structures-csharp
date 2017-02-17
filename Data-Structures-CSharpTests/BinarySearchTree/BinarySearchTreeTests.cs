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

        }

        [TestMethod]
        public void findMinimumTest()
        {
        }

        [TestMethod]
        public void findMaximumTest()
        {
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