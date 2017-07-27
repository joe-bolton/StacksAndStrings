using System;
using System.Text;

namespace StacksAndStrings
{
    public static class StringExtensions
    {
        /// <summary>
        /// An string extension method that reverses the words of a sentence.
        /// 
        /// This implementation should return the same results as the result from the following statement:
        /// String.Join(" ", source.Trim().Split(' ').Reverse());
        /// 
        /// This function does not handle terminal punctuation mark
        /// </summary>
        /// <param name="source">the sentence to have its words reversed</param>
        /// <returns>a string with the words from the source in reverse order</returns>
        public static string ReverseWords(this string source, char delimiter = ' ')
        {
            var word = new StringBuilder();
            var sentence = string.Empty;

            foreach (var character in source.Trim())
            {
                word.Append(character);

                if (character.Equals(delimiter))
                {
                    sentence = string.Concat(word, sentence);
                    word.Clear();
                }
            }

            if (word.Length > 0)
            {
                sentence = string.Concat(word, delimiter, sentence);
            }

            return sentence.ToString().TrimEnd();
        }
    }
}
