using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        // Sorts the array, skips duplicates, and checks gaps between adjacent numbers to find missing values
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                Array.Sort(nums);
                List<int> lst = new List<int>();

                for (int i = 0; i < nums.Length - 1; i++)
                {
                    if (nums[i] == nums[i + 1]) continue; // skip duplicates

                    int diff = nums[i + 1] - nums[i];
                    if (diff > 1) {
                        for (int j = 1; j < diff; j++) { 
                        lst.Add(nums[i] + j); // add missing numbers between gaps
                        }
                    }               
                }
                return lst; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        //Uses two-pointer approach to place even numbers at the start and odd numbers at the end
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                int[] res1 = new int[nums.Length]; // Initialize result array

                int start = 0, end = nums.Length - 1;

                foreach (int num in nums)
                {
                    if (num % 2 == 0)
                        res1[start++] = num; // Place even numbers at the start
                    else
                        res1[end--] = num; // Place odd numbers at the end
                }

                return res1; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        // Uses a dictionary to store indices of numbers and checks for complements
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                Dictionary<int, int> m1 = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];
                    if (m1.ContainsKey(complement))
                        return new int[] { m1[complement], i }; // Found the pair
                    if (!m1.ContainsKey(nums[i]))
                        m1[nums[i]] = i; // Store index of the number
                }
                return new int[0]; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        // Sorts the array and calculates the maximum product of three numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                Array.Sort(nums);
                int n = nums.Length;
                return Math.Max(nums[n - 1] * nums[n - 2] * nums[n - 3],
                                nums[0] * nums[1] * nums[n - 1]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        // Converts a decimal number to binary using division by 2
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                if (decimalNumber == 0) return "0"; 
                string binary1  = "";
                while (decimalNumber > 0)
                {
                    binary1 = (decimalNumber % 2) + binary1; // Prepend the binary digit
                    decimalNumber /= 2;
                }
                return binary1;// Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        // Uses binary search to find the minimum element in a rotated sorted array
        public static int FindMin(int[] nums)
        {
            try
            {
                int lft = 0, rght = nums.Length - 1; 
                while (lft < rght)
                {
                    int mid = lft + (rght - lft) / 2;
                    if (nums[mid] > nums[rght])
                        lft= mid + 1; // Move left pointer
                    else
                        rght = mid;// Move right pointer
                }
                return nums[lft]; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        // Checks if a number is a palindrome by reversing its digits
        public static bool IsPalindrome(int x)
        {
            try
            {
                if (x < 0) return false; // Negative numbers are not palindromes
                int original = x, reversed = 0;
                while (x > 0)
                {
                    int digit = x % 10;
                    reversed = reversed * 10 + digit; // Append digit to reversed
                    x /= 10;
                }
                return original == reversed; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        // Uses an iterative approach to calculate the nth Fibonacci number
        public static int Fibonacci(int n)
        {
            try
            {
                if (n == 0) return 0; // Check for base case


                if (n == 1) return 1; // Check for base case
                int a = 0, b = 1, c = 0; 
                for (int i = 2; i <= n; i++) 
                {
                    c = a + b;
                    a = b;
                    b = c;
                }
                return c; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
