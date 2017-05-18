using System;

namespace ConsoleApplication1
{
    /// <summary>
    /// Calculates the fibbonacci sequence number.
    /// Presumes the sequence starts out: [1, 2, 3, 5 ...]
    /// </summary>
    /// <remarks>
    /// To make the sequence start [0,1,2,3...] set <see cref="Initial"/> to be zero and <see cref="PreviousInitial"/> to be one.
    /// To make the sequence start [1,1,2,3...] set <see cref="Initial"/> to be 1 and <see cref="PreviousInitial"/> to be zero.
    /// </remarks>
    public class FibRunner
    {
        /// <summary>
        /// The first number in the fibbonacci sequence.
        /// </summary>
        public const int Initial = 1;

        /// <summary>
        /// The first 'previous' number to add in the sequence.
        /// </summary>
        public const int PreviousInitial = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting fibbonacci sequence");

            Console.WriteLine($"Fibbonacci sequence 10: {Fib(10)}");

            Console.WriteLine($"Fibbonacci sequence 40: {Fib(40)}");
        }

        public static int Fib(int position)
        {
            int current = Initial;
            int prev = PreviousInitial;
            int temp = 0;

            for (int i = 1; i < position; i++)
            {
                temp = current;
                current = current + prev;
                prev = temp;
            }

            return current;
        }
    }
}
