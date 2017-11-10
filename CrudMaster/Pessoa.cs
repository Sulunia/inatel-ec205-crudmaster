using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudMaster
{
    public class Pessoa
    {
        public string nome { get; set; }  //Nota rápida para iniciantes em C#
        public string telefone { get; set; }    //Getters e setters triviais podem ser implementados dessa forma! 
        public string endereço { get; set; }
        public string email { get; set; } = "---"; //E nesse caso ele ja vem com um valor padrão
        public string cpf { get; set; }
        public List<Servico> servicos { get; set; }

        public Pessoa(string nome, string telefone, string cpf, string endereço, string email, List<Servico> s)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.endereço = endereço;
            this.email = email;
            this.cpf = cpf;
            this.servicos = s;
        }

        public override string ToString()
        {
            string result = this.nome + ":" + this.endereço + ":" + this.telefone + ":" + this.cpf + ":" + this.email;
            return result;
        }

    }
}
