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
        }

        private void produtoWin_Closed(object sender, EventArgs e)
        {
            mainMenu menu = new CrudMaster.mainMenu();
            menu.Show();
        }
    }
}
