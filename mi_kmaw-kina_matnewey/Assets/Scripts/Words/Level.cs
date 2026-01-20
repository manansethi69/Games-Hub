using System.Collections.Generic;

public class Level
{
    public List<MikmaqWord> words = new List<MikmaqWord>();

    public virtual MikmaqWord GetRandomWord()
    {
        // Return a random word from the list
        int index = UnityEngine.Random.Range(0, words.Count);
        return words[index];
    }

    public virtual List<string> GetAllEnglishWords()
    {
        List<string> englishWords = new List<string>();
        for (int i = 0; i < words.Count; i++)
        {
            englishWords.Add(words[i].getEnglishWord());
        }
        return englishWords;
    }

    public virtual void ExcludeWord(MikmaqWord exclusion)
    {
        words.Remove(exclusion);
    }
}
