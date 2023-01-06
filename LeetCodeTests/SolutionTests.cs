using LeetCode;

namespace LeetCodeTests
{
    [TestFixture]
    public class Tests
    {
        private Solution s;
        
        [SetUp]
        public void Setup()
        {
            s = new Solution();
        }

        [Test]
        [TestCase(new int[] { 2,7,11,15 }, 9, new int[] { 0,1})]
        public void TwoSum(int[] intArray, int target, int[] result)
        {
            Assert.That(s.TwoSum(intArray, target), Is.EqualTo(result));
        }

        [Test]
        [TestCase(121, true)]
        [TestCase(-121, false)]
        [TestCase(0, true)]
        [TestCase(123, false)]
        public void PalindromeNumber(int x, bool result )
        {
            Assert.That(s.PalindromeNumber(x), Is.EqualTo(result));
        }


    }

    
}