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
        //Membros =========================================
        private Funcionario p;
        funcionarioWindow janAnterior;

        //Construtores ====================================
        public detalhesFuncionario(funcionarioWindow e)
        {
            InitializeComponent();
            p = new Funcionario();
            janAnterior = e;
        }

        //Métodos =========================================
        private void cadastra_funcionario(object sender, RoutedEventArgs e)
        {
            p.nome = boxNome.Text;
            p.senha = boxSenha.Text;
            p.username = boxLogin.Text;
            DAO.cadastrar_funcionario(p);
            MessageBox.Show("Cadastrado com sucesso.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            janAnterior.listar_funcionarios();
            this.Close();
            
        }

        private void voltar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
