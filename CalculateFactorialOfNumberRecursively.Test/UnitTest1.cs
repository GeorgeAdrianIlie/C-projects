using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace CalculateFactorialOfNumberRecursively.Test
{
    public class UnitTest1
    {
        [Fact]
        public void GetFactorialOfNumber_ShouldReturnCorrectFactorialResult()
        {
            int number = 4;
            Assert.Equal(24, Program.GetFactorialOfNumber(number));
        }
    }
}