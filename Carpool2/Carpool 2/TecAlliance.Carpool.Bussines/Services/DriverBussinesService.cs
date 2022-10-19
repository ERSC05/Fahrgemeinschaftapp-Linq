using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecAlliance.Carpool.Bussines.Models;
using TecAlliance.Carpool.Data.Models;
using TecAlliance.Carpool.Data.Services;

namespace TecAlliance.Carpool.Bussines.Services
{
    public class DriverBussinesService
    {
        DriverDataService dataService;

        public DriverBussinesService()
        {
            dataService = new DriverDataService();
        }

        private DriverDto ToDriverDto( Driver driverToMap)
        {

            var mappedDriver = new DriverDto(driverToMap.Id, driverToMap.Name, driverToMap.Sitzplaetze, driverToMap.AutoMarke, driverToMap.FahrtZiehl, driverToMap.AbfahrtZeit);

            return mappedDriver;

        }
        public List<DriverDto> Get(long id)
        {
            var driver1 = new DriverDataService();
            List<DriverDto> driverDtos = new List<DriverDto>();
            List<Driver> drivers = driver1.DriverReadOneCsv(id);
            foreach (Driver driver in drivers)
            {
                var sdto = ToDriverDto(driver);
                driverDtos.Add(sdto);
            }
            return driverDtos;


        }
        public List<DriverDto> ReadDriver ()
        {
            
            var driver1 = new DriverDataService();
            List<DriverDto> driverDtos = new List<DriverDto>();
            List<Driver>drivers = driver1.DriverReadCsv();
            foreach(Driver driver in drivers)
            {
                var sdto =ToDriverDto(driver);
                driverDtos.Add(sdto);
            }
            return driverDtos;
        }

        public void AddDriver(DriverDto driverDto)
        {
            var driver = new Driver(driverDto.Id, driverDto.Name,driverDto.Sitzplaetze,driverDto.AutoMarke,driverDto.FahrtZiehl,driverDto.AbfahrtZeit);
            var driver1 = new DriverDataService();
            driver1.DriverAddCsv(driver);

        }
    }
}
