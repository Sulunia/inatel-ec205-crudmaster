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
    /// Lógica interna para detalhesFuncionario.xaml
    /// </summary>
    public partial class detalhesFuncionario : Window
    {
        private Funcionario p;

        public detalhesFuncionario()
        {
            InitializeComponent();
            p = new Funcionario();
        }

        private void buttonSalvar_Click(object sender, RoutedEventArgs e)
        {
            p.nome = boxNome.Text;
            p.senha = boxSenha.Text;
            p.username = boxLogin.Text;
            var saveString = p.ToString();
            Debug.WriteLine(saveString);
        }
    }
}
