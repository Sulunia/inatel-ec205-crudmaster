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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CrudMaster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool foundLogin = false;
        public MainWindow()
        {
            InitializeComponent();
            DAO.initialize();
            foundLogin = false;
        }

        private void loginSubmit(object sender, RoutedEventArgs e)
        {
            //Verifica se o login existe:
            if (String.Equals(usernameBox.Text, "admin") && String.Equals(passwordInput.Password.ToString(), "crudmaster"))
            {
                funcionarioWindow funcWin = new CrudMaster.funcionarioWindow();
                funcWin.Show();
                loginScreen.Close();
            }
            else
            {
                foreach (Funcionario item in DAO.funcionarioLista)
                {
                    if(String.Equals(item.username, usernameBox.Text))
                    {
                        if(String.Equals(item.senha, passwordInput.Password.ToString()))
                        {
                            mainMenu menu = new CrudMaster.mainMenu(item.nome);
                            menu.Show();
                            this.Close();
                            foundLogin = true;
                            break;
                        }
                    }
                }
                if (!foundLogin)
                {
                    MessageBox.Show("Login ou senha digitados incorretamente!", "Erro ao fazer login", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

    }
}
