using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TecAlliance.Carpool.Bussines.Models;
using TecAlliance.Carpool.Data.Models;
using TecAlliance.Carpool.Data.Services;

namespace TecAlliance.Carpool.Bussines.Services
{
    public class CarpoolBussinesService
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
        private DriverDto ToCarpoolDto(CarpoolDto carpoolToMap)
        {

            var mappedDriver = new DriverDto(carpoolToMap.Id, driverToMap.Name, driverToMap.Sitzplaetze, driverToMap.AutoMarke, driverToMap.FahrtZiehl, driverToMap.AbfahrtZeit);

            return mappedDriver;

        }
        private long ReturnLastId()
        {
            var carpool1 = new CarpoolDataService();
            List<CarPool> carpool2 = carpool1.CarpoolReadCsv("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer\\Fahrgemeinschaften.csv");
            long id = 0;
            foreach (CarPool car in carpool2)
            {
                id = car.Id;
            }
            //var lastDriver = drivers.Last().Id;               /////////////
            return id;



        }
        public void AddCarpool(CarPool carPool)
        {
            var readAllItems = new CarpoolBussinesService();
            long id = readAllItems.ReturnLastId();
            id++;
            var carpool = new CarPool(id, carPool.NameBeifahrer, carPool.NameFahrer, carPool.Sitzplaetze, carPool.AutoMarke, carPool.AutoZiel, carPool.AbfahrtZeit);
            var carpool1 = new CarpoolDataService();
            carpool1.CarpoolAddCsv(carpool);
        }
        public List<CarPool> ShowCarpool()
        {
            List<CarPool> carPools = new List<CarPool>();
            var allLiens = "";
            int a = 0;
            long id = 0;
            string NameBeifahrer = "";
            string NameFahrer = "";
            int Sitzplaetze = 0;
            string AutoMarke = "";
            string AutoZiel = "";
            string AbfahrtZeit = "";


            using (StreamReader reader = new StreamReader("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer\\Fahrgemeinschaften.csv"))
            {
                allLiens = reader.ReadToEnd();
            }
            string[] allItems = allLiens.Split(';');

            foreach (string item in allItems)
            {
                
                carPools.Add(carPools[a]);
                a++;
            }

            return carPools;


        }
    }
}
