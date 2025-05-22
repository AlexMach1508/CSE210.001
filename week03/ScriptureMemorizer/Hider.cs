using System;
using System.Collections.Generic;
using System.Linq;

public class Hider
{
    private readonly Random _random = new Random();

    public void HideRandomWords(Scripture scripture, int count)
    {
        var visibleWords = scripture.GetWords().Where(w => !w.IsHidden).ToList();
        int wordsToHide = Math.Min(count, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }
}
