using APPTCCUGB;
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

namespace UGBAPPCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var menuRegister = new List<SubItem>();
            menuRegister.Add(new SubItem("Cadastro", new UserControlCadastroUsuarios()));
            menuRegister.Add(new SubItem("Consulta", new UserControlConsultaUsuario()));
            var item6 = new ItemMenu("Usuários", menuRegister, PackIconKind.Register);

            var menuSchedule = new List<SubItem>();
            menuSchedule.Add(new SubItem("Cadastro", new UserControlCadastroProdutos()));
            menuSchedule.Add(new SubItem("Consulta", new UserControlConsultaProduto()));
            var item1 = new ItemMenu("Produtos", menuSchedule, PackIconKind.Factory);

            var menuReports = new List<SubItem>();
            menuReports.Add(new SubItem("Customers"));
            menuReports.Add(new SubItem("Providers"));
            menuReports.Add(new SubItem("Products"));
            menuReports.Add(new SubItem("Stock"));
            menuReports.Add(new SubItem("Sales"));
            var item2 = new ItemMenu("Relatórios", menuReports, PackIconKind.FileReport);

            var menuExpenses = new List<SubItem>();
            menuExpenses.Add(new SubItem("Cadastro", new UserControlCadastroTurnos()));
            menuExpenses.Add(new SubItem("Consulta", new UserControlConsultaTurno()));
            var item3 = new ItemMenu("Turno", menuExpenses, PackIconKind.Schedule);

            var menuFinancial = new List<SubItem>();
            menuFinancial.Add(new SubItem("Cadastro", new UserControlCadastroSetor()));
            menuFinancial.Add(new SubItem("Consulta", new UserControlConsultaSetor()));
            var item4 = new ItemMenu("Setor", menuFinancial, PackIconKind.AccountGroup);

            Menu.Children.Add(new UserControlMenuItem(item6, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
            Menu.Children.Add(new UserControlMenuItem(item3, this));
            Menu.Children.Add(new UserControlMenuItem(item4, this));
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

        public static void teste()
        {
            Class1 teste = new Class1();
            ClassStantard teste4 = new ClassStantard();

        }
    }
}
