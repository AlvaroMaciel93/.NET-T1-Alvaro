/*
Em C#, pode-se realizar a conversão de um tipo double para um tipo int usando cast.
Mas se a parte fracionária do número double não puder ser acomodada em um int,
a informação decimal resultará na perda da parte fracionária.
No exemplo abaixo, a variável numeroDouble possui o valor 13.75.
Quando convertido para int, a penas a parte inteira (13) será mantida e exibida. 
*/

using System;

class Conversao {
    static void Main() {
        double numeroDouble = 13.75;

        int numeroInteiro = (int)numeroDouble;

        Console.WriteLine($"Número double: {numeroDouble}");
        Console.WriteLine($"Número inteiro após conversão: {numeroInteiro}");
    }
}
