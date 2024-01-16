namespace RecursivelyReplaceWordFromText.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Search_Caracter_AndReplaceWith_Caracter_Recursivly_ShouldReturnNewTextWitoutSearched()
        {
            string text = "mare";
            string toSearchAndReplace = "m";
            string toFillIn = "t";
            Assert.Equal("tare", Program.SearchAndReplace(text, toSearchAndReplace, toFillIn));
        }

        [Fact]
        public void Search_Caracter_AndReplaceWith_Text_Recursivly_ShouldReturnNewTextWitoutSearched()
        {
            string text = "se pe";
            string toSearchAndReplace = "e";
            string toFillIn = "us";
            Assert.Equal("sus pus", Program.SearchAndReplace(text, toSearchAndReplace, toFillIn));
        }

        [Fact]
        public void Search_Caracter_AndReplaceWith_ManyCaractersOfSameType_Recursivly_ShouldReturnNewTextWitoutSearched()
        {
            string text = "test";
            string toSearchAndReplace = "s";
            string toFillIn = "sss";
            Assert.Equal("tessst", Program.SearchAndReplace(text, toSearchAndReplace, toFillIn));
        }
    }
}