using System;
using System.Collections.Generic;
using System.Text;

namespace BacktrackingInActions.src
{
    public class PhoneNumberCombinationsOps
    {
        private readonly static Dictionary<char, string> s_dict = new ()
        {
            ['2'] = "abc", // { '2', "abc" }
            ['3'] = "def",
            ['4'] = "ghi",
            ['5'] = "jkl",
            ['6'] = "mno",
            ['7'] = "pqrs",
            ['8'] = "tuv",
            ['9'] = "wxyz"
        };

        public static IList<string> LetterCombinations(string digits)
        {
            if (string.IsNullOrEmpty(digits)) return [];

            var result = new List<string>();
            var stringBuilder = new StringBuilder();

            Backtrack(digits, 0, stringBuilder, result);

            return result;
        }

        public static void Backtrack(string digits, int index, StringBuilder path, IList<string> list)
        {
            if (index == digits.Length)
            {
                list.Add(path.ToString());
                return;
            }

            string ss = s_dict[digits[index]];

            foreach (var c in ss)
            {
                path.Append(c);
                Backtrack(digits, index + 1, path, list);
                path.Length--;
            }
        }
    }
}
