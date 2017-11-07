using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudMaster
{
    class Pessoa
    {
        private string nome { get; set; }  //Nota rápida para iniciantes em C#
        private int telefone { get; set; }    //Getters e setters triviais podem ser implementados dessa forma! 
        private string endereço { get; set; }
        private string empresa { get; set; } = "---"; //E nesse caso ele ja vem com um valor padrão
        private string cpf { get; set; }
        private List<Servico> servicos; 

        public Pessoa(string nome, int telefone, string cpf, string endereço)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.endereço = endereço;
            this.cpf = cpf;
            Console.WriteLine("Sem empresa!");
            this.servicos = new List<Servico>();
        }

        public Pessoa(string nome, int telefone, string cpf, string endereço, string empresa)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.endereço = endereço;
            this.empresa = empresa;
            this.servicos = new List<Servico>();
        }


    }
}
