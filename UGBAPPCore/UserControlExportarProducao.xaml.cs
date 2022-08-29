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
            try
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
            catch (Exception)
            {
                throw;
            }
        }

        private void exportarPlanilhaExcel()
        {
            string caminhoPlanilha = @"c:\Dados\TestePlanilha.xlsx";

            criarPlanilhaExcel(caminhoPlanilha);
            abrirPlanilhaExcel(caminhoPlanilha);
        }

        private void criarPlanilhaExcel(string caminho)
        {
            try
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
                criarPlanilhaProducao(excel);//var workSheet2 = excel.Workbook.Worksheets.Add("Producao");
                criarPlanilhaParadas(excel);//var workSheet3 = excel.Workbook.Worksheets.Add("Parada");
                criarPlanilhaPerdas(excel);//var workSheet4 = excel.Workbook.Worksheets.Add("Perda");

                // define propriedades da planilha
                workSheet.TabColor = System.Drawing.Color.Black;
                workSheet.DefaultRowHeight = 12;

                // define propriedades da primeira linha
                workSheet.Row(1).Height = 20;
                workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(1).Style.Font.Bold = true;

                // define o cabeçalho da planilha(base 1)
                workSheet.Cells[1, 1].Value = "Data";  //A
                workSheet.Cells[1, 2].Value = "Turno"; //B
                workSheet.Cells[1, 3].Value = "Tempo Planejado(min)"; //C
                workSheet.Cells[1, 4].Value = "Tempo Parada(min)"; //D
                workSheet.Cells[1, 5].Value = "Produção Prevista(ton)"; //E
                workSheet.Cells[1, 6].Value = "Tempo de Ciclo Padrão"; //F
                workSheet.Cells[1, 7].Value = "Produção Realizada"; //G
                workSheet.Cells[1, 8].Value = "Perdas(ton)"; //H
                workSheet.Cells[1, 9].Value = "Disponibilidade"; // I
                workSheet.Cells[1, 10].Value = "Performance"; //J
                workSheet.Cells[1, 11].Value = "Qualidade"; //K
                workSheet.Cells[1, 12].Value = "Resultado"; // L

                workSheet.Cells["A1:C1"].Style.Font.Italic = true;

                // inclui dados na planilha
                // inicia na segunda linha
                int indice = 2;

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

                //var testeSubSelect = from producao in dbSqlServer.Producoes
                //                     select new
                //                     {
                //                         Paradas = (from parada in dbSqlServer.Paradas.Where(i => i.CodigoProducao.Equals(producao.Id))
                //                                    select parada.DiferencaParadaMinutos),
                //                         Perdas = from perda in dbSqlServer.Perdas.Where(i => i.CodigoProducao.Equals(producao.Id))
                //                                  select perda.Qtde
                //                     }.Perdas;
                //var queryGroupMax =
                //    (from producao in dbSqlServer.Producoes
                //    group producao by producao.Id into producaoGroup
                //    select new
                //    {
                //        Level = producaoGroup.Key,
                //        HighestScore = (from parada in dbSqlServer.Paradas where producaoGroup.Any(i => i.Id.Equals(parada.CodigoProducao)) select parada.DiferencaParadaMinutos).Sum()
                //    }).AsEnumerable();

                //var query3 = from producoes in dbSqlServer.Producoes
                //             from user in dbSqlServer.Paradas
                //             select new { user, producoes };

                //query3.Any();
                //var allUsers = await query.ToListAsync();



                //    var query = from producao in dbSqlServer.Producoes
                //                group producao by new { producao.Id, producao.Resultado } into f
                //                //let salarioTotal = dbSqlServer.Paradas.Sum(x => x.DiferencaParadaMinutos)
                //                //let mediaSalarial = dbSqlServer.Perdas.Average(x => x.Qtde)
                //                //let mediaResultado = dbSqlServer.Paradas.Where(i => i.CodigoProducao.Equals(f.Key.Id)).Sum(j => j.DiferencaParadaMinutos)//f.Sum(i => i.Resultado)
                //                orderby f.Key.Id
                //                select new
                //                {
                //                    Id = f.Key.Id,
                //                    Resultado = f.Key.Resultado,
                //                    //mediaR = dbSqlServer.Paradas.Where(i => i.CodigoProducao.Equals(f.Key.Id)).Sum(j => j.DiferencaParadaMinutos) ?? 0
                //                    Total = dbSqlServer.Paradas.Where(i => i.CodigoProducao.Equals(f.Key.Id)).DefaultIfEmpty().Select(l => (double?)l.DiferencaParadaMinutos)
                //    //Media = mediaSalarial
                //};


                //    query.Any();

                //var test = from c in dbSqlServer.Producoes
                //           select new
                //           {
                //               Period = c.Id,
                //               Group = c.IndiceDisponibilidade,
                //               Code = c.Resultado,
                //               Amount = (System.Int32)
                //               ((from m0 in dbSqlServer.Paradas
                //                 where m0.CodigoProducao == c.Id
                //                 group m0 by new
                //                 {
                //                     m0.Id
                //                 } into g
                //                 select new
                //                 {
                //                     Expr1 = (System.Int32)g.Sum(p => p.DiferencaParadaMinutos)
                //                 }).First().Expr1)
                //           };

                //test.Any();

                //var result = from cr in dbSqlServer.Producoes
                //             let totalCount = (from parada in dbSqlServer.Paradas where cr.Id == parada.CodigoProducao select parada.DiferencaParadaMinutos).Sum()
                //             orderby cr.Id
                //             select new
                //             {
                //                 Days = cr.Id,
                //                 Com = totalCount,
                //                 //ComPercent = Math.Round((double)totalCount / ComCount * 100, 2)
                //             };

                //var applicantList = (from producao in dbSqlServer.Producoes
                //                     join listaParadas in dbSqlServer.Paradas
                //                     on producao.Id equals listaParadas.CodigoProducao 
                //                     into par from parada in par.DefaultIfEmpty()
                //                     join listPerdas in dbSqlServer.Perdas
                //                     on producao.Id equals listPerdas.CodigoProducao
                //                     into per from perda in per.DefaultIfEmpty()
                //                     //group per by new { } producao.Id
                //                     select new
                //                     {
                //                         IdProducao = producao.Id,
                //                         DataProducao = producao.Data,
                //                         QtdeParada = (parada == null ? 0 : parada.DiferencaParadaMinutos),
                //                         QtdePerda = (perda == null ? 0 : perda.Qtde),
                //                         Disponibilidade = producao.IndiceDisponibilidade
                //                     }).Take(1000).AsEnumerable();

                //applicantList.Any();

                //var testeGroup = applicantList.GroupBy(i => i.IdProducao);

                //testeGroup.Any();

                //var query3 = listProducao.GroupJoin(listParadas,
                //usr => usr.Id, ex => ex.CodigoProducao,
                //(usr, ex) => new { Usr = usr, Ex = ex.DefaultIfEmpty() })
                //.SelectMany(final => final.Ex,
                //    (final, ex) => new
                //    {
                //        IdProducao = final.Usr.Id,
                //        DataProducao = final.Usr.Data,
                //        QtdeParada = ex.DiferencaParadaMinutos,
                //        // Uma forma de proteger do null, não testado.
                //        Disponibilidade = ex != null ? final.Usr.IndiceDisponibilidade : 0
                //    }).ToList();

                //query3.Any();

                //var teste2 = query3.GroupBy(i => i.IdProducao);

                var adverts = (from producao in dbSqlServer.Producoes
                               let turno = (from turnos in dbSqlServer.Turnos
                                            where turnos.Id == producao.IdTurno
                                            select turnos).FirstOrDefault()
                               let setor = (from setores in dbSqlServer.Setores
                                            where setores.Id == producao.IdSetor
                                            select setores).FirstOrDefault()
                               let paradas = (from parada in dbSqlServer.Paradas
                                              where parada.CodigoProducao == producao.Id
                                              select parada.DiferencaParadaMinutos).AsEnumerable()
                               let produto = (from produto in dbSqlServer.Produtos
                                              where produto.Id == producao.IdProduto
                                              select produto).FirstOrDefault()
                               let produtoproducao = (from produtoProducao in dbSqlServer.ProdutoProducoes
                                                      where produtoProducao.CodigoProduto == producao.IdProduto
                                                      && produtoProducao.CodigoProducao == producao.Id
                                                      select produtoProducao.Qtde).AsEnumerable()
                               let perdas = (from perda in dbSqlServer.Perdas
                                             where perda.CodigoProducao == producao.Id
                                             select perda.Qtde).AsEnumerable()                
                               orderby producao.Id ascending
                               select new { producao, turno, setor,  paradas, produto, produtoproducao, perdas}).ToList();

                adverts.Any();

                foreach (var producoes in adverts)
                {
                    TimeSpan t = TimeSpan.FromHours(decimal.ToDouble(producoes.turno.HorasProducao));
                    string answer = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                    t.Hours,t.Minutes,t.Seconds);
                    workSheet.Cells[indice, 1].Value = producoes.producao.Data.ToShortDateString();
                    workSheet.Cells[indice, 2].Value = producoes.turno.Nome;
                    workSheet.Cells[indice, 3].Value = answer; //producoes.turno.HorasProducao * 60;
                    workSheet.Cells[indice, 4].Value = producoes.paradas.Sum();
                    workSheet.Cells[indice, 5].Value = producoes.produto.QtdeEstimativa;
                    workSheet.Cells[indice, 6].Value = (producoes.turno.HorasProducao * 60) / producoes.produto.QtdeEstimativa;
                    workSheet.Cells[indice, 7].Value = producoes.produtoproducao.Sum();
                    workSheet.Cells[indice, 8].Value = producoes.perdas.Sum();
                    workSheet.Cells[indice, 9].Value = producoes.producao.IndiceDisponibilidade;
                    workSheet.Cells[indice, 10].Value = producoes.producao.IndicePerfomance;
                    workSheet.Cells[indice, 11].Value = producoes.producao.IndiceQualidade;
                    workSheet.Cells[indice, 12].Value = producoes.producao.Resultado;
                    indice++;
                    //}
                }

                // ajusta o tamanho da coluna
                workSheet.Columns.AutoFit();// (1).AutoFit();
                //workSheet.Column(2).AutoFit();
                //workSheet.Column(3).AutoFit();
                //workSheet.Column(4).AutoFit();

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
            catch (Exception)
            {

                throw;
            }
        }

        private void criarPlanilhaProducao(ExcelPackage excel)
        {
            var planilhaProducao = excel.Workbook.Worksheets.Add("Produção");

            // define propriedades da planilha
            planilhaProducao.TabColor = System.Drawing.Color.Black;
            planilhaProducao.DefaultRowHeight = 12;

            // define propriedades da primeira linha
            planilhaProducao.Row(1).Height = 20;
            planilhaProducao.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            planilhaProducao.Row(1).Style.Font.Bold = true;

            // define o cabeçalho da planilha(base 1)
            planilhaProducao.Cells[1, 1].Value = "Data";
            planilhaProducao.Cells[1, 2].Value = "Indice Disponibilidade";
            planilhaProducao.Cells[1, 3].Value = "Indice Performance";
            planilhaProducao.Cells[1, 4].Value = "Indice Qualidade";
            planilhaProducao.Cells[1, 5].Value = "Resultado";

            planilhaProducao.Cells["A1:C1"].Style.Font.Italic = true;

            // inclui dados na planilha
            // inicia na segunda linha
            int indice = 2;

            List<Producao> listProducao = dbSqlServer.Producoes.ToList();

            foreach (Producao producao in listProducao)
            {
                planilhaProducao.Cells[indice, 1].Value = producao.Data.ToString("d");
                planilhaProducao.Cells[indice, 2].Value = producao.IndiceDisponibilidade;
                planilhaProducao.Cells[indice, 3].Value = producao.IndicePerfomance;
                planilhaProducao.Cells[indice, 4].Value = producao.IndiceQualidade;
                planilhaProducao.Cells[indice, 5].Value = producao.Resultado;
                indice++;
            }

            // ajusta o tamanho da coluna
            planilhaProducao.Column(1).AutoFit();
            planilhaProducao.Column(2).AutoFit();
            planilhaProducao.Column(3).AutoFit();
            planilhaProducao.Column(4).AutoFit();
            planilhaProducao.Column(5).AutoFit();
        }

        private void criarPlanilhaParadas(ExcelPackage excel)
        {
            var planilhaParadas = excel.Workbook.Worksheets.Add("Paradas");

            // define propriedades da planilha
            planilhaParadas.TabColor = System.Drawing.Color.Black;
            planilhaParadas.DefaultRowHeight = 12;

            // define propriedades da primeira linha
            planilhaParadas.Row(1).Height = 20;
            planilhaParadas.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            planilhaParadas.Row(1).Style.Font.Bold = true;

            // define o cabeçalho da planilha(base 1)
            planilhaParadas.Cells[1, 1].Value = "Tipo Parada";
            planilhaParadas.Cells[1, 2].Value = "Observação";
            planilhaParadas.Cells[1, 3].Value = "Tempo(min)";

            planilhaParadas.Cells["A1:C1"].Style.Font.Italic = true;

            // inclui dados na planilha
            // inicia na segunda linha
            int indice = 2;

            List<Parada> listParadas = dbSqlServer.Paradas.ToList();

            foreach (Parada parada in listParadas)
            {
                planilhaParadas.Cells[indice, 1].Value = parada.TipoParada;
                planilhaParadas.Cells[indice, 2].Value = parada.Observacao;
                planilhaParadas.Cells[indice, 3].Value = parada.DiferencaParadaMinutos;
                indice++;
            }

            // ajusta o tamanho da coluna
            planilhaParadas.Column(1).AutoFit();
            planilhaParadas.Column(2).AutoFit();
            planilhaParadas.Column(3).AutoFit();
        }

        private void criarPlanilhaPerdas(ExcelPackage excel)
        {
            var planilhaParadas = excel.Workbook.Worksheets.Add("Perdas");

            // define propriedades da planilha
            planilhaParadas.TabColor = System.Drawing.Color.Black;
            planilhaParadas.DefaultRowHeight = 12;

            // define propriedades da primeira linha
            planilhaParadas.Row(1).Height = 20;
            planilhaParadas.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            planilhaParadas.Row(1).Style.Font.Bold = true;

            // define o cabeçalho da planilha(base 1)
            planilhaParadas.Cells[1, 1].Value = "Nome";
            planilhaParadas.Cells[1, 2].Value = "Quantidade";

            planilhaParadas.Cells["A1:C1"].Style.Font.Italic = true;

            // inclui dados na planilha
            // inicia na segunda linha
            int indice = 2;

            List<Perda> listPerdas = dbSqlServer.Perdas.ToList();

            foreach (Perda perdas in listPerdas)
            {
                planilhaParadas.Cells[indice, 1].Value = perdas.Nome;
                planilhaParadas.Cells[indice, 2].Value = perdas.Qtde;
                indice++;
            }

            // ajusta o tamanho da coluna
            planilhaParadas.Column(1).AutoFit();
            planilhaParadas.Column(2).AutoFit();
        }

        private void abrirPlanilhaExcel(string caminho)
        {

        }
    }
}
