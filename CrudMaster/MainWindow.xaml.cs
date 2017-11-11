﻿using System;
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
        public MainWindow()
        {
            InitializeComponent();
            DAO.initialize();
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
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
                mainMenu menu = new CrudMaster.mainMenu();
                menu.Show();
                loginScreen.Close();
            }
        }

    }
}
