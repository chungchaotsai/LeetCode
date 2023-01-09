using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// LeetCode solution, 
    /// Runtime > 90%, ***
    ///         > 70%, **
    /// Memory  > 90%, ***
    ///         > 70%, **
    /// </summary>
    public class Solution
    {
        private int Factorial(int n)
        {
            if (n == 0) return 1;
            var result = 1;
            for (int i = 1; i <= n; i++)
            {
                result = result * i;
            }
            return result;
        }
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
        /// <summary>
        /// R *, M *
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
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
        /// <summary>
        /// R *, M *
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int RomanToInteger(string s)
        {
            Dictionary<string, int> romanNumbersDictionary = new()
            {
                { "I", 1 },
                { "V", 5 },
                { "X", 10 },
                { "L", 50 },
                { "C", 100 },
                { "D", 500 },
                { "M", 1000 },
                { "IV", 4 },
                { "IX", 9 },
                { "XL", 40 },
                { "XC", 90 },
                { "CD", 400 },
                { "CM", 900 },
            };

            int sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var current = s[i].ToString();
                romanNumbersDictionary.TryGetValue(current, out int num1);
                if (i + 1 < s.Length)
                {
                    var twoChar = s[i].ToString() + s[i + 1].ToString();

                    if (romanNumbersDictionary.TryGetValue(twoChar, out int num2))
                    {
                        sum += num2;
                        i++;
                    }
                    else
                    {
                        sum += num1;
                    }
                }
                else
                {
                    sum += num1;
                }
            }
            return sum;
        }
        /// <summary>
        /// R: *, M **
        /// </summary>
        /// <param name="strs"></param>
        /// <param name="result"></param>
        public string LongestCommonPrefix(string[] strs)
        {

            string prefix = "";
            int prfixDigit = 0;
            char[] s1Array = strs[0].ToCharArray();
            try
            {
                while (true)
                {
                    if (s1Array.Length < prfixDigit + 1)
                    {
                        return prefix;
                    }
                    prefix += s1Array[prfixDigit];
                    foreach (var str in strs)
                    {
                        if (prfixDigit > str.Length)
                        {
                            return prefix;
                        }

                        if (!str.StartsWith(prefix))
                        {
                            return prefix.Remove(prefix.Length - 1);
                        }


                    }
                    prfixDigit++;
                }

            }
            catch (Exception e)
            {
                return prefix;
            }
        }
        /// <summary>
        /// R *, M *
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool ValidParenthesesd(string s)
        {
            var result = true;
            Dictionary<char, char> PairedParentheseHead = new Dictionary<char, char>();
            PairedParentheseHead.Add('(', ')');
            PairedParentheseHead.Add('[', ']');
            PairedParentheseHead.Add('{', '}');
            Dictionary<char, char> PairedParentheseTail = new Dictionary<char, char>();
            PairedParentheseTail.Add(')', '(');
            PairedParentheseTail.Add(']', '[');
            PairedParentheseTail.Add('}', '{');
            var charArray = s.ToCharArray();
            char currentChar;
            var ParenthesesAry = new List<char>();
            for (int i = 0; i < charArray.Length; i++)
            {
                currentChar = charArray[i];
                var isFindHead = PairedParentheseHead.TryGetValue(currentChar, out char tail);
                var isFindTail = PairedParentheseTail.TryGetValue(currentChar, out char head);

                if (isFindHead) ParenthesesAry.Add(currentChar);
                if (isFindTail)
                {
                    if (ParenthesesAry.Count == 0 || head != ParenthesesAry.Last()) return false;
                    ParenthesesAry.RemoveAt(ParenthesesAry.Count - 1);
                }

            }
            if (ParenthesesAry.Count() > 0) result = false;
            return result;
        }
        /// <summary>
        /// R **, M *
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(0);
            ListNode current = result;

            if (l1 == null && l2 == null)
                return null;
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;

            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    current.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    current.next = l2;
                    l2 = l2.next;
                }
                current = current.next;
            }
            current.next = l1 ?? l2;
            return result.next;
        }
        /// <summary>
        /// R: ** , M *
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            if (target == nums[nums.Length - 1]) return nums.Length - 1;
            if (target > nums[nums.Length - 1]) return nums.Length;
            if (target <= nums[0]) return 0;
            var start = 0;
            var end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] == target) return mid;
                if (nums[mid] < target)
                {
                    if (nums[mid + 1] >= target) return mid + 1;
                    start = mid;
                }

                if (nums[mid] > target)
                {
                    if (nums[mid - 1] < target) return mid;
                    if (nums[mid - 1] == target) return mid - 1;
                    end = mid;
                }
            }

            return 0;
        }
        /// <summary>
        /// R * , M *
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLastWord(string s)
        {
            s = s.Trim();
            if (s.Length == 0) return 0;
            string[] words = s.Split(' ');

            return words[words.Length - 1].Length;
        }
        /// <summary>
        /// R: ***, M * 
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public int[] PlusOne(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int digit = digits[i];

                // If num is less than 9 simply increment
                if (digit < 9)
                {
                    digits[i] = digit + 1;
                    return digits;
                }
                else
                {
                    // Set current num to 0 and there will be a carry.
                    digits[i] = 0;
                }
            }

            // Edge case when all values are 9's
            int[] newDigitArray = new int[digits.Length + 1];
            newDigitArray[0] = 1;

            return newDigitArray;
        }
        /// <summary>
        /// R: ** , M: *
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string AddBinary(string a, string b)
        {
            var charA = a.ToCharArray();
            var charB = b.ToCharArray();
            Array.Reverse(charA);
            Array.Reverse(charB);

            var longArray = (charA.Length >= charB.Length) ? charA : charB;
            var shrtArray = (charA.Length < charB.Length) ? charA : charB;
            var ret = new List<int>();
            var up = false;

            for (int i = 0; i < longArray.Length; i++)
            {

                int l = Int32.Parse(longArray[i].ToString());
                if (i < shrtArray.Length)
                {
                    int s = Int32.Parse(shrtArray[i].ToString());

                    if (up) ret.Add((l + s + 1) % 2);
                    else
                    {
                        ret.Add((l + s) % 2);
                    }

                    if (l + s + Convert.ToInt32(up) >= 2)
                    {
                        up = true;
                    }
                    else
                    {
                        up = false;
                    }
                }
                else
                {
                    if (up)
                    {
                        ret.Add((1 + l) % 2);
                        if (1 + Int32.Parse(longArray[i].ToString()) == 2)
                        {
                            up = true;
                        }
                        else
                        {
                            up = false;
                        }
                    }
                    else
                    {
                        ret.Add(l);
                    }
                }
            }

            if (up) ret.Add(1);
            ret.Reverse();
            var c = string.Join("", ret.ToArray());
            return c;
        }
 // TODO
        public int MySqrt() { return 0; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            return Math.Fabonacci(n);
        }
    }
}
