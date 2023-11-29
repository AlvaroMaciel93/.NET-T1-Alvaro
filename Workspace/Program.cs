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
            public string CPF { get; set; }
            public string Sexo { get; set; }
            public string Sintomas { get; set; }
        }
         // Coleções para armazenar Médicos e Pacientes
        List<Medico> medicos = new List<Medico>();
        List<Paciente> pacientes = new List<Paciente>();

        // Métodos para validação de CPF único
        bool ValidarCPFMedico(string cpf)
        {
            return !medicos.Any(m => m.CPF == cpf);
        }

        bool ValidarCPFPaciente(string cpf)
        {
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
        void AdicionarPaciente(string nome, string datadenasc, int cpf, string sexo, string sintomas)

            }
        }
    }
}
