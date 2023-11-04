using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoriComplier;

public class App {
    private readonly string[] args;
    public App(string[] args) {
        this.args = args;
    }
    public void run() {
        if (args.Length > 1) {
            Console.WriteLine("Invaild parameter");
            return;
        } else if (args.Length == 1) {
            RunFile(args[0]);
        } else {
            RunPrompt();
        }
    }
    private void RunPrompt() {
        Console.WriteLine("[Script Mode]");
        while (true) {
            Console.Write("> ");
            var line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
                return;
            var lexer = new Lexer(line);
            while (true) {
                var token = lexer.NextToken();
                if (token.Type == TokenType.EOF)
                    break;
                Console.Write($"type: {token.Type} literal: {token.Literal}");
                if (token.Value != null)
                    Console.Write($" value:{token.Value}");
                Console.WriteLine();
            }
        }
    }
    private void RunFile(string text) {
        throw new NotImplementedException();
    }
}