public class MikmaqWord
{
    public string mikmaqWord;
    public string englishDefinition;
    public string hint;

    public MikmaqWord(string mikmaqWord, string englishDefinition, string hint)
    {
        this.mikmaqWord = mikmaqWord;
        this.englishDefinition = englishDefinition;
        this.hint = hint;
    }

    public string getWord()
    {
        return this.mikmaqWord;
    }

    public string getEnglishWord()
    {
        return this.englishDefinition;
    }

    public string getHint()
    {
        return this.hint;
    }
}