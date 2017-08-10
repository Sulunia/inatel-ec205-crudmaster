﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudMaster
{
    class Pessoa
    {
        private string nome { get; set; }  //Nota rápida para iniciantes em C#
        private int idade { get; set; }    //Getters e setters triviais podem ser implementados dessa forma! 
        private string endereço { get; set; }
        private string empresa { get; set; } = "---"; //E nesse caso ele ja vem com um valor padrão

        public Pessoa(string nome, int idade, string endereço)
        {
            this.nome = nome;
            this.idade = idade;
            this.endereço = endereço;
            Console.WriteLine("Sem empresa!");
        }

        public Pessoa(string nome, int idade, string endereço, string empresa)
        {
            this.nome = nome;
            this.idade = idade;
            this.endereço = endereço;
            this.empresa = empresa;
        }

    }
}
