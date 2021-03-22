using System;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Using decimals:");
            decimal a = 0.1M;
            decimal b = 0.2M;
            if (a + b == 0.3M)
            {
                Console.WriteLine($"{a} + {b} equals 0.3");
            }
            else
            {
                Console.WriteLine($"{a} + {b} does NOT equal 0.3");
            }

        }
    }
}
