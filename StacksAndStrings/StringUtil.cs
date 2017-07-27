using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndStrings
{
    public static class StringUtil
    {
        /// <summary>
        /// Reverse the words in a sentence using CustomStack.
        /// </summary>
        /// <param name="sentence">the sentence to have its words reversed</param>
        /// <returns>string with the sentence words reversed</returns>
        public static string ReverseWordsUsingCustomStack(string sentence)
        {
            var words = sentence.Trim().Split(' ');
            var customStack = new CustomStack<string>();
            var reversedResult = new StringBuilder();

            foreach (var word in words)
            {
                customStack.Push(word);
            }

            while (!customStack.IsEmpty)
            {
                var item = customStack.Pop();
                reversedResult.AppendFormat("{0} ", item);
            }

            var reversedUsingCustomStack = reversedResult.ToString().TrimEnd();

            return reversedUsingCustomStack;
        }

        /// <summary>
        /// Reverse the words in a sentence using builtin string methods.
        /// </summary>
        /// <param name="sentence">the sentence to have its words reversed</param>
        /// <returns></returns>
        public static string ReverseWordsUsingStringMethods(string sentence)
        {
            return String.Join(" ", sentence.Trim().Split(' ').Reverse());
        }

        /// <summary>
        /// Return a string composed of a distinct character array that match one or more times 
        /// between the 2 string arguments.
        /// This approach uses a LINQ query that joins the char arrays of both string arguments testing for matches.
        /// </summary>
        /// <param name="s1">the first string to compare</param>
        /// <param name="s2">the second string to compare</param>
        /// <returns>a string of distinct characters contained in both string arguments</returns>
        public static string MatchCharsUsingLinq(string s1, string s2)
        {
            var chars1 = s1.ToCharArray();
            var chars2 = s2.ToCharArray();

            var result = from c1 in chars1
                         join c2 in chars2 on c1 equals c2
                         select c1;

            return new string(result.Distinct().ToArray());
        }

        /// <summary>
        /// Return a string composed of a distinct character array that match one or more times 
        /// between the 2 string arguments.
        /// This approach iterates through the chars of both string arguments testing for matches.
        /// </summary>
        /// <param name="s1">the first string to compare</param>
        /// <param name="s2">the second string to compare</param>
        /// <returns>a string of distinct characters contained in both string arguments</returns>
        public static string MatchCharsUsingNestedIteration(string s1, string s2)
        {
            var matches = new HashSet<char>();

            foreach (var c1 in s1)
            {
                for (var i = 0; i < s2.Length; i++)
                {
                    var c2 = s2[i];

                    if (c1 == c2)
                    {
                        matches.Add(c1); // prevent duplicate chars
                        s2.Remove(i);   // limit duplicate comparisons
                        break;
                    }
                }
            }

            return new string(matches.Select(c => c).ToArray());       
        }
    }
}
