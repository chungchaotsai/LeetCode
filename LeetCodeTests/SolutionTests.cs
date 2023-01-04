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
    }

    
}