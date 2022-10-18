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
        public void DriverAddCsv(Driver driver)
        {
            using(StreamWriter writer = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer.csv"))
            {
                var newLine = $"{driver.Id};{driver.Name};{driver.Sitzplaetze};{driver.AutoMarke};{driver.FahrtZiehl};{driver.AbfahrtZeit}";
                writer.WriteLine(newLine);
            }
        }
        public void DrivingSearch(Driver driver)
        {
            Console.WriteLine();
        }
    }
}
