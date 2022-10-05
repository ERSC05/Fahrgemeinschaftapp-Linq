using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Threading;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {
            Menue();
            //ADHS();
            //Fahrer r = new Fahrer();
            //r.Fahrgemeinschaften();
            //TanzendeKuh();
        }
        
        static void TanzendeKuh()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            int a = 0;
            while (a == a)
            {
                Console.WriteLine("                                                                               \r\n                                           @@                                   \r\n                                         /%(&,                                  \r\n                                         @(((@ .,,,       @(@                   \r\n                             &@.    .@@  @&         ,@@@@@((@.                  \r\n                            @   ......              @@@@@@@@&                   \r\n                            ,@   ....                   .@@@@% */*.             \r\n                                &@@@                    %@@@@@@....@@@@         \r\n                                   @    @,@             (, @@@@......@@@        \r\n                                  */   ,   #           @@/@ %@@@&#%@@@@         \r\n                                  ,(         ,/((*.     *     &                 \r\n                                   @  (@*............../@/    @                 \r\n                                   .@...,@@&.........,@@,..@.@                  \r\n                            &@@*   @.....#&..........,@@,...*%                  \r\n                         @         %*........................%                  \r\n                       .%       @@@  @,......@....@........&#      ,&@@@@       \r\n                        &       (/  ....&@/............/@@@@@@@      @@@@*      \r\n                        #*        @,..................               @@@@&      \r\n                         ,&     @@@@@..................              %@@@(      \r\n                           @%@@@@@@@....................  ##%&@@@&#,            \r\n                           *&@@@@,......................  ./                    \r\n                         *@     ........................  (*                    \r\n                       &(        ......................   @                     \r\n                    /@.              ................    @                      \r\n                   @@@@/      .%@@@/                   ,&                       \r\n                    @@@@@(,@.          ,&@@             @*   &@@,               \r\n                      @@@                  ,#        *#@@. (@%%&@               \r\n                                            @        @                          \r\n                                            @       @                           \r\n                                            @@@@@@@@&                           \r\n                                           ,@@@@@@@@*                           \r\n                                                                              ");
                Thread.Sleep(100);
                Console.Clear();
                Console.WriteLine("                                                                                \r\n                                                                                \r\n                                                                                \r\n                                    @@                                          \r\n                                   &((@                                         \r\n                   /%%%      .,,,. @(((%                                        \r\n                   ##((@@@@@          @@  @@     *@,                            \r\n                    @@@@@@@@@              ......   @                           \r\n              ,//, @@@@@                    ....   @                            \r\n          @@@#...,@@@@@@.                   #@@@#                               \r\n         @@#......@@@@ /*            (%*@    @                                  \r\n          @@@@##@@@@, @%@@           #   .   @                                  \r\n                 #,    ..     .*((/.         @                                  \r\n                  @    %@*..............(@.  @                                  \r\n                   &##..%@@..........@@@...*@                                   \r\n                   @....%@&...........&*....,%   (@@#                           \r\n                   @........................&.        .@                        \r\n        @@@@#       @/.......(&...*@......(@  @@(       @                       \r\n       @@@@@      @@@@@@@,............#@#...   @.       @                       \r\n       @@@@*              .................../@        &                        \r\n       @@@@               .................*@@@@&     @                         \r\n             *%&@@@&#@   ....................@@@@@@@%#                          \r\n                     @   ....................../@@@&@                           \r\n                     %   ........................     @                         \r\n                      @   .....................         @/                      \r\n                       &   .................              &@                    \r\n                        @                    %@@@#       &@@@@                  \r\n                (@@#   %@            .@@%.          (@ @@@@@@                   \r\n               .@%%%@  *@%@         @                  ,@@@                     \r\n                           @       .%                                           \r\n                           */      ,#                                           \r\n                            @@@@@@@@@                                           \r\n                            &@@@@@@@@                                           \r\n                                                                                ");
                Thread.Sleep(100);
                Console.Clear();
            }

        }//Eine tolle Kuh
        static void Hallo()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Console.WriteLine("                                                                          \r\n                                                                          \r\nHHHHHHHHH     HHHHHHHHH                  lllllll lllllll                  \r\nH:::::::H     H:::::::H                  l:::::l l:::::l                  \r\nH:::::::H     H:::::::H                  l:::::l l:::::l                  \r\nHH::::::H     H::::::HH                  l:::::l l:::::l                  \r\n  H:::::H     H:::::H    aaaaaaaaaaaaa    l::::l  l::::l    ooooooooooo   \r\n  H:::::H     H:::::H    a::::::::::::a   l::::l  l::::l  oo:::::::::::oo \r\n  H::::::HHHHH::::::H    aaaaaaaaa:::::a  l::::l  l::::l o:::::::::::::::o\r\n  H:::::::::::::::::H             a::::a  l::::l  l::::l o:::::ooooo:::::o\r\n  H:::::::::::::::::H      aaaaaaa:::::a  l::::l  l::::l o::::o     o::::o\r\n  H::::::HHHHH::::::H    aa::::::::::::a  l::::l  l::::l o::::o     o::::o\r\n  H:::::H     H:::::H   a::::aaaa::::::a  l::::l  l::::l o::::o     o::::o\r\n  H:::::H     H:::::H  a::::a    a:::::a  l::::l  l::::l o::::o     o::::o\r\nHH::::::H     H::::::HHa::::a    a:::::a l::::::ll::::::lo:::::ooooo:::::o\r\nH:::::::H     H:::::::Ha:::::aaaa::::::a l::::::ll::::::lo:::::::::::::::o\r\nH:::::::H     H:::::::H a::::::::::aa:::al::::::ll::::::l oo:::::::::::oo \r\nHHHHHHHHH     HHHHHHHHH  aaaaaaaaaa  aaaallllllllllllllll   ooooooooooo   \r\n                                                                          \r\n                                                                          ");
            //Console.WriteLine("                       **        **          ****           **            **                 ***       ");
            //Console.WriteLine("                      **        **         **  **          **            **              ***   ***    ");
            //Console.WriteLine("                     **        **        **    **         **            **             ***     ***   ");
            //Console.WriteLine("                    ************       **      **        **            **             **        **  ");
            //Console.WriteLine("                   ************      **        **       **            **             **        **  ");
            //Console.WriteLine("                  **        **     ***************     **            **             ***      **   ");
            //Console.WriteLine("                 **        **    **             **    ***********   ***********      ***  ***    ");
            //Console.WriteLine("                **        **   **               **   ***********   ***********        ****      ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("            und willkomme zu der Fahrgemeinschaft App!!!\n\n\n");
            Thread.Sleep(2000);
            Console.Clear();







        }//Willkommensgruß
        static void Login()
        {
        LoginBegin:
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                           ║");
            Console.WriteLine("║                   Wass willst du machen?                  ║");
            Console.WriteLine("║                                                           ║");
            Console.WriteLine("╠═══════════════════════════════════════════════════════════╣");
            Console.WriteLine("║                                                           ║");
            Console.WriteLine("║                        Anmelden 1:                        ║");
            Console.WriteLine("║                                                           ║");
            Console.WriteLine("╠═══════════════════════════════════════════════════════════╣");
            Console.WriteLine("║                                                           ║");
            Console.WriteLine("║                       Registrieren 2:                     ║");
            Console.WriteLine("║                                                           ║");
            Console.WriteLine("╠═══════════════════════════════════════════════════════════╝");
            Console.WriteLine("║");
            Console.WriteLine("║");
            Console.WriteLine("║");
            Console.Write("╚════════════════════");
            string b = Console.ReadLine();
            switch (b)
            {
                case "1":
                    Login:
                    Console.Clear();
                    string Username = "0";
                    int v = 0;
                    string Usereingabe = "0";
                    
                    List<string> list = new List<string>();
                    FileInfo info = new FileInfo("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Test.csv");
                    long length = info.Length;
                    do
                    {
                        using (var reader = new StreamReader("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Test.csv"))
                        {
                            Usereingabe = reader.ReadToEnd();
                            Usereingabe.Split(',',';');
                            list.Add(Usereingabe);
                        }
                    } while (v == 1);

                    Console.WriteLine("Gebe deinen nutzernamen ein");
                    string Nuzername = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Gebe dein passwort ein");
                    Console.ForegroundColor = ConsoleColor.Black;
                    string Passwort = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    var matchinngvalues = list
                        .Where(stringToCheck => stringToCheck.Contains(Username));


                    var match = list
                        .FirstOrDefault(stringToCheck => stringToCheck.Contains(Nuzername));

                    if (match != null)
                    { 
                    }
                    
                    else
                    {
                        Console.WriteLine("Benutzer oder Passwort ist falsch.");
                        Thread.Sleep(1000);
                        Console.WriteLine("Du wirst wieder auf die Loginseite weitergeleitet");
                        Thread.Sleep(2000);
                        goto Login;
                    }
                    return;
                case "2":
                    Console.Clear();
                    Fahrer f = new Fahrer();
                    f.Registrieren();
                    return;
                default:
                    Console.Clear();
                    goto LoginBegin;
            }


        }//login
        static void AuswahlFenster()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Was willst du machen?");
            Console.WriteLine("[1] : Fahrgemeinschaft finden?");
            Console.WriteLine("[2] : Fahrer werden");
            Console.WriteLine("[3] : Auflistung der Bisherige Fahrer");
            Console.WriteLine("[4] : Eigenen Account Bearbeiten");
            Console.WriteLine("[5] : Neuen Account Registrieren");
            Console.WriteLine("[6] : Fahrer mit bestimmtem Auto suchen");
            Console.WriteLine("[7] : Carpool");
            Console.WriteLine("[8] : Datenschutz von Fortnite lesen");
            Console.WriteLine("[9] : App verlassen");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("--->");

        }//Appeigenschafften um witer zu machen
        static void Menue()//Eigentliches Programm
        {


            Hallo();//Willkommensgruß

            Login();//login
        Start:
            AuswahlFenster();//Appeigenschafften um weiter zu machen

            string a = Console.ReadLine();

            switch (a)
            {
                case "1"://Fahrersuche
                    Console.Clear();
                case1:
                    Console.WriteLine("Gebe dein Ziel Ort ein.");
                    string ort = Console.ReadLine();
                    Fahrer f = new Fahrer();
                    if (ort == "wkh")
                    {//Fahrersuche für Weikersheim
                        f.FahrersucheSara(ort);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        goto Start;
                    }
                    else if (ort == "mgh")
                    {//Fahrersuche Bad Mergentheim
                        f.FahrersucheFerdinant(ort);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        goto Start;

                    }
                    else if (ort == "Kaufland")
                    {//Fahrersuche für Kaufland (10 Sitze)
                        f.FahrersucheBastian(ort);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        goto Start;
                    }
                    else
                    {//Wenn Das ZiehlOrt nicht existiert
                        Console.WriteLine($"Es wird nicht nach {ort} gefahren");
                        Thread.Sleep(2000);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        goto case1;
                    }
                case "2"://Fahrer werden
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Clear();
                    List<Fahrer> fahrers1 = new List<Fahrer>
                    {
                        new Ferdinant("Ferdinat ", "Falschparker ", "Toyota Corolla ", "wkh", 1),

                        new Sara("Sara ", "Blond ", "Opel ", "mgh", 3),
                        new Bastian("Bastian ", "Nachnamiii ", "Lambo","Kaufland", 10)
                    };
                //Vergewisserrung Fahrer zu werden
                Copyright:
                    Console.WriteLine("Willst du auch ein mitglied der Fahrer App werden?");
                    Console.WriteLine("Dann schreibe y! Mit dem Drüben von y bestätigst du automatisch, das wir deine Daten klauen und verkaufen dürfen.\nDich dürden wir dann auch einsperren.");
                    Console.WriteLine("");
                    Console.WriteLine("Oder b um unseren Copyright schutz durchzulessen.");
                    string b = Console.ReadLine();
                    if (b == "y")
                    {
                        Console.Clear();
                        Console.WriteLine("Willkommen um ein unser der app zu werden");
                        foreach (Fahrer fahre in fahrers1) { fahre.FahrerEdit(); break; }
                        goto Start;
                    }
                    else if (b == "b")
                    {
                        Console.Clear();
                        Console.WriteLine("Der Copyright-Hinweis war früher \nmal notwendig. Z.B. mussten in den USA die Urheberrechte \n" +
                            "registriert und mit einem solchen Hinweis versehen \nwerden. Ansonsten konnten die Rechte an dem Werk erlöschen. \n" +
                            "Daher ist der Hinweis so stark verbreitet. Seit dem 1 April \n1989 entsteht das Copyright in den USA, genauso wie \n" +
                            "Urheberrechte in Europa, automatisch (z.B., wenn ein Autor ein\n Buch verfasst oder der Fotograf die Kamera auslöst).\r\n\r\n" +
                            "Ein Copyright-Hinweis ist daher lediglich ein Fingerzeig\n auf das Urheberrecht. Also ein Hinweisschild, das keinen Einfluss \n" +
                            "auf die Entstehung des Urheberrechts hat.\r\n\r\nDas heißt, der Copyright-Hinweis ist nicht notwendig. Allerdings heißt das \n" +
                            "nicht, dass er unnütz ist. Ganz im Gegenteil.\r\n\r\nAber bevor es um die Vorteilen des Urheberrechtsvermerks geht, erkläre ich\n" +
                            " einen anderen, häufig zusammen mit dem Copyright-Hinweis verwendeten Begriff.\r\n\r\n[sc name=“tshinweisboxBEGIN“]Wann ist es ein\n" +
                            " Copyright, wann ein Urheberrecht? Grundsätzlich bestimmt sich\n das maßgebliche Recht nach dem Land, in dem ein Werk entsteht.\n" +
                            " Wobei in vielen nationale Urheberrechtsgesetzen steht, dass\n sie auch für Werke gelten, die von ihren Bürgern im Ausland erstellt \n" +
                            "wurden. Es kann also im Fall von Unterschieden durchaus\n kompliziert werden, das passende Recht zu bestimmen. Wenn es um die\n" +
                            "Verteidigung des Urheberrechts geht, dann kommt es auf das\n Recht des Landes an, in dem man sich z.B. auf das eigene Recht\n" +
                            " beruft (sog. Schutzlandprinzip). Wenn Sie z.B. in den USA \nIhre Schutzrechte an einer Fotografie geltend machen wollen, \n" +
                            "dann berufen Sie sich auf das US-Copyright.\n[sc name=“tshinweisboxEND“]ahwjldhaöoduahfklafhaklfjhajhk afklajfhafljkafh\n " +
                            "wdiqjhjldhqwdkqghdqwjhkdgqjkhgdqjghdqgjwwdkhjqwgdqgjkdqdhjqg\nwwqeqwkejqlekqwjeqwljehqklehqwwjklehqkjhqwkjehqwewjkqwhekqjwlwbdqhe");
                        Console.ReadLine();
                        Console.Clear();
                        goto Copyright;
                    }
                    else
                    {
                        goto Start;
                    }
                case "3"://Fahrer Auflisten Die existieren und wann sie fahren
                    Console.Clear();
                    Fahrer f2 = new Fahrer();
                    f2.Write();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Thread.Sleep(5000);
                    goto Start;
                case "4":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Fahrer f4 = new Fahrer();
                    Console.Clear();
                    f4.Registrieren();
                    goto Start;
                case "5":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Fahrer f5 = new Fahrer();
                    Console.Clear();
                    f5.Registrieren();
                    goto Start;
                case "6":
                    Console.Clear();
                    Fahrer f6 = new Fahrer();
                    f6.BestimmteAutoSuche();
                    goto Start;
                case "7":
                    Console.Clear();
                    Fahrer f7 = new Fahrer();
                    f7.CarPool();
                    goto Start;
                case "8":
                    Fahrer f8 = new Fahrer();
                    f8.Datenschutz();
                    Console.ReadLine();
                    goto Start;
                case "9":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Clear();
                    Console.WriteLine("Bist du dir sicher das du Die App schließen willst? y/n");
                    if (Console.ReadLine() == "y")
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.Clear();
                        goto Start;
                    }
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Du hast etwas falsches getrückt. Du wirst zum start weitergeleitet");
                    Thread.Sleep(3000);
                    Console.Clear();
                    goto Start;


            }


        }
        static void ADHS()
        {
            WriteCharacterStrings(1, 1000000000, true);
        }//Für den Flex
        private static void WriteCharacterStrings(int start, float end, bool changeColor)
        {
            for (int ctr = start; ctr <= end; ctr++)
            {
                if (changeColor)
                    Console.BackgroundColor = (ConsoleColor)((ctr - 1) % 16);
                //Thread.Sleep(100);
                Console.WriteLine("P");
            }
            Console.ResetColor();
            Console.Clear();
        }//Der Flex


    }
}