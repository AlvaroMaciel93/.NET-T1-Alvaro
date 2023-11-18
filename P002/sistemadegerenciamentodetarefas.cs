using System;
using System.Collections.Generic;
using System.Linq;

class GerenciadorTarefas
{
    class Tarefa
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool EstaCompleta { get; set; }
    }

    private List<Tarefa> tarefas;

    public GerenciadorTarefas()
    {
        tarefas = new List<Tarefa>();
    }

    public void CriarTarefa(string titulo, string descricao, DateTime dataVencimento)
    {
        Tarefa novaTarefa = new Tarefa
        {
            Titulo = titulo,
            Descricao = descricao,
            DataVencimento = dataVencimento,
            EstaCompleta = false
        };

        tarefas.Add(novaTarefa);
        Console.WriteLine("Tarefa criada com sucesso!");
    }

    public void ListarTodasTarefas()
    {
        Console.WriteLine("Lista de tarefas:");
        foreach (var tarefa in tarefas)
        {
            Console.WriteLine($"Título: {tarefa.Titulo} | Descrição: {tarefa.Descricao} | Data de vencimento: {tarefa.DataVencimento} | Concluída: {(tarefa.EstaCompleta ? "Sim" : "Não")}");
        }
    }

    public void MarcarTarefaComoCompleta(int indiceTarefa)
    {
        if (indiceTarefa >= 0 && indiceTarefa < tarefas.Count)
        {
            tarefas[indiceTarefa].EstaCompleta = true;
            Console.WriteLine("Tarefa marcada como concluída!");
        }
        else
        {
            Console.WriteLine("Índice de tarefa inválido.");
        }
    }

    public void ListarTarefasPendentes()
    {
        var tarefasPendentes = tarefas.Where(tarefa => !tarefa.EstaCompleta).ToList();
        Console.WriteLine("Tarefas pendentes:");
        foreach (var tarefa in tarefasPendentes)
        {
            Console.WriteLine($"Título: {tarefa.Titulo} | Descrição: {tarefa.Descricao} | Data de vencimento: {tarefa.DataVencimento}");
        }
    }

    public void ListarTarefasConcluidas()
    {
        var tarefasConcluidas = tarefas.Where(tarefa => tarefa.EstaCompleta).ToList();
        Console.WriteLine("Tarefas concluídas:");
        foreach (var tarefa in tarefasConcluidas)
        {
            Console.WriteLine($"Título: {tarefa.Titulo} | Descrição: {tarefa.Descricao} | Data de vencimento: {tarefa.DataVencimento}");
        }
    }

    public void ExcluirTarefa(int indiceTarefa)
    {
        if (indiceTarefa >= 0 && indiceTarefa < tarefas.Count)
        {
            tarefas.RemoveAt(indiceTarefa);
            Console.WriteLine("Tarefa excluída com sucesso!");
        }
        else
        {
            Console.WriteLine("Índice de tarefa inválido.");
        }
    }

    public void PesquisarTarefas(string palavraChave)
    {
        var tarefasEncontradas = tarefas.Where(tarefa =>
            tarefa.Titulo.Contains(palavraChave, StringComparison.OrdinalIgnoreCase) ||
            tarefa.Descricao.Contains(palavraChave, StringComparison.OrdinalIgnoreCase)
        ).ToList();

        Console.WriteLine($"Tarefas encontradas para '{palavraChave}':");
        foreach (var tarefa in tarefasEncontradas)
        {
            Console.WriteLine($"Título: {tarefa.Titulo} | Descrição: {tarefa.Descricao} | Data de vencimento: {tarefa.DataVencimento}");
        }
    }

    public void ExibirEstatisticas()
    {
        int quantidadeTarefasConcluidas = tarefas.Count(tarefa => tarefa.EstaCompleta);
        int quantidadeTarefasPendentes = tarefas.Count(tarefa => !tarefa.EstaCompleta);

        Tarefa tarefaMaisAntiga = tarefas.OrderBy(tarefa => tarefa.DataVencimento).FirstOrDefault();
        Tarefa tarefaMaisRecente = tarefas.OrderByDescending(tarefa => tarefa.DataVencimento).FirstOrDefault();

        Console.WriteLine($"Número de tarefas concluídas: {quantidadeTarefasConcluidas}");
        Console.WriteLine($"Número de tarefas pendentes: {quantidadeTarefasPendentes}");
        Console.WriteLine($"Tarefa mais antiga: {tarefaMaisAntiga?.Titulo ?? "N/A"}");
        Console.WriteLine($"Tarefa mais recente: {tarefaMaisRecente?.Titulo ?? "N/A"}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        GerenciadorTarefas gerenciador = new GerenciadorTarefas();

        while (true)
        {
            Console.WriteLine("\n===== Gerenciador de Tarefas =====");
            Console.WriteLine("1 - Criar Tarefa");
            Console.WriteLine("2 - Listar Todas as Tarefas");
            Console.WriteLine("3 - Marcar Tarefa como Concluída");
            Console.WriteLine("4 - Listar Tarefas Pendentes");
            Console.WriteLine("5 - Listar Tarefas Concluídas");
            Console.WriteLine("6 - Excluir Tarefa");
            Console.WriteLine("7 - Pesquisar Tarefas por Palavra-chave");
            Console.WriteLine("8 - Exibir Estatísticas");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("===================================");

            Console.Write("Escolha uma opção: ");
            int opcao;
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                continue;
            }

            switch (opcao)
            {
                case 0:
                    Console.WriteLine("Saindo do programa...");
                    return;
                case 1:
                    Console.Write("Digite o título da tarefa: ");
                    string titulo = Console.ReadLine();
                    Console.Write("Digite a descrição da tarefa: ");
                    string descricao = Console.ReadLine();
                    Console.Write("Digite a data de vencimento da tarefa (Formato: dd/MM/yyyy HH:mm:ss): ");
                    if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime dataVencimento))
                    {
                        gerenciador.CriarTarefa(titulo, descricao, dataVencimento);
                    }
                    else
                    {
                        Console.WriteLine("Data inválida. Certifique-se de usar o formato correto.");
                    }
                    break;
                case 2:
                    gerenciador.ListarTodasTarefas();
                    break;
                case 3:
                    Console.Write("Digite o índice da tarefa a ser marcada como concluída: ");
                    if (int.TryParse(Console.ReadLine(), out int indiceCompleta))
                    {
                        gerenciador.MarcarTarefaComoCompleta(indiceCompleta);
                    }
                    else
                    {
                        Console.WriteLine("Índice inválido.");
                    }
                    break;
                case 4:
                    gerenciador.ListarTarefasPendentes();
                    break;
                case 5:
                    gerenciador.ListarTarefasConcluidas();
                    break;
                case 6:
                    Console.Write("Digite o índice da tarefa a ser excluída: ");
                    if (int.TryParse(Console.ReadLine(), out int indiceExclui))
                    {
                        gerenciador.ExcluirTarefa(indiceExclui);
                    }
                    else
                    {
                        Console.WriteLine("Índice inválido.");
                    }
                    break;
                case 7:
                    Console.Write("Digite a palavra-chave para pesquisa: ");
                    string chavePesquisa = Console.ReadLine();
                    gerenciador.PesquisarTarefas(chavePesquisa);
                    break;
                case 8:
                    gerenciador.ExibirEstatisticas();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    break;
            }
        }
    }
}
