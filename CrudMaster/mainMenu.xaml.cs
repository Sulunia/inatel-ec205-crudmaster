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
    /// Interaction logic for mainMenu.xaml
    /// </summary>
    public partial class mainMenu : Window
    {
        public mainMenu()
        {
            InitializeComponent();
        }

        private void buttonPessoas_Click(object sender, RoutedEventArgs e)
        {
            clienteMain clienteWin = new CrudMaster.clienteMain();
            clienteWin.Show();
            MainMenu.Close();
            
        }

        private void buttonProdutos_Click(object sender, RoutedEventArgs e)
        {
            produtoMain produtoWin = new CrudMaster.produtoMain();
            MainMenu.Close();
            produtoWin.Show();
        }
    }
}
