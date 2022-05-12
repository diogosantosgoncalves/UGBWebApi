using APPTCCUGB;
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

namespace UGBAPPCore
{
    /// <summary>
    /// Interação lógica para UserControlConsultaParadas.xam
    /// </summary>
    public partial class UserControlConsultaParadas : UserControl
    {
        AppDbContext dbSqlServer = new AppDbContext();
        string buscaProduto = string.Empty;
        public UserControlConsultaParadas()
        {
            InitializeComponent();
        }
        private void bt_ConsultarProduto_Click(object sender, RoutedEventArgs e) => consultarProduto();

        public void consultarProduto()
        {
            buscaProduto = txt_nomeUsuario.Text;
            AppDbContext dbSqlServer = new AppDbContext();
            dtgr_ConsultaProduto.ItemsSource = dbSqlServer.Paradas.Where(i => i.Observacao.Contains(buscaProduto)).ToList();
        }

        private void btEditarProduto_Click(object sender, RoutedEventArgs e)
        {
            Produto produto = new Produto();
            AppDbContext dbSqlServer = new AppDbContext();
            produto = dbSqlServer.Produtos.FirstOrDefault(i => i.Id.Equals(PegarCodigo()));

            UserControlMenuItem.testeTela(new UserControlCadastroProdutos(produto));
        }


        public int PegarCodigo()
        {
            var selectedItem = dtgr_ConsultaProduto.SelectedItem.ToString();
            Type t = dtgr_ConsultaProduto.SelectedItem.GetType();
            System.Reflection.PropertyInfo[] props = t.GetProperties();
            string propertyValue = props[0].GetValue(dtgr_ConsultaProduto.SelectedItem, null).ToString();
            return int.Parse(propertyValue);
        }

        private void btExcluirProduto_Click(object sender, RoutedEventArgs e)
        {
            Produto produto = (Produto)dtgr_ConsultaProduto.SelectedItem;
            dbSqlServer.Produtos.Attach(produto);
            dbSqlServer.Produtos.Remove(produto);
            dbSqlServer.SaveChanges();

            consultarProduto();
        }
    }
}
