using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Data.Services
{
    public class DriverDataService
    {
        /// <summary>
        /// Count all Lines
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
        /// Read all Driver in CSV File
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Driver are getting add to CSV file
        /// </summary>
        /// <param name="driver"></param>
        public void DriverAddCsv(Driver driver)
        {
            var pfad1 = Assembly.GetEntryAssembly().Location;
            pfad1 = pfad1 + "\\..\\..\\..\\..\\Fahrer.csv";
            using (StreamWriter writer = new StreamWriter(pfad1, true))
            {

                var newLine = $"{driver.Id};{driver.Name};{driver.Sitzplaetze};{driver.AutoMarke};{driver.FahrtZiehl};{driver.AbfahrtZeit}";
                writer.WriteLine(newLine);
            }
        }
        /// <summary>
        /// Sort the given list
        /// </summary>
        /// <param name="drivers"></param>
        /// <returns></returns>
        private List<Driver> SortList(List<Driver> drivers)
        {
            List<Driver> driverList = new List<Driver>();
            List<Driver> sortetdriverlist = new List<Driver>();
            sortetdriverlist = drivers.OrderBy(s => s.Id).ToList();


            return sortetdriverlist;
        }
        /// <summary>
        /// Deliting driver from CSV file
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Driver> DeliteDriver(long id)
        {
            DriverDataService sorter = new DriverDataService();
            long a = 0;
            List<Driver> drivers = new List<Driver>();
            var pfad1 = Assembly.GetEntryAssembly().Location;
            pfad1 = pfad1 + "\\..\\..\\..\\..\\Fahrer.csv";
            var oldcsv = DriverReadCsv(pfad1);
            using (StreamWriter writer = new StreamWriter(pfad1))
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
    }
}
