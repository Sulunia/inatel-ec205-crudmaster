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
    /// Lógica interna para produtoMain.xaml
    /// </summary>
    public partial class produtoMain : Window
    {
        public produtoMain()
        {
            InitializeComponent();
            DAO.exibeProdutos(this);
        }

        private void produtoWin_Closed(object sender, EventArgs e)
        {
            mainMenu menu = new CrudMaster.mainMenu();
            menu.Show();
        }

        private void buttonCadastro_Click(object sender, RoutedEventArgs e)
        {
            detalhesProduto prod = new CrudMaster.detalhesProduto(this);
            prod.Show();
        }

        private void buttonEdita_Click(object sender, RoutedEventArgs e)
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

        private void buttonExclui_Click(object sender, RoutedEventArgs e)
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
                    DAO.excluiProduto(p2);
                    DAO.exibeProdutos(this);
                }                          
            }
        }
    }
}
