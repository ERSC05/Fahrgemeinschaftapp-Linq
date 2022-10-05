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
    public class Fahrer : FahrerInterface
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
            Console.WriteLine($"Bastian Nachnamiii Fährt nach: Kaufland");

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
        }//Öffnung bei Kaufland1
        public void BestimmteAutoSuche()
        {
            Console.WriteLine("Mit welchem Auto willst du unbedingt Fahren?");
            string AusgewaeltesAuto = Console.ReadLine();
            if (AusgewaeltesAuto == "Toyota")
            {
                Console.WriteLine("Ferdinant fährt nach Weikersheim mit einem " + AusgewaeltesAuto);
            }
            else if (AusgewaeltesAuto == "Opel")
            {
                Console.WriteLine("Sara fährt nach Bad Mergentheim mit einem " + AusgewaeltesAuto);
            }
            else if (AusgewaeltesAuto == "Lambo")
            {
                Console.WriteLine("Bastian färt nach Kaufland mit einem " + AusgewaeltesAuto);
            }
            else
            {
                Console.WriteLine("Keiner färt mit einem " + AusgewaeltesAuto);
            }
            Thread.Sleep(2000);
        }//Sucht von allen Autos ein Bestimmtes herraus
        public void CarPool()
        {
            Console.WriteLine("Ferdinant fährt nach Bad Mergentheim mit einem TOYOTA");
            Console.WriteLine("Sara fährt nach Weikersheim mit einem OPEL");
            Console.WriteLine("Bastian fährt nach Kaufland mit einem LAMBO");
            Thread.Sleep(5000);
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
            string nutzerInfo = Uvorname + " " + Unachname + " " + UCartype + " " + ZiehlOrt + " " + splaetze;
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

            FileStream inStream = new FileStream("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Test.csv", FileMode.Open, FileAccess.Read, FileShare.None);
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
        {

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
            string VohrerigCSV = "0";
            using (StreamReader sr = new StreamReader("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Test.csv"))
            {
                VohrerigCSV = sr.ReadToEnd();
            }
            using (StreamWriter sr = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Test.csv"))
            {
                sr.Write(Username);
                sr.Write(Passwort);
                //sr.WriteLine();
                sr.WriteLine(VohrerigCSV);
            }

        }
        public void Datenschutz()
        {
            Console.Clear();
            Console.WriteLine("2. WELCHE DATEN ERFASSEN WIR?\r\n\n" +
                "Die Arten der von uns erfassten Daten hängt von Ihrer Interaktion mit uns ab. Im Allgemeinen erfassen wir Daten auf drei Hauptarten:\n" +
                "A) wenn Sie uns diese zur Verfügung stellen,\n" +
                "B) automatisch, wenn Sie die Epic-Dienste nutzen, und\n" +
                "C) von Dienstleistungsanbietern und Drittparteien.\r\n\r\n          " +
                "A. Von Ihnen bereitgestellte Informationen\r\n\r\nSie können uns verschiedene Arten von Informationen zur Verfügung stellen, \n" +
                "abhängig davon, wie Sie mit den Epic-Diensten interagieren. Manchmal bitten wir Sie um die Bereitstellung bestimmter Informationen, \n" +
                "beispielsweise, wenn wir diese benötigen, um Ihnen Teile der Epic-Dienste zur Verfügung zu stellen (zum Beispiel, wenn wir Sie auffordern,\n" +
                " einen Online-Registrierungsprozess abzuschließen). Wenn wir Sie in diesen Fällen um die Bereitstellung von Informationen bitten und Sie \n" +
                "sich weigern, uns diese zur Verfügung zu stellen, können Sie möglicherweise nicht auf die entsprechenden Epic-Dienste zugreifen und/oder\n" +
                "einige Funktionen funktionieren unter Umständen nicht wie vorgesehen.\r\n\r\nUm beispielsweise im Epic Games Store einkaufen und manche\n" +
                " unserer Spiele spielen zu können, benötigen Sie ein Epic-Konto. Um ein solches zu erstellen, müssen Sie uns grundlegende Registrierungsdaten \n" +
                "wie Ihren Namen, einen öffentlich sichtbaren Anzeigenamen, ein Passwort, das Land, in dem Sie leben, und Ihre E-Mail-Adresse zur Verfügung stellen.\n" +
                "Wenn Sie einen Kauf tätigen möchten, bitten wir Sie möglicherweise um zahlungsbezogene Informationen (wie Ihre Kreditkartennummer und das Ablaufdatum), \n" +
                "um die Transaktion abschließen zu können.\r\n\r\nWir erfassen auch die Informationen, die Sie freiwillig zur Verfügung stellen, um sich \n" +
                "für E-Mail-Benachrichtigungen anzumelden, soziale Funktionen wie Foren oder Chats zu nutzen, sich für einen frühzeitigen Zugriff auf unsere Spiele zu \n" +
                "registrieren, unsere Entwickler-Tools zu nutzen (einschließlich der Erstellung und Veröffentlichung von Spielen und anderen Inhalten), Umfragen auszufüllen \n" +
                "oder uns über Spieler-Support-Anfragen oder den Kundendienst zu kontaktieren. Wenn Sie an einem Wettbewerb, einer wettbewerbsorientierten Veranstaltung,\n" +
                " oder an unserem Programm Support-A-Creator teilnehmen, erfassen wir Ihre Antragsinformationen und andere Informationen, die wir benötigen, um Ihre \n" +
                "Berechtigung zu bestätigen und Auszahlungen zu bearbeiten. Wir erfassen jegliche Informationen, die Sie uns in diesen oder ähnlichen Fällen zur Verfügung stellen." +
                "2. WELCHE DATEN ERFASSEN WIR?\r\n\n" +
                "Die Arten der von uns erfassten Daten hängt von Ihrer Interaktion mit uns ab. Im Allgemeinen erfassen wir Daten auf drei Hauptarten:\n" +
                "A) wenn Sie uns diese zur Verfügung stellen,\n" +
                "B) automatisch, wenn Sie die Epic-Dienste nutzen, und\n" +
                "C) von Dienstleistungsanbietern und Drittparteien.\r\n\r\n          " +
                "A. Von Ihnen bereitgestellte Informationen\r\n\r\nSie können uns verschiedene Arten von Informationen zur Verfügung stellen, \n" +
                "abhängig davon, wie Sie mit den Epic-Diensten interagieren. Manchmal bitten wir Sie um die Bereitstellung bestimmter Informationen, \n" +
                "beispielsweise, wenn wir diese benötigen, um Ihnen Teile der Epic-Dienste zur Verfügung zu stellen (zum Beispiel, wenn wir Sie auffordern,\n" +
                " einen Online-Registrierungsprozess abzuschließen). Wenn wir Sie in diesen Fällen um die Bereitstellung von Informationen bitten und Sie \n" +
                "sich weigern, uns diese zur Verfügung zu stellen, können Sie möglicherweise nicht auf die entsprechenden Epic-Dienste zugreifen und/oder\n" +
                "einige Funktionen funktionieren unter Umständen nicht wie vorgesehen.\r\n\r\nUm beispielsweise im Epic Games Store einkaufen und manche\n" +
                " unserer Spiele spielen zu können, benötigen Sie ein Epic-Konto. Um ein solches zu erstellen, müssen Sie uns grundlegende Registrierungsdaten \n" +
                "wie Ihren Namen, einen öffentlich sichtbaren Anzeigenamen, ein Passwort, das Land, in dem Sie leben, und Ihre E-Mail-Adresse zur Verfügung stellen.\n" +
                "Wenn Sie einen Kauf tätigen möchten, bitten wir Sie möglicherweise um zahlungsbezogene Informationen (wie Ihre Kreditkartennummer und das Ablaufdatum), \n" +
                "um die Transaktion abschließen zu können.\r\n\r\nWir erfassen auch die Informationen, die Sie freiwillig zur Verfügung stellen, um sich \n" +
                "für E-Mail-Benachrichtigungen anzumelden, soziale Funktionen wie Foren oder Chats zu nutzen, sich für einen frühzeitigen Zugriff auf unsere Spiele zu \n" +
                "registrieren, unsere Entwickler-Tools zu nutzen (einschließlich der Erstellung und Veröffentlichung von Spielen und anderen Inhalten), Umfragen auszufüllen \n" +
                "oder uns über Spieler-Support-Anfragen oder den Kundendienst zu kontaktieren. Wenn Sie an einem Wettbewerb, einer wettbewerbsorientierten Veranstaltung,\n" +
                " oder an unserem Programm Support-A-Creator teilnehmen, erfassen wir Ihre Antragsinformationen und andere Informationen, die wir benötigen, um Ihre ");
        }
        public void Fahrgemeinschaften()
        {
            string path = "C:\\010Projects\\Linq\\Fahrgemeinschaft\\Fahrgemeinschaften.csv";
            string NutzerSara = "0";
            string NutzerFerdinant = "0";
            string NutzerBastian = "0";
            using (StreamReader sr = File.OpenText(path))
            {
                
                NutzerFerdinant = sr.ReadLine();
                NutzerSara = sr.ReadLine();
                NutzerBastian = sr.ReadLine();
                Console.ReadLine();
            }

        }




    }
}
