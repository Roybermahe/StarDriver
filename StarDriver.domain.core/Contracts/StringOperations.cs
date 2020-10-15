using System.Collections.Generic;

namespace StarDriver.domain.core.Contracts
{
    public static class StringOperations
    {
        private const string Separator = "|";

        public static bool IsEmpty(string word)
        {
            return string.IsNullOrEmpty(word) || string.IsNullOrWhiteSpace(word);
        }

        public static bool IsEqual(string wordA, string wordB)
        {
            return string.Equals(wordA, wordB);
        }

        public static IEnumerable<string> Split(string word)
        {
            return word.Split(Separator);
        }
    }
}