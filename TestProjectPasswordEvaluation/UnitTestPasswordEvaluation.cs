using PasswordEvaluation;
using Xunit.Abstractions;

namespace TestProjectPasswordEvaluation
{
    public class UnitTest1
    {
        [Fact]
        public void TestHasMinimumSmallLetters_ShouldReturnTrue()
        {
            int minimumSmallLetters = 5;
            string passwordToTestUnit = "abcdeAB23+-";
            Assert.Equal(true, Program.HasMinimumSmallLetters(minimumSmallLetters, passwordToTestUnit));
        }

        [Fact]
        public void TestHasMinimumBigLetters_ShouldReturnTrue()
        {
            int minimumBigLetters = 2;
            string passwordToTestUnit = "abcdeAB23+-";
            Assert.Equal(true, Program.HasMinimumBigLetters(minimumBigLetters, passwordToTestUnit));
        }

        [Fact]
        public void TestHasMinimumIntegers_ShouldReturnTrue()
        {
            int minimumIntegers = 2;
            string passwordToTestUnit = "abcdeAB23+-";
            Assert.Equal(true, Program.HasMinimumIntegers(minimumIntegers, passwordToTestUnit));
        }

        [Fact]
        public void TestHasMinimumSimbols_ShouldReturnTrue()
        {
            int minimumSimbols = 2;
            string passwordToTestUnit = "abcdeAB23+-";
            Assert.Equal(true, Program.HasMinimumSimbols(minimumSimbols, passwordToTestUnit));
        }

        [Fact]
        public void TestMayContainSimilarChars_ShouldReturnTrue()
        {
            bool mayContainSimilarChars = true;
            string passwordToTestUnit = "abcdeAB23+-";
            Assert.Equal(true, Program.MayContainSimilarChars(mayContainSimilarChars, passwordToTestUnit));
        }

        [Fact]
        public void TestMayContainAmbiguesChars_ShouldReturnTrue()
        {
            bool mayContainAmbiguesChars = true;
            string passwordToTestUnit = "abcdeAB23+-";
            Assert.Equal(true, Program.MayContainAmbiguesChars(mayContainAmbiguesChars, passwordToTestUnit));
        }

        [Fact]
        public void TestEvaluatePassword_ShouldReturnTrue()
        {
            PasswordComplexity passwordComplexity = new PasswordComplexity();
            passwordComplexity.MinLowercaseChars = 5;
            passwordComplexity.MinUpercaseChars = 2;
            passwordComplexity.MinDigits = 2;
            passwordComplexity.MinSymbols = 2;
            passwordComplexity.MayContainSimilarChars = true;
            passwordComplexity.MayContainAmbiguesChars = true;

            string toTest = "abcdeAB23+-";
            Assert.Equal(true, Program.EvaluatePasswordMinimumRequirements(passwordComplexity, toTest));
        }
    }
}