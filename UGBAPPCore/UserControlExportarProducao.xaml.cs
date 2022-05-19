using APPTCCUGB.Context;
using APPTCCUGB.Models;
using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.Style;
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
            //List<Producao> listProducao = dbSqlServer.Producoes.ToList();
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs";
            //if (saveFileDialog.ShowDialog() == true)
            //{
            //    using (StreamWriter sw = File.CreateText(saveFileDialog.FileName))
            //    {
            //        foreach (Producao producao in listProducao)
            //        {
            //            sw.WriteLine($"{producao.Id};{producao.IndiceDisponibilidade};{producao.IndicePerfomance};{producao.IndiceQualidade};{producao.Resultado};");
            //        }
            //    }
            //    MessageBox.Show("Quantidade de paradas: " + listProducao.Count.ToString());
            //}
            exportarPlanilhaExcel();
        }

        private void exportarPlanilhaExcel()
        {
            string caminhoPlanilha = @"c:\Dados\TestePlanilha.xlsx";

            criarPlanilhaExcel(caminhoPlanilha);
            abrirPlanilhaExcel(caminhoPlanilha);
        }

        private void criarPlanilhaExcel(string caminho)
        {

            //var listProducoes = new List<Producao> { new Producao { Id = 1, IndiceDisponibilidade = 100, IndicePerfomance = 100},
            //                                         new Producao { Id = 2, IndiceDisponibilidade = 200, IndicePerfomance = 200},
            //                                        new Producao  { Id= 3, IndiceDisponibilidade = 300, IndicePerfomance = 200}};

            // define a licença
            // cria instância do ExcelPackage
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();

            // nome da planilha
            var workSheet = excel.Workbook.Worksheets.Add("PlanilhaProducao");

            // define propriedades da planilha
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            // define propriedades da primeira linha
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            // define o cabeçalho da planilha(base 1)
            workSheet.Cells[1, 1].Value = "Data";
            workSheet.Cells[1, 2].Value = "Indice Disponibilidade";
            workSheet.Cells[1, 3].Value = "Indice Performance";

            workSheet.Cells["A1:C1"].Style.Font.Italic = true;

            // inclui dados na planilha
            // inicia na segunda linha
            int indice = 2;

            List<Producao> listProducao = dbSqlServer.Producoes.ToList();
            List<Parada> listParadas = dbSqlServer.Paradas.ToList();

            //var query = listProducao.Join(listParadas, producao => producao.Id, parada => parada.CodigoProducao, (producao, parada) => new
            //{
            //    IdProducao = producao.Id,
            //    DataProducao = producao.Data,
            //    QtdeParada = parada.DiferencaParadaMinutos,
            //    Disponibilidade = producao.IndiceDisponibilidade,
            //}
            //).GroupBy(i => i.IdProducao);

            //var query = listProducao.GroupJoin(listParadas, producao => producao.Id, parada => parada.CodigoProducao, (producao, parada) => new {Producao = producao, Parada = parada.DefaultIfEmpty()})
            //    .SelectMany(producaoFinal => producaoFinal.Producao, (producaoFinal, parada) => new
            //{

            //    IdProducao = producao.Id,
            //    DataProducao = producao.Data,
            //    QtdeParada = parada.ho,
            //    Disponibilidade = producao.IndiceDisponibilidade,
            //};

            var applicantList = (from producao in dbSqlServer.Producoes
                                 join parada in dbSqlServer.Paradas
                                 on producao.Id equals parada.CodigoProducao into output
                                 from j in output.DefaultIfEmpty()
                                 select new { APPLICANT_ID = producao.Id, Applicant_Name = (j == null ? producao.QtdeProduzida : j.DiferencaParadaMinutos) }).Take(1000).AsEnumerable();

            applicantList.Any();



            var query3 = listProducao.GroupJoin(listParadas,
            usr => usr.Id, ex => ex.CodigoProducao,
            (usr, ex) => new { Usr = usr, Ex = ex.DefaultIfEmpty() })
            .SelectMany(final => final.Ex,
                (final, ex) => new
                {
                    IdProducao = final.Usr.Id,
                    DataProducao = final.Usr.Data,
                    QtdeParada = ex.DiferencaParadaMinutos,
                    // Uma forma de proteger do null, não testado.
                    Disponibilidade = ex != null ? final.Usr.IndiceDisponibilidade : 0
                }).ToList();

            query3.Any();


            foreach (var listProducaoJoin in query3)
            {
                //foreach(var producao in listProducaoJoin)
                //{
                    workSheet.Cells[indice, 1].Value = listProducaoJoin.DataProducao.ToString("d");
                workSheet.Cells[indice, 2].Value = 0;//listProducaoJoin.Sum(i => i.QtdeParada);
                workSheet.Cells[indice, 3].Value = 0; //listProducaoJoin.FirstOrDefault().Disponibilidade;
                    indice++;
                //}
            }

            // ajusta o tamanho da coluna
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();

            //se o arquivo existir excluir
            if (File.Exists(caminho))
                File.Delete(caminho);

            // Cria o arquivo excel no disco fisico
            FileStream fileStream = File.Create(caminho);
            fileStream.Close();

            // Escreve o conteudo para o arquivo excel
            File.WriteAllBytes(caminho, excel.GetAsByteArray());

            // fecha o arquivo excel
            excel.Dispose();

            MessageBox.Show("Planilha criada com sucesso!");
        }

        private void abrirPlanilhaExcel(string caminho)
        {

        }
    }
}
