using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace ConsoleApp1
{
    public class Fahrer     : FahrerInterface
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CarType { get; set; }
        public string ZielOrt { get; set; }
        public int Sitzplaetze { get; set; }
        public virtual void Write()
        {
            Console.WriteLine($"Sara Blond Fährt nach: Weikersheim");
            Console.WriteLine($"Ferdinant Falschparker Fährt nach: Bad Mergentheim");
        }//Schreibt alle Fahrer nieder
        public virtual void FahrersucheSara(string ort)
        {//Method to add the driver sara
            Console.Clear();
            //Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("gebe ein wieviel du mitnehmen willst");
            int sitzplaetze = Convert.ToInt32(Console.ReadLine());
            if (sitzplaetze <= 3)
            {
                Console.WriteLine("Wann willst du fahren?");


                string wann = Console.ReadLine();
                if (wann == "morgen")
                {
                    Console.WriteLine($"{wann} kannst du mit Sara Blond fahren");
                    Thread.Sleep(2000);
                    Console.WriteLine("Du wirst wieder zur Haubtseite weitergeleitet");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                
                else if (wann == "Montag")
                {
                    Console.WriteLine($"{wann} kannst du mit Sara Blond fahren");
                    Thread.Sleep(2000);
                    Console.WriteLine("Du wirst wieder zur Haubtseite weitergeleitet");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else if (wann == "in einer Woche")
                {
                    Console.WriteLine($"{wann} kannst du mit Sara Blond fahren");
                    Thread.Sleep(2000);
                    Console.WriteLine("Du wirst wieder zur Haubtseite weitergeleitet");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else if (wann == "Freitag")
                {
                    Console.WriteLine($"{wann} kannst du mit Sara Blond fahren");
                    Thread.Sleep(2000);
                    Console.WriteLine("Du wirst wieder zur Haubtseite weitergeleitet");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else if (wann == "in einem Monat")
                {
                    Console.WriteLine($"{wann} kannst du mit Sara Blond fahren");
                    Thread.Sleep(2000);
                    Console.WriteLine("Du wirst wieder zur Haubtseite weitergeleitet");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine($"Sara färt nicht {wann}. Du darfst also nicht fahren");
                    Thread.Sleep(2000);
                    Console.WriteLine("Du wirst wieder zur Haubtseite weitergeleitet");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            else
            {

                Console.WriteLine($"Sara hat nur 3 Sitze frei. Also kannst du nicht mitfahren.");
                Thread.Sleep(2000);
                Console.WriteLine("Du wirst wieder zur Haubtseite weitergeleitet");
                Thread.Sleep(2000);
                Console.Clear();

            }

        }//Öfnung bei whk
        public virtual void FahrersucheFerdinant(string ort)
        {//Mehtod for the Driver "Ferdinant"
            Console.Clear();
            if (ort == "mgh")
            {
                Console.WriteLine("gebe ein wieviel du mitnehmen willst");
                int sitzplaetze = Convert.ToInt32(Console.ReadLine());
                if (sitzplaetze <= 1)
                {
                    Console.WriteLine("Wann willst du fahren?");


                    string wann = Console.ReadLine();
                    if (wann == "morgen")
                    {
                        Console.WriteLine($"Morgen kannst du mit Ferdinant fahren");
                        Thread.Sleep(2000);
                        Console.WriteLine("Du wirst wieder zur Haubtseite weitergeleitet");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                    else if (wann == "heute")
                    {
                        Console.WriteLine("Heute kannst du mit Ferdinant fahren");
                        Thread.Sleep(2000);
                        Console.WriteLine("Du wirst wieder zur Haubtseite weitergeleitet");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine($"Ferdinant färt nicht {wann}. Du darfst also nicht fahren");
                        Thread.Sleep(2000);
                        Console.WriteLine("Du wirst wieder zur Haubtseite weitergeleitet");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }


                }
                else
                {

                    Console.WriteLine($"Ferdinant hat nur 1 Sitze frei also kannst du nicht mitfahren.");
                    Thread.Sleep(2000);
                    Console.WriteLine("Du wirst wieder zur Haubtseite weitergeleitet");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine($"Du darfst nicht mit mitfahren fahren");
                Thread.Sleep(2000);
                Console.WriteLine("Du wirst wieder zur Haubtseite weitergeleitet");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }//Öffnung bei mgh
        public virtual void FahrersucheBastian(string ort)
        {//Mehtod for the Driver "Ferdinant"
            Console.Clear();
            if (ort == "Kaufland")
            {
                Console.WriteLine("gebe ein wieviel du mitnehmen willst");
                int sitzplaetze = Convert.ToInt32(Console.ReadLine());
                if (sitzplaetze <= 10)
                {
                    Console.WriteLine("Wann willst du fahren?");


                    string wann = Console.ReadLine();
                    if (wann == "morgen")
                    {
                        Console.WriteLine($"Morgen kannst du mit Bastian fahren");
                        Thread.Sleep(2000);
                        Console.WriteLine("Du wirst wieder zur Haubtseite weitergeleitet");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                    else if (wann == "heute")
                    {
                        Console.WriteLine("Heute kannst du mit Bastian fahren");
                        Thread.Sleep(2000);
                        Console.WriteLine("Du wirst wieder zur Haubtseite weitergeleitet");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine($"Bastian färt nicht {wann}. Du darfst also nicht fahren");
                        Thread.Sleep(2000);
                        Console.WriteLine("Du wirst wieder zur Haubtseite weitergeleitet");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }


                }
                else
                {

                    Console.WriteLine($"Bastian hat nur 10 Sitze frei also kannst du nicht mitfahren.");
                    Thread.Sleep(2000);
                    Console.WriteLine("Du wirst wieder zur Haubtseite weitergeleitet");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine($"Du darfst nicht mit mitfahren fahren");
                Thread.Sleep(2000);
                Console.WriteLine("Du wirst wieder zur Haubtseite weitergeleitet");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
        public void BestimmteAutoSuche()
        {
            Console.WriteLine("Mit welchem Auto willst du unbedingt Fahren?");
            string AusgewaeltesAuto = Console.ReadLine();
            if (AusgewaeltesAuto == "Toyota")
            {
                Console.WriteLine("Ferdinant fährt nach Weikersheim mit einem "+AusgewaeltesAuto);
            }
            else if (AusgewaeltesAuto == "Opel")
            {
                Console.WriteLine("Sara fährt nach Bad Mergentheim mit einem "+AusgewaeltesAuto);
            }
            else if (AusgewaeltesAuto == "Lambo")
            {
                Console.WriteLine("Bastian färt nach Kaufland mit einem "+AusgewaeltesAuto);
            }
            else
            {
                Console.WriteLine("Keiner färt mit einem "+AusgewaeltesAuto);
            }
            Thread.Sleep(2000);
        }
        public void FahrerEdit()
        {//Method to add the User as a driver
            string path = @"C:\010Projects\Linq\Fahrgemeinschaft\UserEigenschaft.csv";
            Console.WriteLine("Gib deinen vornamen ein");
            string Uvorname = Console.ReadLine();

            Console.WriteLine("Gib deinen Nachnamen ein");
            string Unachname = Console.ReadLine();
            Console.WriteLine("Gib dein Auto ein");
            string UCartype = Console.ReadLine();
            Console.WriteLine("Gib dien Ziel Ort ein");
            string ZiehlOrt = Console.ReadLine();
            Console.WriteLine("Gib ein wieviele Sitzplätze du hast");
            string splaetze = Console.ReadLine();
            string nutzerInfo = Uvorname+" "+Unachname+" "+UCartype+" "+ZiehlOrt+ " "+splaetze;
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(nutzerInfo);
                sw.WriteLine();
                
            }
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
            Console.WriteLine("Deine Daten wurden erfolgreich hinzugefügt.\n" +
                "               Du bist jezt ein Teil der App");

        }//Fahrer werden option
        public void Copy()
        {
            Console.WriteLine("File Copying...");

            FileStream inStream = new FileStream("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Test.csv", FileMode.Open, FileAccess.Read,FileShare.None);
            FileStream outStram = new FileStream("C:\\010Projects\\Linq\\Fahrgemeinschaft\\TestCopy.csv", FileMode.Create, FileAccess.Write, FileShare.Read);

            using (inStream)
            {
                while (true)
                {
                    int b = inStream.ReadByte();
                    if (b == -1)
                        break;
                    outStram.WriteByte((byte)b);
                }
            }
            Console.WriteLine("File Copied...");
        }//File1 auf File2 Copieren
        public void Registrieren()//Anlegen eines neuen Accounts
        {//Wenn anmendung nicht geht, Datei muss existieren mit mindestens einem Username und einem Passwort.

            Copy();
            string path = "C:\\010Projects\\Linq\\Fahrgemeinschaft\\Test.csv";
            
            System.IO.StreamWriter objWriter;

            objWriter = new System.IO.StreamWriter(path);

            String[] ArrayDetails = new string[2];
        start:
            Console.Write("Enter Username: ");
            string Username = Console.ReadLine();
            
            Console.Write("Enter Passwort: ");
            string Passwort = Console.ReadLine();
            Console.WriteLine("Wiederhole dein Passwort: ");
            string PasswortKontrolle = Console.ReadLine();
            if (Passwort == PasswortKontrolle)
            {
                Console.WriteLine("Dein Passwort ist richtig");
            }
            else
            {
                Console.WriteLine("Passwörter stimmen nicht über ein");
                goto start;
            }

            //List<string> LDetails = new List<string>(); // Create new list of strings
            //LDetails.Add(Username); // Add string 1
            //LDetails.Add(Passwort); // 2
            //string LDetailsCSV = string.Join(",", LDetails.ToArray());
            //Console.WriteLine(LDetailsCSV);
            objWriter.WriteLine(Username);
            objWriter.WriteLine(Passwort);
            objWriter.Close();

        }

        


    }
}
