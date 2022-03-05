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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Setores setores = new Setores();

            setores.Id = int.Parse(txtCodigo.Text);
            setores.Nome = txtNome.Text;
            setores.HorasProducao = decimal.Parse(txtHorasProducao.Text);

            dbSqlServer.Setores2.Add(setores);

            if (setores.Id == 0)
            {
                dbSqlServer.SaveChanges();
            }
            else
                dbSqlServer.Update(setores);
        }
    }
}
