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
    public partial class UserControlCadastroSetor : UserControl
    {
        AppDbContext dbSqlServer = new AppDbContext();

        public UserControlCadastroSetor()
        {
            InitializeComponent();
            bStatus.Visibility = System.Windows.Visibility.Collapsed;
            clearSetor();
        }

        public UserControlCadastroSetor(Setor setor)
        {
            InitializeComponent();
            fillSetor(setor);
        }

        public void clearSetor()
        {
            txtCodigo.Text = "0";
            txtNome.Text =
                txtHorasProducao.Text = string.Empty;
        }

        public void fillSetor(Setor setor)
        {
            txtCodigo.Text = setor.Id.ToString();
            txtNome.Text = setor.Nome;
            txtHorasProducao.Text = setor.HorasProducao.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Setor setores = new Setor();

            setores.Id = int.Parse(txtCodigo.Text);
            setores.Nome = txtNome.Text;
            setores.HorasProducao = decimal.Parse(txtHorasProducao.Text);

            dbSqlServer.Setores.Add(setores);

            if (setores.Id == 0)
                dbSqlServer.SaveChanges();
            else
            {
                dbSqlServer.Setores.Attach(setores);
                dbSqlServer.Update(setores);
                dbSqlServer.SaveChanges();
                UserControlMenuItem.testeTela(new UserControlConsultaProduto());
            }

            txtCodigo.Text = setores.Id.ToString();

            bStatus.Content = "Cadastrado com sucesso!";
            bStatus.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
