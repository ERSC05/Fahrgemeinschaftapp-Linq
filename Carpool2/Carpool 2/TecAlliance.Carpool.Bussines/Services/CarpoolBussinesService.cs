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

        }  //////////////
        private CarpoolDto ToCarpoolDto(CarPool carpoolToMap)
        {

            var mappedDriver = new CarpoolDto(carpoolToMap.Id, carpoolToMap.NameBeifahrer, carpoolToMap.NameFahrer, carpoolToMap.Sitzplaetze, carpoolToMap.AutoMarke, carpoolToMap.AutoZiel, carpoolToMap.AbfahrtZeit);

            return mappedDriver;

        }  //////////////
        private long ReturnLastId()
        {
            var carpool1 = new CarpoolDataService();
            List<CarPool> carpool2 = carpool1.CarpoolReadCsv("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer\\Fahrgemeinschaften.csv");
            long id = 0;
            foreach (CarPool car in carpool2)
            {
                id = car.Id;
            }
            return id;
        }                                   //////////////
        public void AddCarpool(CarPool carPool)
        {
            var idreturner = new CarpoolDataService();

            long id = idreturner.ReturnLastId();
            id++;
            var carpool = new CarPool(id, carPool.NameBeifahrer, carPool.NameFahrer, carPool.Sitzplaetze, carPool.AutoMarke, carPool.AutoZiel, carPool.AbfahrtZeit);
            var carpool1 = new CarpoolDataService();
            carpool1.CarpoolAddCsv(carpool);
        }
        public List<CarpoolDto> ShowCarpool()
        {
            var carPool1 = new CarpoolDataService();
            List<CarpoolDto> carPooldto = new List<CarpoolDto>();
            List<CarPool> carPool = carPool1.CarpoolReadCsv("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer\\Fahrgemeinschaften.csv");
            List<string> liststring = new List<string>();
            liststring = carPool1.ReadCarpoolCsv("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer\\Fahrgemeinschaften.csv");
            string[] strings = new string[6];
            string[] allItems = liststring.ToArray();
            foreach (string item in allItems)
            {
                strings = item.Split(';');
                long id = Convert.ToInt64(strings[0]);
                string nameBeifahrer = strings[1];
                string nameFahrer = strings[2];
                int sitzplaetze = Convert.ToInt32(strings[3]);
                string automarke = strings[4];
                string autoZiel = strings[5];
                string abfahrtzeit = strings[6];
                var newCarpool = new CarpoolDto(id, nameBeifahrer, nameFahrer, sitzplaetze, automarke, autoZiel, abfahrtzeit);
                carPooldto.Add(newCarpool);
            }
            using(StreamWriter writer = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer\\Fahrgemeinschaften.csv"))
            {
                
            }
            return carPooldto;
        }
        public string FindCarpool(string Zielort)
        {
            var returner = new CarpoolDataService();
            var returntext = returner.FindCarpool(Zielort);
            return returntext;
        }
        public List<CarpoolDto> DeliteCarpool(long id)
        {
            var carpool = new CarpoolDataService();
            List<CarpoolDto> delitedcarpool = new List<CarpoolDto>();
            var test = carpool.DelitedList(id);
            foreach (var delitet in test)
            {
                var driver2 = ToCarpoolDto(delitet);
                delitedcarpool.Add(driver2);
            }
            //var converteddelitedcarpool = ToCarpoolDto(delitedcarpool);
            return delitedcarpool;
        }
    }
}
