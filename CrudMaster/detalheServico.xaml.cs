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
        public detalheServico()
        {
            InitializeComponent();
        }

        private void buttonCancela_Click(object sender, RoutedEventArgs e)
        {
            detalheServicos.Close();
        }
    }
}
