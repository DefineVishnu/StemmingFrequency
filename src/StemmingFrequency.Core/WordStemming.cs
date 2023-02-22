namespace StemmingFrequency.Core;

/// <summary>
///  Contains the logic for word stemming.
/// </summary>
public class WordStemming
{
    #region  PublicMethods

    /// <summary>
    /// Returns the Stem word.
    /// </summary>
    /// <param name="word"></param>
    public string GetStemmedWord(string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            return word;
        }

        if (word.Length <= 2)
        {
            return word;
        }

        word = word.ToLower();
        word = TrimCharacter(word, "'");
        word = TrimCharacter(word, ",");
        word = TrimCharacter(word, ".");
        word = TrimSuffix(word, "lier");
        word = TrimSuffix(word, "lies");
        word = TrimSuffix(word, "ification");
        word = TrimSuffix(word, "ify");
        word = TrimSuffix(word, "ly");
        word = TrimSuffix(word, "y");
        word = TrimSuffix(word, "es");

        if (!word.EndsWith("ss"))
        {
            word = TrimSuffix(word, "s");
        }

        return word;
    }

    #endregion

    #region PrivateMethods

    /// <summary>
    ///  Removes  suffix of the word.
    /// </summary>
    /// <param name="word">word parameter. </param>
    /// <param name="suffix">suffix of the word which needs to be removed.</param>
    private string TrimSuffix(string word, string suffix)
    {
        if (word.EndsWith(suffix))
        {
            word = word.Substring(0, word.Length - suffix.Length);
        }

        return word;
    }

    /// <summary>
    /// Removes the character if its present in the word.
    /// </summary>
    /// <param name="word">word parameter. </param>
    /// <param name="characterToBeRemoved">The character to be removed from the word.</param>
    /// <returns></returns>
    private string TrimCharacter(string word, string characterToBeRemoved)
    {
        var index = word.IndexOf(characterToBeRemoved, StringComparison.CurrentCultureIgnoreCase);
        if (index != -1)
        {
            return word.Remove(index, 1);
        }
        return word;
    }


    #endregion

}