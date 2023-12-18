using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoriComplier;

public enum SyntaxType
{
    NumberExpression,
    BinaryExpression,
}

abstract class Node
{
    public abstract SyntaxType Type { get; }
}

abstract class Expression : Node
{
}
sealed class NumberExpression : Expression
{
    public Token Token { get; }
    public override SyntaxType Type => SyntaxType.NumberExpression;
    NumberExpression(Token token)
    {
        Token = token;
    }
}

sealed class BinaryExpression : Expression
{
    public Expression Left { get; }
    public Node OperatorToken { get; }
    public Expression Right { get; }
    public override SyntaxType Type => SyntaxType.BinaryExpression;
    public BinaryExpression(Expression left, Node operatorToken, Expression right)
    {
        Left = left;
        OperatorToken = operatorToken;
        Right = right;
    }
}