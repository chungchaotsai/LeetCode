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
    }
}
