using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoriComplier;

public class Parser
{
    private readonly List<Token> tokens;
    public Parser(string text)
    {
        this.tokens = Lexer.GetTokens(text);
    }

    private void Calculate()
    {
        for (int i = 0; i < tokens.Count(); i++)
        {
            var type = tokens[i].Type;
            if (type == TokenType.Plus
            || type == TokenType.Minus
            || type == TokenType.Star
            || type == TokenType.Slash)
            {
                // TODO!
            }
        }
    }
}
