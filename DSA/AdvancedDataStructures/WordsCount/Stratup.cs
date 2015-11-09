namespace WordsCount
{
    using System;
    using System.IO;
    using System.Linq;
    using rm.Trie;

    public class Stratup
    {
        public static void Main()
        {
            ITrie trie = TrieFactory.CreateTrie();

            using (var reader = new StreamReader(@"..\..\Files\text.txt"))
            {
                while (!reader.EndOfStream)
                {
                    reader
                        .ReadLine()
                        .Split(' ', '.', ',', '?', '!', ':')
                        .ToList()
                        .ForEach(word =>
                        {
                            trie.AddWord(word);
                        });
                }
            }

            var countOfLorem = trie.WordCount("lorem");

            Console.WriteLine("Lorem -> {0} times", countOfLorem);
        }
    }
}
