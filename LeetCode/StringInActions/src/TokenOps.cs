using System.Text.RegularExpressions;

namespace StringInActions.src
{
    public class TokenOps
    {
        //public static int Sum(string s)
        //{
        //    var tokens = s.Split(new char[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries);
        //    var symbols = s.Split(new string[] { "one", "two" }, StringSplitOptions.RemoveEmptyEntries);
        //    int total = tokens[0] == "one" ? 1 : 2;

        //    for(int i = 1; i < tokens.Length; i++)
        //    {
        //        if (symbols[i-1] == "+")/        {
        //            total += tokens[i] == "one" ? 1 : 2;
        //        }
        //        else if (symbols[i-1] == "-")
        //        {
        //            total -= tokens[i] == "one" ? 1 : 2;
        //        }
        //    }
        //    return total;
        //}

        public static int Sum(string s)
        {
            var tokens = s.Split(new char[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries);
            var symbols = s.Where(c => c == '+' || c == '-').ToArray();
            int total = tokens[0] == "one" ? 1 : 2;
            for (int i = 1; i < tokens.Length; i++)
            {
                if (symbols[i - 1] == '+')
                {
                    total += tokens[i] == "one" ? 1 : 2;
                }
                else if (symbols[i - 1] == '-')
                {
                    total -= tokens[i] == "one" ? 1 : 2;
                }
            }
            return total;
        }

        public static int Sum2(string s)
        {
            var matches = Regex.Matches(s, @"(one|two)|([+-])");

            int total = matches[0].Value == "one" ? 1 : 2;

            for (int i = 1; i < matches.Count; i += 2)
            {
                string symbol = matches[i].Value;
                string number = matches[i+1].Value;
                if (symbol == "+")
                {
                    total += number == "one" ? 1 : 2;
                }
                else if (symbol == "-")
                {
                    total -= number == "one" ? 1 : 2;
                }
            }

            return total;
        }

        public static void Sum_Test()
        {
            string s = "one+two-one+two";
            int result = TokenOps.Sum(s);
            Console.WriteLine();
            Console.WriteLine("TokenInAction.Sum_Test:");
            Console.WriteLine($"The result of summing up the expression '{s}' is: {result}");

            int result2 = TokenOps.Sum2(s);
            Console.WriteLine();
            Console.WriteLine("TokenInAction.Sum2_Test:");
            Console.WriteLine($"The result of summing up the expression '{s}' is: {result2}");
        }
    }
}
