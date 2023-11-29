using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciamentoEstoque
{
    class Program
    {
        // Definição da classe representando um produto
        public class Produto
        {
            public int Codigo { get; set; }
            public string Nome { get; set; }
            public int Quantidade { get; set; }
            public double Preco { get; set; }

            public Produto(int codigo, string nome, int quantidade, double preco)
            {
                Codigo = codigo;
                Nome = nome;
                Quantidade = quantidade;
                Preco = preco;
            }
        }

        // Lista para armazenar os produtos em estoque
        static List<Produto> estoque = new List<Produto>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1 - Cadastrar Produto");
                Console.WriteLine("2 - Consultar Produto por Código");
                Console.WriteLine("3 - Atualizar Estoque");
                Console.WriteLine("4 - Gerar Relatórios");
                Console.WriteLine("5 - Sair");

                Console.Write("Escolha uma opção: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarProduto();
                        break;
                    case 2:
                        ConsultarProduto();
                        break;
                    case 3:
                        AtualizarEstoque();
                        break;
                    case 4:
                        GerarRelatorios();
                        break;
                    case 5:
                        Console.WriteLine("Saindo do sistema...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void CadastrarProduto()
        {
            try
            {
                Console.WriteLine("Digite o código do produto:");
                int codigo = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o nome do produto:");
                string nome = Console.ReadLine();

                Console.WriteLine("Digite a quantidade em estoque:");
                int quantidade = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o preço unitário:");
                double preco = double.Parse(Console.ReadLine());

                Produto novoProduto = new Produto(codigo, nome, quantidade, preco);
                estoque.Add(novoProduto);

                Console.WriteLine("Produto cadastrado com sucesso!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: entrada inválida.");
            }
        }

        static void ConsultarProduto()
        {
            Console.WriteLine("Digite o código do produto para consulta:");
            int codigoConsulta = int.Parse(Console.ReadLine());

            var produto = estoque.FirstOrDefault(p => p.Codigo == codigoConsulta);

            if (produto != null)
            {
                Console.WriteLine($"Produto encontrado: {produto.Nome}, Quantidade: {produto.Quantidade}, Preço: {produto.Preco:C}");
            }
            else
            {
                Console.WriteLine("Produto não encontrado!");
            }
        }

        static void AtualizarEstoque()
        {
            Console.WriteLine("Digite o código do produto para atualização de estoque:");
            int codigoAtualizacao = int.Parse(Console.ReadLine());

            var produto = estoque.FirstOrDefault(p => p.Codigo == codigoAtualizacao);

            if (produto != null)
            {
                Console.WriteLine($"Produto: {produto.Nome}, Quantidade atual: {produto.Quantidade}");

                Console.WriteLine("Digite a quantidade de entrada (+) ou saída (-):");
                int quantidadeAtualizacao = int.Parse(Console.ReadLine());

                if (produto.Quantidade + quantidadeAtualizacao < 0)
                {
                    Console.WriteLine("Operação inválida. Quantidade em estoque não pode ser negativa.");
                }
                else
                {
                    produto.Quantidade += quantidadeAtualizacao;
                    Console.WriteLine("Estoque atualizado com sucesso!");
                }
            }
            else
            {
                Console.WriteLine("Produto não encontrado!");
            }
        }

        static void GerarRelatorios()
        {
            Console.WriteLine("1 - Lista de produtos com quantidade abaixo de um limite");
            Console.WriteLine("2 - Lista de produtos com valor entre mínimo e máximo");
            Console.WriteLine("3 - Valor total do estoque e valor total de cada produto");

            Console.Write("Escolha uma opção de relatório: ");
            int opcaoRelatorio = int.Parse(Console.ReadLine());

            switch (opcaoRelatorio)
            {
                case 1:
                    Console.WriteLine("Digite o limite de quantidade:");
                    int limite = int.Parse(Console.ReadLine());

                    var produtosAbaixoLimite = estoque.Where(p => p.Quantidade < limite);
                    Console.WriteLine("Produtos com quantidade abaixo do limite:");
                    foreach (var produto in produtosAbaixoLimite)
                    {
                        Console.WriteLine($"{produto.Nome}, Quantidade: {produto.Quantidade}, Preço: {produto.Preco:C}");
                    }
                    break;
                case 2:
                    Console.WriteLine("Digite o valor mínimo:");
                    double minimo = double.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o valor máximo:");
                    double maximo = double.Parse(Console.ReadLine());

                    var produtosEntreValores = estoque.Where(p => p.Preco >= minimo && p.Preco <= maximo);
                    Console.WriteLine("Produtos com valor entre mínimo e máximo:");
                    foreach (var produto in produtosEntreValores)
                    {
                        Console.WriteLine($"{produto.Nome}, Preço: {produto.Preco:C}");
                    }
                    break;
                case 3:
                    double valorTotalEstoque = estoque.Sum(p => p.Quantidade * p.Preco);
                    Console.WriteLine($"Valor total do estoque: {valorTotalEstoque:C}");

                    Console.WriteLine("Valor total de cada produto:");
                    foreach (var produto in estoque)
                    {
                        double valorTotalProduto = produto.Quantidade * produto.Preco;
                        Console.WriteLine($"{produto.Nome}, Valor Total: {valorTotalProduto:C}");
                    }
                    break;
                default:
                    Console.WriteLine("Opção de relatório inválida.");
                    break;
            }
        }
    }
}