using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCP_Assessment.Helpers
{
    /// <summary>
    /// Class to split names into first and last names
    /// </summary>
    class SplitName
    {
        private static List<string> Suffixes = null;

        static SplitName()
        {
            // Initialize suffixes
            Suffixes = new List<string>();
            Suffixes.Add("jr");
            Suffixes.Add("sr");
            Suffixes.Add("esq");
            Suffixes.Add("ii");
            Suffixes.Add("iii");
            Suffixes.Add("iv");
            Suffixes.Add("v");
            Suffixes.Add("2nd");
            Suffixes.Add("3rd");
            Suffixes.Add("4th");
            Suffixes.Add("5th");
        }

        /// <summary>
        /// Splits a name string into the first and last name
        /// </summary>
        /// <param name="name">Name to be split</param>
        /// <param name="firstName">Returns the first name</param>
        /// <param name="lastName">Returns the last name</param>
        public static void Split(string name, out string firstName, out string lastName)
        {
            // Parse last name
            int pos = FindWordStart(name, name.Length - 1);

            // If last token is suffix, include next token
            // as part of last name also
            if (IsSuffix(name.Substring(pos)))
                pos = FindWordStart(name, pos);

            // Set results
            firstName = name.Substring(0, pos).Trim();
            lastName = name.Substring(pos).Trim();
        }

        /// <summary>
        /// Finds the start of the word that comes before startIndex.
        /// </summary>
        /// <param name="s">String to examine</param>
        /// <param name="startIndex">Position to begin search</param>
        private static int FindWordStart(string s, int startIndex)
        {
            // Find end of previous word
            while (startIndex > 0 && Char.IsWhiteSpace(s[startIndex]))
                startIndex--;
            // Find start of previous word
            while (startIndex > 0 && !Char.IsWhiteSpace(s[startIndex]))
                startIndex--;
            // Return final position
            return startIndex;
        }

        /// <summary>
        /// Returns true if the given string appears to be a name suffix
        /// </summary>
        /// <param name="s">String to test</param>
        private static bool IsSuffix(string s)
        {
            // Strip any punctuation from string
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                if (Char.IsLetterOrDigit(c))
                    sb.Append(c);
            }
            return Suffixes.Contains(sb.ToString(), StringComparer.OrdinalIgnoreCase);
        }
    }
}
