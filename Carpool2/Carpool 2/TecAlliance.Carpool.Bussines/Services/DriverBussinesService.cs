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
            int a = 0;
            long listwert = 0;
            var driver1 = new DriverDataService();
            List<DriverDto> driverDtos = new List<DriverDto>();
            List<Driver> drivers = driver1.DriverReadCsv("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer\\Fahrer.csv");
            List<Driver> savingdrivers = new List<Driver>();
            foreach(Driver driver2 in drivers)
            {
                
                if (listwert != id)
                {
                    listwert = drivers[a].Id;
                    savingdrivers = drivers;
                }
                else
                {
                    driverDtos.Add(ToDriverDto(savingdrivers[1]));
                    break;
                }
                a++;
            }
            return driverDtos;


        }
        public List<DriverDto> ReadDriver ()
        {
            
            var driver1 = new DriverDataService();
            List<DriverDto> driverDtos = new List<DriverDto>();
            List<Driver>drivers = driver1.DriverReadCsv("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer\\Fahrer.csv");
            foreach(Driver driver in drivers)
            {
                var sdto =ToDriverDto(driver);
                driverDtos.Add(sdto);
            }
            return driverDtos;
        }
        private long ReturnLastId()
        {           
            var drivers1 = new DriverDataService();
            List<Driver>drivers2 = drivers1.DriverReadCsv("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer\\Fahrer.csv");
            long id = 0;      
            foreach (Driver driver in drivers2)
            {
                id = driver.Id;                 
            }
            //var lastDriver = drivers.Last().Id;               /////////////
            return id;



        }
        public void AddDriver(DriverDto driverDto)
        {
            var readAllItems = new DriverBussinesService();
            long id = readAllItems.ReturnLastId();
            id++;            
            var driver = new Driver(id, driverDto.Name,driverDto.Sitzplaetze,driverDto.AutoMarke,driverDto.FahrtZiehl,driverDto.AbfahrtZeit);
            var driver1 = new DriverDataService();
            driver1.DriverAddCsv(driver);

        }

        public List<DriverDto> DeliteDriver(long id)
        {
            var driver = new DriverDataService();
            List<DriverDto> finaldelite = new List<DriverDto>();
            var delitetlist = driver.DeliteDriver(id);
            foreach(var delitet in delitetlist)
            {
                var driver2 = ToDriverDto(delitet);
                finaldelite.Add(driver2);
            }
            return finaldelite;
        }
    }
}
