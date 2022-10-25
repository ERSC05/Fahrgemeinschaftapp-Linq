using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        /// <summary>
        /// Mapper from Carpool to CarpoolDto
        /// </summary>
        /// <param name="carpoolToMap"></param>
        /// <returns></returns>
        private CarpoolDto ToCarpoolDto(CarPool carpoolToMap)
        {

            var mappedDriver = new CarpoolDto(carpoolToMap.Id, carpoolToMap.NameBeifahrer, carpoolToMap.NameFahrer, carpoolToMap.Sitzplaetze, carpoolToMap.AutoMarke, carpoolToMap.AutoZiel, carpoolToMap.AbfahrtZeit);

            return mappedDriver;

        }  //////////////
        /// <summary>
        /// Add a Carpool to the CSV
        /// </summary>
        /// <param name="carPool"></param>
        public void AddCarpool(CarPool carPool)
        {
            var idreturner = new CarpoolDataService();

            long id = idreturner.ReturnLastId();
            id++;
            var carpool = new CarPool(id, carPool.NameBeifahrer, carPool.NameFahrer, carPool.Sitzplaetze, carPool.AutoMarke, carPool.AutoZiel, carPool.AbfahrtZeit);
            var carpool1 = new CarpoolDataService();
            carpool1.CarpoolAddCsv(carpool);
        }
        /// <summary>
        /// Shows all Carpool in the CSV File
        /// </summary>
        /// <returns></returns>
        public List<CarpoolDto> ShowCarpool()
        {
            var carPool1 = new CarpoolDataService();
            List<CarpoolDto> carPooldto = new List<CarpoolDto>();
            var pfad1 = Assembly.GetEntryAssembly().Location;
            pfad1 = pfad1 + "\\..\\..\\..\\..\\Fahrgemeinschaften.csv"; ///////////////
            List<CarPool> carPool = carPool1.CarpoolReadCsv(pfad1);
            List<string> liststring = new List<string>();
            liststring = carPool1.ReadCarpoolCsv(pfad1);
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
            using(StreamWriter writer = new StreamWriter(pfad1))
            {                
            }
            return carPooldto;
        }
        /// <summary>
        /// Search between all Carpools for the special index
        /// </summary>
        /// <param name="Zielort"></param>
        /// <returns></returns>
        public string FindCarpool(string Zielort)
        {
            var returner = new CarpoolDataService();
            var returntext = returner.FindCarpool(Zielort);
            return returntext;
        }
        /// <summary>
        /// Deliting the Carpool at special index
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
