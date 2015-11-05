namespace WordsCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var path = "../../Files/words.txt";
            var file = File.ReadAllText(path);
            var words = file.Split(new char[] { ',', ' ', '.', '!', '?', '"' }, StringSplitOptions.RemoveEmptyEntries);

            var wordsCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                var wordToLowerCase = word.ToLower();
                if (!wordsCount.ContainsKey(wordToLowerCase))
                {
                    wordsCount[wordToLowerCase] = 0;
                }

                wordsCount[wordToLowerCase]++;
            }

            wordsCount
                .OrderBy(w => w.Value)
                .ToList()
                .ForEach(pair => Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value));
        }
    }
}
