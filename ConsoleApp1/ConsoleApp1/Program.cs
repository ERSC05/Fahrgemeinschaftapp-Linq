using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menue();
        }
        static void Hallo()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;




            Console.WriteLine("       **        **          ****           **            **                 ***       ");
            Console.WriteLine("      **        **         **  **          **            **              ***   ***    ");
            Console.WriteLine("     **        **        **    **         **            **             ***     ***   ");
            Console.WriteLine("    ************       **      **        **            **             **        **  ");
            Console.WriteLine("   ************      **        **       **            **             **        **  ");
            Console.WriteLine("  **        **     ***************     **            **             ***      **   ");
            Console.WriteLine(" **        **    **             **    ***********   ***********      ***  ***    ");
            Console.WriteLine("**        **   **               **   ***********   ***********        ****      ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("und willkomme zu der Fahrgemeinschaft App!!!\n\n\n");
            Thread.Sleep(2000);
            Console.Clear();





        }
        static void Login()
        {
            Console.WriteLine("Wass willst du machen?\n");
            Console.WriteLine("Anmelden 1: ");
            Console.WriteLine("Registrieren 2: ");
            string b = Console.ReadLine();
            switch (b)
            {
                case "1":
                    Console.Clear();
                    string Username = "0";
                    string passwort = "0";
                    using (var reader = new StreamReader("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Test.csv"))
                    {
                        Username = reader.ReadLine();
                        passwort = reader.ReadLine();

                    }

                    Console.WriteLine("Gebe deinen nutzernamen ein");
                    string Nuzername = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Gebe dein passwort ein");
                    Console.ForegroundColor = ConsoleColor.Black;
                    string Passwort = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    bool a = false;
                    while (a == false)
                    {
                        if (Nuzername == Username)
                        {
                            if (Passwort == passwort)
                            {
                                a = true;
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Dein Passwort ist falsch. Bitte versuche es erneut");
                                Thread.Sleep(2000);
                                a = false;
                                Passwort = Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Dein Nutzername ist falsch. Bitte wiederhole ihn");
                            Thread.Sleep(2000);
                            a = false;
                            Nuzername = Console.ReadLine();
                        }
                    }
                    return;
                case "2":
                    Console.Clear();
                    Fahrer f = new Fahrer();
                    f.Registrieren();
                    return;
            }
            
            
        }
        static void AuswahlFenster()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Was willst du machen?");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("1 : Fahrgemeinschaft finden?");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("2 : Fahrer werden");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("3 : Auflistunf der Bisherige Fahrer");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("4 : App verlassen");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Menue()
        {


        Hallo();
            
        Login();
        Start:
            AuswahlFenster();

            int a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case 1://Fahrersuche
                    Console.Clear();
                    List<Fahrer> fahrers = new List<Fahrer>
                    {
                        new Ferdinant("Ferdinat ", "Falschparker ", "Toyota Corolla ", "wkh", 1),
                        new Sara("Sara ", "Blond ", "Opel ", "mgh", 3)
                    };

                case1:
                    Console.WriteLine("Gebe dein Ziel Ort ein.");
                    string ort = Console.ReadLine();
                    Fahrer f = new Fahrer();
                    if (ort == "wkh")
                    {//Fahrersuche für Wikersheim
                        f.FahrersucheSara(ort);
                        Console.ForegroundColor = ConsoleColor.White;
                        goto Start;
                    }
                    else if (ort == "mgh")
                    {//Fahrersuche Bad Mergentheim
                        f.FahrersucheFerdinant(ort);
                        Console.ForegroundColor = ConsoleColor.White;
                        goto Start;

                    }
                    else
                    {//Wenn Das ZiehlOrt nicht existiert
                        Console.WriteLine($"Es wird nicht nach {ort} gefahren");
                        Thread.Sleep(2000);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        goto case1;
                    }
                case 2://Fahrer werden
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Clear();
                    List<Fahrer> fahrers1 = new List<Fahrer>
                    {
                        new Ferdinant("Ferdinat ", "Falschparker ", "Toyota Corolla ", "wkh", 1),
                        new Sara("Sara ", "Blond ", "Opel ", "mgh", 3)
                    };
                    //Vergewisserrung Fahrer zu werden
                    Console.WriteLine("Willst du auch ein mitglied der Fahrer App werden?");
                    Console.WriteLine("Dann schreibe y!");
                    if (Console.ReadLine() == "y")
                    {
                        Console.Clear();
                        Console.WriteLine("Willkommen um ein unser der app zu werden");
                        foreach (Fahrer fahre in fahrers1) { fahre.FahrerEdit(); break; }
                        goto Start;
                    }
                    else
                    {
                        goto Start;
                    }
                case 3://Fahrer Auflisten Die existieren und wann sie fahren
                    Fahrer f2 = new Fahrer();
                    f2.Write();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Thread.Sleep(5000);
                    goto Start;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
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
        static void Rgb()
        {
            WriteCharacterStrings(1, 1000, true);
        }

        private static void WriteCharacterStrings(int start, float end, bool changeColor)
        {
            for (int ctr = start; ctr <= end; ctr++)
            {
                if (changeColor)
                    Console.BackgroundColor = (ConsoleColor)((ctr - 1) % 16);
                //Thread.Sleep(100);
                Console.WriteLine("PENISPENISPENISPENISPENISPENISPENISPENISPENISPENISPENISPENISPENISPENISPENISPENISPENISPENISPENISPENISPENISPENISPENIS");
            }
            Console.ResetColor();
            Console.Clear();
        }



    }
}