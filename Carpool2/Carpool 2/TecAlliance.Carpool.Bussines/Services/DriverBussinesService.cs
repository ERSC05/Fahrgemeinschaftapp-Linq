﻿using System;
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
            var driverdto = new List<DriverDto>();

            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT*FROM Fahrer";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        var driverdtoItems = new DriverDto(Convert.ToInt64(reader["IdFahrer"]), Convert.ToString(reader["Firstname"]), Convert.ToInt32(reader["Sitzplaetze"]), Convert.ToString(reader["CarName"]),Convert.ToString(reader["ZielOrt"]), Convert.ToString(reader["ZielZeit"]), Convert.ToString(reader["DeletedOrNot"]));
                        driverdto.Add(driverdtoItems);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return driverdto;
        }
        /// <summary>
        /// Gives you the last Id back
        /// </summary>
        /// <returns></returns>
        private long ReturnLastId()
        {
            int a = 1;
            var drivers1 = driverdataService;
            var pfad1 = Assembly.GetEntryAssembly().Location;
            pfad1 = pfad1 + "\\..\\..\\..\\..\\Fahrer.csv";
            List<Driver> drivers2 = drivers1.DriverReadCsv(pfad1);
            long id = 0;
            foreach (Driver driver in drivers2)
            {

                if (a == 1)
                {
                    id = driver.Id + 1;
                    a++;
                }
                else
                {
                    id++;
                }

            }
            return id;



        }
        /// <summary>
        /// Add a Driver from the user
        /// </summary>
        /// <param name="driverDto"></param>
        public DriverDto AddDriver(DriverDto driverDto)
        {
            long id = ReturnLastId();
            Driver driverWithLastId;
            var driver = new Driver(id, driverDto.Name, driverDto.Sitzplaetze, driverDto.AutoMarke, driverDto.FahrtZiehl, driverDto.AbfahrtZeit, driverDto.DeletedOrNot);
            var driver1 = driverdataService;
            driver1.DriverAddCsv(driver);
            return ToDriverDto(driver);
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

        public List<DriverDto> GetDriverById(int id)
        {
            List<DriverDto> driverDtos = new List<DriverDto>();
            driverDtos.Add(ToDriverDto(driverdataService.GetDriverById(id)));
            return driverDtos;
        }
    }
}
