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

namespace UGBAPPCore
{
    /// <summary>
    /// Interação lógica para UserControlCadastroProducao.xam
    /// </summary>
    public partial class UserControlCadastroProducao : UserControl
    {
        AppDbContext dbSqlServer = new AppDbContext();
        public UserControlCadastroProducao(Producao producao)
        {
            InitializeComponent();
            fillProducao(producao);
        }

        public void fillProducao(Producao producao)
        {
            txtCodigo.Text = producao.Id.ToString();
            txtIndiceDisponibilidade.Text = producao.IndiceDisponibilidade.ToString();
            txtIndicePerfomance.Text = producao.IndicePerfomance.ToString();
            txtIndiceQualidade.Text = producao.IndiceQualidade.ToString();
            txtResultado.Text = producao.Resultado.ToString();
            txtData.Text = producao.Data.ToString();
        }

        private void btnEditarProducao_Click(object sender, RoutedEventArgs e)
        {
            Producao producao = new Producao();

            producao.Id = int.Parse(txtCodigo.Text);

            producao.IndiceDisponibilidade = decimal.Parse(txtIndiceDisponibilidade.Text);
            producao.IndicePerfomance = decimal.Parse(txtIndicePerfomance.Text);
            producao.IndiceQualidade = decimal.Parse(txtIndiceQualidade.Text);
            producao.Resultado = decimal.Parse(txtResultado.Text);
            producao.Data = DateTime.Parse(txtData.Text);

            dbSqlServer.Producoes.Add(producao);

            dbSqlServer.Producoes.Attach(producao);
            dbSqlServer.Update(producao);
            dbSqlServer.SaveChanges();
            dbSqlServer.Dispose();

            bStatus.Content = "Atualizado com sucesso!";
            txtIndiceDisponibilidade.IsEnabled =
                txtIndicePerfomance.IsEnabled =
                txtIndiceQualidade.IsEnabled =
                txtResultado.IsEnabled =
                txtData.IsEnabled = false;

            bStatus.Visibility = Visibility.Visible;
            btnEditarProducao.Visibility = Visibility.Collapsed;
            btnVoltar.Visibility = Visibility.Visible;
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            UserControlMenuItem.testeTela(new UserControlConsultaProducoes());
        }
    }
}
