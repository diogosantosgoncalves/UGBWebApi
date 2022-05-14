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
    /// Interação lógica para UserControlExportarProducao.xam
    /// </summary>
    public partial class UserControlExportarProducao : UserControl
    {
        AppDbContext dbSqlServer = new AppDbContext();
        public UserControlExportarProducao()
        {
            InitializeComponent();
        }

        private void btnExportarProducao_Click(object sender, RoutedEventArgs e)
        {
            List<Producao> listProducao = dbSqlServer.Producoes.ToList();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs";
            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter sw = File.CreateText(saveFileDialog.FileName))
                {
                    foreach (Producao producao in listProducao)
                    {
                        sw.WriteLine($"{producao.Id};{producao.IndiceDisponibilidade};{producao.IndicePerfomance};{producao.IndiceQualidade};{producao.Resultado};");
                    }
                }
                MessageBox.Show("Quantidade de paradas: " + listProducao.Count.ToString());
            }
        }
    }
}
