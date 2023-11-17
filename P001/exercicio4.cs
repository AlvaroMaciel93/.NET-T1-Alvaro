using System;

class Calc {

    static void Main() {
        int x = 10;
        int y = 3;
        int soma, subt, mult;
        double div;
        
        soma = x + y;
        subt = x - y;
        mult = x * y;
        div = x / y;

        Console.WriteLine($"Soma: {soma}");
        Console.WriteLine($"Subtração: {subt}");
        Console.WriteLine($"Multiplicação: {mult}");
        Console.WriteLine($"Divisão: {div}");
    }
}