using System;
using System.Collections.Generic;

namespace _2019_Fall_Assignment2
{
    class Program
    {
        public static void Main(string[] args)
        {
            int target = 2;
            int[] nums = { 1, 3, 5, 6 };
            Console.WriteLine("Position to insert {0} is = {1}\n", target, SearchInsert(nums, target));

            int[] nums1 = { 2, 5, 2, 2 };
            int[] nums2 = { 5, 5 };
            int[] intersect = Intersect(nums1, nums2);
            Console.WriteLine("Intersection of two arrays is: ");
            DisplayArray(intersect);
            Console.WriteLine("\n");

            int[] A = { 5, 7, 3, 9, 4, 9, 8, 3, 1 };
            Console.WriteLine("Largest integer occuring once = {0}\n", LargestUniqueNumber(A));

            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "cba";
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

                // declaring variables
                int index = 0;
                int n = nums.Length - 1;
                int y;

                // while loop to 
                while (index < n)
                {
                    y = index + (n - index) / 2;

                    if (target == nums[y])
                    {
                        return y;
                    }

                    if (target < nums[y])
                    {
                        n = y - 1;
                    }
                    else
                    {
                        index = y + 1;
                    }
                }

                if (target <= nums[index])
                {
                    return index;
                }

                return index + 1;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing SearchInsert()");
            }

            return 0;
        }

        public static int[] Intersect(int[] nums1, int[] nums2)
        {

            try
            {

                HashSet<int> hash = new HashSet<int>(); // we store integers in this hashset
                foreach (int x in nums1)
                {
                    hash.Add(x); // adding unique values from first array to the hashset
                }

                HashSet<int> intersec = new HashSet<int>(); // we store integers that intersect
                foreach (int x in nums2)
                {
                    if (hash.Contains(x))
                    {
                        intersec.Add(x); // add value to intersection if similar values found
                    }
                }

                int[] intersecValue = new int[intersec.Count]; // the value contains size of the intersection hashset
                int index = 0;

                foreach (int i in intersec)
                {
                    intersecValue[index++] = i;
                }

                return intersecValue; // returns result value - intersection value

            }
            catch
            {
                Console.WriteLine("Exception occured while computing Intersect()");
            }

            return new int[] { };
        }

        public static int LargestUniqueNumber(int[] A)
        {
            // sorting and reversing the array provided as parameter
            Array.Sort(A);
            Array.Reverse(A);

            try
            {
                // declaring temporary variables for the for loops
                int x;
                int y;

                for (x = 0; x < A.Length; x++)
                {

                    for (y = 0; y < A.Length; y++)
                    {
                        if (x != y && A[x] == A[y])
                        {
                            break;
                        }
                    }

                    if (y == A.Length)
                    {
                        return A[x];
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing LargestUniqueNumber()");
            }
            // returning -1 in case no integer occurs once
            return -1;
        }

        public static int CalculateTime(string keyboard, string word)
        {
            try
            {
                // declaring of variables: result and position
                int result = 0;
                int position = 0;

                // foreach loop to calculate the time
                foreach (var i in word)
                {
                    // int value to store value read from the keyboard:
                    int value;
                    value = keyboard.IndexOf(i);
                    // calculating results through Abs method  to return
                    // absolute value where positon subtracts value
                    result = result + Math.Abs(position - value);
                    position = value;

                }
                // returning result
                return result;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing CalculateTime()");
            }

            return 0;
        }

        public static int[,] FlipAndInvertImage(int[,] A)
        {
            // declaring variables
            int i, j;
            i = A.GetLength(0);
            j = A.GetLength(1);

            int cols = i - 1;
            int actualValue, invertedResult;

            // result will be stored in this array
            int[,] arrayResult = new int[i, j];

            try
            {
                // for loop to iterate through the rows
                for (int x = 0; x <= i; x++)
                {
                    // for loop to iterate through the columns
                    for (int y = 0; y <= j - 1; y++)
                    {
                        actualValue = A[x, y];
                        if (actualValue == 1)
                        {
                            invertedResult = 0;
                        }
                        else
                        {
                            invertedResult = 1;
                        }

                        arrayResult.SetValue(invertedResult, x, cols);
                        cols--;
                    }
                    cols = i - 1;

                }
                // returns inverted values in the array
                return arrayResult;
            }

            catch
            {
                Console.WriteLine("Exception occured while computing FlipAndInvertImage()");
            }
            //return arrayResult;
            return new int[,] { };
        }

        public static int MinMeetingRooms(int[,] intervals)
        {
            // declaring initial variables for for-loops and setting initial values
            int loopBegin = 0;
            int loopEnd = 0;
            int max = 0;
            int used = 0;

            // declaring lists for start and end
            List<int> start = new List<int>();
            List<int> end = new List<int>();

            try
            {
                //creating start and end time for the intervals
                for (int i = 0; i < intervals.GetLength(0); i++)
                {
                    start.Add(intervals[i, 0]);
                    end.Add(intervals[i, 1]);
                }
                start.Sort();
                end.Sort();

                // the while loop is going through the lists
                while (loopBegin < start.Count && loopEnd < start.Count)
                {
                    // the if else statement increments counters for in use rooms 
                    // and start time counter
                    if (start[loopBegin] <= end[loopEnd])
                    {
                        used++;

                        //if statement to overwrite the maximum
                        if (used > max)
                        {
                            max = used;
                        }

                        loopBegin++;
                    }

                    // else clause for the end time of current entry
                    else
                    {
                        used--;
                        loopEnd++;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing MinMeetingRooms()");
            }

            //returning the maximum number of rooms to get the output
            return max;
        }

        private static int[] SortedSquares(int[] arr)
        {
            // declaring variable length to store the number of values in the array
            int length;
            length = arr.GetLength(0);

            // declaring integer array to store the values. The number of values
            // is the same to the length of the original array arr
            int[] squareArray = new int[length];

            int num;
            int y = 0;

            try
            {
                Array.Sort(arr);
                foreach (int x in arr)
                {
                    num = (int)Math.Pow(x, 2);
                    squareArray.SetValue(num, y);
                    y++;
                }
                Array.Sort(squareArray);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing SortedSquares()");
            }
            // returning result of the squareArray
            return squareArray;
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