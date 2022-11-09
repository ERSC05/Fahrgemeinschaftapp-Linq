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
using static System.Net.Mime.MediaTypeNames;

namespace TecAlliance.Carpool.Bussines.Services
{
    public class CarpoolBussinesService : ICarpoolBussinesService
    {
        private ICarpoolDataService carpooldataService;

        public CarpoolBussinesService(ICarpoolDataService carpoolDataService)
        {
            carpooldataService = carpoolDataService;
        }
        /// <summary>
        /// Mapper from Carpool to CarpoolDto
        /// </summary>
        /// <param name="carpoolToMap"></param>
        /// <returns></returns>
        private CarpoolDto ToCarpoolDto(CarPool carpoolToMap)
        {

            var mappedDriver = new CarpoolDto(carpoolToMap.Id, carpoolToMap.NameBeifahrer, carpoolToMap.NameFahrer, carpoolToMap.Sitzplaetze, carpoolToMap.AutoMarke, carpoolToMap.AutoZiel, carpoolToMap.AbfahrtZeit);

            return mappedDriver;

        }
        /// <summary>
        /// Add a Carpool to the CSV
        /// </summary>
        /// <param name="carPool"></param>
        public void AddCarpool(CarPool carPool)
        {
            try
            {
                var carpool = new CarPool(0, carPool.NameBeifahrer, carPool.NameFahrer, carPool.Sitzplaetze, carPool.AutoMarke, carPool.AutoZiel, carPool.AbfahrtZeit);
                var carpool1 = new CarpoolDataService();
                carpool1.CarpoolAddCsv(carpool);
            }
            catch { throw new ArgumentException("carpool got not created"); }

        }
        /// <summary>
        /// Showing all Carpool that exist in the Database/CSV
        /// </summary>
        /// <returns></returns>
        public List<CarpoolDto> ShowAllExistCarpool()
        {
            List<CarpoolDto> carPools = new List<CarpoolDto>();
            var carpool = carpooldataService.Showcarpool();
            foreach (var delitet in carpool)
            {
                var driver2 = ToCarpoolDto(delitet);
                carPools.Add(driver2);
            }

            return carPools;
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
        public List<CarpoolDto> DeleteCarpool(long id)
        {
            List<CarpoolDto> delitedcarpool = new List<CarpoolDto>();
            var test = carpooldataService.DelitedList(id);
            foreach (var delitet in test)
            {
                var driver2 = ToCarpoolDto(delitet);
                delitedcarpool.Add(driver2);
            }
            return delitedcarpool;
        }
    }
}