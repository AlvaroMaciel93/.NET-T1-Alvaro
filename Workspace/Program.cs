#region POGDEV
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    class Medico
    {
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public int CPF { get; set; }
        public string CRM { get; set; }
    }

    class Paciente
    {
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public int CPF { get; set; }
        public string Sexo { get; set; }
        public string Sintomas { get; set; }
    }

    static List<Medico> medicos = new List<Medico>();
    static List<Paciente> pacientes = new List<Paciente>();

    static bool ValidarCPFMedico(int cpf)
    {
        return !medicos.Any(m => m.CPF == cpf);
    }

    static bool ValidarCPFPaciente(int cpf)
    {
        return !pacientes.Any(p => p.CPF == cpf);
    }

    static void AdicionarMedico(string nome, string dataNascimento, int cpf, string crm)
    {
        if (ValidarCPFMedico(cpf))
        {
            medicos.Add(new Medico
            {
                Nome = nome,
                DataNascimento = dataNascimento,
                CPF = cpf,
                CRM = crm
            });
            Console.WriteLine("Médico adicionado com sucesso!");
        }
        else
        {
            throw new Exception("CPF já cadastrado para outro médico.");
        }
    }

    static void AdicionarPaciente(string nome, string datadenasc, int cpf, string sexo, string sintomas)
    {
        if (ValidarCPFPaciente(cpf))
        {
            pacientes.Add(new Paciente
            {
                Nome = nome,
                DataNascimento = datadenasc,
                CPF = cpf,
                Sexo = sexo,
                Sintomas = sintomas
            });
            Console.WriteLine("Paciente adicionado com sucesso!");
        }
        else
        {
            throw new Exception("CPF já cadastrado para outro paciente.");
        }
    }

    static void RelatorioMedicosEntreIdades(List<Medico> medicos, int idadeMinima, int idadeMaxima)
    {
        var medicosEntreIdades = medicos.Where(m => (DateTime.Now.Year - int.Parse(m.DataNascimento.Split('/')[0])) >= idadeMinima && (DateTime.Now.Year - int.Parse(m.DataNascimento.Split('/')[0])) <= idadeMaxima).ToList();
        foreach (var medico in medicosEntreIdades)
        {
            Console.WriteLine($"Médico: {medico.Nome}, Idade: {DateTime.Now.Year - int.Parse(medico.DataNascimento.Split('/')[0])}");
        }
    }

    static void RelatorioPacientesPorSexo(List<Paciente> pacientes, string sexo)
    {
        var pacientesPorSexo = pacientes.Where(p => p.Sexo.ToLower() == sexo.ToLower()).ToList();
        foreach (var paciente in pacientesPorSexo)
        {
            Console.WriteLine($"Paciente: {paciente.Nome}, Sexo: {paciente.Sexo}");
        }
    }

    static void RelatorioPacientesOrdemAlfabetica()
    {
        var pacientesOrdenados = pacientes.OrderBy(p => p.Nome).ToList();
        foreach (var paciente in pacientesOrdenados)
        {
            Console.WriteLine($"Paciente: {paciente.Nome}");
        }
    }

    static void RelatorioPacientesPorSintomas(List<Paciente> pacientes, string textoSintomas)
    {
        var pacientesComSintomas = pacientes.Where(p => p.Sintomas.ToLower().Contains(textoSintomas.ToLower())).ToList();
        foreach (var paciente in pacientesComSintomas)
        {
            Console.WriteLine($"Paciente: {paciente.Nome}, Sintomas: {paciente.Sintomas}");
        }
    }

    static void RelatorioAniversariantesDoMes(int mes, List<Medico> medicos, List<Paciente> pacientes)
{
    var medicosAniversariantes = medicos.Where(m => int.Parse(m.DataNascimento.Split('/')[1]) == mes).ToList();
    var pacientesAniversariantes = pacientes.Where(p => int.Parse(p.DataNascimento.Split('/')[1]) == mes).ToList();

    Console.WriteLine($"Aniversariantes do Mês {mes}:");

    foreach (var medico in medicosAniversariantes)
    {
        Console.WriteLine($"Médico aniversariante: {medico.Nome}");
    }

    foreach (var paciente in pacientesAniversariantes)
    {
        Console.WriteLine($"Paciente aniversariante: {paciente.Nome}");
    }
}

    static void MenuPrincipal()
    {
        while (true)
        {
            Console.WriteLine("\n=== Menu Principal ===");
            Console.WriteLine("1. Adicionar Médico");
            Console.WriteLine("2. Adicionar Paciente");
            Console.WriteLine("3. Relatório de Médicos por Idade");
            Console.WriteLine("4. Relatório de Pacientes por Sexo");
            Console.WriteLine("5. Relatório de Pacientes em Ordem Alfabética");
            Console.WriteLine("6. Relatório de Pacientes por Sintomas");
            Console.WriteLine("7. Relatório de Aniversariantes do Mês");
            Console.WriteLine("8. Sair");

            Console.Write("\nEscolha uma opção: ");
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    Console.Write("Nome do Médico: ");
                    string nomeMedico = Console.ReadLine();

                    Console.Write("Data de Nascimento (yyyy/mm/dd): ");
                    string dataNascimentoMedico = Console.ReadLine();

                    Console.Write("CPF do Médico: ");
                    int cpfMedico = int.Parse(Console.ReadLine());

                    Console.Write("CRM do Médico: ");
                    string crmMedico = Console.ReadLine();

                    try
                    {
                        AdicionarMedico(nomeMedico, dataNascimentoMedico, cpfMedico, crmMedico);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao adicionar médico: {ex.Message}");
                    }
                    break;

                case "2":
                    Console.Write("Nome do Paciente: ");
                    string nomePaciente = Console.ReadLine();

                    Console.Write("Data de Nascimento (yyyy/mm/dd): ");
                    string dataNascimentoPaciente = Console.ReadLine();

                    Console.Write("CPF do Paciente: ");
                    int cpfPaciente = int.Parse(Console.ReadLine());

                    Console.Write("Sexo do Paciente: ");
                    string sexoPaciente = Console.ReadLine();

                    Console.Write("Sintomas do Paciente: ");
                    string sintomasPaciente = Console.ReadLine();

                    try
                    {
                        AdicionarPaciente(nomePaciente, dataNascimentoPaciente, cpfPaciente, sexoPaciente, sintomasPaciente);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao adicionar paciente: {ex.Message}");
                    }
                    break;

                case "3":
                    Console.Write("Idade mínima: ");
                    int idadeMinima = int.Parse(Console.ReadLine());

                    Console.Write("Idade máxima: ");
                    int idadeMaxima = int.Parse(Console.ReadLine());

                    RelatorioMedicosEntreIdades(medicos, idadeMinima, idadeMaxima);
                    break;

                case "4":
                    Console.Write("Informe o sexo para o relatório de pacientes (Masculino/Feminino): ");
                    string sexoParaRelatorio = Console.ReadLine();
                    RelatorioPacientesPorSexo(pacientes, sexoParaRelatorio);
                    break;

                case "5":
                    RelatorioPacientesOrdemAlfabetica();
                    break;

                case "6":
                    Console.Write("Informe os sintomas para o relatório de pacientes: ");
                    string sintomasParaRelatorio = Console.ReadLine();
                    RelatorioPacientesPorSintomas(pacientes, sintomasParaRelatorio);
                    break;

                case "7":
                    Console.Write("Informe o mês para o relatório de aniversariantes: ");
                    int mesParaRelatorio = int.Parse(Console.ReadLine());
                    RelatorioAniversariantesDoMes(mesParaRelatorio, medicos, pacientes);
                    break;

                case "8":
                    Console.WriteLine("Encerrando o programa.");
                    return;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void Main()
    {
        MenuPrincipal();
    }
}
#endregion 
