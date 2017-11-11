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
    /// Lógica interna para funcionarioWindow.xaml
    /// </summary>
    public partial class funcionarioWindow : Window
    {
        public funcionarioWindow()
        {
            InitializeComponent();
            listarFuncionarios();
        }

        private void buttonCadastra_Click(object sender, RoutedEventArgs e)
        {
            detalhesFuncionario detFunc = new detalhesFuncionario(this);
            detFunc.Show();

        }

        public void listarFuncionarios()
        {
            funcView.SelectionMode = SelectionMode.Single;
            funcView.Items.Clear();
            foreach (Funcionario e in DAO.funcionarioLista)
            {
                var row = new { Nome = e.nome, Login = e.username };
                funcView.Items.Add(row);
            }
        }

        private void funcWin_Closed(object sender, EventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
        }

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            if (funcView.SelectedIndex != -1)
            {
                MessageBoxResult result = MessageBox.Show("Deseja mesmo remover o funcionário selecionado?", "Atenção", MessageBoxButton.OKCancel, MessageBoxImage.Asterisk);
                if (result == MessageBoxResult.OK)
                {
                    var index = funcView.SelectedIndex;
                    DAO.excluir_funcionario(DAO.funcionarioLista[index]);
                    listarFuncionarios();
                }
            }
        }
    }
}
