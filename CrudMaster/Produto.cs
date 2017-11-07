using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudMaster
{
    class Produto
    {
        string nome { get; set; }
        int quantidade { get; set; }
        string preco { get; set; }
        string fabricante { get; set; }

        public Produto(string nome, int quantidade, string preco, string fabricante)
        {
            this.nome = nome;
            this.quantidade = quantidade;
            this.preco = preco;
            this.fabricante = fabricante;
        }
    }
}
