using System;
using Novacode;

namespace Set_Metting.GenDoc
{
    class GenerateDoc
    {
        private DocX document;
        private int membersCount;
        public GenerateDoc(string[][] data, int count)
        {
            Notifications.Notif.Info("Generowanie pliku z rozpiskami");
            document = DocX.Create(@"Rozpiska.docx");
            membersCount = count;
            CreateHeader();
            CreateCopyright();
            GenerateClashes(data);
        }

        ~GenerateDoc()
        {
            try
            {
                document.Save();
            }
            catch(Exception e)
            {
                Notifications.Notif.Error(e.Message);
            }
            Notifications.Notif.Info("Plik z rozpiskami zapisano jako: Rozpiska.docx");
        }

        private void CreateCopyright()
        {
            this.document.AddFooters();
            Footer footer_default = this.document.Footers.odd;
            Paragraph p = footer_default.InsertParagraph();
            p.Append("Wygenerowane przez 'Set_Meeting' by Jakub Sydor").Italic();
        }

        private void CreateHeader()
        {
            Paragraph title = this.document.InsertParagraph().Append("Rozpiska kolejek ligi szachowej").FontSize(22);
            title.Alignment = Alignment.center;

            Paragraph under = this.document.InsertParagraph().Append("Opiekun: Rafał Kamiński").FontSize(16);
            under.Alignment = Alignment.center;
        }

        private void GenerateClashes(string[][] data)
        {
            int que = 1;
            Paragraph p = this.document.InsertParagraph();
            for (int i = 0; i < data.Length; i++)
            {
                if (i % (this.membersCount/2) == 0)
                {
                    p.AppendLine("Kolejka " + que).FontSize(14);
                    que++;
                }
                p.AppendLine("\t" + data[i][0] + " - " + data[i][1]);
            }
        }
    }
}
