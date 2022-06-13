using System;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;

namespace ProjetoPrisma5.Repositório
{
    public class ConverterModelo
    {
        public void CriaPlanilhaExcel(List<Modelo>modelos)
        {
            string caminhoPlanilha = @"C:\temp\";
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();

            // Definição do nome da Planilha
            var workSheet = excel.Workbook.Worksheets.Add("Cidades");

            // Define propriedades da planilha
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;
            workSheet.DefaultColWidth = 30; 

            // Define propriedades do cabeçalho
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            // Define os valores do cabeçalho
            workSheet.Cells[1, 1].Value = "siglaEstado";
            workSheet.Cells[1, 2].Value = "regiaoNome";
            workSheet.Cells[1, 3].Value = "nomeCidade";
            workSheet.Cells[1, 4].Value = "nomeMesorregião";
            workSheet.Cells[1, 5].Value = "nomeFormatado";

            // Preenche a planilha com os dados contidos no modelo.
            int contador = 2;
            foreach (var modelo in modelos)
            {
                workSheet.Cells[contador, 1].Value = modelo.SiglaEstado;
                workSheet.Cells[contador, 2].Value = modelo.RegiaoNome;
                workSheet.Cells[contador, 3].Value = modelo.NomeCidade;
                workSheet.Cells[contador, 4].Value = modelo.NomeMesoregiao;
                workSheet.Cells[contador, 5].Value = modelo.NomeFormatado;
                contador++;
            }
            
            excel.SaveAs(@"C:\Users\Pichau\Desktop\Teste_pratico_prisma-Gerar_Planilha\WebApplication1\WebApplication1\Dados\Dados.xlsx");

            //Fecha o arquivo excel
            excel.Dispose();
        }
    }
}
