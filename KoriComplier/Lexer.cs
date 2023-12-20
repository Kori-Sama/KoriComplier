using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoriComplier;

public class Lexer
{
    private readonly string text;
    private int position;
    private char Current
    {
        get
        {
            if (position >= text.Length)
                return '\0';
            return text[position];
        }
    }
    public Lexer(string text)
    {
        this.text = text;
    }
    public Token NextToken()
    {
        if (position >= text.Length)
            return new Token(TokenType.EOF, "\0", null);
        if (char.IsWhiteSpace(Current))
            WhiteSpaceSkip();
        if (char.IsLetter(Current) || Current == '_')
            return NameMatch();
        if (char.IsDigit(Current))
            return DigitMatch();
        if (Current == '\"')
            return StringMatch();
        var token = Current switch
        {
            '+' => new Token(TokenType.Plus, "+", null),
            '-' => new Token(TokenType.Minus, "-", null),
            '*' => new Token(TokenType.Star, "*", null),
            '/' => new Token(TokenType.Slash, "/", null),
            '(' => new Token(TokenType.LeftParen, "(", null),
            ')' => new Token(TokenType.RightParen, ")", null),
            ';' => new Token(TokenType.Semicolon, ";", null),
            '.' => new Token(TokenType.Dot, ".", null),
            ',' => new Token(TokenType.Comma, ",", null),
            '{' => new Token(TokenType.LeftBrace, "{", null),
            '}' => new Token(TokenType.RightBrace, "}", null),
            '=' => PeekEqual(TokenType.Equal, '='),
            '>' => PeekEqual(TokenType.Greater, '>'),
            '<' => PeekEqual(TokenType.Less, '<'),
            '!' => PeekEqual(TokenType.Bang, '!'),
            '\0' => new Token(TokenType.EOF, "\0", null),
            _ => new Token(TokenType.Unknown, text.Substring(position, 1), null),
        };
        position++;
        return token;
    }


    private void Next() => position++;
    private Token DigitMatch()
    {
        var start = position;
        while (char.IsDigit(Current))
            Next();
        var length = position - start;
        var _text = text.Substring(start, length);
        _ = int.TryParse(_text, out int value);
        return new Token(TokenType.Integer, _text, value);
    }
    private Token NameMatch()
    {
        var start = position;
        while (char.IsLetter(Current) || Current == '_')
            Next();
        var length = position - start;
        var _text = text.Substring(start, length);
        var token = _text switch
        {
            "var" => new Token(TokenType.Var, _text, null),
            "let" => new Token(TokenType.Let, _text, null),
            "func" => new Token(TokenType.Function, _text, null),
            "return" => new Token(TokenType.Return, _text, null),
            "if" => new Token(TokenType.If, _text, null),
            "else" => new Token(TokenType.Else, _text, null),
            _ => new Token(TokenType.Name, _text, null),
        };
        return token;
    }
    private Token StringMatch()
    {
        Next();
        var start = position;
        while (Current != '\"')
            Next();
        var length = position - start;
        Next();
        var _text = text.Substring(start, length);
        return new Token(TokenType.String, _text, _text);
    }
    private Token PeekEqual(TokenType T, char pre)
    {
        if (Peek(1) == '=')
        {
            position++;
            var type = T switch
            {
                TokenType.Less => TokenType.LessEqual,
                TokenType.Equal => TokenType.EqualEqual,
                TokenType.Greater => TokenType.GreaterEqual,
                TokenType.Bang => TokenType.BangEqual,
                _ => TokenType.Unknown,
            };
            return new Token(type, pre + "=", null);
        }
        return new Token(T, pre.ToString(), null);
    }
    private void WhiteSpaceSkip()
    {
        while (char.IsWhiteSpace(Current))
            Next();
    }
    private char Peek(int offset)
    {
        if (position + offset >= text.Length)
            return '\0';
        return text[position + offset];
    }
    public static List<Token> GetTokens(string code)
    {
        var lexer = new Lexer(code);
        var tokens = new List<Token>();
        Token token;
        do
        {
            token = lexer.NextToken();
            if (token.Type != TokenType.Unknown)
                tokens.Add(token);
        } while (token.Type != TokenType.EOF);
        return tokens;
    }
}
