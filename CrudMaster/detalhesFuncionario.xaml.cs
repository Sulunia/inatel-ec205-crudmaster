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
            if(checaPalavra(boxNome.Text, false) == false || checaPalavra(boxSenha.Text, true) == false || checaPalavra(boxLogin.Text, true) == false)
                MessageBox.Show("Por favor prencha todos os campos corretamente.\nNão use caracteres especiais como: '#', '%' e ':'.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                p.nome = boxNome.Text;
                p.senha = boxSenha.Text;
                p.username = boxLogin.Text;
                DAO.cadastrar_funcionario(p);
                MessageBox.Show("Cadastrado com sucesso.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                janAnterior.listar_funcionarios();
                this.Close();
            }           
        }

        private void voltar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool checaPalavra(string checa, bool aux)
        {
            int value;
            foreach (char c in checa)
            {
                if (aux == false)
                {
                    value = Convert.ToInt32(c);
                    if ((value < 65) || (value > 90))
                        if ((value < 97) || (value > 122))
                            return false;
                }
                else
                {
                    value = Convert.ToInt32(c);
                    if (value == 35 || value == 37 || value == 58)
                        return false;
                }
            }
            return true;
        }
    }
}
