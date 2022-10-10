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
using System.Xml.Schema;

namespace ConsoleApp1
{
    /// <summary>
    /// Alle nutzer in dieser App müssen diese Kriterien erfüllem
    /// </summary>
    public class Fahrer : FahrerInterface
    {
        /// <summary>
        /// File counter um die Länge einer csv Datein in einem int zu bekommen
        /// </summary>
        /// <param name="fileToCount"></param>
        /// <returns></returns>
        public static int CountLines(string fileToCount)
        {
            int counter = 0;
            using (StreamReader countReader = new StreamReader(fileToCount))
            {
                while (countReader.ReadLine() != null)
                {
                    counter++; 
                }
                return counter;
            }

        }
        /// <summary>
        /// Print für alle angemeldeten Fahrer
        /// </summary>
        public virtual void PrintOut()
        {
            Console.Clear();
            using (StreamReader sr = new StreamReader("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Fahrgemeinschaften.csv"))
            {
                int countEtries = 1;
                //int count = 0;
                while (CountLines("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Fahrgemeinschaften.csv") >= countEtries)
                {
                    if (countEtries % 6 >= 1)
                    {
                        Console.WriteLine();
                        countEtries++;
                    }
                    else
                    {
                        //                  Vorname             Nachname                    Fahrzeug                Ort                 Datum               Anzahl der Sitze    
                        Console.WriteLine($"{sr.ReadLine()} {sr.ReadLine()} fährt mit einem {sr.ReadLine()} nach {sr.ReadLine()} am {sr.ReadLine()} und hat {sr.ReadLine()} Plätze in seinem Gefährt.");
                        countEtries++;

                    }
                }

            }


        }//Schreibt alle Fahrer niede
        /// <summary>
        /// Zeigt den Nutzer das Auto an, mit dem er Fahren will
        /// </summary>
        public void BestimmteAutoSuche()
        {
            Console.Clear();
            using (StreamReader sr = new StreamReader("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Fahrgemeinschaften.csv"))
            {
                Console.WriteLine("Mit welchem Auto willst du unbedingt fahren?");
                string AusgewaeltesAuto = Console.ReadLine();
                int counter = 0;
                bool a = false;
                while (CountLines("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Fahrgemeinschaften.csv") >= counter)
                {
                    string preName = sr.ReadLine();
                    string lastname = sr.ReadLine();
                    string Fahrzeug = sr.ReadLine();
                    string Ort = sr.ReadLine();
                    string Zeit = sr.ReadLine();
                    string Sitzplaetze = sr.ReadLine();
                    if (AusgewaeltesAuto == Fahrzeug)
                    {
                        Console.WriteLine($"{preName} {lastname} fährt mit einem {Fahrzeug} nach {Ort} am {Zeit} und hat {Sitzplaetze} Plätze in seinem Auto frei");

                        counter++;
                        a = true;
                    }
                    else
                    {
                        //counter++;
                        if (CountLines("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Fahrgemeinschaften.csv") == counter)
                        {
                            if (a == false)
                            {
                                Console.WriteLine("Keiner fährt mit einem " + AusgewaeltesAuto);
                                counter++;

                            }
                            else { counter++; }
                        }
                        else { counter++; }
                    }
                }

            }

            Thread.Sleep(7000);
        }//Sucht von allen Autos ein Bestimmtes herraus
        /// <summary>
        /// Property um Fahrer hinzu zu fügen um ein Fahrere zu werden
        /// </summary>
        public void FahrerEdit()
        {//Method to add the User as a driver
            string b = "0";
            using (StreamReader sr = new StreamReader("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Fahrgemeinschaften.csv"))//Alte UserInfo kopieren
            {
                b = sr.ReadToEnd();
            }

            using (StreamWriter sw = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Fahrgemeinschaften.csv"))
            {//Neue UserInfo bekommen

                Console.WriteLine("Gebe deinen Vornamen ein");
                sw.WriteLine(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Gebe deinen Nachnamen ein");
                sw.WriteLine(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Gebe dein Auto ein");
                sw.WriteLine(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Gebe an wo hin du hinfährst");
                sw.WriteLine(Console.ReadLine());
                Console.WriteLine("Gebe an wann du Fährst(eine Angabe)");
                sw.WriteLine(Console.ReadLine());
                Console.WriteLine("Gebe an wie viele Sitzplätze dein Auto hat");
                sw.WriteLine(Console.ReadLine());
                sw.WriteLine(b);//Alter UserInfo hinzufügen
            }



            Console.WriteLine("Deine Daten wurden erfolgreich hinzugefügt.");
            Console.WriteLine("Du bist jezt ein Teil der App");
        }//Fahrer werden option
        /// <summary>
        /// Anmelde Daten vom Nutzer werden geändert
        /// </summary>
        public void AenderrungVomAccount()
        {
            Console.Clear();
            Console.WriteLine("Was willst du ändern?");
            Console.WriteLine("u/p");
            string a = Convert.ToString(Console.ReadKey().KeyChar);
            int counter = 0;
            string ListeUsername = "0";
            string ListePasswort = "0";
            string alteListe = "0";
            switch (a)
            {
                case "u":
                    Console.WriteLine("Gebe dein alten Username ein");
                    string username = Console.ReadLine();
                    Console.Clear();
                    while (CountLines("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Passwoerter.csv") >= counter)
                    {
                        using (StreamReader sr = new StreamReader("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Passwoerter.csv"))
                        {
                            
                            ListeUsername = sr.ReadLine();
                            ListePasswort = sr.ReadLine();
                            if (username != ListeUsername)
                            {
                                ListeUsername = sr.ReadLine();
                                Console.WriteLine("Usernamen stimmen nicht überein");
                                counter++;
                            }
                            else
                            {
                                alteListe = sr.ReadToEnd();
                            }

                        }

                        if (username == ListeUsername)
                        {
                            using (StreamWriter sw = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Passwoerter.csv"))
                            {
                                Console.WriteLine("Gebe deinen neuen Username ein");
                                string newUsername = Console.ReadLine();
                                sw.WriteLine(newUsername);
                                sw.WriteLine(ListePasswort);
                                sw.WriteLine(alteListe);
                                counter = 100000;
                                Console.ReadLine();
                            }
                        }
                        
                    }


                    return;
                case "p":
                    Console.WriteLine("Gebe dein alten Username ein");
                    string Passwort = Console.ReadLine();
                    Console.Clear();

                    while (CountLines("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Passwoerter.csv") >= counter)
                    {
                        using (StreamReader sr = new StreamReader("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Passwoerter.csv"))
                        {

                            ListeUsername = sr.ReadLine();
                            ListePasswort = sr.ReadLine();
                            if (Passwort != ListePasswort)
                            {
                                ListePasswort = sr.ReadLine();
                                Console.WriteLine("Usernames stimmen nicht überein");
                                counter++;
                            }
                            else
                            {
                                alteListe = sr.ReadToEnd();
                            }

                        }

                        if (Passwort == ListeUsername)
                        {
                            using (StreamWriter sw = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Passwoerter.csv"))
                            {
                                Console.WriteLine("Gebe deinen neuen Username ein");
                                string newUsername = Console.ReadLine();
                                sw.WriteLine(newUsername);
                                sw.WriteLine(ListePasswort);
                                sw.WriteLine(alteListe);
                                counter = 100000;
                                Console.ReadLine();
                            }
                        }

                    }
                    return;
                default:
                    Console.WriteLine("Du hast was falsches eingegeben...");
                    Console.WriteLine("deswegen wirst du zur Startseite weiter geleitet.");
                    return;

            }
        }
        /// <summary>
        /// Anlegen eines neues Accounts, falls noch keins vorhanden ist.
        /// </summary>
        public void Registrieren()//Anlegen eines neuen Accounts
        {
            Console.Clear();
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
            string VohrerigeCSV = "0";
            using (StreamReader sr = new StreamReader("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Passwoerter.csv"))
            {
                VohrerigeCSV = sr.ReadToEnd();
            }
            using (StreamWriter sr = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Passwoerter.csv"))
            {
                sr.WriteLine(Username);
                sr.WriteLine(Passwort);
                sr.WriteLine(VohrerigeCSV);
            }

        }
        /// <summary>
        /// Datenschutzt von Fortnite
        /// </summary>
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
        /// <summary>
        /// Fahrgemeinschaften werden hier in einer CSV Datei niedergeschrieben
        /// </summary>
        /// <param name="preName"></param>
        /// <param name="lastname"></param>
        /// <param name="ZielZeit"></param>
        /// <param name="Fahrzeug"></param>
        /// <param name="prenameMitfahrer"></param>
        /// <param name="lastnameMitfahrer"></param>
        public void FahrersucheListeAdd(string preName, string lastname, string ZielZeit, string Fahrzeug, string prenameMitfahrer, string lastnameMitfahrer)
        {
            Console.WriteLine($"willst du mit {preName} {lastname} in einem {Fahrzeug} mitfahren?");
            Console.WriteLine("y/n");
            if (Convert.ToString(Console.ReadKey().KeyChar) == "y")
            {
                string copiedItems = "0";
                Console.WriteLine($"Du darfst mit {preName} {lastname} am {ZielZeit} in einem {Fahrzeug} fahren");
                using (StreamReader sr2 = new StreamReader("C:\\010Projects\\Linq\\Fahrgemeinschaft\\GefundeneFahrgemeinschaften.csv"))
                {
                    copiedItems = sr2.ReadToEnd();

                }
                using (StreamWriter sw2 = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\GefundeneFahrgemeinschaften.csv"))
                {
                    sw2.WriteLine($"{prenameMitfahrer} {lastnameMitfahrer} ist der Beifahrer von {preName} {lastname} am {ZielZeit} in einem {Fahrzeug} fahren");
                    sw2.WriteLine(copiedItems);
                }
            }
            else
            {
                Console.WriteLine("Du wirst nicht hinzugefügt. Drücke die Entertaste um wieder zum Auswahlfenster zu kommen");
            }

        }
        /// <summary>
        /// Fahrgemeinschaften werden gebildet
        /// </summary>
        public void Fahrersuche2()
        {
            using (StreamReader sr = new StreamReader("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Fahrgemeinschaften.csv"))
            {
                Console.WriteLine("Gebe deinen Vornamen ein");
                string prenameMitfahrer = Console.ReadLine();
                Console.WriteLine("gebe deinen Nachnamen ein");
                string lastnameMitfahrer = Console.ReadLine();
                Console.WriteLine("Wo willst du hin?");
                string ZielOrt = Console.ReadLine();
                Console.WriteLine("Wann willst du dahin?");
                string ZielZeit = Console.ReadLine();
                Console.WriteLine("Wie viele seid ihr?");
                int AnzahlMitfahrer = Convert.ToInt32(Console.ReadLine());
                int counterForLines = CountLines("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Fahrgemeinschaften.csv");
                int counter = 1;
                while (counter < counterForLines)
                {
                   
                    if (counter % 4 == 1)
                    {//Einlesung der verschiedenen Einträge durch überschreiben.
                        string preName = sr.ReadLine();
                        string lastname = sr.ReadLine();
                        string Fahrzeug = sr.ReadLine();
                        string Ort = sr.ReadLine();
                        string Zeit = sr.ReadLine();
                        int Sitzplaetze = Convert.ToInt32(sr.ReadLine());
                        if (ZielOrt == Ort)
                        {
                            if (ZielZeit == Zeit)
                            {
                                if (AnzahlMitfahrer <= Sitzplaetze)
                                {
                                    FahrersucheListeAdd(preName, lastname, ZielZeit, Fahrzeug, prenameMitfahrer, lastnameMitfahrer);
                                }
                                else
                                {
                                    Console.WriteLine($"Es fährt keiner zu dieser Zeit");
                                }
                            }
                            else
                            {
                                //Console.WriteLine($"Es fährt keiner zu dieser Zeit");
                            }

                        }
                        else
                        {
                        }
                        counter++;
                    }
                    else
                    {
                        counter++;
                    }

                }
                
                //Console.ReadLine();

            }
        }
        /// <summary>
        /// Fahrgemeinschaften werden afugelistet
        /// </summary>
        public void FahrgemeinschaftPrint()
        {
            Console.Clear();
            using (StreamReader sr = new StreamReader("C:\\010Projects\\Linq\\Fahrgemeinschaft\\GefundeneFahrgemeinschaften.csv"))
            {
                int countEtries = 0;
                //int count = 0;

                while (CountLines("C:\\010Projects\\Linq\\Fahrgemeinschaft\\GefundeneFahrgemeinschaften.csv") >= countEtries)
                {
                    Console.WriteLine(sr.ReadLine());
                    Console.WriteLine();
                    countEtries++;
                }
            }
        }
        /// <summary>
        /// Anmeldung von dem User, wenn er schon ein Account hat
        /// </summary>
        public void Anmelden()
        {
            Console.Clear();
        UsernameCheck:
            int count = 0;
            int a = 0;
            int b = 1000;
            string UsernameListe = "0";
            string PasswortListe = "0";

            using (StreamReader sr = new StreamReader("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Passwoerter.csv"))
            {
                while (CountLines("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Passwoerter.csv") >= count)
                {
                    UsernameListe = sr.ReadLine();
                    Console.WriteLine("gebe dein Username ein");
                    string Username = Console.ReadLine();
                    while (Username != UsernameListe)
                    {
                        if (Username == UsernameListe)
                        {
                            UsernameListe = Username;
                        }
                        else
                        {
                            if (a <= b)
                            {
                                UsernameListe = sr.ReadLine();
                                a++;
                            }
                            else
                            {
                                Console.WriteLine("Nutzername ist falsch");
                                goto UsernameCheck;
                            }
                        }


                    }


                    if (Username == UsernameListe)
                    {
                        PasswortListe = sr.ReadLine();
                    PasswortCheck:
                        Console.WriteLine("gebe dein Passwort ein");
                        Console.ForegroundColor = ConsoleColor.Black;
                        string Passwort = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        if (Passwort == PasswortListe)
                        {
                            Console.WriteLine("Dein Passwort ist richtig");
                            count = 100000;
                        }
                        else
                        {
                            goto PasswortCheck;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Dein Username ist falsch");
                        goto UsernameCheck;
                    }
                }
            }


        }
    }
}