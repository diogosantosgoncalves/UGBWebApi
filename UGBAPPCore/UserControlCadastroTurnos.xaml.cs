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
    public partial class UserControlCadastroTurnos : UserControl
    {
        AppDbContext dbSqlServer = new AppDbContext();
        public UserControlCadastroTurnos()
        {
            InitializeComponent();
            bStatus.Visibility = System.Windows.Visibility.Collapsed;
            clearTurno();
        }

        public UserControlCadastroTurnos(Turno turno)
        {
            InitializeComponent();
            fillTurno(turno);
        }

        public void clearTurno()
        {
            txtCodigo.Text = "0";
            txtNome.Text =
                txtHorasProducao.Text = string.Empty;
        }

        public void fillTurno(Turno turno)
        {
            txtCodigo.Text = turno.Id.ToString();
            txtNome.Text = turno.Nome;
            txtHorasProducao.Text = turno.HorasProducao.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Turno turno = new Turno();

            turno.Id = int.Parse(txtCodigo.Text);
            turno.Nome = txtNome.Text;
            turno.HorasProducao = decimal.Parse(txtHorasProducao.Text);

            dbSqlServer.Turnos.Add(turno);

            if (turno.Id == 0)
                dbSqlServer.SaveChanges();
            else
            {
                dbSqlServer.Turnos.Attach(turno);
                dbSqlServer.Update(turno);
                dbSqlServer.SaveChanges();
                UserControlMenuItem.testeTela(new UserControlConsultaTurno());
            }

            txtCodigo.Text = turno.Id.ToString();
            btnNovo.Visibility = Visibility.Visible;
            btnCadastrar.Visibility = Visibility.Collapsed;
            bStatus.Content = "Cadastrado com sucesso!";
            bStatus.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            clearTurno();
            btnNovo.Visibility = Visibility.Hidden;
            btnCadastrar.Visibility = Visibility.Visible;
            bStatus.Content = string.Empty;
        }
    }
}
