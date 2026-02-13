using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzerInActions.src
{
    public enum TokenType
    {
        Identifier = 0,
        Number,
        Plus,
        Minus,
        Star,
        Slash,
        LParen,
        RParen,
        EOF
    }

    public record Token(TokenType Type, string Lexeme);

    //
    // A small lexical analyzer to analyze expressions like "a*b" etc
    //
    // Tokens to support:
    //   Identifiers: a, abs, var1
    //   Number: 123, 42
    //   Operators: + - * /
    //   Parentheses: ( )
    //   EOF
    //
    public class Lexer
    {
        private readonly string _input;
        private int _pos;

        public Lexer(string input)
        {
            _input = input;
            _pos = 0;
        }

        public Token NextToken()
        {
            SkipWhitespace();

            if (_pos >= _input.Length)
                return new Token(TokenType.EOF, "");

            char c = _input[_pos];

            // Identifier: a, abc, a1
            if (char.IsLetter(c))
                return ReadIdentifier();

            // Number: 123
            if (char.IsDigit(c))
                return ReadNumber();

            _pos++;
            return c switch
            {
                '+' => new Token(TokenType.Plus, "+"),
                '-' => new Token(TokenType.Minus, "-"),
                '*' => new Token(TokenType.Star, "*"),
                '/' => new Token(TokenType.Slash, "/"),
                '(' => new Token(TokenType.LParen, "("),
                ')' => new Token(TokenType.RParen, ")"),
                _ => throw new Exception($"Unexpected character: {c}")
            };
        }

        private void SkipWhitespace()
        {
            while (_pos < _input.Length && char.IsWhiteSpace(_input[_pos]))
                _pos++;
        }

        private Token ReadIdentifier()
        {
            int start = _pos;
            while (_pos < _input.Length && char.IsLetterOrDigit(_input[_pos]))
                _pos++;

            return new Token(
                TokenType.Identifier,
                _input[start.._pos]
            );
        }

        private Token ReadNumber()
        {
            int start = _pos;
            while (_pos < _input.Length && char.IsDigit(_input[_pos]))
                _pos++;

            return new Token(
                TokenType.Number,
                _input[start.._pos]
            );
        }
    }
}
