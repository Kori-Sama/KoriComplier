using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoriComplier;

public enum TokenType
{
    // Single-character tokens.
    LeftParen, RightParen, LeftBrace, RightBrace,
    Semicolon, Dot, Minus, Plus, Slash, Star, Comma,
    // One or two character tokens.
    Bang, BangEqual,
    Equal, EqualEqual,
    Greater, GreaterEqual,
    Less, LessEqual,
    // Literals.
    Integer, String, Name,
    // Keywords.
    Var, Let, Function, Return, If, Else, Loop, Struct,
    //Others.
    EOF, Unknown,
}

public class Token : IEquatable<Token>
{
    public TokenType Type { get; }
    public string Literal { get; }
    public Object? Value { get; }
    // public int Position { get; }
    public Token(TokenType type, string literal, Object? value)
    {
        Type = type;
        Literal = literal;
        Value = value;
        // Position = position;
    }
    public override string ToString()
    {
        return $"[{Literal}][{Type}][{Value}]";
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        return Equals(obj as Token);
    }
    public bool Equals(Token? other)
    {
        if (other is null)
            return false;

        return Type == other.Type && Literal == other.Literal && Equals(Value, other.Value);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Type, Literal, Value);
    }
}
