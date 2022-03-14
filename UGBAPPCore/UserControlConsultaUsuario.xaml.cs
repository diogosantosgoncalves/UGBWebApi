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
    public partial class UserControlConsultaUsuario : UserControl
    {
        AppDbContext dbSqlServer = new AppDbContext();
        string buscaUsuario = string.Empty;
        public UserControlConsultaUsuario()
        {
            InitializeComponent();
            dtgr_ConsultaUsuario.Items.Clear();
            dtgr_ConsultaUsuario.Items.Refresh();
        }

        private void bt_ConsultaUsuario_Click(object sender, RoutedEventArgs e) => consultarUsuario();

        public void consultarUsuario()
        {
            buscaUsuario = txtUsuario.Text;
            AppDbContext dbSqlServer = new AppDbContext();
            dtgr_ConsultaUsuario.ItemsSource = dbSqlServer.Usuarios.Where(i => i.Nome.Contains(buscaUsuario)).ToList();
        }

        private void btEditarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();
            AppDbContext dbSqlServer = new AppDbContext();
            usuario = dbSqlServer.Usuarios.FirstOrDefault(i => i.Id.Equals(PegarCodigo()));

            UserControlMenuItem.testeTela(new UserControlCadastroUsuarios(usuario));
        }

        public int PegarCodigo()
        {
            var selectedItem = dtgr_ConsultaUsuario.SelectedItem.ToString();
            Type t = dtgr_ConsultaUsuario.SelectedItem.GetType();
            System.Reflection.PropertyInfo[] props = t.GetProperties();
            string propertyValue = props[0].GetValue(dtgr_ConsultaUsuario.SelectedItem, null).ToString();
            return int.Parse(propertyValue);
        }

        private void btExcluirUsuario_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = (Usuario)dtgr_ConsultaUsuario.SelectedItem;
            dbSqlServer.Usuarios.Attach(usuario);
            dbSqlServer.Usuarios.Remove(usuario);
            dbSqlServer.SaveChanges();

            consultarUsuario();
        }
    }
}
