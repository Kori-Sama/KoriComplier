using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoriComplier;

public class Parser
{
    private readonly Token[] tokens;
    private int position;
    public Parser(string text)
    {
        var lexer = new Lexer(text);
        var tokens = new List<Token>();
        Token? token;
        do
        {
            token = lexer.NextToken();
            if (token.Type != TokenType.WhiteSpace &&
                token.Type != TokenType.Unknown)
            {
                tokens.Add(token);
            }
        } while (token.Type != TokenType.EOF);

        this.tokens = tokens.ToArray();
    }
}
