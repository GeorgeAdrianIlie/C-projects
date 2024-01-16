using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace AreaOfTriangle.Test
{
    public class UnitTestAreaOfTriangle
    {
        [Fact]
        public void Test1()
        {
            Triangle test = new Triangle();
            test.A.X = 1;
            test.A.Y = 1;
            test.B.X = 5;
            test.B.Y = 1;
            test.C.X = 5;
            test.C.Y = 4;

            Assert.Equal(6, Program.CalculateArea(test));
        }
            
    }
}