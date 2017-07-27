using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StacksAndStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            const string sentence = "let's reverse the words of this sentence";
            Console.WriteLine("source sentence: \"{0}\"", sentence);
            Console.WriteLine();

            var reversedUsingCustomFunc = sentence.ReverseWords();
            Console.WriteLine("Reversed words using custom string extension method:");
            Console.WriteLine("\"{0}\"", reversedUsingCustomFunc);
            Console.WriteLine();            

            var reversedUsingCustomStack = StringUtil.ReverseWordsUsingCustomStack(sentence);
            Console.WriteLine("Reversed words using custom stack:");
            Console.WriteLine("\"{0}\"", reversedUsingCustomStack);
            Console.WriteLine();

            var reversedUsingStringMethods = StringUtil.ReverseWordsUsingStringMethods(sentence);
            Console.WriteLine("Reversed words using built-in string methods:");
            Console.WriteLine("\"{0}\"", reversedUsingStringMethods);
            Console.WriteLine();

            Debug.Assert(new [] { reversedUsingCustomFunc, reversedUsingCustomStack }.All(s => s.Equals(reversedUsingStringMethods)));

            const string String1 = "asdfaerty";
            const string String2 = "sdfgsyis";
            
            var linqMatches = StringUtil.MatchCharsUsingLinq(String1, String2);
            Console.WriteLine("Matching characters in \"{0}\" and \"{1}\"", String1, String2);
            Console.WriteLine("\tusing LINQ returned: {0}", linqMatches);

            var nestedIterationMatches = StringUtil.MatchCharsUsingNestedIteration(String1, String2);
            Console.WriteLine("\tusing nested iteration returned: \"{0}\"", nestedIterationMatches);
            Console.WriteLine();

            Debug.Assert(linqMatches.Equals(nestedIterationMatches));

            Console.ReadLine();
        }        
    }
}
