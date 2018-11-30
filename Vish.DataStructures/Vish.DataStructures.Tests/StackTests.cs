using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vish.DataStructures.Models;

namespace Vish.DataStructures.Tests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void Test_Stack_PushWithNoSize()
        {
            int[] nums = new int[5] { 1,2,3,4,5 };

            Stack<int> s = new Stack<int>();

            foreach (int num in nums)
            {
                s.Push(num);
            }

            int index = nums.Length - 1;

            while (s.Count > 0)
            {
                var popped = s.Pop();

                Assert.AreEqual(nums[index], popped);
                index--;
            }
        }

        [TestMethod]
        public void Test_Stack_PushWithSize_Success()
        {
            int[] nums = new int[5] { 1, 2, 3, 4, 5 };

            Stack<int> s = new Stack<int>(5);

            foreach (int num in nums)
            {
                s.Push(num);
            }

            int index = nums.Length - 1;
            Assert.AreEqual(s.Count, 5);

            while (s.Count > 0)
            {
                var popped = s.Pop();

                Assert.AreEqual(nums[index], popped);
                index--;
            }
        }

        [TestMethod]
        public void Test_Stack_PushWithSize_Fail()
        {
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                int[] nums = new int[6] { 1, 2, 3, 4, 5, 6 };

                Stack<int> s = new Stack<int>(5);

                foreach (int num in nums)
                {
                    s.Push(num);
                }
            });
        }
    }
}
