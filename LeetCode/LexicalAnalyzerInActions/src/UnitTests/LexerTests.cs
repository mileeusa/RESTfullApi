using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzerInActions.src.UnitTests
{
    [TestFixture]
    public class LexerTests
    {
        [Test]
        public void Lexer_Test()
        {
            var lexer = new Lexer("a * (b + 42)");

            Token token;
            do
            {
                token = lexer.NextToken();
                Console.WriteLine($"{token.Type,-10} '{token.Lexeme}'");
            }
            while (token.Type != TokenType.EOF);
        }
    }
}
