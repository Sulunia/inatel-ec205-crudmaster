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
        private detalhesCliente janelaAnterior;
        private Pessoa pessoa;

        public detalheServico(detalhesCliente w, Pessoa p)
        {
            InitializeComponent();
            servicoCalendar.SelectedDate = DateTime.Now;
            janelaAnterior = w;
            pessoa = p;
        }

        private void buttonCancela_Click(object sender, RoutedEventArgs e)
        {
            detalheServicos.Close();
        }

        private void buttonSalvar_Click(object sender, RoutedEventArgs e)
        {
            Servico serv = new Servico(boxDescricao.Text, Convert.ToDateTime(servicoCalendar.SelectedDate));
            janelaAnterior.addServicoToCliente(serv.ToString());
            janelaAnterior.listarServicos(pessoa, serv.ToString());
            this.Close();
        }
    }
}
