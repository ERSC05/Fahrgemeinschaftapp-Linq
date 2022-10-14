using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;

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
        private static int CountLines(string fileToCount)
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
        public void PrintOut()
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
                        int a = 0;
                        if (a % 2 == 2)
                        {
                            int b = 0;
                            if (b % 2 == 2)
                                Console.WriteLine();
                            else { b++; }

                        }
                        else { a++; }
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

        //Neue UserInfo bekommen
        start:
            Console.WriteLine("Gebe deinen Vornamen ein");
            string c = Console.ReadLine();
            Console.Clear();

            if (c == "")
            {
                Console.WriteLine("Deine Angebe ist Leer!!!");
                Thread.Sleep(1000);
                Console.Clear();
                goto start;
            }
            else
            { Console.Clear(); }
            Console.WriteLine("Gebe deinen Nachnamen ein");
            string d = Console.ReadLine();
            Console.Clear();

            if (d == "")
            {
                Console.WriteLine("Deine Angebe ist Leer!!!");
                Thread.Sleep(1000);
                Console.Clear();
                goto start;
            }
            else
            { Console.Clear(); }
            Console.WriteLine("Gebe dein Auto ein");
            string e = Console.ReadLine();
            Console.Clear();

            if (e == "")
            {
                Console.WriteLine("Deine Angebe ist Leer!!!");
                Thread.Sleep(1000);
                Console.Clear();
                goto start;
            }
            else
            { Console.Clear(); }
            Console.WriteLine("Gebe an wo hin du hinfährst");
            string f = Console.ReadLine();
            Console.Clear();

            if (f == "")
            {
                Console.WriteLine("Deine Angebe ist Leer!!!");
                Thread.Sleep(1000);
                Console.Clear();
                goto start;
            }
            else
            { Console.WriteLine("Gebe an wann du Fährst(eine Angabe)"); }
            string g = Console.ReadLine();
            Console.Clear();

            if (g == "")
            {
                Console.WriteLine("Deine Angebe ist Leer!!!");
                Thread.Sleep(1000);
                Console.Clear();
                goto start;
            }
            else
            { Console.WriteLine("Gebe an wie viele Sitzplätze dein Auto hat"); }
            string h = Console.ReadLine();
            Console.Clear();
            if (h == "")
            {
                Console.WriteLine("Deine Angebe ist Leer!!!");
                Thread.Sleep(1000);
                Console.Clear();
                goto start;
            }
            else
            {
                using (StreamWriter sw = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Fahrgemeinschaften.csv"))
                {

                    sw.WriteLine(c);
                    sw.WriteLine(d);
                    sw.WriteLine(e);
                    sw.WriteLine(f);
                    sw.WriteLine(g);
                    sw.WriteLine(h);
                    sw.WriteLine(b);//Alter UserInfo hinzufügen
                }
            }




            Console.WriteLine("Deine Daten wurden erfolgreich hinzugefügt.");
            Console.WriteLine("Du bist jezt ein Teil der App");
        }//Fahrer werden option
        /// <summary>
        /// Anmelde Daten vom Nutzer werden geändert
        /// </summary>
        public void AenderrungVomAccount()
        {
        start:
            Console.Clear();
            Console.WriteLine("Was willst du ändern?");
            Console.WriteLine("u/p");
            string a = Convert.ToString(Console.ReadKey().KeyChar);
            int counter = 0;
            int counter2 = 0;
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
                                counter++;
                            }
                            else
                            {
                                alteListe = sr.ReadToEnd();
                            }
                            if (counter == CountLines("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Passwoerter.csv"))
                            {
                                Console.WriteLine("Dein Username stimmt nicht mit dem deines Accounts überein.");
                                goto start;
                            }

                        }

                        if (username == ListeUsername)
                        {
                            using (StreamWriter sw = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Passwoerter.csv"))
                            {
                                Console.WriteLine("Gebe deinen neuen Username ein");
                                string newUsername = Console.ReadLine();
                                Console.WriteLine($"Gebe dein Passwort ein, damit wir prüfen können ob du wirklich {username} bist");
                                string Passwortcheck = Console.ReadLine();
                                if (Passwortcheck == ListePasswort)
                                {
                                    sw.WriteLine(newUsername);
                                    sw.WriteLine(ListePasswort);
                                    sw.WriteLine(alteListe);
                                    counter = 100000;
                                }
                                else
                                {
                                    Console.WriteLine("Das ist das falsche Passwort. versüche es erneut.");
                                    Passwortcheck = Console.ReadLine();
                                    counter2++;
                                }
                                if (counter2 >= 3)
                                {
                                    Console.WriteLine("Du hast 3 mal dein Passwort falsch eingegebn. du wirst zum start weiter geleitet.");

                                }
                            }
                        }

                    }


                    return;
                case "p":
                    Console.WriteLine("Gebe dein Username ein");
                    username = Console.ReadLine();
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
                                counter++;
                            }
                            else
                            {
                                alteListe = sr.ReadToEnd();
                            }
                            if (counter == CountLines("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Passwoerter.csv"))
                            {
                                Console.WriteLine("Dein Username stimmt nicht mit dem deines Accounts überein.");
                                goto start;
                            }

                        }

                        if (username == ListeUsername)
                        {
                            using (StreamWriter sw = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Passwoerter.csv"))
                            {
                                Console.WriteLine("Gebe deinen neues Passwort ein");
                                string newPasswort = Console.ReadLine();
                                Console.WriteLine($"Wiederhole dein Passwort");
                                string Passwortcheck = Console.ReadLine();
                                if (Passwortcheck == newPasswort)
                                {
                                    sw.WriteLine(ListeUsername);
                                    sw.WriteLine(newPasswort);
                                    sw.WriteLine(alteListe);
                                    counter = 100000;
                                }
                                else
                                {
                                    Console.WriteLine("Das ist das falsche Passwort. Wiederhole ihn");
                                    Passwortcheck = Console.ReadLine();
                                    counter2++;
                                }
                                if (counter2 >= 3)
                                {
                                    Console.WriteLine("Du hast 3 mal dein Passwort falsch eingegebn. du wirst zum start weiter geleitet.");

                                }
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
            if (Username == "")
            {
                Console.WriteLine("Deine Eingabe ist leer");
                Thread.Sleep(1000);
                Console.Clear();
                goto start;
            }
            else
            {
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
        public void FahrersucheListeAdd(string preName, string lastname, string ZielZeit, string Fahrzeug, string prenameMitfahrer, string lastnameMitfahrer, int sitzplaetze)
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
                    sw2.WriteLine($"{prenameMitfahrer} {lastnameMitfahrer} ist der Beifahrer von {preName} {lastname} am {ZielZeit} in einem {Fahrzeug} und hat noch{sitzplaetze} Sitzplätze frei");
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
        public void Fahrersuche4()
        {
            int AnzahlMitfahrer = 0;

        start2:
            Console.WriteLine("Gebe deinen Vornamen ein");
            string prenameMitfahrer = Console.ReadLine();

            if (prenameMitfahrer == "")
            {
                Console.WriteLine("Deine Eingabe ist leer");
                Thread.Sleep(1000);
                Console.Clear();
                goto start2;
            }
            else
            { }
            Console.WriteLine("gebe deinen Nachnamen ein");
            string lastnameMitfahrer = Console.ReadLine();
            if (lastnameMitfahrer == "")
            {
                Console.WriteLine("Deine Eingabe ist leer");
                Thread.Sleep(1000);
                Console.Clear();
                goto start2;
            }
            else
            { }
            Console.WriteLine("Wo willst du hin?");
            string ZielOrt = Console.ReadLine();
            if (ZielOrt == "")
            {
                Console.WriteLine("Deine Eingabe ist leer");
                Thread.Sleep(1000);
                Console.Clear();
                goto start2;
            }
            else
            { }
            Console.WriteLine("Wann willst du dahin?");
            string ZielZeit = Console.ReadLine();
            if (ZielZeit == "")
            {
                Console.WriteLine("Deine Eingabe ist leer");
                Thread.Sleep(1000);
                Console.Clear();
                goto start2;
            }
            else
            { }
        start:
            Console.WriteLine("Wie viele seid ihr?");
            string input = Console.ReadLine(); //get the input

            if (!int.TryParse(input, out AnzahlMitfahrer))          //
            {
                Console.WriteLine("Das ist keine Zahl!!!");         //
                Thread.Sleep(1000);                                 //    
                Console.Clear();                                    //
                goto start;                                         //
            }                                                       //
            else                                                    //                    
            {
                AnzahlMitfahrer = Convert.ToInt32(input);
                int counter = 1;
                string rest1 = "0";
                string rest2 = "0";
                string oldpreName = "0";
                string oldlastname = "0";
                string oldFahrzeug = "0";
                string oldOrt = "0";
                string oldZeit = "0";
                int oldSitzplaetze = 0;
                while (counter < CountLines("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Fahrgemeinschaften.csv"))
                {
                    if (counter % 4 == 1)
                    {//Einlesung der verschiedenen Einträge durch überschreiben.
                        using (StreamReader sr = new StreamReader("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Fahrgemeinschaften.csv"))
                        {
                            string preName = sr.ReadLine();
                            string lastname = sr.ReadLine();
                            string Fahrzeug = sr.ReadLine();
                            string Ort = sr.ReadLine();
                            string Zeit = sr.ReadLine();
                            int Sitzplaetze = Convert.ToInt32(sr.ReadLine());

                            if (ZielOrt == Ort && ZielZeit == Zeit && AnzahlMitfahrer <= Sitzplaetze)
                            {
                                using (StreamReader sr3 = new StreamReader("C:\\010Projects\\Linq\\Fahrgemeinschaft\\FahrgemeinschaftenKopie.csv"))
                                {
                                    oldpreName = sr3.ReadLine();
                                    oldlastname = sr3.ReadLine();
                                    oldFahrzeug = sr3.ReadLine();
                                    oldOrt = sr3.ReadLine();
                                    oldZeit = sr3.ReadLine();
                                    oldSitzplaetze = Convert.ToInt32(sr3.ReadLine());
                                }

                                rest1 = sr.ReadToEnd();
                                using (StreamWriter sw3 = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\FahrgemeinschaftenKopie.csv"))
                                {
                                    sw3.WriteLine(preName);
                                    sw3.WriteLine(lastname);
                                    sw3.WriteLine(Fahrzeug);
                                    sw3.WriteLine(Ort);
                                    sw3.WriteLine(Zeit);
                                    sw3.WriteLine(Convert.ToString(Sitzplaetze));
                                    sw3.WriteLine(rest1);
                                }


                                oldSitzplaetze = oldSitzplaetze - AnzahlMitfahrer;
                                using (StreamWriter sw2 = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\FahrgemeinschaftenNeuGeschrieben.csv"))
                                {
                                    sw2.WriteLine(preName);
                                    sw2.WriteLine(lastname);
                                    sw2.WriteLine(Fahrzeug);
                                    sw2.WriteLine(Ort);
                                    sw2.WriteLine(Zeit);
                                    sw2.WriteLine(Convert.ToString(oldSitzplaetze));
                                }
                                using (StreamReader sr2 = new StreamReader("C:\\010Projects\\Linq\\Fahrgemeinschaft\\FahrgemeinschaftenNeuGeschrieben.csv"))
                                {

                                    preName = sr2.ReadLine();
                                    lastname = sr2.ReadLine();
                                    Fahrzeug = sr2.ReadLine();
                                    Ort = sr2.ReadLine();
                                    Zeit = sr2.ReadLine();
                                    Sitzplaetze = Convert.ToInt32(sr2.ReadLine());
                                    if (Sitzplaetze <= -1)
                                    {
                                        Console.WriteLine($"Das Auto, welches nach {Ort} am {Zeit} fährt, ist schon voll.");
                                        break;
                                    }
                                    else { rest2 = sr2.ReadToEnd(); }
                                }
                                using (StreamWriter sw3 = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\FahrgemeinschaftenKopie.csv"))
                                {
                                    sw3.WriteLine(preName);
                                    sw3.WriteLine(lastname);
                                    sw3.WriteLine(Fahrzeug);
                                    sw3.WriteLine(Ort);
                                    sw3.WriteLine(Zeit);
                                    sw3.WriteLine(Sitzplaetze);
                                    sw3.WriteLine(rest2);
                                    sw3.WriteLine(rest1);
                                }
                                FahrersucheListeAdd(preName, lastname, ZielZeit, Fahrzeug, prenameMitfahrer, lastnameMitfahrer, Sitzplaetze);


                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Es fährt keiner zu dieser Zeit");
                                Console.WriteLine($"Du wirst wieder auf die Startseite geleitet");
                                break;
                            }
                        }


                    }
                    else
                    {
                        counter++;
                    }
                }
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
                        if (Username == "")
                        {
                            goto UsernameCheck;
                        }
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
        public void BeifahrerAendern()
        {
            int counter = 0;
            string x = "x";
            string y = "y";
            string Usereingabe1 = "0";
            string RestlicheEingaben = "0";
            string VorherigeEingaben = "0";
            string[] Usereingabe = new string[] { };
            int Kopie = CountLines("C:\\010Projects\\Linq\\Fahrgemeinschaft\\GefundeneFahrgemeinschaftenKopie.csv");
            int a = 0;
            List<string> UsereingabeListe = new List<string>();
            Console.WriteLine("gebe deinen Vornamen ein (der name, der in der Liste ist)");
            string UserVorname = Console.ReadLine();
            Console.WriteLine("gebe deinen Nachnamen ein (der name, der in der Liste ist)");
            string UserNachname = Console.ReadLine();
            using (StreamReader sr = new StreamReader("C:\\010Projects\\Linq\\Fahrgemeinschaft\\GefundeneFahrgemeinschaften.csv"))
            {
                while (CountLines("C:\\010Projects\\Linq\\Fahrgemeinschaft\\GefundeneFahrgemeinschaften.csv") >= a)
                {
                    Usereingabe1 = sr.ReadLine();

                    if (Usereingabe1 == null)
                    {
                        break;
                    }
                    Usereingabe = Usereingabe1.Split(new char[] { ' ' });
                    x = Usereingabe[0];
                    y = Usereingabe[1];
                    using (StreamWriter sw2 = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\GefundeneFahrgemeinschaftenKopie.csv"))
                    {
                        while (Kopie >= counter)
                        {
                            sw2.WriteLine();
                            counter++;
                        }
                    }
                    using (StreamWriter sw2 = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\GefundeneFahrgemeinschaftenKopie.csv",true))
                    {
                        if (x != UserVorname && y != UserNachname)
                        {
                            sw2.WriteLine(Usereingabe1);
                        }
                        else
                        {
                            Console.WriteLine("else");
                        }
                    }
                    if (x == UserVorname && y == UserNachname)
                    {
                        _ = sr.ReadLine();
                        RestlicheEingaben = sr.ReadToEnd();
                        VorherigeEingaben = sr.ReadToEnd();

                    }
                    using (StreamWriter sw2 = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\GefundeneFahrgemeinschaftenKopie.csv", true))
                    {
                        sw2.WriteLine(VorherigeEingaben);
                        sw2.WriteLine(RestlicheEingaben);
                        UsereingabeListe.Add(x);
                        UsereingabeListe.Add(y);
                    }

                    a++;

                }
                if (UsereingabeListe == null)
                {
                    Console.WriteLine($"Es gibt keinen Eintrag mit {UserVorname} {UserNachname}.");
                }



            }
            Console.ReadLine();
        }

    }
}
