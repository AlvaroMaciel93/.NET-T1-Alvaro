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
    }
}