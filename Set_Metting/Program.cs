using System;

namespace Set_Metting
{
    class StartMeeting
    {
        public const string version = "2.0.0";
        public const string author = "Jakub Sydor";
        public const string license = "GNU GPLv3";

        public static void Wellcome()
        {
            Console.WriteLine("Ładowanie programu Set_Meeting");
            Console.WriteLine("");
            Console.WriteLine("Autor: {0}", author);
            Console.WriteLine("Wersja: {0}", version);
            Console.WriteLine("Licencja: {0}", license);
            Console.WriteLine("");
        }

        public static void Main(string[] args)
        {

            Wellcome();
            if (args.Length < 1)
            {
                Notifications.Notif.Error("Brak wymaganych argumentów. Użycie: SetMeeting.exe <list_z_uczestnikami>");
            }

            ReadFile.ReadFile rf = new ReadFile.ReadFile(args[0]);

            try
            {
                new GenDoc.GenerateDoc(rf.ListMembers, rf.MembersCount);
                new GenXlsX.GenerateXlsx(rf.ListMembers);
            }
            catch (Exception e)
            {
                Notifications.Notif.Error(e.Message);
            }

            Notifications.Notif.Info("Zakończono generowanie. Pliki zostaną zapisane po zamknięciu. Przyciśnij dowolny klawisz, aby zamknąć...");
            Console.ReadKey();
        }
    }
}
