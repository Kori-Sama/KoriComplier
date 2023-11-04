using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoriComplier;

public enum ErrorType {
    SyntaxError
}

public class Error {
    public ErrorType Type { get; }
    public int Line { get; }
    public string Message { get; }

    public Error(ErrorType type, int line, string message) {
        Type = type;
        Line = line;
        Message = message;
    }
    public void Report() {
        Console.Error.WriteLine($"{Type}: {Message} in line {Line}");
    }
}
