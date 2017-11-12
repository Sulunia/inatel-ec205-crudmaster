using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudMaster
{
    public class Produto
    {
        public string nome { get; set; }
        public int quantidade { get; set; }
        public string preco { get; set; }
        public string fabricante { get; set; }

        public Produto(string nome, int quantidade, string preco, string fabricante)
        {
            this.nome = nome;
            this.quantidade = quantidade;
            this.preco = preco;
            this.fabricante = fabricante;
        }
        public override string ToString()
        {
            string result = $"{nome}/{quantidade}/{preco}/{fabricante}";
            return result;
        }
    }
}
