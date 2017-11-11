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
            if(checaPalavra(boxDescricao.Text) == false)
                MessageBox.Show("Por favor prencha todos os campos corretamente.\nNão use caracteres especiais como: '#', '%' e ':'.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                Servico serv = new Servico(boxDescricao.Text, Convert.ToDateTime(servicoCalendar.SelectedDate));
                janelaAnterior.adicionar_servico_arquivo(serv.ToString());
                janelaAnterior.listar_servico(pessoa, serv.ToString());
                this.Close();
            }            
        }

        private bool checaPalavra(string checa)
        {
            int value;
            foreach (char c in checa)
            {
                value = Convert.ToInt32(c);
                if (value == 35 || value == 37 || value == 58)
                    return false;
            
            }
            return true;
        }
    }
}
