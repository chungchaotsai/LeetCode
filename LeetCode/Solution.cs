using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Solution
    {
        public Solution() { }
        public int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        result[0] = i;
                        result[1] = j;
                    }
                }
            }
            return result;
        }
        public bool PalindromeNumber(int num)
        {
            if (num < 0) return false;
            var ch = num.ToString().ToCharArray();
            char[] reversech = new char[ch.Length];

            int i = 0;
            foreach (var c in ch)
            {
                reversech[ch.Length - 1 - i] = c;
                i++;
            }

            return ch.SequenceEqual(reversech);
        }
    }
}
