using APPTCCUGB.Context;
using APPTCCUGB.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interação lógica para UserControlExportarParadas.xam
    /// </summary>
    public partial class UserControlExportarParadas : UserControl
    {
        AppDbContext dbSqlServer = new AppDbContext();
        public UserControlExportarParadas()
        {
            InitializeComponent();
        }

        private void btnExportarParada_Click(object sender, RoutedEventArgs e)
        {
            List<Parada> listParadas = dbSqlServer.Paradas.ToList();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs";
            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter sw = File.CreateText(saveFileDialog.FileName))
                {
                    foreach (Parada parada in listParadas)
                    {
                        sw.WriteLine($"{parada.Id};{parada.Observacao};{parada.HoraInicial};{parada.HoraFinal};");
                    }
                }
                MessageBox.Show("Quantidade de paradas: " + listParadas.Count.ToString());
            }
        }
    }
}
