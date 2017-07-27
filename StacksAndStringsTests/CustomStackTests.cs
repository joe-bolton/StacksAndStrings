using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StacksAndStrings;

namespace StacksAndStringsTest
{
    [TestClass]
    public class CustomStackTests
    {
        [TestMethod]
        public void TestPushPop()
        {
            int item = 1;
            var stack = new CustomStack<int>();
            Assert.IsTrue(stack.IsEmpty);
            Assert.AreEqual(stack.Size, 0);

            stack.Push(item);
            Assert.IsTrue(!stack.IsEmpty);
            Assert.AreEqual(stack.Size, 1);

            var popped = stack.Pop();
            Assert.AreEqual(item, popped);
            Assert.IsTrue(stack.IsEmpty);
            Assert.AreEqual(stack.Size, 0);
        }

        [TestMethod]
        public void TestStackExpansion()
        {
            const int TotalItemCount = 10000;
            var stack = new CustomStack<int>();

            for (var i = 0; i < TotalItemCount; i++)
            {
                stack.Push(i);
            }

            Assert.AreEqual(TotalItemCount, stack.Size);

            for (var i = TotalItemCount - 1; i >= 0; i--)
            {
                var popped = stack.Pop();

                Assert.AreEqual(i, popped);
            }
        }

        [TestMethod]
        public void TestEmptyPop()
        {
            try
            {
                var stack = new CustomStack<string>();

                stack.Pop();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
            }
        }
    }
}
