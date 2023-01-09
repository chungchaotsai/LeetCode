using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Math
    {
        private static Dictionary<int, int> Fibonaccy = new Dictionary<int, int>();
        public static int Fabonacci(int n)
        {
            var result = 0;
            if (n == 1)
            {
                result = 1;
            }

            if (n == 2)
            {
                result = 2;
            }
            if (n <= 2) { return result; }
            else
            {
                if (Fibonaccy.TryGetValue(n, out int value))
                {
                    return value;
                }
                else
                {
                    value = Fabonacci(n - 1) + Fabonacci(n - 2);
                    Fibonaccy.Add(n, value);
                    return value;
                }
            }
        }
    }
}
