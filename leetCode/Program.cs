﻿using System;

namespace leetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(7 / 2);
            Rotate(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 3);
            Console.WriteLine(ContainsDuplicate(new int[] { 1, 6, 2, 3, 5, 6 }));
            Console.WriteLine(SingleNumber(new int[] { 3,4,1,2,1,2}));
            Console.WriteLine(Intersect(new int[] { 2,1,3,2}, new int[] { 1,4,2,2,5}));
            PlusOne(new int[] { 9 });
            MoveZeroes(new int[] { 1, 0, 0, 2, 5, 6 });
            TwoSum(new int[] { -1, -2, -3, -4, -5 }, -8);

            Console.WriteLine();
            char[][] ver = new char[][]{
            new char[]{'5','3','.','.','7','.','.','.','.'},
            new char[]{'6','.','.','1','9','5','.','.','.'},
            new char[]{'.','9','8','.','.','.','.','6','.'},
            new char[]{'8','.','.','.','6','.','.','.','3'},
            new char[]{'4','.','.','8','.','3','.','.','1'},
            new char[]{'7','.','.','.','2','.','.','.','6'},
            new char[]{'.','6','.','.','.','.','2','8','.'},
            new char[]{'.','.','.','4','1','9','.','.','5'},
            new char[]{'.','.','.','.','8','.','.','7','9'}
            };
            Console.WriteLine(ver[1][0]);
            Console.WriteLine();
            bool res = IsValidSudoku(new char[][]{
            new char[]{'.', '.', '.', '.', '.', '.', '5', '.', '.'},
            new char[]{'.', '.', '.', '.', '.', '.', '.', '.', '.'},
            new char[]{'.', '.', '.', '.', '.', '.', '.', '.', '.'},
            new char[]{'9', '3', '.', '.', '2', '.', '4', '.', '.'},
            new char[]{'.', '.', '7', '.', '.', '.', '3', '.', '.'},
            new char[]{'.', '.', '.', '.', '.', '.', '.', '.', '.'},
            new char[]{'.', '.', '.', '3', '4', '.', '.', '.', '.'},
            new char[]{'.', '.', '.', '.', '.', '3', '.', '.', '.'},
            new char[]{'.', '.', '.', '.', '.', '5', '2', '.', '.'}});
            
            Console.WriteLine(res);

            Rotate(new int[][] { new int[] { 1, 2, 3 },
                                 new int[] {4,5,6},
                                 new int[] {7,8,9 } });

            ReverseString(new char[] { 'h', 'e', 'l', 'l', 'o' });

            Console.WriteLine(Reverse(536));

            Console.WriteLine(FirstUniqChar("aadad"));

            Console.WriteLine(IsAnagram("anagram", "nagaram"));
        }

        //Given a sorted array nums, remove the duplicates in-place such that each element appear only once and return the new length.
        //Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
        public static int RemoveDuplic(int[] arr)
        {
            if (arr.Length == 0) return 0;
            int result = 1;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] != arr[i - 1])
                {
                    arr[result] = arr[i];
                    result++;
                }
            }
            return result;
        }

        //Say you have an array prices for which the ith element is the price of a given stock on day i.
        //Design an algorithm to find the maximum profit.You may complete as many transactions as you like (i.e., buy one and sell one share of the stock multiple times).
        public static int MaxProfit(int[] prices)
        {
            int result = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (i + 1 >= prices.Length)
                {
                    break;
                }

                while (prices[i] >= prices[i + 1])
                {
                    i++;
                    if (i + 1 >= prices.Length)
                    {
                        return result;
                        i--;
                        break;
                    }

                }
                if (prices[i] < prices[i + 1]) result -= prices[i];

                while (prices[i] <= prices[i + 1])
                {
                    i++;
                    if (i + 1 >= prices.Length)
                    {
                        result += prices[i];
                        i--;
                        break;
                    }

                }
                if (prices[i] > prices[i + 1]) result += prices[i];

            }
            return result;
        }

        //Given an array, rotate the array to the right by k steps, where k is non-negative.
        public static void Rotate(int[] nums, int k)
        {


            while (k >= nums.Length) k -= nums.Length;
            if (nums.Length > 1 && k != 0)
            {
                int[] arr = new int[nums.Length];
                nums.CopyTo(arr, 0);
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i + nums.Length - k < nums.Length) nums[i] = arr[i + nums.Length - k];
                    else nums[i] = arr[i - k];
                }
            }
            foreach (var item in nums)
            {
                Console.WriteLine(item);
            }
        }

        //Given an array of integers, find if the array contains any duplicates.
        //Your function should return true if any value appears at least twice in the array, and it should return false if every element is distinct.
        public static bool ContainsDuplicate(int[] nums)
        {
            //////Too lower
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    for (int k = i; k < nums.Length; k++)
            //    {
            //        if (nums[i] == nums[k + 1]) return true;
            //    }
            //}
            //return false;
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1]) return true;
            }
            return false;
        }

        //Given a non-empty array of integers, every element appears twice except for one. Find that single one.
        //Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?
        public static int SingleNumber(int[] nums)
        {
            //if (nums.Length == 1) return nums[0];
            //Array.Sort(nums);
            //int save = nums[0];
            //for (int i = 0; i < nums.Length - 1; i++)
            //{
            //    if (nums[i] == nums[i + 1]) {
            //        save = nums[i + 1];
            //        continue;
            //    } 
            //    if (i == nums.Length - 2) return nums[i + 1];
            //    if (i == 0 && nums[i] != nums[i + 1]) return nums[i];
            //    if(save != nums[i+1] && nums[i+1] != nums[i+2]) return nums[i + 1];
            //}
            //return 0;

            int res = 0;
            foreach (var n in nums)
            {
                res = res ^ n;
            }
            return res;
        }

        //Given two arrays, write a function to compute their intersection.
        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            int[] arr = new int[nums1.Length];
            int itemarr = 0;
            Array.Sort(nums1);
            Array.Sort(nums2);
            int i = 0; int j = 0;
            while(i < nums1.Length && j < nums2.Length)
            {
                if(nums1[i] == nums2[j])
                {
                    arr[itemarr++] = nums1[i++];
                    j++;
                }
                else if(nums1[i] < nums2[j])
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }
            int[] arr2 = new int[itemarr];
            for (int b = 0; b < arr2.Length; b++)
            {
                arr2[b] = arr[b];
            }
            foreach (var item in arr2)
            {
                Console.WriteLine(item);
            }
            return arr2;
        }

        //Given a non-empty array of digits representing a non-negative integer, increment one to the integer.
        //The digits are stored such that the most significant digit is at the head of the list, and each element in the array contains a single digit.
        //You may assume the integer does not contain any leading zero, except the number 0 itself.
        public static int[] PlusOne(int[] digits)
        {
            //Dont handle large arrays
            //string numb = "";
            //foreach (var item in digits)
            //{
            //    numb += item.ToString();
            //}
            //int number = Convert.ToInt32(numb);
            //number++;
            //int[] arr = new int[number.ToString().Length];
            //int i= 0;
            //foreach (var item in number.ToString())
            //{
            //    arr[i] = Convert.ToInt32(item) - 48;
            //    i++;
            //}
            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item);
            //}
            //return arr;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if(digits[i] == 9 && i == 0)
                {
                    digits[i] = 0;
                    int[] arr = new int[digits.Length + 1];
                    arr[0] = 1;
                    for (int k = 1; k < arr.Length; k++)
                    {
                        arr[k] = digits[k - 1];
                    }
                    return arr;
                }
                else if (digits[i] == 9)
                {
                    digits[i] = 0;
                }
                else
                {
                    digits[i]++;
                    break;
                }
            }
            foreach (var item in digits)
            {
                Console.WriteLine(item);
            }
            return digits;
        }

        //Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.
        public static void MoveZeroes(int[] nums)
        {
            int iszero = 0;
            for (int i = 0; i < nums.Length - iszero; i++)
            {
                if (nums[i] != 0) continue;
                for (int k = i; k < nums.Length - 1; k++)
                {
                    nums[k] = nums[k + 1];
                    nums[k + 1] = 0;
                }
                iszero++;
                i--;
            }
            foreach (var item in nums)
            {
                Console.WriteLine(item);
            }
        }

        //Given an array of integers, return indices of the two numbers such that they add up to a specific target.
        //You may assume that each input would have exactly one solution, and you may not use the same element twice.
        public static int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int k = i; k < nums.Length - 1; k++)
                {
                    if(nums[i] + nums[k + 1] == target)
                    {
                        result[0] = i;
                        result[1] = k + 1;
                    }
                }
            }
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            return result;
        }

        //Determine if a 9x9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:
        //Each row must contain the digits 1-9 without repetition.
        //Each column must contain the digits 1-9 without repetition.
        //Each of the 9 3x3 sub-boxes of the grid must contain the digits 1-9 without repetition.
        public static bool IsValidSudoku(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                if (ContainsDuplicateInSudoku(board[i])) return false;
            }
            for (int k = 0; k < 9; k++)
            {
                if (ContainsDuplicateInSudoku(new char[]{ board[0][k],
                                                          board[1][k],
                                                          board[2][k],
                                                          board[3][k],
                                                          board[4][k],
                                                          board[5][k],
                                                          board[6][k],
                                                          board[7][k],
                                                          board[8][k]})) return false;
                            }
            int m = 0;
            int n = 0;
            for (int iter = 1; iter <= 9; iter++)
            {
                if (ContainsDuplicateInSudoku(new char[]{   board[n][m],
                                                            board[n][m + 1],
                                                            board[n][m + 2],
                                                            board[n + 1][m],
                                                            board[n + 1][m + 1],
                                                            board[n + 1][m + 2],
                                                            board[n + 2][m],
                                                            board[n + 2][m + 1],
                                                            board[n + 2][m + 2]})) return false;
                if (iter % 3 == 0 && iter != 0)
                {
                    n += 3;
                    m = 0;
                }
                else
                {
                    m += 3;
                }
            }
            return true;
        }

        //Handle method for IsValidSudoku
        public static bool ContainsDuplicateInSudoku(char[] nums)
        {
            char[] copy = new char[9];
            nums.CopyTo(copy,0);
            Array.Sort(copy);
            for (int i = 0; i < copy.Length - 1; i++)
            {
                if ((copy[i] == copy[i + 1]) && copy[i] != '.') return true;
            }
            return false;
        }

        //You are given an n x n 2D matrix representing an image.
        //Rotate the image by 90 degrees(clockwise).
        //Note:
        //You have to rotate the image in-place, which means you have to modify the input 2D matrix directly.DO NOT allocate another 2D matrix and do the rotation.
        public static void Rotate(int[][] matrix)
        {
            //int save;
            //int save2;
            //int[] saveindex = new int[] { 0, 0 };
            //int i = 0;
            //int k = 0;
            //int numb = 0;
            //int max = matrix.Length - 1;
            //save2 = matrix[i][k];
            //save = save2;
            //for (int m = 0; m < matrix.Length / 2; m++)
            //{
            //    if(m != 0)
            //    {
            //        max--;
            //        i = m;
            //        k = m;
            //    }
            //    while (true)
            //    {
            //        if (k < max && i < max) k += max;
            //        else if (k == max && i < max) i += max;
            //        else if (k == max && i == max) k -= max;
            //        else if (k < max && i == max) i -= max;
            //        if (i > max) i -= max;
            //        if (i < 0) i += max;
            //        if(k > max) k -= max;
            //        if(k < 0) k += max;
            //        save2 = matrix[i][k];
            //        matrix[i][k] = save;
            //        if (i == saveindex[0] && k == saveindex[1])
            //        {
            //            i++;
            //            k++;
            //            saveindex[0] = i;
            //            saveindex[1] = k;
            //        }
            //        else
            //        {
            //            save = save2;
            //        }
            //    }
            
            
            Console.WriteLine(matrix.Length * (matrix.GetUpperBound(0) + 1));
            for (int d = 0; d < matrix.Length; d++)
            {
                for (int m = 0; m < matrix.Length; m++)
                {
                    Console.Write("{0} ", String.Join(" ", matrix[d][m]));
                }
                Console.Write("\n");
            }

            //Write a function that reverses a string. The input string is given as an array of characters char[].
            //Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
            //You may assume all the characters consist of printable ascii characters.
            
        }
        public static void ReverseString(char[] s)
        {
            if (s.Length > 1)
            {
                char save1;
                for (int i = 0; i < s.Length / 2; i++)
                {
                    save1 = s[i];
                    s[i] = s[s.Length - i - 1];
                    s[s.Length - i - 1] = save1;
                }
            }
            
            foreach (var item in s)
            {
                Console.WriteLine(item);
            }
        }

        //Given a 32-bit signed integer, reverse digits of an integer.
        public static int Reverse(int x)
        {
            if (x.ToString().Length < 2) return x;
            string s = x.ToString();
            bool minus = false;
            if (s[0] == '-')
            {
                minus = true;
                s = s.Substring(1);
            }
            char save1;
            char save2;
            int m = (s.Length / 2 > 1) ? s.Length / 2 : s.Length - 1;
            for (int i = 0; i < m; i++)
            {
                save1 = s[s.Length - i - 1];
                save2 = s[i];
                s = s.Remove(s.Length - i - 1, 1);
                s = s.Insert(s.Length - i, save2.ToString());
                s = s.Remove(i, 1);
                s = s.Insert(i, save1.ToString());
            }
            if (minus) s = s.Insert(0, "-");
            int res = 0;
            Int32.TryParse(s, out res);
            return res;
        }

        //Given a string, find the first non-repeating character in it and return its index. If it doesn't exist, return -1.
        public static int FirstUniqChar(string s)
        {
            if (s.Length == 1) return 0;
            int flag;
            for (int i = 0; i < s.Length; i++)
            {
                flag = 0;
                for (int k = 1; k < s.Length; k++)
                {
                    if (s[i] == s[k]) break;
                    if (k == s.Length - 1) return i;
                }
            }
            return -1;
        }

        //Given two strings s and t , write a function to determine if t is an anagram of s.
        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            //set the counter for values 
            int[] arr = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                arr[s[i] - 'a']++;
                arr[t[i] - 'a']--;
            }

            foreach (int count in arr)
            {
                if (count != 0)
                    return false;
            }

            return true;
        }
    }
}
