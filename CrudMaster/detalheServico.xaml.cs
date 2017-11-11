using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CrudMaster
{
    /// <summary>
    /// Lógica interna para detalheServico.xaml
    /// </summary>
    public partial class detalheServico : Window
    {
        //Membros ==============================
        private detalhesCliente janelaAnterior;
        private Pessoa pessoa;

        //Construtores =========================
        public detalheServico(detalhesCliente w, Pessoa p)
        {
            InitializeComponent();
            servicoCalendar.SelectedDate = DateTime.Now;
            janelaAnterior = w;
            pessoa = p;
        }

        //Métodos ==============================
        private void voltar(object sender, RoutedEventArgs e)
        {
            detalheServicos.Close();
        }

        private void cadastrar_servico(object sender, RoutedEventArgs e)
        {
            Servico serv = new Servico(boxDescricao.Text, Convert.ToDateTime(servicoCalendar.SelectedDate));
            janelaAnterior.adicionar_servico_arquivo(serv.ToString());
            janelaAnterior.listaServico(pessoa, serv.ToString());
            this.Close();
        }
    }
}
