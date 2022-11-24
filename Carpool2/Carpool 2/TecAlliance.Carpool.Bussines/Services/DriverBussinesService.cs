using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TecAlliance.Carpool.Bussines.Models;
using TecAlliance.Carpool.Data.Models;
using TecAlliance.Carpool.Data.Services;

namespace TecAlliance.Carpool.Bussines.Services
{
    public class DriverBussinesService : IDriverBussinesService
    {
        private IDriverDataService driverdataService;

        public DriverBussinesService(IDriverDataService driverDataService)
        {
            this.driverdataService = driverDataService;
        }
        /// <summary>
        /// Mapper from Driver to DriverDto
        /// </summary>
        /// <param name="driverToMap"></param>
        /// <returns></returns>
        private DriverDto ToDriverDto(Driver driverToMap)
        {

            var mappedDriver = new DriverDto(driverToMap.Id, driverToMap.Name, driverToMap.Sitzplaetze, driverToMap.AutoMarke, driverToMap.FahrtZiehl, driverToMap.AbfahrtZeit, driverToMap.DeletedOrNot);

            return mappedDriver;

        }
        /// <summary>
        /// Read all Driver in CSV file
        /// </summary>
        /// <returns></returns>
        public List<DriverDto> ReadDriver()
        {
            List<DriverDto> driverDtos = new List<DriverDto>();
            var allDriverInDriverFormat = driverdataService.ReadDriver();
            foreach (var driver in allDriverInDriverFormat)
            {
                var allDivertoOneDtoDriver = ToDriverDto(driver);
                driverDtos.Add(allDivertoOneDtoDriver);
            }
            return driverDtos;
        }
        /// <summary>
        /// Add a Driver from the user
        /// </summary>
        /// <param name="driverDto"></param>
        public DriverDto AddDriver(DriverDto driverDto)
        {

            var driver = new Driver(0, driverDto.Name, driverDto.Sitzplaetze, driverDto.AutoMarke, driverDto.FahrtZiehl, driverDto.AbfahrtZeit, driverDto.DeletedOrNot);
            var driver1 = driverdataService;
            driver1.DriverAddCsv(driver);
            return ToDriverDto(driver);
        }
        /// <summary>
        /// Delite a Driver
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<DriverDto> DeliteDriver(long id)
        {
            var driver = driverdataService;
            List<DriverDto> finaldelite = new List<DriverDto>();
            var delitetlist = driver.DeliteDriver(id);
            foreach (var delitet in delitetlist)
            {
                var driver2 = ToDriverDto(delitet);
                finaldelite.Add(driver2);
            }
            return finaldelite;
        }
        public List<DriverDto> GetDriverById(int id)
        {
            List<DriverDto> driverDtos = new List<DriverDto>();
            driverDtos.Add(ToDriverDto(driverdataService.GetDriverById(id)));
            return driverDtos;
        }
    }
}
