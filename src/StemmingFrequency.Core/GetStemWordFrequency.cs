namespace StemmingFrequency.Core;

/// <summary>
/// Contains logic for counting the frequency of the stem words.
/// </summary>
public class GetStemWordFrequency
{
    #region PrivateMembers

    private readonly string[] _displayWordList = {
        "following",
        "flow",
        "classification",
        "class",
        "flower",
        "friend",
        "friendly",
        "classes",
    };

    private readonly WordStemming _wordStemming;


    #endregion PrivateMembers

    #region Constructor

    public GetStemWordFrequency()
    {
        _wordStemming = new WordStemming();
    }

    #endregion

    #region PublicMethods

    /// <summary>
    ///  Returns the stem word and its frequency in the given input string.
    /// </summary>
    /// <param name="inputString">input parameter string </param>
    public IEnumerable<(string word, int Frequency)> GetFrequency(string inputString)
    {
        var words = inputString.Split(',', ' ', '\t');
        var stemmedWordCount = words
            .Where(x => !string.IsNullOrEmpty(x))
            .Select(x => x.Trim())
            .Select(z => _wordStemming.GetStemmedWord(z))
            .GroupBy(x => x)
            .ToDictionary(x => x.Key, y => y.Count());

        return _displayWordList
            .Select(x => new
            {
                stemmedWord = _wordStemming.GetStemmedWord(x),
                word = x
            })
            .Select(x => (x.word, stemmedWordCount.GetValueOrDefault(x.stemmedWord)));
    }

    #endregion

}