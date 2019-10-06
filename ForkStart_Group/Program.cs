using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

/*
 A project to help student groups learn how to collaborate using github

  Task:
  One group member forks the repository, and adds fellow group members as collaborators to the repository.
  
  These fellow group members clone the repository and add content. Once all group members are synced, all
    group members have the same code
   */

namespace ForkStart_Group
{
  class Program
  {
    public static void Main(string[] args)
    {
        int target = 5;
        int[] nums = { 1, 3, 5, 6 };
        Console.WriteLine("Position to insert {0} is = {1}\n", target, SearchInsert(nums, target));

        int[] nums1 = { 3, 6, 2 };
        int[] nums2 = { 6, 3, 6, 7, 3};
        int[] intersect = Intersect(nums1, nums2);
        Console.WriteLine("Intersection of two arrays is: ");
        DisplayArray(intersect);
        Console.WriteLine("\n");

        int[] A = { 5, 7, 3, 9, 4, 9, 8, 3, 1};
        Console.WriteLine("Largest integer occuring once = {0}\n", LargestUniqueNumber(A));

        string keyboard = "abcdefghijklmnopqrstuvwxyz";
        string word = "leetcode";
        Console.WriteLine("Time taken to type with one finger = {0}\n", CalculateTime(keyboard, word));

        int[,] image = { { 1, 1, 0 }, { 1, 0, 1 }, { 0, 0, 0 } };
        int[,] flipAndInvertedImage = FlipAndInvertImage(image);
        Console.WriteLine("The resulting flipped and inverted image is:\n");
        Display2DArray(flipAndInvertedImage);
        Console.Write("\n");

        int[,] intervals = { { 0, 30 }, { 5, 10 }, { 15, 20 } };
        int minMeetingRooms = MinMeetingRooms(intervals);
        Console.WriteLine("Minimum meeting rooms needed = {0}\n", minMeetingRooms);

        int[] arr = { -4, -1, 0, 3, 10 };
        int[] sortedSquares = SortedSquares(arr);
        Console.WriteLine("Squares of the array in sorted order is:");
        DisplayArray(sortedSquares);
        Console.Write("\n");

        string s = "abca";
        if (ValidPalindrome(s))
        {
            Console.WriteLine("The given string \"{0}\" can be made PALINDROME", s);
        }
        else
        {
            Console.WriteLine("The given string \"{0}\" CANNOT be made PALINDROME", s);
        }
    }

    public static void DisplayArray(int[] a)
    {
        foreach (int n in a)
        {
            Console.Write(n + " ");
        }
    }

    public static void Display2DArray(int[,] a)
    {
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.Write(a[i, j] + "\t");
            }
            Console.Write("\n");
        }
    }

    public static int SearchInsert(int[] nums, int target)
    {
        try
        {
            // Question 1:
            Console.WriteLine("Question1: Binary Search");
            int min = 0; // define a varibale to iterate
            int max = nums.Length - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;
                if( target == nums[mid])
                {
                    return mid;
                }
                else if (target < nums[mid])
                {
                    max = mid - 1;
                }
                else
                {

                        min = mid + 1;
                }
            }
                
        }
        catch
        {
            Console.WriteLine("Exception occured while computing SearchInsert()");
        }

        return 0;
    }

    public static int[] Intersect(int[] nums1, int[] nums2)
    {
        Console.WriteLine("Question2: ");
        try
        {
            int i = 0, j = 0;
            int n = nums1.Length;
            int m = nums2.Length;

            // Sort the two arrays
            Array.Sort(nums1);
            Array.Sort(nums2);

            while(i<n && j < m)
            {
                if(nums1[i] > nums2[j])
                {
                    j++;
                }
                else
                {
                    if (nums2[j] > nums1[i])
                    {
                        i++;
                    }
                    else
                    {
                        // when both are equal
                        Console.WriteLine(nums1[i] + " ");
                        i++;
                        j++;
                    }

                }
            }
        }
        catch
        {
            Console.WriteLine("Exception occured while computing Intersect()");
        }

        return new int[] { };
    }

    public static int LargestUniqueNumber(int[] A)
    {
        try
        {
            Console.WriteLine("Question3:");
            List<int> listA = new List<int>(A);

            Array.Sort(A);
            listA.Sort();

            for (int i = A.Length-1; i >0; i--)
            {
                if (listA[i - 1] == listA[i]) continue;

                if (listA[i + 1] == listA[i]) continue;

                return listA[i];
            }
            return -1;
        }
        catch
        {
            Console.WriteLine("Exception occured while computing LargestUniqueNumber()");
        }

        return 0;
    }

    public static int CalculateTime(string keyboard, string word)
    {
        try
        {
                Console.WriteLine("Question4: ");
                Dictionary<int, string> hash = new Dictionary<int, string>(); 

                for(int i = 0; i<keyboard.Length; i++)
                {
                    hash.Add(i, keyboard[i].ToString());
                }
                var distance = hash.Where(p => p.Value == word[0].ToString()).Select(p =>p.Key).FirstOrDefault();
                for (int i = 1; i<word.Length; i++)
                {
                    int dis_cur = hash.Where(p => p.Value == word[i].ToString()).Select(p => p.Key).FirstOrDefault();
                    int dis_pre = hash.Where(p => p.Value == word[i - 1].ToString()).Select(p => p.Key).FirstOrDefault();
                    distance += Math.Abs(dis_cur-dis_pre);
                }
                return distance;
        }
        catch
        {
            Console.WriteLine("Exception occured while computing CalculateTime()");
        }

        return 0;
    }

    public static int[,] FlipAndInvertImage(int[,] A)
    {
        try
        {
            // Write your code here
        }
        catch
        {
            Console.WriteLine("Exception occured while computing FlipAndInvertImage()");
        }

        return new int[,] { };
    }

    public static int MinMeetingRooms(int[,] intervals)
    {
        try
        {
            // Write your code here
        }
        catch
        {
            Console.WriteLine("Exception occured while computing MinMeetingRooms()");
        }

        return 0;
    }

    public static int[] SortedSquares(int[] A)
    {
        try
        {
            // Write your code here
        }
        catch
        {
            Console.WriteLine("Exception occured while computing SortedSquares()");
        }

        return new int[] { };
    }

    public static bool ValidPalindrome(string s)
    {
        try
        {
            // Write your code here
        }
        catch
        {
            Console.WriteLine("Exception occured while computing ValidPalindrome()");
        }

        return false;
    }
    }
}