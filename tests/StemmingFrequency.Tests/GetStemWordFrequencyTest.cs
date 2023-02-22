using StemmingFrequency.Core;

namespace StemmingFrequency.Tests
{
    public class GetStemWordFrequencyTest
    {
        private const string ClassifyString = "Class classify classes ";
        private const string FriendString = "friend, friendly,friend's friendly. ";
        private const string EmptyString = "          ";


        [Fact]
        public void GetStemWordFrequency_WitInputString_ShouldReturnStemWordWithFrequency()
        {
            var stemWordFrequency = new GetStemWordFrequency();
            var mockCount = new Dictionary<string, int>()
            {
                {"following",1 },
                {"flow",2 },
                {"classification",3 },
                {"class",3 },
                {"flower",3 },
                {"friend",5 },
                {"friendly",5 },
                {"classes",3 }
            };

            var wordsWithFreq
                = stemWordFrequency.GetFrequency(InputConstants.DefaultInputString);

            foreach (var wordFrequency in wordsWithFreq)
            {
                Assert.Equal(mockCount[wordFrequency.word], wordFrequency.Frequency);
            }
        }


        [Fact]
        public void GetStemWordFrequency_WithClassifyString_ShouldReturnStemWordWithFrequency()
        {
            var stemWordFrequency = new GetStemWordFrequency();
            var mockCount = new Dictionary<string, int>()
            {
                {"following",0 },
                {"flow",0 },
                {"classification",3 },
                {"class",3 },
                {"flower",0 },
                {"friend",0 },
                {"friendly",0},
                {"classes",3 }
            };

            var wordWithFrequency = stemWordFrequency.GetFrequency(ClassifyString);

            foreach (var wordFreq in wordWithFrequency)
            {
                Assert.Equal(mockCount[wordFreq.word], wordFreq.Frequency);
            }
        }


        [Fact]
        public void GetStemWordFrequency_WithFriendString_ShouldReturnStemWordWithFrequency()
        {
            var stemWordFrequency = new GetStemWordFrequency();
            var mockCount = new Dictionary<string, int>()
            {
                {"following",0 },
                {"flow",0 },
                {"classification",0 },
                {"class",0 },
                {"flower",0 },
                {"friend",4 },
                {"friendly",4},
                {"classes",0 }
            };

            var wordWithFrequency = stemWordFrequency.GetFrequency(FriendString);

            foreach (var wordFreq in wordWithFrequency)
            {
                Assert.Equal(mockCount[wordFreq.word], wordFreq.Frequency);
            }
        }


        [Fact]
        public void GetStemWordFrequency_WithEmptyString_ShouldReturnStemWordWithFrequency()
        {
            var stemWordFrequency = new GetStemWordFrequency();
            var mockCount = new Dictionary<string, int>()
            {
                {"following",0 },
                {"flow",0 },
                {"classification",0 },
                {"class",0 },
                {"flower",0 },
                {"friend",0 },
                {"friendly",0},
                {"classes",0 }
            };

            var wordWithFrequency = stemWordFrequency.GetFrequency(EmptyString);

            foreach (var wordFreq in wordWithFrequency)
            {
                Assert.Equal(mockCount[wordFreq.word], wordFreq.Frequency);
            }
        }

    }
}