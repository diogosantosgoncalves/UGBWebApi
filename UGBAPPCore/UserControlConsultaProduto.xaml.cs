using APPTCCUGB.Context;
using APPTCCUGB.Models;
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
using UGBAPPCore;

namespace APPTCCUGB
{
    /// <summary>
    /// Interação lógica para UserControlProviders.xam
    /// </summary>
    public partial class UserControlConsultaProduto : UserControl
    {
        AppDbContext dbSqlServer = new AppDbContext();
        string buscaProduto = string.Empty;
        public UserControlConsultaProduto()
        {
            InitializeComponent();
        }

        private void bt_ConsultarProduto_Click(object sender, RoutedEventArgs e) => consultarProduto();

        public void consultarProduto()
        {
            buscaProduto = txt_nomeUsuario.Text;
            dtgr_ConsultaUsuario.ItemsSource = dbSqlServer.Produtos.Where(i => i.Nome.Contains(buscaProduto)).ToList();
        }

        private void btEditarProduto_Click(object sender, RoutedEventArgs e)
        {
            Produto produto = new Produto();
            produto = dbSqlServer.Produtos.FirstOrDefault(i => i.Id.Equals(PegarCodigo()));

            UserControlMenuItem.testeTela(new UserControlCadastroProdutos(produto));
        }


        public int PegarCodigo()
        {
            var selectedItem = dtgr_ConsultaUsuario.SelectedItem.ToString();
            Type t = dtgr_ConsultaUsuario.SelectedItem.GetType();
            System.Reflection.PropertyInfo[] props = t.GetProperties();
            string propertyValue = props[0].GetValue(dtgr_ConsultaUsuario.SelectedItem, null).ToString();
            return int.Parse(propertyValue);
        }

        private void btExcluirProduto_Click(object sender, RoutedEventArgs e)
        {
            Produto produto = (Produto)dtgr_ConsultaUsuario.SelectedItem;
            dbSqlServer.Produtos.Attach(produto);
            dbSqlServer.Produtos.Remove(produto);
            dbSqlServer.SaveChanges();

            consultarProduto();
        }
    }
}
