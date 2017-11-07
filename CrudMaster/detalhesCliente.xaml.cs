using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Lógica interna para detalheCliente.xaml
    /// </summary>
    public partial class detalhesCliente : Window
    {
        public detalhesCliente()
        {
            InitializeComponent();
        }

        private void adicionaServico_Click(object sender, RoutedEventArgs e)
        {
            detalheServico detalhe = new CrudMaster.detalheServico();
            detalhe.Show();
        }

        private void buttonCancelar_Click(object sender, RoutedEventArgs e)
        {
            detalheCliente.Close();
        }

        private void salvarButton_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(telefoneBox.Text, out int val))
            {
                DAO.addPessoa(new Pessoa(nomeBox.Text, Int32.Parse(telefoneBox.Text), CPFBox.Text, enderecoBox.Text));
            }
            else
            {
                Debug.WriteLine("Failed to create new cliente!");
            }
        }
    }
}
