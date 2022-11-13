using FileHelper;

namespace FileHelperTests
{
    [TestFixture]
    public class StringTests
    {
        [TestCase("you", "this is you and it should be you", 2)]
        [TestCase("you", "this is You and it should be you", 2)]
        [TestCase("not", "this is You and it should be you", 0)]
        public void StringOccurenceFoundInText(string s, string text, int actualOccurenceCount)
        {
            int value = s.Occurence(text);
            Assert.That(value, Is.EqualTo(actualOccurenceCount));
        }
    }
}
