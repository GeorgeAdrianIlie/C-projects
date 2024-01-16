namespace ConversionFromBase16ToBase10.Test
{
    public class ConversionFromBase16ToBase10_Test1
    {
        [Fact]
        public void Conversion_ShouldReturnTrueForEqualTo()
        {
            string base16 = "12F";
            int power = base16.Length;
            int index = -1;
            int base10 = 303;
            Assert.Equal(base10, Program.Conversion(base16, power, index)); 
        }
    }
}