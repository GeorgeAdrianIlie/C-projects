using DominoSolution;
using System.Collections.Generic;

namespace DominoRecursiveSolution.Test
{
    public class UnitTest1
    {
        [Fact]
        public void DominoRecursiveSolution_Test_ShouldReturnStringsFromResult()
        {
            int numberOfDominoPairs = 6;
            List<string> pairsList = new List<string> { "1 2", "1 3", "3 4", "2 3", "3 5", "4 5" };
            int xorSeries = 3;
            List<string> solutions = new List<string> { "1 2 2 3 3 4", "1 2 2 3 3 5", "1 3 3 4 4 5", "2 3 3 4 4 5" };
            Assert.Equal(solutions, Program.CreateDominoSolution(xorSeries, pairsList));
        }
    }

    public class UnitTest2
    {
        public void DominoRecursiveSolution_Test_ShouldReturnSigleStringFromResult()
        {
            int numberOfDominoPairs = 6;
            List<string> pairsList = new List<string> { "1 2", "2 3", "3 4", "4 6", "5 5", "5 6" };
            int xorSeries = 4;
            List<string> solutions = new List<string> { "1 2 2 3 3 4 4 6" };
            Assert.Equal(solutions, Program.CreateDominoSolution(xorSeries, pairsList));
        }
    }
}