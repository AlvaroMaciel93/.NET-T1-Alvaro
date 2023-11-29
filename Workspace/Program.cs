#region POGDEV

using System;
using System.Collections.Generic;
using System.Linq;

//Sistema de Gerenciamento de Consultório

public class Program {
    public static void Main(string[] args){
        class Medico {
            public string Nome { get; set; }
            public string DataNascimento { get; set; }
            public int CPF { get; set; }
            public string CRM { get; set; }
        }
        class Paciente {
            public string Nome { get; set; }
            public string DataNascimento { get; set; }
            public int CPF { get; set; }
            public string Sexo { get; set; }
            public string Sintomas { get; set; }
        }
         // Coleções para armazenar Médicos e Pacientes
        List<Medico> medicos = new List<Medico>();
        List<Paciente> pacientes = new List<Paciente>();

        // Métodos para validação de CPF único
        bool ValidarCPFMedico(int cpf) {
            return !medicos.Any(m => m.CPF == cpf);
        }

        bool ValidarCPFPaciente(int cpf) {
            return !pacientes.Any(p => p.CPF == cpf);
        }

        //Método para cadastrar médico
        void AdicionarMedico(string nome, string dataNascimento, int cpf, string crm) {
            if (ValidarCPFMedico (cpf)){
                medicos.Add(new Medico {
                    Nome = nome, DataNascimento = dataNascimento, CPF = cpf, CRM = crm});
                    Console.WriteLine("Médico adicionado com sucesso!");
            }
            else {
                throw new Exception("CPF já cadastrado para outro médico.");
            }
        }
        //Método para cadastrar paciente
        void AdicionarPaciente(string nome, string datadenasc, int cpf, string sexo, string sintomas) {
            if (ValidarCPFMedico (cpf)){
                pacientes.Add(new Paciente {
                    Nome = nome, DataNascimento = datadenasc, CPF = cpf, Sexo = sexo, Sintomas = sintomas});
                    Console.WriteLine("Paciente adicionado com sucesso!");
                }
            else {
                throw new Exception("CPF já cadastrado para outro paciente.");
            }
        }
        // Consultas LINQ para relatórios
        void RelatorioMedicosEntreIdades(List<Medico> medicos, int idadeMinima, int idadeMaxima) {
            var medicosEntreIdades = medicos.Where(m => (DateTime.Now.Year - m.DataNascimento.Year) >= idadeMinima && (DateTime.Now.Year - m.DataNascimento.Year) <= idadeMaxima).ToList();
            foreach (var medico in medicosEntreIdades){
                Console.WriteLine($"Médico: {medico.Nome}, Idade: {DateTime.Now.Year - medico.DataNascimento.Year}");
            }
        }
        void RelatorioPacientesEntreIdades(List<Paciente> pacientes, int idadeMinima, int idadeMaxima){
            var pacientesEntreIdades = pacientes.Where(m => (DateTime.Now.Year - m.DataNascimento.Year) >= idadeMinima && (DateTime.Now.Year - m.DataNascimento.Year) <= idadeMaxima).ToList();
            foreach (var paciente in pacientesEntreIdades) {
                Console.WriteLine($"Paciente: {paciente.Nome}, Idade: {DateTime.Now.Year - paciente.DataNascimento.Year}");
            }
        }
        void RelatorioPacientesPorSexo(List<Paciente> pacientes, string sexo) {
            var pacientesPorSexo = pacientes.Where(p => p.Sexo.ToLower() == sexo.ToLower()).ToList();
            foreach (var paciente in pacientesPorSexo) {
                Console.WriteLine($"Paciente: {paciente.Nome}, Sexo: {paciente.Sexo}");
            }
        }

        void RelatorioPacientesOrdemAlfabetica(List<Paciente> pacientes){
            var pacientesOrdenados = pacientes.OrderBy(p => p.Nome).ToList();
            foreach (var paciente in pacientesOrdenados) {
                Console.WriteLine($"Paciente: {paciente.Nome}");
            }
        }

        void RelatorioPacientesPorSintomas(List<Paciente> pacientes, string textoSintomas) {
            var pacientesComSintomas = pacientes.Where(p => p.Sintomas.ToLower().Contains(textoSintomas.ToLower())).ToList();
            foreach (var paciente in pacientesComSintomas) {
                Console.WriteLine($"Paciente: {paciente.Nome}, Sintomas: {paciente.Sintomas}");
            }
        }
        void RelatorioAniversariantesDoMes(int mes, List<Medico> medicos, List<Paciente> pacientes) {
            var aniversariantes = medicos.Where(m => m.DataNascimento.Month == mes).Union(pacientes.Where(p => p.DataNascimento.Month == mes)).ToList();
            foreach (var pessoa in aniversariantes) {
                if (pessoa is Medico) {
                    var medico = (Medico)pessoa;
                    Console.WriteLine($"Médico aniversariante do mês {mes}: {medico.Nome}");
                }
                else if (pessoa is Paciente) {
                    var paciente = (Paciente)pessoa;
                    Console.WriteLine($"Paciente aniversariante do mês {mes}: {paciente.Nome}");
                }
            }
        }
    }
}

#endregion
