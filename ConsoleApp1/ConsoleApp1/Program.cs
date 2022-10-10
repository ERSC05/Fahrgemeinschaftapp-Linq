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
        }

        static void TanzendeKuh()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            int a = 0;
            int b = 0;
            while (a == b)
            {
                Console.WriteLine("                                                                               \r\n                                           @@                                   \r\n                                         /%(&,                                  \r\n                                         @(((@ .,,,       @(@                   \r\n                             &@.    .@@  @&         ,@@@@@((@.                  \r\n                            @   ......              @@@@@@@@&                   \r\n                            ,@   ....                   .@@@@% */*.             \r\n                                &@@@                    %@@@@@@....@@@@         \r\n                                   @    @,@             (, @@@@......@@@        \r\n                                  */   ,   #           @@/@ %@@@&#%@@@@         \r\n                                  ,(         ,/((*.     *     &                 \r\n                                   @  (@*............../@/    @                 \r\n                                   .@...,@@&.........,@@,..@.@                  \r\n                            &@@*   @.....#&..........,@@,...*%                  \r\n                         @         %*........................%                  \r\n                       .%       @@@  @,......@....@........&#      ,&@@@@       \r\n                        &       (/  ....&@/............/@@@@@@@      @@@@*      \r\n                        #*        @,..................               @@@@&      \r\n                         ,&     @@@@@..................              %@@@(      \r\n                           @%@@@@@@@....................  ##%&@@@&#,            \r\n                           *&@@@@,......................  ./                    \r\n                         *@     ........................  (*                    \r\n                       &(        ......................   @                     \r\n                    /@.              ................    @                      \r\n                   @@@@/      .%@@@/                   ,&                       \r\n                    @@@@@(,@.          ,&@@             @*   &@@,               \r\n                      @@@                  ,#        *#@@. (@%%&@               \r\n                                            @        @                          \r\n                                            @       @                           \r\n                                            @@@@@@@@&                           \r\n                                           ,@@@@@@@@*                           \r\n                                                                              ");
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine("                                                                                \r\n                                                                                \r\n                                                                                \r\n                                    @@                                          \r\n                                   &((@                                         \r\n                   /%%%      .,,,. @(((%                                        \r\n                   ##((@@@@@          @@  @@     *@,                            \r\n                    @@@@@@@@@              ......   @                           \r\n              ,//, @@@@@                    ....   @                            \r\n          @@@#...,@@@@@@.                   #@@@#                               \r\n         @@#......@@@@ /*            (%*@    @                                  \r\n          @@@@##@@@@, @%@@           #   .   @                                  \r\n                 #,    ..     .*((/.         @                                  \r\n                  @    %@*..............(@.  @                                  \r\n                   &##..%@@..........@@@...*@                                   \r\n                   @....%@&...........&*....,%   (@@#                           \r\n                   @........................&.        .@                        \r\n        @@@@#       @/.......(&...*@......(@  @@(       @                       \r\n       @@@@@      @@@@@@@,............#@#...   @.       @                       \r\n       @@@@*              .................../@        &                        \r\n       @@@@               .................*@@@@&     @                         \r\n             *%&@@@&#@   ....................@@@@@@@%#                          \r\n                     @   ....................../@@@&@                           \r\n                     %   ........................     @                         \r\n                      @   .....................         @/                      \r\n                       &   .................              &@                    \r\n                        @                    %@@@#       &@@@@                  \r\n                (@@#   %@            .@@%.          (@ @@@@@@                   \r\n               .@%%%@  *@%@         @                  ,@@@                     \r\n                           @       .%                                           \r\n                           */      ,#                                           \r\n                            @@@@@@@@@                                           \r\n                            &@@@@@@@@                                           \r\n                                                                                ");
                Thread.Sleep(500);
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
            string b = Convert.ToString(Console.ReadKey().KeyChar);
            switch (b)
            {
                case "1":

                    Fahrer fahrer2 = new Fahrer();
                    fahrer2.Anmelden();
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
        {//Erstes Fenster, die sich nach dem Login öffnet
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Was willst du machen?\n\n\n\n");
            Console.WriteLine(" ____ \r\n||1 ||\r\n||__|| : Fahrgemeinschaft finden\r\n|/__\\|\n");
            Console.WriteLine(" ____ \r\n||2 ||\r\n||__|| : Fahrer werden\r\n|/__\\|\n");
            Console.WriteLine(" ____ \r\n||3 ||\r\n||__|| : Auflistung der Bisherigen Fahrer\r\n|/__\\|\n");
            Console.WriteLine(" ____ \r\n||4 ||\r\n||__|| : Eigene Anmeldedaten bearbeiten\r\n|/__\\|\n");
            Console.WriteLine(" ____ \r\n||5 ||\r\n||__|| : Neuen Account Registrieren \r\n|/__\\|\n");
            Console.WriteLine(" ____ \r\n||6 ||\r\n||__|| : Fahrer mit bestimmtem Auto suchen\r\n|/__\\|\n");
            Console.WriteLine(" ____ \r\n||7 ||\r\n||__|| : Tanzende Kuh (Wir hafften für keine Schäden mit ihren Augen)\r\n|/__\\| \n");
            Console.WriteLine(" ____ \r\n||8 ||\r\n||__|| : Datenschutz von Fortnite lesen\r\n|/__\\| \n");
            Console.WriteLine(" ____ \r\n||9 ||\r\n||__|| : App verlassen\r\n|/__\\|\n");
            Console.WriteLine(" ____ \r\n||0 ||\r\n||__|| : Gebildete Fahrgemeinschaften anzeigen\r\n|/__\\|\n");

            //          Console.WriteLine(" ____ \r\n||10||\r\n||__|| : Tanzende Kuh (Wir hafften für keine Schäden mit ihren Augen)\r\n|/__\\|\n");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("--->");

        }//Appeigenschafften um witer zu machen
        static void Menue()//Alle anderen Methoden zusammengefasst
        {
        //Hallo();//Willkommensgruß

        //Login();//login
        Start:
            AuswahlFenster();
            string a = Convert.ToString(Console.ReadKey().KeyChar);
            Fahrer fahrer = new Fahrer();
            switch (a)
            {
                case "1"://Fahrersuche
                    Console.Clear();
                    fahrer.Fahrersuche2();
                    Console.ReadLine();

                    goto Start;
                case "2"://Fahrer werden
                    Console.Clear();
                //Vergewisserrung Fahrer zu werden
                Copyright:
                    Console.WriteLine("Willst du auch ein mitglied der Fahrer App werden?");
                    Console.WriteLine("Dann schreibe y! Mit dem Drücken von y bestätigst du automatisch, das wir deine Daten klauen und verkaufen dürfen.\nDich dürden wir dann auch einsperren.");
                    Console.WriteLine("");
                    Console.WriteLine("Oder b um unseren Datenschutz durchzulessen.");
                    string b = Convert.ToString(Console.ReadKey().KeyChar);
                    if (b == "y")
                    {
                        Console.Clear();
                        Console.WriteLine("Willkommen um ein unser der app zu werden");
                        fahrer.FahrerEdit();
                        Console.ReadLine();
                        goto Start;
                    }
                    else if (b == "b")
                    {
                        Console.Clear();
                        fahrer.Datenschutz();
                        Console.ReadLine();
                        Console.Clear();
                        goto Copyright;
                    }
                    else
                    {
                        goto Start;
                    }
                case "3"://Fahrer Auflisten Die existieren und wann sie fahren
                    fahrer.PrintOut();
                    Console.ReadLine();
                    goto Start;
                case "4":
                    fahrer.AenderrungVomAccount();
                    Console.ReadLine();
                    goto Start;
                case "5":
                    fahrer.Registrieren();
                    goto Start;
                case "6":
                    fahrer.BestimmteAutoSuche();
                    Console.ReadLine();
                    goto Start;
                case "7":
                    Console.Clear();
                    ADHS();
                    Console.ReadLine();
                    goto Start;
                case "8":
                    fahrer.Datenschutz();
                    Console.ReadLine();
                    goto Start;
                case "9":
                    Console.Clear();
                    Console.WriteLine("Bist du dir sicher das du Die App schließen willst? y/n");
                    if ((Convert.ToString(Console.ReadKey().KeyChar) == "y"))
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.Clear();
                        goto Start;
                    }
                    return;
                case "0":
                    fahrer.FahrgemeinschaftPrint();
                    Console.ReadLine();
                    goto Start;


                default:
                    Console.Clear();
                    Console.WriteLine("Du hast etwas falsches getrückt. Du wirst zum start weitergeleitet");
                    Console.ReadLine();
                    Console.Clear();
                    goto Start;


            }


        }
        static void ADHS()
        {
            WriteCharacterStrings(1, 1000000000, true);
        }//Für den Flex
        static void WriteCharacterStrings(int start, float end, bool changeColor)
        {
            for (int ctr = start; ctr <= end; ctr++)
            {
                if (changeColor)
                {
                    Console.BackgroundColor = (ConsoleColor)((ctr - 1) % 16);
                    Console.ForegroundColor = (ConsoleColor)((ctr - 1) % 5);
                }
                //Thread.Sleep(100);
                Console.WriteLine("                                                                               \r\n                                           @@                                   \r\n                                         /%(&,                                  \r\n                                         @(((@ .,,,       @(@                   \r\n                             &@.    .@@  @&         ,@@@@@((@.                  \r\n                            @   ......              @@@@@@@@&                   \r\n                            ,@   ....                   .@@@@% */*.             \r\n                                &@@@                    %@@@@@@....@@@@         \r\n                                   @    @,@             (, @@@@......@@@        \r\n                                  */   ,   #           @@/@ %@@@&#%@@@@         \r\n                                  ,(         ,/((*.     *     &                 \r\n                                   @  (@*............../@/    @                 \r\n                                   .@...,@@&.........,@@,..@.@                  \r\n                            &@@*   @.....#&..........,@@,...*%                  \r\n                         @         %*........................%                  \r\n                       .%       @@@  @,......@....@........&#      ,&@@@@       \r\n                        &       (/  ....&@/............/@@@@@@@      @@@@*      \r\n                        #*        @,..................               @@@@&      \r\n                         ,&     @@@@@..................              %@@@(      \r\n                           @%@@@@@@@....................  ##%&@@@&#,            \r\n                           *&@@@@,......................  ./                    \r\n                         *@     ........................  (*                    \r\n                       &(        ......................   @                     \r\n                    /@.              ................    @                      \r\n                   @@@@/      .%@@@/                   ,&                       \r\n                    @@@@@(,@.          ,&@@             @*   &@@,               \r\n                      @@@                  ,#        *#@@. (@%%&@               \r\n                                            @        @                          \r\n                                            @       @                           \r\n                                            @@@@@@@@&                           \r\n                                           ,@@@@@@@@*                           \r\n                                                                              ");
                Thread.Sleep(100);
                Console.Clear();
                Console.WriteLine("                                                                                \r\n                                                                                \r\n                                                                                \r\n                                    @@                                          \r\n                                   &((@                                         \r\n                   /%%%      .,,,. @(((%                                        \r\n                   ##((@@@@@          @@  @@     *@,                            \r\n                    @@@@@@@@@              ......   @                           \r\n              ,//, @@@@@                    ....   @                            \r\n          @@@#...,@@@@@@.                   #@@@#                               \r\n         @@#......@@@@ /*            (%*@    @                                  \r\n          @@@@##@@@@, @%@@           #   .   @                                  \r\n                 #,    ..     .*((/.         @                                  \r\n                  @    %@*..............(@.  @                                  \r\n                   &##..%@@..........@@@...*@                                   \r\n                   @....%@&...........&*....,%   (@@#                           \r\n                   @........................&.        .@                        \r\n        @@@@#       @/.......(&...*@......(@  @@(       @                       \r\n       @@@@@      @@@@@@@,............#@#...   @.       @                       \r\n       @@@@*              .................../@        &                        \r\n       @@@@               .................*@@@@&     @                         \r\n             *%&@@@&#@   ....................@@@@@@@%#                          \r\n                     @   ....................../@@@&@                           \r\n                     %   ........................     @                         \r\n                      @   .....................         @/                      \r\n                       &   .................              &@                    \r\n                        @                    %@@@#       &@@@@                  \r\n                (@@#   %@            .@@%.          (@ @@@@@@                   \r\n               .@%%%@  *@%@         @                  ,@@@                     \r\n                           @       .%                                           \r\n                           */      ,#                                           \r\n                            @@@@@@@@@                                           \r\n                            &@@@@@@@@                                           \r\n                                                                                ");
                Thread.Sleep(100);
                Console.Clear();
            }
            Console.ResetColor();
            Console.Clear();
        }//Der Flex


    }
}