using System;
using ClosedXML.Excel;

namespace Set_Metting.GenXlsX
{
    class GenerateXlsx
    {
        private XLWorkbook workbook;
        private IXLWorksheet worksheet;
        public GenerateXlsx(string[][] data)
        {
            Notifications.Notif.Info("Generowanie pliku z wynikami");
            workbook = new XLWorkbook();
            worksheet = workbook.Worksheets.Add("Liga szachowa");
            CreateHeader();
            GenerateClash(data);
        }

        ~GenerateXlsx()
        {
            try
            {
                workbook.SaveAs("Wyniki.xlsx");
            }
            catch(Exception e)
            {
                Notifications.Notif.Error(e.Message);
            }
            Notifications.Notif.Info("Plik z wynikami zapisano jako: Wyniki.xlsx");
        }

        private void CreateHeader()
        {
            this.worksheet.Cell("A1").Value = "Wyniki - Szkolna liga szachowa";
            this.worksheet.Cell("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            this.worksheet.Cell("A1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            this.worksheet.Cell("A1").Style.Font.FontSize = 16;
            this.worksheet.Cell("A1").Style.Fill.BackgroundColor = XLColor.FromName("PowderBlue");
            this.worksheet.Range("A1:D4").Merge();

            this.worksheet.Column("A").Width = 30;
            this.worksheet.Column("B").Width = 30;
            this.worksheet.Column("C").Width = 30;
            this.worksheet.Column("D").Width = 30;

            this.worksheet.Cell("A5").Value = "Zawodnik #1";
            this.worksheet.Cell("A5").Style.Font.Bold = true;
            this.worksheet.Cell("A5").Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

            this.worksheet.Cell("B5").Value = "Zawodnik #2";
            this.worksheet.Cell("B5").Style.Font.Bold = true;
            this.worksheet.Cell("B5").Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

            this.worksheet.Cell("C5").Value = "Wynik";
            this.worksheet.Cell("C5").Style.Font.Bold = true;
            this.worksheet.Cell("C5").Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

            this.worksheet.Cell("D5").Value = "Notatka";
            this.worksheet.Cell("D5").Style.Font.Bold = true;
            this.worksheet.Cell("D5").Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
        }

        private void GenerateClash(string[][] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i][0] == "PAUZA" || data[i][1] == "PAUZA") continue;

                this.worksheet.Cell("A" + (i + 6)).Value = data[i][0];
                this.worksheet.Cell("A" + (i + 6)).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                this.worksheet.Cell("B" + (i + 6)).Value = data[i][1];
                this.worksheet.Cell("B" + (i + 6)).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            }
        }
    }
}
