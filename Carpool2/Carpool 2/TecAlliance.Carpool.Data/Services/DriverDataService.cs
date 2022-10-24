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
        public List<Driver> DriverReadCsv(string path)
        {
            List<Driver> driverItems = new List<Driver>();
            int counter = 1;
            using (StreamReader reader = new StreamReader(path))
            {


                while (counter <= CountLines(path))
                {

                    //2;Lucas;4;bmw;wkh;morgen
                    string csveintraege = reader.ReadLine();
                    string[] splittedstring = csveintraege.Split(';');
                    var id = Convert.ToInt64(splittedstring[0]);
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
        public void DriverAddCsv(Driver driver)
        {

            //int a = 
            using (StreamWriter writer = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer\\Fahrer.csv", true))
            {

                var newLine = $"{driver.Id};{driver.Name};{driver.Sitzplaetze};{driver.AutoMarke};{driver.FahrtZiehl};{driver.AbfahrtZeit}";
                writer.WriteLine(newLine);
            }
        }
        private List<Driver> SortList(List<Driver> drivers)
        {
            List<Driver> driverList = new List<Driver>();
            List<Driver> sortetdriverlist = new List<Driver>();
            sortetdriverlist = drivers.OrderBy(s => s.Id).ToList();


            return sortetdriverlist;
        }
        public List<Driver> DeliteDriver(long id)
        {
            DriverDataService sorter = new DriverDataService();
            long a = 0;
            List<Driver> drivers = new List<Driver>();
            var oldcsv = DriverReadCsv("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer\\Fahrer.csv");
            using (StreamWriter writer = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer\\Fahrer.csv"))
            {
                foreach (Driver driver in oldcsv)
                {
                    if (driver.Id == id)
                    {
                        long trash = driver.Id;
                        a++;
                    }
                    else
                    {
                        if (a == 1)
                        {
                            writer.WriteLine($"{driver.Id - 1};{driver.Name};{driver.Sitzplaetze};{driver.AutoMarke};{driver.FahrtZiehl};{driver.AbfahrtZeit}");
                        }
                        else
                        {
                            drivers.Add(driver);
                            writer.WriteLine($"{driver.Id};{driver.Name};{driver.Sitzplaetze};{driver.AutoMarke};{driver.FahrtZiehl};{driver.AbfahrtZeit}");
                            
                        }
                    }
                }
            }
            sorter.SortList(drivers);


            //using(StreamWriter writer = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer\\Fahrer.csv"))
            //{
            //    writer.WriteLine(drivers);
            //}

            return drivers;



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
