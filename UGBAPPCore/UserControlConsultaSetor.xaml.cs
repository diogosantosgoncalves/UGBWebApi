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

namespace APPTCCUGB
{
    /// <summary>
    /// Interação lógica para UserControlProviders.xam
    /// </summary>
    public partial class UserControlConsultaSetor : UserControl
    {
        AppDbContext dbSqlServer = new AppDbContext();
        string buscaSetor = string.Empty;
        public UserControlConsultaSetor()
        {
            InitializeComponent();
            dtgr_ConsultaSetor.Items.Clear();
            dtgr_ConsultaSetor.Items.Refresh();
        }

        private void bt_ConsultaSetor_Click(object sender, RoutedEventArgs e) => consultarSetor();

        public void consultarSetor()
        {
            buscaSetor = txtSetor.Text;
            AppDbContext dbSqlServer = new AppDbContext();
            dtgr_ConsultaSetor.ItemsSource = dbSqlServer.Setores.Where(i => i.Nome.Contains(buscaSetor)).ToList();
        }


        private void btEditarSetor_Click(object sender, RoutedEventArgs e)
        {
            Setor setor = new Setor();
            AppDbContext dbSqlServer = new AppDbContext();
            setor = dbSqlServer.Setores.FirstOrDefault(i => i.Id.Equals(PegarCodigo()));

            UserControlMenuItem.testeTela(new UserControlCadastroSetor(setor));
        }


        public int PegarCodigo()
        {
            var selectedItem = dtgr_ConsultaSetor.SelectedItem.ToString();
            Type t = dtgr_ConsultaSetor.SelectedItem.GetType();
            System.Reflection.PropertyInfo[] props = t.GetProperties();
            string propertyValue = props[0].GetValue(dtgr_ConsultaSetor.SelectedItem, null).ToString();
            return int.Parse(propertyValue);
        }

        private void btExcluirSetor_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = (Usuario)dtgr_ConsultaSetor.SelectedItem;
            dbSqlServer.Usuarios.Attach(usuario);
            dbSqlServer.Usuarios.Remove(usuario);
            dbSqlServer.SaveChanges();

            consultarSetor();
        }
    }
}
