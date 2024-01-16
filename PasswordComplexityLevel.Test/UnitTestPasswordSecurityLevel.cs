using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace PasswordSecurityLevel.Test
{
    public class UnitTestPasswordSecurityLevel
    {
        [Fact]
        public void GetPasswordComplexityLevel_ShouldReturn_High()
        {
            string password = "abcdeAB12+-";
            Assert.Equal(PasswordComplexityLevel.High, Program.GetPasswordComplexityLevel(password));
        }

        [Fact]
        public void GetPasswordComplexityLevel_ShouldReturn_Medium()
        {
            string password = "abcA1+";
            Assert.Equal(PasswordComplexityLevel.Medium, Program.GetPasswordComplexityLevel(password));
        }

        [Fact]
        public void GetPasswordComplexityLevel_ShouldReturn_Low()
        {
            string password = "abA2+";
            Assert.Equal(PasswordComplexityLevel.Low, Program.GetPasswordComplexityLevel(password));
        }

        /*  ambigue:
                cand poate avea si are, 
                cand poate avea si nu are, 
                cand nu poate avea si are, 
                cand nu poate avea si nu are

            similare:
                cand poate avea si are, 
                cand poate avea si nu are, 
                cand nu poate avea si are, 
                cand nu poate avea si nu are*/
    }
}