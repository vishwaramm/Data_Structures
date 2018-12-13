using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingProblems.Tests
{
    [TestClass]
    public class SolutionsTests
    {
        [TestMethod]
        public void Test_ReverseStringWithSpecialCharacters()
        {
            /*
             *  Input:   str = "a,b$c"
                Output:  str = "c,b$a"
                Note that $ and , are not moved anywhere.  
                Only subsequence "abc" is reversed

                Input:   str = "Ab,c,de!$"
                Output:  str = "ed,c,bA!$"          
             */

            string str = "a,b$c";
            Solutions s = new Solutions();

            string result = s.ReverseArrayWithSpecialCharacters(str.ToCharArray());

            Assert.AreEqual("c,b$a", result);

            str = "Ab,c,de!$";

            result = s.ReverseArrayWithSpecialCharacters(str.ToCharArray());

            Assert.AreEqual("ed,c,bA!$", result);

            str = "a!!!b.c.d,e'f,ghi";

            result = s.ReverseArrayWithSpecialCharacters(str.ToCharArray());

            Assert.AreEqual("i!!!h.g.f,e'd,cba", result);

        }

        [TestMethod]
        public void Test_ReverseStringWithSpecialCharacters_NoSpace()
        {
            /*
             *  Input:   str = "a,b$c"
                Output:  str = "c,b$a"
                Note that $ and , are not moved anywhere.  
                Only subsequence "abc" is reversed

                Input:   str = "Ab,c,de!$"
                Output:  str = "ed,c,bA!$"          
             */

            string str = "a,b$c";
            Solutions s = new Solutions();

            string result = s.ReverseArrayWithSpecialCharacters_ConstantSpace(str.ToCharArray());

            Assert.AreEqual("c,b$a", result);

            str = "Ab,c,de!$";

            result = s.ReverseArrayWithSpecialCharacters_ConstantSpace(str.ToCharArray());

            Assert.AreEqual("ed,c,bA!$", result); 

            str = "a!!!b.c.d,e'f,ghi";

            result = s.ReverseArrayWithSpecialCharacters_ConstantSpace(str.ToCharArray());

            Assert.AreEqual("i!!!h.g.f,e'd,cba", result);

        }

        [TestMethod]
        public void Test_GetAllPalindromicPartitions()
        {
            Solutions s = new Solutions();
            //k a y a k
            //kaak
            //kayak
            //aya
            //kyk
            //kak
            //akka
            //aa
            //kk
            string str = "kayak";

            List<string> results = s.GetAllPalindromicPartitions(str);

            Console.WriteLine(string.Join(",", results));
            Assert.AreEqual(13, results.Count);

            str = "geeks";

            results = s.GetAllPalindromicPartitions(str);

            Console.WriteLine(string.Join(",", results));
            Assert.AreEqual(6, results.Count);
        }

        [TestMethod]
        public void Test_GetTripletsLessThanSumCount()
        {
            int[] arr = { -2, 0, 1, 3 };
            Solutions s = new Solutions();

            int result = s.GetTripletsLessThanSumCount(arr, 2);
            Assert.AreEqual(2, result);

            int[] arr2 = { 5, 1, 3, 4, 7}; 

            result = s.GetTripletsLessThanSumCount(arr2, 12);
            Assert.AreEqual(4, result);

        }

        [TestMethod]
        public void Test_GetTripletsLessThanSumCount_Fast()
        {
            int[] arr = { -2, 0, 1, 3 };
            Solutions s = new Solutions();

            int result = s.GetTripletsLessThanSumCount_Faster(arr, 2);

            Assert.AreEqual(2, result);

            int[] arr2 = { 5, 1, 3, 4, 7 };

            result = s.GetTripletsLessThanSumCount_Faster(arr2, 12);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Test_PythagoreanTriplet()
        {
            int[] arr = { 3, 1, 4, 6, 5 };
            Solutions s = new Solutions();

            bool result = s.HasPythagoreanTriplet(arr);

            Assert.IsTrue(result);

            int[] arr2 = { 10, 4, 6, 12, 5 };

           result = s.HasPythagoreanTriplet(arr2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_PythagoreanTriplet_Fast()
        {
            int[] arr = { 3, 1, 4, 6, 5 };
            Solutions s = new Solutions();

            bool result = s.HasPythagoreanTriplet_Faster(arr);

            Assert.IsTrue(result);

            int[] arr2 = { 10, 4, 6, 12, 5 };

            result = s.HasPythagoreanTriplet_Faster(arr2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_GetLengthOfLargestSubArrayWithContiguousElements()
        {
            int[] arr = { 10, 12, 11 };
            Solutions s = new Solutions();

            int result = s.GetLengthOfLargestSubArrayWithContiguousElements(arr);

            Assert.AreEqual(3, result);

            int[] arr2 = { 14, 12, 11, 20};

            result = s.GetLengthOfLargestSubArrayWithContiguousElements(arr2);
            Assert.AreEqual(2, result);

            int[] arr3 = { 1, 56, 58, 57, 90, 92, 94, 93, 91, 45 };

            result = s.GetLengthOfLargestSubArrayWithContiguousElements(arr3);
            Assert.AreEqual(5, result);

            int[] arr4 = { 5, 10, 15, 20, 3, 1, 18 };

            result = s.GetLengthOfLargestSubArrayWithContiguousElements(arr4);
            Assert.AreEqual(0, result);

            result = s.GetLengthOfLargestSubArrayWithContiguousElements(new int[0]);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Test_CovertToZigZag()
        {
            int[] arr = { 4, 3, 7, 8, 6, 2, 1 };
            Solutions s = new Solutions();
            s.ConvertToZigZag(arr);
            Console.WriteLine(String.Join(",", arr));
            zValidateZigZag(arr);

            int[] arr2 = { 1, 4, 3, 2 };
            s.ConvertToZigZag(arr2);
            Console.WriteLine(String.Join(",", arr2));
            zValidateZigZag(arr2);
        }

        [TestMethod]
        public void Test_CovertToZigZag_Fast()
        {
            int[] arr = { 4, 3, 7, 8, 6, 2, 1 };
            Solutions s = new Solutions();
            s.ConvertToZigZag_Faster(arr);
            Console.WriteLine(String.Join(",", arr));
            zValidateZigZag(arr);

            int[] arr2 = { 1, 4, 3, 2 };
            s.ConvertToZigZag_Faster(arr2);
            Console.WriteLine(String.Join(",", arr2));
            zValidateZigZag(arr2);
        }

        private void zValidateZigZag(int[] arr)
        {
            bool isLess = true;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (isLess)
                {
                    Assert.IsTrue(arr[i] < arr[i + 1]);
                    isLess = false;
                }
                else
                {
                    Assert.IsTrue(arr[i] > arr[i + 1]);
                    isLess = true;
                }
            }
        }

        [TestMethod]
        public void Test_ModularExponentiation()
        {
            Solutions s = new Solutions();

            int result = s.ModularExponentiation(2, 3, 5);

            Assert.AreEqual(3, result);

            result = s.ModularExponentiation(2, 5, 13);

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Test_ModularExponentiation_Bits()
        {
            Solutions s = new Solutions();

            int result = s.ModularExponentiation_Bits(2, 3, 5);

            Assert.AreEqual(3, result);

            result = s.ModularExponentiation_Bits(2, 5, 13);

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Test_Power()
        {
            Solutions s = new Solutions();
            decimal result = s.Power(2, -2);

            Assert.AreEqual(.25m, result);

            result = s.Power(2, 3);

            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void Test_IsPrime()
        {
            Solutions s = new Solutions();

            Assert.IsTrue(s.IsPrime(11));
            Assert.IsFalse(s.IsPrime(15));
            Assert.IsFalse(s.IsPrime(1));
        }

        [TestMethod]
        public void Test_IsPrime2()
        {
            Solutions s = new Solutions();

            Assert.IsTrue(s.IsPrime2(11));
            Assert.IsFalse(s.IsPrime2(15));
            Assert.IsFalse(s.IsPrime2(1));
        }

        [TestMethod]
        public void Test_IsPrimeWithHighProbability()
        {
            Solutions s = new Solutions();

            Assert.IsTrue(s.IsPrimeWithHighProbability(11, 3));
            Assert.IsFalse(s.IsPrimeWithHighProbability(15, 3));
        }

        [TestMethod]
        public void Test_EulersTotient()
        {
            Solutions s = new Solutions();
            int[] nums = { 1,1,2,2,4,2,6,4,6,4 };

            for (int i = 0; i < nums.Length; i++)
            {
                int result = s.EulersTotient(i + 1);

                Assert.AreEqual(nums[i], result);
            }
        }

        [TestMethod]
        public void Test_EulersTotientUsingEulersProduct()
        {
            Solutions s = new Solutions();
            int[] nums = { 1, 1, 2, 2, 4, 2, 6, 4, 6, 4 };

            for (int i = 0; i < nums.Length; i++)
            {
                int result = s.EulersTotientUsingEulersProduct(i + 1);

                Assert.AreEqual(nums[i], result);
            }
        }
    }
}
