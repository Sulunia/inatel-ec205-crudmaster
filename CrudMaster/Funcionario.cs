using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudMaster
{
    class Funcionario
    {
        string nome { get; set; }
        string senha { get; set; } //Nunca jamais de forma alguma salve sua senha como string!
                                   //Masssss... Dessa vez, só dessa vez!... A gente deixa passar.

        public Funcionario(string nome, string senha)
        {
            this.nome = nome;
            this.senha = senha; //Meu deus, que horrível
        }
    }

}
