using LeetCode;

namespace LeetCodeTests
{
    [TestFixture]
    public class Tests
    {
        private Solution sol;

        [SetUp]
        public void Setup()
        {
            sol = new Solution();
        }

        [Test]
        [TestCase(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
        public void TwoSum(int[] intArray, int target, int[] result)
        {
            Assert.That(sol.TwoSum(intArray, target), Is.EqualTo(result));
        }

        [Test]
        [TestCase(121, true)]
        [TestCase(-121, false)]
        [TestCase(0, true)]
        [TestCase(123, false)]
        public void PalindromeNumber(int x, bool result)
        {
            Assert.That(sol.PalindromeNumber(x), Is.EqualTo(result));
        }

        [Test]
        [TestCase("III", 3)]
        [TestCase("LVIII", 58)]
        [TestCase("LVIII", 58)]
        [TestCase("MCMXCIV", 1994)]
        public void RomanToInteger(string s, int result)
        {
            Assert.That(sol.RomanToInteger(s), Is.EqualTo(result));
        }

        [Test]
        [TestCase(new string[] { "flower", "flow", "flight" }, "fl")]
        [TestCase(new string[] { "dog", "racecar", "car" }, "")]
        public void LongestCommonPrefix(string[] strs, string result)
        {
            Assert.That(sol.LongestCommonPrefix(strs), Is.EqualTo(result));
        }

        [Test]
        [TestCase("()",true)]
        [TestCase("()[]{}", true)]
        [TestCase("(]", false)]
        public void LongestCommonPrefix(string s, bool result)
        {
            Assert.That(sol.ValidParenthesesd(s), Is.EqualTo(result));
        }

        [Test]
        public void MergeTwoLists()
        {
            ListNode list1_3 = new ListNode() { val = 33 };
            ListNode list1_2 = new ListNode() { val = 22, next = list1_3 };
            ListNode list1_1 = new ListNode() { val = 11, next = list1_2 };
            ListNode list2_3 = new ListNode() { val = 35 };
            ListNode list2_2 = new ListNode() { val = 25, next = list2_3 };
            ListNode list2_1 = new ListNode() { val = 15, next = list2_2 };
            var reulst1 = sol.MergeTwoLists(list1_1, list2_1);
            Assert.That(reulst1.val, Is.EqualTo(11));
            Assert.That(reulst1.next.val, Is.EqualTo(15));
            Assert.That(reulst1.next.next.val, Is.EqualTo(22));
            Assert.That(reulst1.next.next.next.val, Is.EqualTo(25));
            Assert.That(reulst1.next.next.next.next.val, Is.EqualTo(33));
            Assert.That(reulst1.next.next.next.next.next.val, Is.EqualTo(35));

            ListNode list2_2_1 = null;
            ListNode list2_2_2 = new ListNode() { val = 0 };
            var result2 = sol.MergeTwoLists(list2_2_1, list2_2_2);

            Assert.That(result2.val, Is.EqualTo(0));
            Assert.That(result2.next,Is.Null);

        }
    }


}

    