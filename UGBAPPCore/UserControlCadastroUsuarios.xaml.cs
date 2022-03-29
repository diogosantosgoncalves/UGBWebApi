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
    public partial class UserControlCadastroUsuarios : UserControl
    {
        AppDbContext dbSqlServer = new AppDbContext();
        public UserControlCadastroUsuarios()
        {
            InitializeComponent();
            bStatus.Content = string.Empty;
            bStatus.Visibility = Visibility.Collapsed;
            clearUsuario();
        }

        public UserControlCadastroUsuarios(Usuario usuario)
        {
            InitializeComponent();
            fillUsuario(usuario);
        }

        public void clearUsuario()
        {
            txtCodigo.Text = "0";
            txtNome.Text = string.Empty;
            txtSenha.Text = string.Empty;
            chkAdministrador.IsChecked = false;
        }

        public void fillUsuario(Usuario usuario)
        {
            txtCodigo.Text = usuario.Id.ToString();
            txtNome.Text = usuario.Nome;
            txtSenha.Text = usuario.Senha;
            chkAdministrador.IsChecked = usuario.Administrador;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario.Id = int.Parse(txtCodigo.Text);
            usuario.Nome = txtNome.Text;
            usuario.Senha = txtSenha.Text;
            usuario.Administrador = chkAdministrador.IsChecked.Value;

            dbSqlServer.Usuarios.Add(usuario);

            if (usuario.Id == 0)
                dbSqlServer.SaveChanges();
            else
            {
                dbSqlServer.Usuarios.Attach(usuario);
                dbSqlServer.Update(usuario);
                dbSqlServer.Entry(usuario).Property(u => u.Nome).IsModified = true;
                //dbSqlServer.Usuarios.mod
                dbSqlServer.Entry(usuario).CurrentValues.SetValues(usuario);
                dbSqlServer.SaveChanges();
                UserControlMenuItem.testeTela(new UserControlConsultaUsuario());
            }

            txtCodigo.Text = usuario.Id.ToString();

            bStatus.Content = "Cadastrado com sucesso!";
            bStatus.Visibility = Visibility.Visible;
        }
    }
}
