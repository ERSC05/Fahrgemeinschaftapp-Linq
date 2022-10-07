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
    public class Fahrer : FahrerInterface
    {
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string CarType { get; set; }
        //public string ZielOrt { get; set; }
        //public int Sitzplaetze { get; set; }
        public static int CountLines(string fileToCount)
        {
            int counter = 0;
            using (StreamReader countReader = new StreamReader(fileToCount))
            {
                while (countReader.ReadLine() != null) { counter++; }
                return counter;
            }

        }
        public virtual void PrintOut()
        {
            using (StreamReader sr = new StreamReader("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Fahrgemeinschaften.csv"))
            {
                int countEtries = 0;
                //int count = 0;
                while (CountLines("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Fahrgemeinschaften.csv") >= countEtries)
                {
                    if (countEtries % 3 >= 1)
                    {
                        Console.WriteLine();
                        countEtries++;


                    }
                    else
                    {

                        Console.WriteLine($"{sr.ReadLine()} {sr.ReadLine()} fährt mit einem {sr.ReadLine()} nach {sr.ReadLine()} am {sr.ReadLine()}");
                        countEtries++;

                    }
                }

                Thread.Sleep(5000);
            }


        }//Schreibt alle Fahrer niede
        public void BestimmteAutoSuche()
        {
            using (StreamReader sr = new StreamReader("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Fahrgemeinschaften.csv"))
            {
                Console.WriteLine("Mit welchem Auto willst du unbeedingt fahren?");
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
                    if (AusgewaeltesAuto == Fahrzeug)
                    {
                        Console.WriteLine($"{preName} {lastname} fährt mit einem {Fahrzeug} nach {Ort} am {Zeit}");

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

            Thread.Sleep(2000);
        }//Sucht von allen Autos ein Bestimmtes herraus
        public void FahrerEdit()
        {//Method to add the User as a driver
            List<string> ItemList = new List<string>();
            string b = "0";
            using (StreamReader sr = new StreamReader("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Fahrgemeinschaften.csv"))//Alte UserInfo kopieren
            {
                b = sr.ReadToEnd();
            }

            using (StreamWriter sw = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Fahrgemeinschaften.csv"))
            {//Neue UserInfo bekommen

                Console.WriteLine("Gebe deinen Vor namen ein");
                sw.WriteLine(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Gebe deinen Nachnamen ein");
                sw.WriteLine(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Gebe dein auto ein");
                sw.WriteLine(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Gebe an wo hin du hinfährst");
                sw.WriteLine(Console.ReadLine());
                Console.WriteLine("Gebe an wann du Fährst(eine Angabe)");
                sw.WriteLine(Console.ReadLine());
                sw.WriteLine(b);//Alter UserInfo hinzufügen
            }



            Console.WriteLine("Deine Daten wurden erfolgreich hinzugefügt.");
            Console.WriteLine("Du bist jezt ein Teil der App");
            Thread.Sleep(2000);

        }//Fahrer werden option
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
        public void FahrersucheListeAdd(string preName, string lastname, string ZielZeit, string Fahrzeug, string prenameMitfahrer, string lastnameMitfahrer)
        {
            Console.WriteLine($"willst du mit {preName} {lastname} in einem {Fahrzeug} mitfahren?");
            Console.WriteLine("Dann drücke y");
            if (Console.ReadLine() == "y")
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
                int counterForLines = CountLines("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Fahrgemeinschaften.csv");
                int counter = 1;
                while (counter < counterForLines)
                {
                    if (counter == 1)
                    {//Lukas wird eingelesen (erster eintrag(1-4))

                        string preName = sr.ReadLine();
                        string lastname = sr.ReadLine();
                        string Fahrzeug = sr.ReadLine();
                        string Ort = sr.ReadLine();
                        string Zeit = sr.ReadLine();
                        if (ZielOrt == Ort)
                        {
                            if (ZielZeit == Zeit)
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
                        }
                        counter++;


                    }
                    if (counter % 80 == 1)
                    {//Bastian wird eingelesen(fünfter Eintrag (17-20))

                        string preName = sr.ReadLine();
                        string lastname = sr.ReadLine();
                        string Fahrzeug = sr.ReadLine();
                        string Ort = sr.ReadLine();
                        string Zeit = sr.ReadLine();
                        if (ZielOrt == Ort)
                        {
                            if (ZielZeit == Zeit)
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
                        }
                        counter++;
                    }
                    if (counter % 76 == 1)
                    {//Bastian wird eingelesen(fünfter Eintrag (17-20))

                        string preName = sr.ReadLine();
                        string lastname = sr.ReadLine();
                        string Fahrzeug = sr.ReadLine();
                        string Ort = sr.ReadLine();
                        string Zeit = sr.ReadLine();
                        if (ZielOrt == Ort)
                        {
                            if (ZielZeit == Zeit)
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
                        }
                        counter++;
                    }
                    if (counter % 72 == 1)
                    {//Bastian wird eingelesen(fünfter Eintrag (17-20))

                        string preName = sr.ReadLine();
                        string lastname = sr.ReadLine();
                        string Fahrzeug = sr.ReadLine();
                        string Ort = sr.ReadLine();
                        string Zeit = sr.ReadLine();
                        if (ZielOrt == Ort)
                        {
                            if (ZielZeit == Zeit)
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
                        }
                        counter++;
                    }
                    if (counter % 68 == 1)
                    {//Bastian wird eingelesen(fünfter Eintrag (17-20))

                        string preName = sr.ReadLine();
                        string lastname = sr.ReadLine();
                        string Fahrzeug = sr.ReadLine();
                        string Ort = sr.ReadLine();
                        string Zeit = sr.ReadLine();
                        if (ZielOrt == Ort)
                        {
                            if (ZielZeit == Zeit)
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
                        }
                        counter++;
                    }
                    if (counter % 64 == 1)
                    {//Bastian wird eingelesen(fünfter Eintrag (17-20))

                        string preName = sr.ReadLine();
                        string lastname = sr.ReadLine();
                        string Fahrzeug = sr.ReadLine();
                        string Ort = sr.ReadLine();
                        string Zeit = sr.ReadLine();
                        if (ZielOrt == Ort)
                        {
                            if (ZielZeit == Zeit)
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
                        }
                        counter++;
                    }
                    if (counter % 60 == 1)
                    {//Bastian wird eingelesen(fünfter Eintrag (17-20))

                        string preName = sr.ReadLine();
                        string lastname = sr.ReadLine();
                        string Fahrzeug = sr.ReadLine();
                        string Ort = sr.ReadLine();
                        string Zeit = sr.ReadLine();
                        if (ZielOrt == Ort)
                        {
                            if (ZielZeit == Zeit)
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
                        }
                        counter++;
                    }
                    if (counter % 56 == 1)
                    {//Bastian wird eingelesen(fünfter Eintrag (17-20))

                        string preName = sr.ReadLine();
                        string lastname = sr.ReadLine();
                        string Fahrzeug = sr.ReadLine();
                        string Ort = sr.ReadLine();
                        string Zeit = sr.ReadLine();
                        if (ZielOrt == Ort)
                        {
                            if (ZielZeit == Zeit)
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
                        }
                        counter++;
                    }
                    if (counter % 52 == 1)
                    {//Bastian wird eingelesen(fünfter Eintrag (17-20))

                        string preName = sr.ReadLine();
                        string lastname = sr.ReadLine();
                        string Fahrzeug = sr.ReadLine();
                        string Ort = sr.ReadLine();
                        string Zeit = sr.ReadLine();
                        if (ZielOrt == Ort)
                        {
                            if (ZielZeit == Zeit)
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
                        }
                        counter++;
                    }
                    if (counter % 48 == 1)
                    {//Bastian wird eingelesen(fünfter Eintrag (17-20))

                        string preName = sr.ReadLine();
                        string lastname = sr.ReadLine();
                        string Fahrzeug = sr.ReadLine();
                        string Ort = sr.ReadLine();
                        string Zeit = sr.ReadLine();
                        if (ZielOrt == Ort)
                        {
                            if (ZielZeit == Zeit)
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
                        }
                        counter++;
                    }
                    if (counter % 44 == 1)
                    {//Bastian wird eingelesen(fünfter Eintrag (17-20))

                        string preName = sr.ReadLine();
                        string lastname = sr.ReadLine();
                        string Fahrzeug = sr.ReadLine();
                        string Ort = sr.ReadLine();
                        string Zeit = sr.ReadLine();
                        if (ZielOrt == Ort)
                        {
                            if (ZielZeit == Zeit)
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
                        }
                        counter++;
                    }
                    if (counter % 40 == 1)
                    {//Bastian wird eingelesen(fünfter Eintrag (17-20))

                        string preName = sr.ReadLine();
                        string lastname = sr.ReadLine();
                        string Fahrzeug = sr.ReadLine();
                        string Ort = sr.ReadLine();
                        string Zeit = sr.ReadLine();
                        if (ZielOrt == Ort)
                        {
                            if (ZielZeit == Zeit)
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
                        }
                        counter++;
                    }
                    if (counter % 36 == 1)
                    {//Bastian wird eingelesen(fünfter Eintrag (17-20))

                        string preName = sr.ReadLine();
                        string lastname = sr.ReadLine();
                        string Fahrzeug = sr.ReadLine();
                        string Ort = sr.ReadLine();
                        string Zeit = sr.ReadLine();
                        if (ZielOrt == Ort)
                        {
                            if (ZielZeit == Zeit)
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
                        }
                        counter++;
                    }
                    if (counter % 32 == 1)
                    {//Bastian wird eingelesen(fünfter Eintrag (17-20))

                        string preName = sr.ReadLine();
                        string lastname = sr.ReadLine();
                        string Fahrzeug = sr.ReadLine();
                        string Ort = sr.ReadLine();
                        string Zeit = sr.ReadLine();
                        if (ZielOrt == Ort)
                        {
                            if (ZielZeit == Zeit)
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
                        }
                        counter++;
                    }
                    if (counter % 28 == 1)
                    {//Bastian wird eingelesen(fünfter Eintrag (17-20))

                        string preName = sr.ReadLine();
                        string lastname = sr.ReadLine();
                        string Fahrzeug = sr.ReadLine();
                        string Ort = sr.ReadLine();
                        string Zeit = sr.ReadLine();
                        if (ZielOrt == Ort)
                        {
                            if (ZielZeit == Zeit)
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
                        }
                        counter++;
                    }
                    if (counter % 24 == 1)
                    {//Bastian wird eingelesen(fünfter Eintrag (17-20))

                        string preName = sr.ReadLine();
                        string lastname = sr.ReadLine();
                        string Fahrzeug = sr.ReadLine();
                        string Ort = sr.ReadLine();
                        string Zeit = sr.ReadLine();
                        if (ZielOrt == Ort)
                        {
                            if (ZielZeit == Zeit)
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
                        }
                        counter++;
                    }
                    if (counter % 20 == 1)
                    {//Copied

                        string preName = sr.ReadLine();
                        string lastname = sr.ReadLine();
                        string Fahrzeug = sr.ReadLine();
                        string Ort = sr.ReadLine();
                        string Zeit = sr.ReadLine();
                        if (ZielOrt == Ort)
                        {
                            if (ZielZeit == Zeit)
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
                        }
                        counter++;
                    }
                    if (counter % 16 == 1)
                    {//Bastian wird eingelesen(fünfter Eintrag (17-20))

                        string preName = sr.ReadLine();
                        string lastname = sr.ReadLine();
                        string Fahrzeug = sr.ReadLine();
                        string Ort = sr.ReadLine();
                        string Zeit = sr.ReadLine();
                        if (ZielOrt == Ort)
                        {
                            if (ZielZeit == Zeit)
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
                        }
                        counter++;
                    }
                    if (counter % 12 == 1)
                    {//Sara wird eingelesen (vierter Eintrag(12-16))
                        string preName = sr.ReadLine();
                        string lastname = sr.ReadLine();
                        string Fahrzeug = sr.ReadLine();
                        string Ort = sr.ReadLine();
                        string Zeit = sr.ReadLine();
                        if (ZielOrt == Ort)
                        {
                            if (ZielZeit == Zeit)
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
                        }
                        counter++;
                    }
                    if (counter % 8 == 1)
                    {//Ferdinant wird eingelesen(dritterEintrag(9-12))
                        string preName = sr.ReadLine();
                        string lastname = sr.ReadLine();
                        string Fahrzeug = sr.ReadLine();
                        string Ort = sr.ReadLine();
                        string Zeit = sr.ReadLine();
                        if (ZielOrt == Ort)
                        {
                            if (ZielZeit == Zeit)
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
                        }
                        counter++;
                    }
                    if (counter % 4 == 1)
                    {//Erwin wird eingelesen (zweiterEintrag(5-8))
                        string preName = sr.ReadLine();
                        string lastname = sr.ReadLine();
                        string Fahrzeug = sr.ReadLine();
                        string Ort = sr.ReadLine();
                        string Zeit = sr.ReadLine();
                        if (ZielOrt == Ort)
                        {
                            if (ZielZeit == Zeit)
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
                        }
                        counter++;
                    }
                    else
                    {
                        counter++;
                    }
                }
                Console.ReadLine();

            }
        }
        public void FahrgemeinschaftPrint()
        {
            List<string>FahrGemeinschaften = new List<string>();
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
                
                Thread.Sleep(5000);
            }
        }
    }
}

