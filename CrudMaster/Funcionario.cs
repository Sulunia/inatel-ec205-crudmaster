using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudMaster
{
    class Funcionario
    {
        public string nome { get; set; }
        public string senha { get; set; } //Nunca jamais de forma alguma salve sua senha como string!
                                          //Masssss... Dessa vez, só dessa vez!... A gente deixa passar.
        public string username { get; set; }

        public Funcionario(string nome, string senha, string username)
        {
            this.nome = nome;
            this.senha = senha; //Meu deus, que horrível
            this.username = username;
        }

        public Funcionario()
        {

        }

        public override string ToString()
        {
            string result = this.nome + ":" + this.senha + ":" + this.username ;
            return result;
        }
    }

}
