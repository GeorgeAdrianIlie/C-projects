namespace FibonacciRecursive.Test
{
    public class UnitTest1
    {
        [Fact]
        public void GetFibonacciNumberAtPosition_n_InTheList_Sgould_Return_ValidNumber()
        {
            int n = 7;
            int previous = 0;
            Assert.Equal(13, Program.Fibonacci(n, ref previous));
        }
    }
}