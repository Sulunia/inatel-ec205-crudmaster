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
    /// Lógica interna para funcionarioWindow.xaml
    /// </summary>
    public partial class funcionarioWindow : Window
    {
        public funcionarioWindow()
        {
            InitializeComponent();
        }

        private void buttonCadastra_Click(object sender, RoutedEventArgs e)
        {
            detalhesFuncionario detFunc = new detalhesFuncionario();
            detFunc.Show();
        }
    }
}
