using StemmingFrequency.Core;

namespace StemmingFrequency.Tests
{
    public class WordStemmingTest
    {
        private readonly WordStemming _wordStemming = new WordStemming();
        [Fact]
        public void GetStemmedWord_WhenWordHasOnlyOneCharacter_ShouldReturnTheSameWord()
        {
            var smallLetter = "i";

            var actual = _wordStemming.GetStemmedWord(smallLetter);

            Assert.Equal(smallLetter, actual);
        }

        [Fact]
        public void GetStemmedWord_WhenFirstLetterIsCapitalized_ShouldReturnInSmallCase()
        {
            var word = "Friend";

            var actual = _wordStemming.GetStemmedWord(word);

            Assert.Equal(word.ToLower(), actual);
        }


        [Theory]
        [InlineData("Friends", "friend")]
        [InlineData("friendlies", "friend")]
        [InlineData("friendly", "friend")]
        [InlineData("friendlier", "friend")]
        [InlineData("friends", "friend")]
        [InlineData("classification", "class")]
        [InlineData("classify", "class")]
        [InlineData("class", "class")]
        [InlineData("classes", "class")]
        [InlineData("Flowery", "flower")]
        [InlineData("flowers", "flower")]
        [InlineData("following", "following")]
        [InlineData("class.", "class")]
        [InlineData("class,", "class")]
        [InlineData("friend's", "friend")]

        public void GetStemmedWord_WhenPassingWordParameter_ShouldReturnStemWord(string word, string stemmedWord)
        {
            var actual = _wordStemming.GetStemmedWord(word);

            Assert.Equal(actual, stemmedWord);
        }






    }
}