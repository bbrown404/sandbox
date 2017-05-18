using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;
using Xunit;

namespace Tests
{
    public class Test
    {
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(5, 8)]
        [InlineData(10, 89)] 
        [InlineData(20, 10946)]
        [InlineData(40, 165580141)]
        [Theory]
        public void CheckFib(int position, int expected)
        {
            int actual = FibRunner.Fib(position);
             Assert.Equal(expected, actual);
        }
    }
}
