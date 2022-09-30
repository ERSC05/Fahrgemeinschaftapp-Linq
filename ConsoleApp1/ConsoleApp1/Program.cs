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

            List<Fahrer> fahrers = new List<Fahrer>();
            fahrers.Add(new Ferdinant("Ferdinat ", "Falschparker ", "Toyota Corolla ", "wkh", 1));
            fahrers.Add(new Sara("Sara ", "Blond ", "Opel ", "mgh", 3));
            Menue();

            Console.ReadLine();
        }
        static void Hallo()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;




            Console.WriteLine("**        **          ****           **            **                 ***       ");
            Console.WriteLine("**        **         **  **          **            **              ***   ***    ");
            Console.WriteLine("**        **        **    **         **            **             ***     ***   ");
            Console.WriteLine("************       **      **        **            **             **        **  ");
            Console.WriteLine("************      **        **       **            **             **        **  ");
            Console.WriteLine("**        **     ***************     **            **             ***      **   ");
            Console.WriteLine("**        **    **             **    ***********   ***********      ***  ***    ");
            Console.WriteLine("**        **   **               **   ***********   ***********        ****      ");
            Console.ForegroundColor = ConsoleColor.White;





        }
        static void Login()
        {
            Console.WriteLine("Gebe deinen nutzernamen ein");
            Console.ForegroundColor = ConsoleColor.Black;
            string Nuzername = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("Gebe dein passwort ein");
            Console.ForegroundColor = ConsoleColor.Black;
            string Passwort = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            bool a = false;
            while (a == false)
            {
                if (Nuzername == "ERSC")
                {
                    if (Passwort == "Passwort")
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
        }
        static void Menue()
        {


            Hallo();
            Console.WriteLine("und willkomme zu der Fahrgemeinschaft App!!!\n\n\n");
            Thread.Sleep(2000);
            Console.Clear();
            Login();
        Start:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Was willst du machen?");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("1 : Fahrgemeinschaft finden?");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("2 : Fahrer werden");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("3 : Auflistunf der Bisherige Fahrer");
            Console.ForegroundColor = ConsoleColor.White;

            int a = Convert.ToInt32(Console.ReadLine());
            

            switch (a)
            {
                case 1:
                    Console.Clear();
                    List<Fahrer> fahrers = new List<Fahrer>();
                    fahrers.Add(new Ferdinant("Ferdinat ", "Falschparker ", "Toyota Corolla ", "wkh", 1));
                    fahrers.Add(new Sara("Sara ", "Blond ", "Opel ", "mgh", 3));

                case1:
                    Console.WriteLine("Gebe dein Ziel Ort ein.");
                    string ort = Console.ReadLine();
                    Fahrer f = new Fahrer();
                    if (ort == "wkh")
                    {
                        f.FahrersucheSara(ort);
                        Console.ForegroundColor = ConsoleColor.White;
                        goto Start;
                    }
                    else if (ort == "mgh")
                    {
                        f.FahrersucheFerdinant(ort);
                        Console.ForegroundColor = ConsoleColor.White;
                        goto Start;

                    }
                    else
                    {
                        Console.WriteLine($"Es wird nicht nach {ort} gefahren");
                        Thread.Sleep(2000);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        goto case1;
                    }
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Clear();
                    List<Fahrer> fahrers1 = new List<Fahrer>();
                    fahrers1.Add(new Ferdinant("Ferdinat ", "Falschparker ", "Toyota Corolla ", "wkh", 1));
                    fahrers1.Add(new Sara("Sara ", "Blond ", "Opel ", "mgh", 3));

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
                case 3:
                    Fahrer f2 = new Fahrer();
                    f2.Write();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    
                    
                        goto Start;

                    
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Du hast etwas falsches getrückt. Du wirst zum start weitergeleitet");
                    Thread.Sleep(3000);
                    Console.Clear();
                    goto Start;


            }


        }
        static void rgb()
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