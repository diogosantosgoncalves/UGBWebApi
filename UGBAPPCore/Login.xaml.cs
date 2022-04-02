using APPTCCUGB.Context;
using APPTCCUGB.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interação lógica para Login.xam
    /// </summary>
    public partial class Login : Window
    {
        AppDbContext dbSqlServer = new AppDbContext();
        List<Empresa> listEmpresas = new List<Empresa>();
        public Login()
        {
            InitializeComponent();
            listEmpresas = dbSqlServer.Empresas.ToList();
            //comboEmpresas.ItemsSource = listEmpresas;
            //comboUsuarios.ItemsSource = dbSqlServer.Usuarios.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if ((Usuario)comboUsuarios.SelectedItem == null)
                //    throw new Exception("Selecione um usuario");
                //if ((Usuario)comboEmpresas.SelectedItem == null)
                //    throw new Exception("Selecione uma empresa");

                //Empresa empresaSelecionada = (Empresa)comboEmpresas.SelectedItem;
                //Usuario usuarioSelecionado = (Usuario)comboUsuarios.SelectedItem;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
