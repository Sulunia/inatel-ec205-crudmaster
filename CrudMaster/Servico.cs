using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudMaster
{
    class Servico
    {
        string descricao { get; set; }
        DateTime previsao { get; set; }

        public Servico(string descricao, DateTime previsao)
        {
            this.descricao = descricao;
            this.previsao = previsao;
        }
    }
}
