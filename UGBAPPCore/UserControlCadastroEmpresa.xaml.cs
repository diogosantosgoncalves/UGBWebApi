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
using APPTCCUGB;
using APPTCCUGB.Context;
using APPTCCUGB.Models;

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

        public void clearProduto()
        {
            txtCodigo.Text = "0";
            txtNome.Text =
                txtQtdeEstimativa.Text =
                txtUnidade.Text = string.Empty;
        }

        public void fillProduto(Produto produto)
        {
            txtCodigo.Text = produto.Id.ToString();
            txtNome.Text = produto.Nome;
            txtQtdeEstimativa.Text = produto.QtdeEstimativa.ToString();
            txtUnidade.Text = produto.Qtde.ToString();
        }



        public static void Teste()
        {
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Produto produto = new Produto();

            produto.Id = int.Parse(txtCodigo.Text);

            produto.Nome = txtNome.Text;
            //produto.QtdeEstimativa = int.Parse(txtQtdeEstimativa.Text);

            dbSqlServer.Produtos.Add(produto);

            if (produto.Id == 0)
            {
                dbSqlServer.SaveChanges();
            }
            else
            {
                dbSqlServer.Produtos.Attach(produto);
                dbSqlServer.Update(produto);
                dbSqlServer.SaveChanges();
                UserControlMenuItem.testeTela(new UserControlConsultaProduto());
                // fill Produto
            }

            txtCodigo.Text = produto.Id.ToString();

            bStatus.Content = "Cadastrado com sucesso!";
            bStatus.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
