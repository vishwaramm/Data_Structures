using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vish.DataStructures.Models;

namespace Vish.DataStructures.Tests
{
    [TestClass]
    public class DynamicArrayTests
    {
        [TestMethod]
        public void Test_Dynamic_InsertWithSizeSpecified()
        {
            DynamicArray<int> da = new DynamicArray<int>(5);
            int[] nums = new int[5] { 3, 7, 2, 1, 100 };

            foreach (int num in nums)
            {
                da.Insert(num);
            }

            Assert.AreEqual(da[0], 3);
            Assert.AreEqual(da[1], 7);
            Assert.AreEqual(da[2], 2);
            Assert.AreEqual(da[3], 1);
            Assert.AreEqual(da[4], 100);
        }

        [TestMethod]
        public void Test_Dynamic_InsertWithNoSize()
        {
            DynamicArray<int> da = new DynamicArray<int>();

            //default size = 10 internally
            int[] nums = new int[10] { 50, 3, 2, 40, 44, 52, 10, 8, 90, 209 };
            foreach (int num in nums)
            {
                da.Insert(num);
            }

            for (int i = 0; i < da.Count; i++)
            {
                Assert.AreEqual(da[i], nums[i]);
            }
        }

        [TestMethod]
        public void Test_Dynamic_InsertMoreThanAllocated()
        {
            DynamicArray<int> da = new DynamicArray<int>();

            //default size = 10 internally
            int[] nums = new int[15] { 50, 3, 2, 40, 44, 52, 10, 8, 90, 209, 33, 45, 87, 70, 86 };
            foreach (int num in nums)
            {
                da.Insert(num);
            }

            for (int i = 0; i < da.Count; i++)
            {
                Assert.AreEqual(da[i], nums[i]);
            }
        }

        [TestMethod]
        public void Test_Dynamic_Delete()
        {
            DynamicArray<int> da = new DynamicArray<int>();

            //default size = 10 internally
            int[] nums = new int[15] { 50, 3, 2, 40, 44, 52, 10, 8, 90, 209, 33, 45, 87, 70, 86 };
            foreach (int num in nums)
            {
                da.Insert(num);
            }

            da.Delete(3);

            Assert.AreNotEqual(da[1], nums[1]);
        }

        [TestMethod]
        public void Test_Dynamic_Count()
        {
            DynamicArray<int> da = new DynamicArray<int>();

            //default size = 10 internally
            int[] nums = new int[15] { 50, 3, 2, 40, 44, 52, 10, 8, 90, 209, 33, 45, 87, 70, 86 };
            foreach (int num in nums)
            {
                da.Insert(num);
            }

            Assert.AreEqual(da.Count, 15);
        }

        [TestMethod]
        public void Test_Dynamic_DeleteLast()
        {
            DynamicArray<int> da = new DynamicArray<int>();

            //default size = 10 internally
            int[] nums = new int[15] { 50, 3, 2, 40, 44, 52, 10, 8, 90, 209, 33, 45, 87, 70, 86 };
            foreach (int num in nums)
            {
                da.Insert(num);
            }

            da.DeleteLast();

            Assert.AreEqual(da[14], 0);
        }
    }
}
