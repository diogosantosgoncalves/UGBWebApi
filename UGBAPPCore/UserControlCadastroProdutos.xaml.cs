using APPTCCUGB.Context;
using APPTCCUGB.Models;
using System.Linq;
using System.Windows.Controls;

namespace APPTCCUGB
{
    /// <summary>
    /// Interação lógica para UserControlProviders.xam
    /// </summary>
    public partial class UserControlCadastroProdutos : UserControl
    {
        //private readonly AppDbContext _context;
        AppDbContext dbSqlServer = new AppDbContext();
        public UserControlCadastroProdutos()
        {
            InitializeComponent();
            bStatus.Visibility = System.Windows.Visibility.Collapsed;
            clearProduto();
        }

        public UserControlCadastroProdutos(Produto produto)
        {
            InitializeComponent();
            fillProduto(produto);
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

                // fill Produto
            }

            txtCodigo.Text = produto.Id.ToString();

            bStatus.Content = "Cadastrado com sucesso!";
            bStatus.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
