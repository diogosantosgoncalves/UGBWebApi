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
    public partial class UserControlConsultaProducoes : UserControl
    {
        AppDbContext dbSqlServer = new AppDbContext();
        string numeroSequencia = string.Empty;
        public UserControlConsultaProducoes()
        {
            InitializeComponent();
            dtgr_ConsultaProducoes.Items.Clear();
            dtgr_ConsultaProducoes.Items.Refresh();
        }

        private void bt_ConsultarProducoes_Click(object sender, RoutedEventArgs e) => consultarProducoes();

        public void consultarProducoes()
        {
            numeroSequencia = txt_numeroSequencia.Text;
            AppDbContext dbSqlServer = new AppDbContext();
            dtgr_ConsultaProducoes.ItemsSource = dbSqlServer.Producoes.Where(i => i.Id.ToString().Contains(numeroSequencia)).ToList();
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
            var selectedItem = dtgr_ConsultaProducoes.SelectedItem.ToString();
            Type t = dtgr_ConsultaProducoes.SelectedItem.GetType();
            System.Reflection.PropertyInfo[] props = t.GetProperties();
            string propertyValue = props[0].GetValue(dtgr_ConsultaProducoes.SelectedItem, null).ToString();
            return int.Parse(propertyValue);
        }

        private void btExcluirProduto_Click(object sender, RoutedEventArgs e)
        {
            Producao producao = (Producao)dtgr_ConsultaProducoes.SelectedItem;
            dbSqlServer.Producoes.Attach(producao);
            dbSqlServer.Producoes.Remove(producao);
            dbSqlServer.SaveChanges();

            consultarProducoes();
        }

        private void btEditarProducao_Click(object sender, RoutedEventArgs e)
        {
            Producao producao = new Producao();
            AppDbContext dbSqlServer = new AppDbContext();
            producao = dbSqlServer.Producoes.FirstOrDefault(i => i.Id.Equals(PegarCodigo()));

            UserControlMenuItem.testeTela(new UserControlCadastroProducao(producao));
        }
    }
}
