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
using UGBAPPCore.Models;

namespace UGBAPPCore
{
    /// <summary>
    /// Interação lógica para UserControlConsultaEmpresa.xam
    /// </summary>
    public partial class UserControlConsultaEmpresa : UserControl
    {
        AppDbContext dbSqlServer = new AppDbContext();
        string buscaEmpresa = string.Empty;
        public UserControlConsultaEmpresa()
        {
            InitializeComponent();
        }
        private void bt_ConsultarEmpresa_Click(object sender, RoutedEventArgs e) => consultarEmpresa();

        public void consultarEmpresa()
        {
            buscaEmpresa = txt_nomeEmpresa.Text;
            AppDbContext dbSqlServer = new AppDbContext();
            dtgr_ConsultaEmpresa.ItemsSource = dbSqlServer.Empresas.Where(i => i.Nome.Contains(buscaEmpresa)).ToList();
        }

        private void btEditarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            Empresa empresa = new Empresa();
            AppDbContext dbSqlServer = new AppDbContext();
            empresa = dbSqlServer.Empresas.FirstOrDefault(i => i.Id.Equals(PegarCodigo()));

            UserControlMenuItem.testeTela(new UserControlCadastroEmpresa(empresa));
        }


        public int PegarCodigo()
        {
            var selectedItem = dtgr_ConsultaEmpresa.SelectedItem.ToString();
            Type t = dtgr_ConsultaEmpresa.SelectedItem.GetType();
            System.Reflection.PropertyInfo[] props = t.GetProperties();
            string propertyValue = props[0].GetValue(dtgr_ConsultaEmpresa.SelectedItem, null).ToString();
            return int.Parse(propertyValue);
        }

        private void btExcluirEmpresa_Click(object sender, RoutedEventArgs e)
        {
            Empresa empresa = (Empresa)dtgr_ConsultaEmpresa.SelectedItem;
            dbSqlServer.Empresas.Attach(empresa);
            dbSqlServer.Empresas.Remove(empresa);
            dbSqlServer.SaveChanges();

            consultarEmpresa();
        }
    }
}
