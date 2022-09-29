using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Fahrer> fahrers = new List<Fahrer>();
            fahrers.Add(new Ferdinant("Ferdinat ", "Falschparker ", "Toyota Corolla ", "Weikersheim", 1));
            fahrers.Add(new Sara("Sara ", "Blond ", "Opel ", "mgh", 3));
            
            Menue();
            Console.ReadLine();
        }
        static void Fahrersucher()
        {

        }
        static void Menue()
        {
        Start:
            Console.WriteLine("Hallo, und willkomme zu der Fahrgemeinschaft App!!!\n\n\n");
            Thread.Sleep(2000);
            Console.Clear();
            //login();
            Console.WriteLine("Was willst du machen?");
            Console.WriteLine("1 : Fahrgemeinschaft finden?");
            Console.WriteLine("2 : Fahrer werden");
            Console.WriteLine("3 : Auflistunf der Bisherige Fahrer");

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
                    }
                    else if (ort == "mgh")
                    {
                        f.FahrersucheFerdinant(ort);
                    
                    }
                    else
                    {
                        Console.WriteLine($"Es wird nicht nach {ort} gefahren");
                        Thread.Sleep(2000);
                        Console.Clear();
                        goto case1;
                    }
                    return;
                case 2:
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
                    return;
                case 3:
                    Console.Clear();
                    List<Fahrer> fahrers2 = new List<Fahrer>();
                    fahrers2.Add(new Ferdinant("Ferdinat ", "Falschparker ", "Toyota Corolla ", "wkh", 1));
                    fahrers2.Add(new Sara("Sara ", "Blond ", "Opel ", "mgh", 3));
                    foreach (Fahrer fahre in fahrers2)
                    {
                        Console.WriteLine(fahre);
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
        static void login()
        {
            Console.WriteLine("Gebe deinen nutzernamen ein");
            string Nuzername = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Gebe dein passwort ein");
            string Passwort = Console.ReadLine();
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
        static string FahrerSuche(Ferdinant ferdinant, string zort, int sfrei)
        {
            Console.Clear();
            string f = "0";
            if (zort == "Weikersheim")
            {
                if (sfrei <= 3)
                {
                    Console.WriteLine("Wann willst du fahren?");

                    string wann = Console.ReadLine();
                    if (wann == "morgen")
                    {
                        Console.WriteLine("Morgen kannst du mit sagra fahren");
                        Console.WriteLine("Sara hat 3 sitze frei, du darfst also mitfahren");
                        Console.WriteLine("Du darfst mit Sara fahren");
                    }
                    else
                    {
                        Console.WriteLine("Sara färt nur morgen. Du darfst also nicht fahren");
                    }


                }
                else
                {

                    Console.WriteLine("Sara hat nur 3 Sitze.\n" +
                                     "Du darfst also nicht mitfahren.");
                }

            }
            else
            {
                Console.WriteLine("Du darfst nicht mit fahren, da keiner deine strecke färht");

            }
            return f;

        }


    }
}