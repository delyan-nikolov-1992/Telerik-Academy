using System;

public struct Token
{
    public string value;
    public TokenType type;
    public int precedence;
    public bool isLeftToRight;

    public Token(string value, TokenType type, int precedence = int.MinValue, bool isLeftToRight = true)
    {
        this.value = value;
        this.type = type;
        this.precedence = precedence;
        this.isLeftToRight = isLeftToRight;
    }
}