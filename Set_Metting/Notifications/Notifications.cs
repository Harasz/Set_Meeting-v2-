using System;

namespace Set_Metting.Notifications
{
    class Notif
    {
        public static void Error(string content=" ")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ Błąd ] {0}", content);
            Console.ResetColor();
            Console.ReadKey();
            Environment.Exit(1);
        }
        public static void Info(string content=" ")
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("[ Info ] {0}", content);
            Console.ResetColor();
        }
    }
}
