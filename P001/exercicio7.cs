using System;
class CondicaoV {
    static void Main() {
        bool condicao1 = true;
        bool condicao2 = false;

        if (condicao1 && condicao2) {
            Console.WriteLine("Ambas as condições são verdadeiras.");
        }
        else {
            Console.WriteLine("Pelo menos uma das condições é falsa.");
        }
    }
}
