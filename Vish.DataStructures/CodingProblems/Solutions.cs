using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CodingProblems
{
    public class Solutions
    {
        /// <summary>
        /// Reverse an array without affecting special characters
        /// Given a string, that contains special character together with 
        /// alphabets(‘a’ to ‘z’ and ‘A’ to ‘Z’), reverse the string in a 
        /// way that special characters are not affected.
        /// Runtime O(n) n = number of characters in str
        /// Space O(n) stack stores letters in str
        /// </summary>
        /// <returns>The array with special characters.</returns>
        /// <param name="array">Character Array.</param>
        public string ReverseArrayWithSpecialCharacters(char[] array)
        {
            Stack<char> stack = new Stack<char>();
            StringBuilder sb = new StringBuilder();

            foreach (char c in array)
            {
                if (char.IsLetter(c))
                {
                    stack.Push(c);
                }
            }

            foreach (char c in array)
            {
                if (char.IsLetter(c))
                {
                    sb.Append(stack.Pop());
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Reverses the array with special characters constant space. 
        /// Runtime O(n)
        /// Space O(1)
        /// </summary>
        /// <returns>The array with special characters constant space.</returns>
        /// <param name="array">Array.</param>
        public string ReverseArrayWithSpecialCharacters_ConstantSpace(char[] array)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left < right)
            {
                if (!char.IsLetter(array[left]))
                {
                    left++;
                }
                else if (!char.IsLetter(array[right]))
                {
                    right--;
                }
                else
                {
                    var temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                    left++;
                    right--;
                }
            }
            return String.Join("", array);
        }

        /// <summary>
        /// Given a string, print all possible palindromic partitions
        /// Given a string, find all possible palindromic partitions of given string.
        /// </summary>
        /// <returns>The all palindromic partitions.</returns>
        /// <param name="s">S.</param>
        public List<string> GetAllPalindromicPartitions(string s)
        {
            List<string> permutations = new List<string>();
            List<string> results = new List<string>();

            permutations.Add("");

            foreach (char c in s)
            {
                int count = permutations.Count;

                for (int i = 0; i < count; i++)
                {
                    permutations.Add(permutations[i] + c);
                }
            }

            foreach (var str in permutations)
            {
                if (str != "" && IsPalindrome(str))
                {
                    results.Add(str);
                }
            }

            return results;
        }

        /// <summary>
        /// Checks if string is a palindrome. Runtime O(n)
        /// </summary>
        /// <returns><c>true</c>, if palindrome was ised, <c>false</c> otherwise.</returns>
        /// <param name="s">S.</param>
        private bool IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length-1;

            while (left < right)
            {
                if (s[left] != s[right])
                    return false;

                left++;
                right--;
            }

            return true;
        }

        /// <summary>
        /// Count triplets with sum smaller than a given value
        /// Given an array of distinct integers and a sum value.
        /// Find count of triplets with sum smaller than given sum value. 
        /// Expected Time Complexity is O(n^2).
        /// Gets the triplets less than sum count.
        /// Runtime O(n^3)
        /// </summary>
        /// <returns>The triplets less than sum count.</returns>
        /// <param name="nums">Nums.</param>
        /// <param name="sum">Sum.</param>
        public int GetTripletsLessThanSumCount(int[] nums, int sum)
        {
            Dictionary<int, int> complements = new Dictionary<int, int>();
            int count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    for (int x = j + 1; x < nums.Length; x++)
                    {
                        if (nums[i] + nums[j] + nums[x] < sum)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Gets the triplets less than sum count.
        /// Runtime O(n^2)
        /// </summary>
        /// <returns>The triplets less than sum count faster.</returns>
        /// <param name="nums">Nums.</param>
        /// <param name="sum">Sum.</param>
        public int GetTripletsLessThanSumCount_Faster(int[] nums, int sum)
        {
            Array.Sort(nums);
            int count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int left = i+1;
                int right = nums.Length - 1;
                while (left < right)
                {
                    if (nums[i] + nums[left] + nums[right] >= sum)
                    {
                        right--;
                    }
                    else
                    {
                        count += right - left;
                        left++;
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Checks if the given array has a pythagorean triplet a^2 + b^2 = c^2.
        /// Pythagorean Triplet in an array
        /// Given an array of integers, write a function that returns true if there is a 
        /// triplet(a, b, c) that satisfies a^2 + b^2 = c^2.
        /// Runtime O(n^3)
        /// </summary>
        /// <returns><c>true</c>, if pythagorean triplet was hased, <c>false</c> otherwise.</returns>
        /// <param name="nums">Nums.</param>
        public bool HasPythagoreanTriplet(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    for (int x = j + 1; x < nums.Length; x++)
                    {
                        int a = (int)Math.Pow(nums[i], 2);
                        int b = (int)Math.Pow(nums[j], 2);
                        int c = (int)Math.Pow(nums[x], 2);

                        if (a + b == c || a + c == b || b + c == a)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Hases the pythagorean triplet faster.
        /// Runtime O(n^2)
        /// </summary>
        /// <returns><c>true</c>, if pythagorean triplet faster was hased, <c>false</c> otherwise.</returns>
        /// <param name="nums">Nums.</param>
        public bool HasPythagoreanTriplet_Faster(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = nums[i] * nums[i];
            }

            Array.Sort(nums);

            for (int i = nums.Length-1; i >= 2; i--)
            {
                int left = 0;
                int right = i - 1;

                while (left < right)
                {
                    if (nums[left] + nums[right] == nums[i])
                        return true;

                    if (nums[left] + nums[right] < nums[i])
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the length of largest sub array with contiguous elements.
        /// Length of the largest subarray with contiguous elements | Set 1
        /// Given an array of distinct integers, find length of the longest 
        /// subarray which contains numbers that can be arranged in a continuous sequence.
        /// Runtime O(n log n)
        /// </summary>
        /// <returns>The length of largest sub array with contiguous elements.</returns>
        /// <param name="nums">Nums.</param>
        public int GetLengthOfLargestSubArrayWithContiguousElements(int[] nums)
        {
            Array.Sort(nums);
            int count = 0;
            int max = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (i + 1 < nums.Length && nums[i+1] - nums[i] == 1)
                {
                    if (count == 0)
                        count += 2;
                    else
                        count++;
                }
                else
                {
                    max = Math.Max(max, count);
                    count = 0;
                }
            }

            return max;
        }

        /// <summary>
        /// Converts to zig zag.
        /// Convert array into Zig-Zag fashion
        /// Given an array of DISTINCT elements, rearrange the elements of 
        /// array in zig-zag fashion in O(n) time.The converted array should 
        /// be in form 
        /// a less than b greater than c less than d greater than e less than f
        /// Runtime O(n log n)
        /// </summary>
        /// <param name="nums">Nums.</param>
        public void ConvertToZigZag(int[] nums)
        {
            Array.Sort(nums);

            for (int i = 1; i < nums.Length-1; i+=2)
            {
                var temp = nums[i];
                nums[i] = nums[i+1];
                nums[i+1] = temp;
            }
        }

        /// <summary>
        /// Converts to zig zag faster.
        /// Runtime O(n)
        /// </summary>
        /// <param name="nums">Nums.</param>
        public void ConvertToZigZag_Faster(int[] nums)
        {
            bool flag = true;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (flag)
                {
                    //if A > B > C if we flip B and C then we get A > B < C
                    if (nums[i] > nums[i + 1])
                    {
                        var temp = nums[i];
                        nums[i] = nums[i + 1];
                        nums[i + 1] = temp;
                    }
                }
                else
                {
                    //if A < B < C if we flip B and C we get A < C > B
                    if (nums[i] < nums[i + 1])
                    {
                        var temp = nums[i];
                        nums[i] = nums[i + 1];
                        nums[i + 1] = temp;
                    }
                }
                flag = !flag;// flip flag
            }
        }

        /// <summary>
        /// Modulars the exponentiation.
        /// Modular Exponentiation (Power in Modular Arithmetic)
        /// Given three numbers x, y and p, compute (<paramref name="x"/>^y) % p.
        /// Runtime O(y)
        /// </summary>
        /// <returns>The exponentiation.</returns>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="p">P.</param>
        public int ModularExponentiation(int x, int y, int p)
        {
            decimal power = Power(x, y);

            int into = (int)power / p;

            return Math.Abs((int)power - (into * p));
        }

        /// <summary>
        /// Power the specified x and y.
        /// Runtime O(y)
        /// </summary>
        /// <returns>The power.</returns>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public decimal Power(int x, int y)
        {
            //power of 
            decimal power = 1;
            bool isNegative = false;

            if (y < 0)
            {
                isNegative = true;
                y = -y;
            }

            for (int i = 0; i < y; i++)
            {
                if (isNegative)
                {
                    power = power / x;
                }
                else
                {
                    power *= x;
                }
            }

            return power;
        }

        /// <summary>
        /// Modulars the exponentiation bits.
        /// Runtime O(Log y)
        /// </summary>
        /// <returns>The exponentiation bits.</returns>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="p">P.</param>
        public int ModularExponentiation_Bits(int x, int y, int p)
        {
            int result = 1;

            x = x % p; //update x if it is more than or equal to p

            while (y > 0)
            {
                if ((y & 1) == 1)
                {
                    result = (result * x) % p;
                }

                y = y >> 1;
                x = (x * x) % p;
            }

            return result;
        }

        /// <summary>
        /// Checks if a number is a prime. Uses sieve of eratosthenes to do so
        /// Runtime O(n^2)
        /// </summary>
        /// <returns><c>true</c>, if prime was ised, <c>false</c> otherwise.</returns>
        /// <param name="n">N.</param>
        public bool IsPrime(int n)
        {
            if (n < 2)
                return false;

            //walk through all numbers from 2 (first prime) to n
            //cross out all numbers that are divisible by the smaller numbers
            //sieve of eratosthenes
            for (int i = 2; i < n; i++)
            {
                int index = i;
                while (index <= n)
                {
                    if (index == n)
                        return false;

                    index += i;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if a number is prime. Divides n by numbers less than itself
        /// if any divides without a remainder returns false, else number is
        /// prime.
        /// Runtime O(n)
        /// </summary>
        /// <returns><c>true</c>, if prime2 was ised, <c>false</c> otherwise.</returns>
        /// <param name="n">N.</param>
        public bool IsPrime2(int n)
        {
            if (n < 2)
                return false;

            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if nsqrt n)
        /// </summary>
        /// <returns><c>true</c>, if prime3 was ised, <c>false</c> otherwise.</returns>
        /// <param name="n">N.</param>
        public bool IsPrime3(int n)
        {
            if (n <= 1)
                return false;

            if (n <= 3)
                return true;

            //skip middle 5 numbers
            if (n % 2 == 0 || n % 3 == 0)
                return false;

            for (int i = 5; i * i <= n; i = i + 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// if n is a prime this will always return true, if n is a composite
        /// then this returns false with high probability the higher the value of k is
        /// 
        /// Note that the above method may fail even if we increase number of iterations 
        /// (higher k). There exist sum composite numbers with the property that for every 
        /// a less than n, an-1 ≡ 1 (mod n). Such numbers are called Carmichael numbers. 
        /// Fermat’s primality test is often used if a rapid method is needed for filtering, 
        /// for example in key generation phase of the RSA public key cryptographic algorithm.
        /// 
        /// Runtime O(k log n)
        /// </summary>
        /// <returns><c>true</c>, if prime with high probability was ised, <c>false</c> otherwise.</returns>
        /// <param name="n">N.</param>
        /// <param name="k">K.</param>
        public bool IsPrimeWithHighProbability(int n, int k)
        {
            if (n < 2 || n == 4)
                return false;

            if (n <= 3)
                return true;

            Random rand = new Random();
            //try k times
            while (k > 0)
            {
                //pick a random number above 2 to n-2
                //where n > 4
                int a = 2 + (int)(rand.Next(2, n-2) % (n - 4));

                //Fermat's little theorem
                if (ModularExponentiation_Bits(a, n-1, n) != 1)
                {
                    return false;
                }

                k--;
            }

            return true;
        }

        /// <summary>
        /// Gets the greatest common divisor by getting the remainder of the division of a and b
        /// until there is no remainder
        /// Runtime O(h) where h is number of digits in smaller number of a and b
        /// </summary>
        /// <returns>The common divisor.</returns>
        /// <param name="a">The alpha component.</param>
        /// <param name="b">The blue component.</param>
        public int GreatestCommonDivisor(int a, int b)
        {
            if (a == 0)
                return b;

            return GreatestCommonDivisor(b % a, a);
        }

        /// <summary>
        /// Euler’s Totient Function
        /// Euler’s Totient function? (n) for an input n is count of numbers in {1, 2, 3, …, n } 
        /// that are relatively prime to n, i.e., the numbers whose GCD(Greatest Common Divisor) 
        /// with n is 1.
        /// Runtime O(n log n)
        /// </summary>
        /// <returns>The totient.</returns>
        /// <param name="n">N.</param>
        public int EulersTotient(int n)
        {
            int result = 1;

            for (int i = 2; i < n; i++)
            {
                if (GreatestCommonDivisor(i, n) == 1)
                {
                    result++; 
                }
            }

            return result;
        }

        /// <summary>
        /// The idea is based on Euler’s product formula which states that 
        /// value of totient functions is below product over all prime factors p of n.
        /// The formula basically says that the value of ?(n) is equal to n multiplied by 
        /// product of (1 – 1/p) for all prime factors p of n. 
        /// For example value of ?(6) = 6 * (1-1/2) * (1 – 1/3) = 2.
        /// </summary>
        /// <returns>The totient using eulers product.</returns>
        /// <param name="n">N.</param>
        public int EulersTotientUsingEulersProduct(int n)
        {
            float result = n;

            //consider all prime factors of n and
            //for every prime factor p multiply result with (1 - (1/p))
            for (int p = 2; p * p <= n; ++p)
            {
                if (n % p == 0)
                {
                    //check if p is a prime factor

                    while (n % p == 0)
                        n = n / p;

                    result *= (1.0f - (1.0f / (float)p));
                }
            }

            //if n has a prime factor greater than sqrt(n)
            //There can be at most one such prime factor
            if (n > 1)
            {
                result *= (1.0f - (1.0f / (float)n));
            }

            return (int)Math.Ceiling(result);
        }
    }
}
