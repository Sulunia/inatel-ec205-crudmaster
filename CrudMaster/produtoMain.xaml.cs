using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica interna para produtoMain.xaml
    /// </summary>
    public partial class produtoMain : Window
    {
        //Construtores ==========================
        public produtoMain()
        {
            InitializeComponent();
            listar_produtos(this);
        }

        //Métodos ===============================
        private void window_close(object sender, EventArgs e)
        {
            mainMenu menu = new CrudMaster.mainMenu();
            menu.Show();
        }

        private void cadastrar_produto(object sender, RoutedEventArgs e)
        {
            detalhesProduto prod = new CrudMaster.detalhesProduto(this);
            prod.Show();
        }

        private void editar_produto(object sender, RoutedEventArgs e)
        {
            if (listaProduto.SelectedItem != null)
            {
                String prod = listaProduto.SelectedItem.ToString();

                int startPos = prod.LastIndexOf("Nome =") + "Nome =".Length + 1;
                int length = prod.IndexOf(",") - startPos;
                string sub = prod.Substring(startPos, length);

                startPos = prod.LastIndexOf("Quantidade =") + "Quantidade =".Length + 1;
                length = prod.IndexOf(", Preço") - startPos;
                string sub2 = prod.Substring(startPos, length);

                startPos = prod.LastIndexOf("Preço =") + "Preço =".Length + 1;
                length = prod.IndexOf(", Fabricante") - startPos;
                string sub3 = prod.Substring(startPos, length);

                startPos = prod.LastIndexOf("Fabricante =") + "Fabricante =".Length + 1;
                length = prod.IndexOf(" }") - startPos;
                string sub4 = prod.Substring(startPos, length);


                Produto p = new Produto(sub,int.Parse(sub2),sub3,sub4);

                detalhesProduto clientWin = new detalhesProduto(this, p, true);
                clientWin.Show();
            }
        }

        public void excluir_produto(object sender, RoutedEventArgs e)
        {
            if (listaProduto.SelectedItem != null)
            {
                String prod = listaProduto.SelectedItem.ToString();

                int startPos = prod.LastIndexOf("Nome =") + "Nome =".Length + 1;
                int length = prod.IndexOf(",") - startPos;
                string sub = prod.Substring(startPos, length);

                startPos = prod.LastIndexOf("Quantidade =") + "Quantidade =".Length + 1;
                length = prod.IndexOf(", Preço") - startPos;
                string sub2 = prod.Substring(startPos, length);

                startPos = prod.LastIndexOf("Preço =") + "Preço =".Length + 1;
                length = prod.IndexOf(", Fabricante") - startPos;
                string sub3 = prod.Substring(startPos, length);

                startPos = prod.LastIndexOf("Fabricante =") + "Fabricante =".Length + 1;
                length = prod.IndexOf(" }") - startPos;
                string sub4 = prod.Substring(startPos, length);

                Produto p2 = new Produto(sub, int.Parse(sub2), sub3, sub4);

                MessageBoxResult result = MessageBox.Show("Realmente deseja excluir esse produto?", "Excluir produto", MessageBoxButton.YesNo);
                if(result == MessageBoxResult.Yes)
                {
                    DAO.excluir_produto(p2);
                    this.listar_produtos(this); //Essa linha tho
                }                          
            }
        }

        public void listar_produtos(produtoMain pM)
        {
            pM.listaProduto.Items.Clear();
            StreamReader produtoFile = new StreamReader((DAO.path + @"\Produtos.txt"));
            string line;
            while ((line = produtoFile.ReadLine()) != null)
            {
                string[] parts = line.Split('/');
                var row = new { Nome = parts[0], Quantidade = parts[1], Preço = parts[2], Fabricante = parts[3] };
                pM.listaProduto.Items.Add(row);
            }
            produtoFile.Close();
        }

        //TODO: Remover método de listagem de produtos do DAO para cá.
    }
}
