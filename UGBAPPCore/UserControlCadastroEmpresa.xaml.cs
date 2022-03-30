using APPTCCUGB;
using APPTCCUGB.Context;
using System.Windows;
using System.Windows.Controls;
using UGBAPPCore.Models;

namespace UGBAPPCore
{
    /// <summary>
    /// Interação lógica para UserControlCadastroEmpresa.xam
    /// </summary>
    public partial class UserControlCadastroEmpresa : UserControl
    {
        AppDbContext dbSqlServer = new AppDbContext();
        public UserControlCadastroEmpresa()
        {
            InitializeComponent();
        }

        public UserControlCadastroEmpresa(Empresa empresa)
        {
            InitializeComponent();
            fillEmpresa(empresa);
        }

        public void fillEmpresa(Empresa empresa)
        {
            txtCodigo.Text = empresa.Id.ToString();
            txtNome.Text = empresa.Nome;
        }

        public void clearEmpresa()
        {
            txtCodigo.Text = "0";
            txtNome.Text = string.Empty;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Empresa empresa = new Empresa();

            empresa.Id = int.Parse(txtCodigo.Text);
            empresa.Nome = txtNome.Text;

            dbSqlServer.Empresas.Add(empresa);

            if (empresa.Id == 0)
            {
                dbSqlServer.SaveChanges();
            }
            else
            {
                dbSqlServer.Empresas.Attach(empresa);
                dbSqlServer.Update(empresa);
                dbSqlServer.SaveChanges();
                UserControlMenuItem.testeTela(new UserControlConsultaEmpresa());
            }

            txtCodigo.Text = empresa.Id.ToString();
            btnNovo.Visibility = Visibility.Visible;
            btnCadastrar.Visibility = Visibility.Collapsed;
            bStatus.Content = "Cadastrado com sucesso!";
            bStatus.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            clearEmpresa();
            btnNovo.Visibility = Visibility.Hidden;
            btnCadastrar.Visibility = Visibility.Visible;
            bStatus.Content = string.Empty;
        }
    }
}
