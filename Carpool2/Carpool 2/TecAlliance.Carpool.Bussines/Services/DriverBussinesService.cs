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
        
        public void AddDriver(DriverDto driverDto)
        {
            var driver = new Driver(driverDto.Id, driverDto.Name,driverDto.Sitzplaetze,driverDto.AutoMarke,driverDto.FahrtZiehl,driverDto.AbfahrtZeit);
            var driver1 = new DriverDataService();
            driver1.DriverAddCsv(driver);

        }
    }
}
