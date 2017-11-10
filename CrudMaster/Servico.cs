using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudMaster
{
    public class Servico
    {
        string descricao { get; set; }
        DateTime previsao { get; set; }

        public Servico(string descricao, DateTime previsao)
        {
            this.descricao = descricao;
            this.previsao = previsao;
        }

        public Servico(string content)
        {
            var splitted = content.Split(':');
            this.descricao = splitted[0];
            this.previsao = Convert.ToDateTime(splitted[1]);
        }

        public override string ToString()
        {
            string result = this.descricao + ":" + this.previsao.ToShortDateString();
            return result;
        }
    }
}
