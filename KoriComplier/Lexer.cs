using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoriComplier;

public class Lexer {
    private readonly string text;
    private int position;
    private char Current {
        get {
            if (position >= text.Length)
                return '\0';
            return text[position];
        }
    }
    public Lexer(string text) {
        this.text = text;
    }
    public Token NextToken() {
        if (position >= text.Length)
            return new Token(TokenType.EOF, "\0", null, position);

        if (char.IsDigit(Current)) {
            var start = position;
            while (char.IsDigit(Current)) {
                Next();
            }
            var length = position - start;
            var _text = text.Substring(start, length);
            _ = int.TryParse(_text, out int value);
            return new Token(TokenType.Number, _text, value, start);
        }
        if (char.IsWhiteSpace(Current)) {
            var start = position;
            while (char.IsWhiteSpace(Current)) {
                Next();
            }
            var length = position - start;
            var _text = text.Substring(start, length);
            return new Token(TokenType.Whitespace, _text, null, start);
        }
        switch (Current) {
            case '+': return new Token(TokenType.Plus, "+", null, position++);
            case '-': return new Token(TokenType.Minus, "-", null, position++);
            case '*': return new Token(TokenType.Star, "*", null, position++);
            case '/': return new Token(TokenType.Slash, "/", null, position++);
            case '(': return new Token(TokenType.LeftParen, "(", null, position++);
            case ')': return new Token(TokenType.RightParen, ")", null, position++);
        }
        return new Token(TokenType.Unknown, text.Substring(position - 1, 1), null, position++);
    }
    private void Next() => position++;
}
