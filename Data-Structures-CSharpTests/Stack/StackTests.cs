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

        [TestMethod]
        public void pushTest()
        {
        }

        [TestMethod]
        public void popTest()
        {
        }

        [TestMethod]
        public void isEmptyTest()
        {
        }
    }
}