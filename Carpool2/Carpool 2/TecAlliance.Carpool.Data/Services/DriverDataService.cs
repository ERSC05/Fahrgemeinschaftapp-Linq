using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Data.Services
{
    public class DriverDataService
    {
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
        public List<Driver> DriverReadCsv()
        {
            List<Driver> driverItems = new List<Driver>();
            int counter = 1;
            using (StreamReader reader = new StreamReader("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer\\Fahrer.csv"))
            {


                while (counter <= CountLines("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer\\Fahrer.csv"))
                {

                    //2;Lucas;4;bmw;wkh;morgen
                    string csveintraege = reader.ReadLine();
                    string[] splittedstring = csveintraege.Split(';');
                    long id = Convert.ToInt64(splittedstring[0]);
                    string name = splittedstring[1];
                    int sitzplaetze = Convert.ToInt32(splittedstring[2]);
                    string automarke = splittedstring[3];
                    string fahrtziel = splittedstring[4];
                    string abfahrtzeit = splittedstring[5];
                    var newDriver = new Driver(id, name, sitzplaetze, automarke, fahrtziel, abfahrtzeit);
                    driverItems.Add(newDriver);

                    counter++;
                }
            }
            return driverItems;
        }
        public List<Driver> DriverReadOneCsv(long id)
        {

            string idAusCsvLesen = "0";
            int counter = 1;
            int ArrayNumber = 0;
            string b = "0";
            List<Driver> driverItems = new List<Driver>();
            using (StreamReader reader = new StreamReader("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer\\Fahrer.csv"))
            {
                while (true)
                {
                    if (id != Convert.ToInt32(b))
                    {
                        //1;Erwin;4;Toyota;wkh;morgen
                        //2;Erwin;4;Toyota;wkh;morgen
                        //4;Erwin;4;Toyota;wkh;morgen

                        
                    }
                    else
                    {
                        //2;Lucas;4;bmw;wkh;morgen
                        //string csveintraege = reader.ReadLine();
                        string[] splittedstring = idAusCsvLesen.Split(';');
                        id = Convert.ToInt64(splittedstring[0]);
                        string name = splittedstring[1];
                        int sitzplaetze = Convert.ToInt32(splittedstring[2]);
                        string automarke = splittedstring[3];
                        string fahrtziel = splittedstring[4];
                        string abfahrtzeit = splittedstring[5];
                        var newDriver = new Driver(id, name, sitzplaetze, automarke, fahrtziel, abfahrtzeit);
                        driverItems.Add(newDriver);
                        break;
                    }
                }
                if (driverItems.Count == 0)
                {

                }


            }
            return driverItems;
        }
        public void DriverAddCsv(Driver driver)
        {

            //int a = 
            using (StreamWriter writer = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer\\Fahrer.csv", true))
            {

                var newLine = $"{driver.Id};{driver.Name};{driver.Sitzplaetze};{driver.AutoMarke};{driver.FahrtZiehl};{driver.AbfahrtZeit}";
                writer.WriteLine(newLine);
            }
        }
        public void DrivingSearch(Driver driver, int eintraege, string eintrag)
        {
            using (StreamReader reader = new StreamReader("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\GebildeteFahrgemeinschaft\\GebildeteFahrgemeinschaft.csv"))
            {
                var csv = reader.ReadToEnd();
            }
            using (StreamWriter writer = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\GebildeteFahrgemeinschaft\\GebildeteFahrgemeinschaft.csv"))
            {
                List<string> listeDerEintraege = new List<string>();
                listeDerEintraege.Add(eintrag);
                List<string> finallist = new List<string>();
                for (int i = 0; i < listeDerEintraege.Count; i++)
                {
                    if (listeDerEintraege[i].Contains("Computers"))
                    {
                        listeDerEintraege[i] = "Calculators";
                    }
                }
            }
        }
    }
}
