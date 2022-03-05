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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Turno turno = new Turno();

            turno.Id = int.Parse(txtCodigo.Text);
            turno.Nome = txtNome.Text;
            turno.Qtde = txtHorasProducao.Text;

            dbSqlServer.Turnos.Add(turno);

            if (turno.Id == 0)
            {
                dbSqlServer.SaveChanges();
            }
            else
                dbSqlServer.Update(turno);
        }
    }
}
