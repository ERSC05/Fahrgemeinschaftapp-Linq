using System;
using System.Collections.Generic;
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

            var mappedDriver = new DriverDto(driverToMap.Id, driverToMap.Name, driverToMap.Sitzplaetze, driverToMap.AutoMarke, driverToMap.FahrtZiehl, driverToMap.AbfahrtZeit);

            return mappedDriver;

        }
        /// <summary>
        /// Get a driver on index
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<DriverDto> Get(long id)
        {
            var driver1 = driverdataService;
            List<DriverDto> driverDtos = new List<DriverDto>();
            var pfad1 = Assembly.GetEntryAssembly().Location;
            pfad1 = pfad1 + "\\..\\..\\..\\..\\Fahrer.csv";

            List<Driver> drivers = driver1.DriverReadCsv(pfad1);
            driverDtos.Add(ToDriverDto(drivers[Convert.ToInt32(id - 1)]));
            return driverDtos;
        }
        /// <summary>
        /// Read all driver in CSV file
        /// </summary>
        /// <returns></returns>
        public List<DriverDto> ReadDriver()
        {

            var driver1 = driverdataService;
            List<DriverDto> driverDtos = new List<DriverDto>();
            var pfad1 = Assembly.GetEntryAssembly().Location;
            pfad1 = pfad1 + "\\..\\..\\..\\..\\Fahrer.csv";
            List<Driver> drivers = driver1.DriverReadCsv(pfad1);
            foreach (Driver driver in drivers)
            {
                var sdto = ToDriverDto(driver);
                driverDtos.Add(sdto);
            }
            return driverDtos;
        }
        /// <summary>
        /// Gives you the last Id back
        /// </summary>
        /// <returns></returns>
        private long ReturnLastId()
        {
            var drivers1 = driverdataService;
            var pfad1 = Assembly.GetEntryAssembly().Location;
            pfad1 = pfad1 + "\\..\\..\\..\\..\\Fahrer.csv";
            List<Driver> drivers2 = drivers1.DriverReadCsv(pfad1);
            long id = 0;
            foreach (Driver driver in drivers2)
            {
                id = driver.Id;
            }
            return id;



        }
        /// <summary>
        /// Add a Driver from the user
        /// </summary>
        /// <param name="driverDto"></param>
        public void AddDriver(DriverDto driverDto)
        {            
            long id = ReturnLastId();
            id++;
            var driver = new Driver(id, driverDto.Name, driverDto.Sitzplaetze, driverDto.AutoMarke, driverDto.FahrtZiehl, driverDto.AbfahrtZeit);
            var driver1 = driverdataService;
            driver1.DriverAddCsv(driver);
        }
        /// <summary>
        /// Delite a driver
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
    }
}
