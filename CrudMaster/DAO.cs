using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudMaster
{
    class DAO
    {
        public static List<Pessoa> pessoaLista = new List<Pessoa>();
        public static List<Produto> produtoLista = new List<Produto>();
        public static List<Funcionario> funcionarioLista = new List<Funcionario>();

        public static void addPessoa(Pessoa p)
        {
            pessoaLista.Add(p);
            Debug.WriteLine("[DAO] Added new Pessoa to list.");
        }
      

    }
}
