using APPTCCUGB;
using APPTCCUGB.Models;
using APPTCCUGB.ViewModel;
using DalCore;
using DalStandard;
using MaterialDesignThemes.Wpf;
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
using UGBAPPCore.Models;

namespace UGBAPPCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(Empresa empresa = null, Usuario usuario = null)
        {
            InitializeComponent();

            lbNomeEmpresa.Content = empresa?.Nome;
            lbNomeUsuario.Content = usuario?.Nome;

            //var uriSource = new Uri(@"/WpfApplication1;component/Images/logo.png", UriKind.Relative);
            //imgLogo.Source = new BitmapImage(uriSource);

            //imgLogo.Source = logo;//new BitmapImage(new Uri(@"logo.png"));

            var menuRegister = new List<SubItem>();
            menuRegister.Add(new SubItem("Cadastro", new UserControlCadastroUsuarios()));
            menuRegister.Add(new SubItem("Consulta", new UserControlConsultaUsuario()));
            var TelaUsuario = new ItemMenu("Usuários", menuRegister, PackIconKind.Register);

            var menuSchedule = new List<SubItem>();
            menuSchedule.Add(new SubItem("Cadastro", new UserControlCadastroProdutos()));
            menuSchedule.Add(new SubItem("Consulta", new UserControlConsultaProduto()));
            var TelaProduto = new ItemMenu("Produtos", menuSchedule, PackIconKind.Factory);

            var menuExpenses = new List<SubItem>();
            menuExpenses.Add(new SubItem("Cadastro", new UserControlCadastroTurnos()));
            menuExpenses.Add(new SubItem("Consulta", new UserControlConsultaTurno()));
            var TelaTurno = new ItemMenu("Turno", menuExpenses, PackIconKind.Schedule);

            var menuFinancial = new List<SubItem>();
            menuFinancial.Add(new SubItem("Cadastro", new UserControlCadastroSetor()));
            menuFinancial.Add(new SubItem("Consulta", new UserControlConsultaSetor()));
            var TelaSetor = new ItemMenu("Setor", menuFinancial, PackIconKind.AccountGroup);

            var menuReports = new List<SubItem>();
            menuReports.Add(new SubItem("Customers"));
            menuReports.Add(new SubItem("Providers"));
            menuReports.Add(new SubItem("Products"));
            menuReports.Add(new SubItem("Stock"));
            menuReports.Add(new SubItem("Sales"));
            var TelaRelatorio = new ItemMenu("Relatórios", menuReports, PackIconKind.FileReport);

            var menuProducao = new List<SubItem>();
            menuProducao.Add(new SubItem("Consulta", new UserControlConsultaProducoes()));
            menuProducao.Add(new SubItem("Exportar", new UserControlExportarProducao()));
            var TelaProducao = new ItemMenu("Produções", menuProducao, PackIconKind.Register);

            var menuParada = new List<SubItem>();
            menuParada.Add(new SubItem("Consulta", new UserControlConsultaParadas()));
            menuParada.Add(new SubItem("Exportar", new UserControlExportarParadas()));
            var TelaParada = new ItemMenu("Paradas", menuParada, PackIconKind.Register);

            var menuPerdas = new List<SubItem>();
            menuPerdas.Add(new SubItem("Consulta", new UserControlConsultaPerdas()));
            menuPerdas.Add(new SubItem("Exportar", new UserControlExportarPerda()));
            var TelaPerdas = new ItemMenu("Perdas", menuPerdas, PackIconKind.Register);

            var menuEmpresa = new List<SubItem>();
            menuEmpresa.Add(new SubItem("Cadastro", new UserControlCadastroEmpresa()));
            menuEmpresa.Add(new SubItem("Consulta", new UserControlConsultaEmpresa()));
            var TelaEmpresa = new ItemMenu("Empresas", menuEmpresa, PackIconKind.Register);
            //Menu.Children.Add(new UserControlMenuItem(item2, this));

            Menu.Children.Add(new UserControlMenuItem(TelaEmpresa, this));
            Menu.Children.Add(new UserControlMenuItem(TelaUsuario, this));
            Menu.Children.Add(new UserControlMenuItem(TelaProduto, this));
            Menu.Children.Add(new UserControlMenuItem(TelaTurno, this));
            Menu.Children.Add(new UserControlMenuItem(TelaSetor, this));
            Menu.Children.Add(new UserControlMenuItem(TelaParada, this));
            Menu.Children.Add(new UserControlMenuItem(TelaPerdas, this));
            Menu.Children.Add(new UserControlMenuItem(TelaProducao, this));
        }

        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);

            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }

        public static void callEditTela(UserControl userControl)
        {
            StackPanel stackPanel = new StackPanel();

            var screen = userControl;

            stackPanel.Children.Clear();
            stackPanel.Children.Add(screen);
        }

        public void callEditTela2(UserControl userControl)
        {
            var screen = userControl;

            StackPanelMain.Children.Clear();
            StackPanelMain.Children.Add(screen);
        }
    }
}
