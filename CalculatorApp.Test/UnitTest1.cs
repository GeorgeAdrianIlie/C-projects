using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace CalculatorApp.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string[] inputs = { "+", "/", "*", "+", "56", "45", "46", "3", "-", "1", "0.25" };
            int length = inputs.Length;
            int result = 1548;

            Assert.Equal(result, Program.PocketCalculator(inputs,length));
        }
    }
}