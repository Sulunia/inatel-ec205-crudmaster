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
    /// Lógica interna para detalhesProduto.xaml
    /// </summary>
    public partial class detalhesProduto : Window
    {
        private List<int> numbers; 

        public detalhesProduto()
        {
            InitializeComponent();

            //Adiciona números a lista de combo box
            numbers = new List<int>();
            for (int i = 0; i <= 300; i++)
            {
                numbers.Add(i);
            }
            comboNum.ItemsSource = numbers;
        }

        private void buttonCancela_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
