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
using System.Windows.Shapes;

namespace CrudMaster
{
    /// <summary>
    /// Lógica interna para clienteMain.xaml
    /// </summary>
    public partial class clienteMain : Window
    {
        //Construtores ============================
        public clienteMain()
        {
            InitializeComponent();
            listar_clientes();
        }

        //Métodos =================================
        private void window_close(object sender, EventArgs e)
        {
            mainMenu menu = new CrudMaster.mainMenu();
            menu.Show();
        }

        public void listar_clientes()
        {
            listaClientes.Items.Clear();
            listaClientes.SelectionMode = SelectionMode.Single;
            foreach (Pessoa p in DAO.pessoaLista)
            {
                var row = new { Nome = p.nome.ToUpper(), Telefone = p.telefone, Endereco = p.endereço };
                listaClientes.Items.Add(row);
            }
        }

        private void cadastrar_clientes(object sender, RoutedEventArgs e)
        {
            detalhesCliente clientWin = new CrudMaster.detalhesCliente(this);
            clientWin.Show();
        }

        private void editar_clientes(object sender, RoutedEventArgs e)
        {
            if(listaClientes.SelectedItem != null)
            {
                detalhesCliente clientWin = new CrudMaster.detalhesCliente(this, DAO.pessoaLista[listaClientes.SelectedIndex], listaClientes.SelectedIndex);
                clientWin.Show();
            }
        }
            
    }
}
