using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StacksAndStrings;

namespace StacksAndStringsTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class StringUtilTests
    {
        private static string sentence;
        private static string expectedReversed;
        private static string matchChars1;
        private static string matchChars2;
        private static string expectedMatches;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            sentence = "All work and no play makes Jack a dull boy";
            expectedReversed = "boy dull a Jack makes play no and work All";

            matchChars1 = "arkansas";
            matchChars2 = "arizona";
            expectedMatches = "arn";
        }

        [TestMethod]
        public void TestCharMatchesUsingLinq()
        {
            var result = StringUtil.MatchCharsUsingLinq(matchChars1, matchChars2);

            Assert.AreEqual(expectedMatches, result);
        }

        [TestMethod]
        public void TestCharMatchesUsingNestedIteration()
        {
            var result = StringUtil.MatchCharsUsingNestedIteration(matchChars1, matchChars2);

            Assert.AreEqual(expectedMatches, result);
        }

        [TestMethod]
        public void TestReverseWordsUsingCustomStack()
        {
            var result = StringUtil.ReverseWordsUsingCustomStack(sentence);

            Assert.AreEqual(expectedReversed, result);
        }

        [TestMethod]
        public void TestReverseWordsUsingCustomStringExt()
        {
            var result = sentence.ReverseWords();

            Assert.AreEqual(expectedReversed, result);
        }

        [TestMethod]
        public void TestReverseWordsUsingStringMethods()
        {
            var result = StringUtil.ReverseWordsUsingStringMethods(sentence);

            Assert.AreEqual(result, expectedReversed);
        }
    }
}
