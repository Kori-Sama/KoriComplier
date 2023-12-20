namespace ComplierTest;

public class UnitTest_Lexer
{
    [Fact]
    public void Test_Tokenize()
    {
        var code = @"let num_one = 114514;
                     let num_two = 1919810;
                     func add(a, b) {
                        return a + b;
                     }
                     var sum = add(num_one,num_two);";

        var tokensExpect = new List<Token>()
        {
            new Token(TokenType.Let,"let",null),
            new Token(TokenType.Name,"num_one",null),
            new Token(TokenType.Equal,"=",null),
            new Token(TokenType.Integer,"114514",114514),
            new Token(TokenType.Semicolon,";",null),
            new Token(TokenType.Let,"let",null),
            new Token(TokenType.Name,"num_two",null),
            new Token(TokenType.Equal,"=",null),
            new Token(TokenType.Integer,"1919810",1919810),
            new Token(TokenType.Semicolon,";",null),
            new Token(TokenType.Function,"func",null),
            new Token(TokenType.Name,"add",null),
            new Token(TokenType.LeftParen,"(",null),
            new Token(TokenType.Name,"a",null),
            new Token(TokenType.Comma,",",null),
            new Token(TokenType.Name,"b",null),
            new Token(TokenType.RightParen,")",null),
            new Token(TokenType.LeftBrace,"{",null),
            new Token(TokenType.Return,"return",null),
            new Token(TokenType.Name,"a",null),
            new Token(TokenType.Plus,"+",null),
            new Token(TokenType.Name,"b",null),
            new Token(TokenType.Semicolon,";",null),
            new Token(TokenType.RightBrace,"}",null),
            // new Token(TokenType.Semicolon,";",null),
            new Token(TokenType.Var,"var",null),
            new Token(TokenType.Name,"sum",null),
            new Token(TokenType.Equal,"=",null),
            new Token(TokenType.Name,"add",null),
            new Token(TokenType.LeftParen,"(",null),
            new Token(TokenType.Name,"num_one",null),
            new Token(TokenType.Comma,",",null),
            new Token(TokenType.Name,"num_two",null),
            new Token(TokenType.RightParen,")",null),
            new Token(TokenType.Semicolon,";",null),
            new Token(TokenType.EOF,"\0",null),
        };

        var tokens = Lexer.GetTokens(code);

        Assert.Equal(tokensExpect.Count(), tokens.Count());

        for (var i = 0; i < tokensExpect.Count(); i++)
        {
            Assert.Equal(tokensExpect[i], tokens[i]);
        }

    }
    [Fact]
    public void Test_Peek()
    {
        var code = @"1 <= 2;
                     2 >= 1;                                   
                     1 == 1;
                     1 != 2;";
        var tokensExpect = new List<Token>() {
            new Token(TokenType.Integer,"1",1),
            new Token(TokenType.LessEqual,"<=",null),
            new Token(TokenType.Integer,"2",2),
            new Token(TokenType.Semicolon,";",null),
            new Token(TokenType.Integer,"2",2),
            new Token(TokenType.GreaterEqual,">=",null),
            new Token(TokenType.Integer,"1",1),
            new Token(TokenType.Semicolon,";",null),
            new Token(TokenType.Integer,"1",1),
            new Token(TokenType.EqualEqual,"==",null),
            new Token(TokenType.Integer,"1",1),
            new Token(TokenType.Semicolon,";",null),
            new Token(TokenType.Integer,"1",1),
            new Token(TokenType.BangEqual,"!=",null),
            new Token(TokenType.Integer,"2",2),
            new Token(TokenType.Semicolon,";",null),
            new Token(TokenType.EOF,"\0",null),
        };
        var tokens = Lexer.GetTokens(code);

        Assert.Equal(tokensExpect.Count(), tokens.Count());

        for (var i = 0; i < tokensExpect.Count(); i++)
        {
            Assert.Equal(tokensExpect[i], tokens[i]);
        }
    }
    [Fact]
    public void Test_String() {
        var code = "let str = \"This is a string;\";";
        var tokens = Lexer.GetTokens(code);
        var tokensExpect = new List<Token>() {
            new Token(TokenType.Let,"let",null),
            new Token(TokenType.Name,"str",null),
            new Token(TokenType.Equal,"=",null),
            new Token(TokenType.String,"This is a string;","This is a string;"),
            new Token(TokenType.Semicolon,";",null),
            new Token(TokenType.EOF,"\0",null),
        };
        
        Assert.Equal(tokensExpect.Count(), tokens.Count());

        for (var i = 0; i < tokensExpect.Count(); i++)
        {
            Assert.Equal(tokensExpect[i], tokens[i]);
        }
    }
}
