using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoriComplier;

public enum TokenType {
    // Single-character tokens.
    LeftParen, RightParen, LeftBrace, RightBrace,
    Semicolon, Dot, Minus, Plus, Slash, Star,
    // One or two character tokens.
    Bang, BangEqual,
    Equal, EqualEqual,
    Greater, GreaterEqual,
    Less, LessEqual,
    // Literals.
    Number, String, Whitespace,
    // Keywords.

    //Others.
    EOF, Unknown,
}

public class Token {
    public TokenType Type { get; }
    public string Literal { get; }
    public Object? Value { get; }
    public int Position { get; }
    public Token(TokenType type, string literal, Object? value, int position) {
        Type = type;
        Literal = literal;
        Value = value;
        Position = position;
    }
    public override string ToString() {
        return $"Type: {Type} Literal: {Literal} Value{Value ?? null}";
    }
}
