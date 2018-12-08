using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var output = GetWordsRelationship("actA","acta");
            Console.WriteLine(output);
            Console.ReadLine();

        }

        internal static string GetWordsRelationship(string word1, string word2)
        {
            //trim words
            word1 = word1.Trim();
            word2 = word2.Trim();

            //noncase sensitive flag
            bool isNonCaseSensitive = false;

            //check if the words are null, empty, or they dont have the same length 
            if ((string.IsNullOrWhiteSpace(word1) || string.IsNullOrWhiteSpace(word1))
                || word1.Length != word2.Length)
            {
                return nameof(AnagramTypes.NoAnagram);
            }

            //check if the words have exactly the same letters
            foreach (var letter in word1)
            {
                var index = word2.IndexOf(letter);

                if (index == -1)
                {
                    var indexNonCaseSensitive = word2.ToLower().IndexOf(letter.ToString().ToLower(), StringComparison.Ordinal);

                    if(indexNonCaseSensitive == -1)return nameof(AnagramTypes.NoAnagram);

                    isNonCaseSensitive = true;
                }
                else
                {
                    word2 = word2.Remove(index,1);
                }
                
            }

            return isNonCaseSensitive ? nameof(AnagramTypes.NonCaseSensitiveAnagram) 
                : nameof(AnagramTypes.CaseSensitiveAnagram);
        }
    }

    internal enum AnagramTypes
    {
        NoAnagram,
        NonCaseSensitiveAnagram,
        CaseSensitiveAnagram
    }

}
