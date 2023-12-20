using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoriComplier;

public class App
{
    private readonly string[] args;
    public App(string[] args)
    {
        this.args = args;
    }
    public void Run()
    {
        if (args.Length > 1)
        {
            Console.WriteLine("Invalid parameter");
            return;
        }
        else if (args.Length == 1)
            RunFile(args[0]);
        else
            RunPrompt();
    }
    private void RunPrompt()
    {
        Console.WriteLine("[Script Mode]");
        while (true)
        {
            Console.Write("> "); var line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line)) return;
            var tokens = Lexer.GetTokens(line);
            foreach (var token in tokens)
            {
                if (token.Type != TokenType.EOF)
                    Console.WriteLine(token);
            }
        }
    }
    private static void RunFile(string text) { throw new NotImplementedException(); }
}