using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Data.Services
{
    public class DriverDataService : IDriverDataService
    {
        /// <summary>
        /// Count all Lines
        /// </summary>
        /// <param name="fileToCount"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Read all Driver in CSV File
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<Driver> DriverReadCsv(string path)
        {
            List<Driver> driverItems = new List<Driver>();
            int counter = 1;
            using (StreamReader reader = new StreamReader(path, true))
            {
                while (counter <= CountLines(path))
                {

                    //2;Lucas;4;bmw;wkh;morgen
                    string csveintraege = reader.ReadLine();
                    string[] splittedstring = csveintraege.Split(';');
                    var id = Convert.ToInt64(splittedstring[0]);
                    string name = splittedstring[1];
                    int sitzplaetze = Convert.ToInt32(splittedstring[2]);
                    string automarke = splittedstring[3];
                    string fahrtziel = splittedstring[4];
                    string abfahrtzeit = splittedstring[5];
                    string delitetOrNot = splittedstring[6];
                    if (delitetOrNot == "Yes")
                    {
                    }
                    else
                    {
                        var newDriver = new Driver(id, name, sitzplaetze, automarke, fahrtziel, abfahrtzeit, delitetOrNot);
                        driverItems.Add(newDriver);
                    }
                    counter++;
                }
            }
            return driverItems;
        }
        /// <summary>
        /// Driver are getting add to CSV file
        /// </summary>
        /// <param name="driver"></param>
        public Driver DriverAddCsv(Driver driver)
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "INSERT INTO Fahrer (Firstname,Sitzplaetze,CarName,ZielOrt,ZielZeit,DeletedOrNot) " +
                                    $"VALUES('{driver.Name}',{driver.Sitzplaetze},'{driver.AutoMarke}','{driver.FahrtZiehl}',GETDATE(),'No')";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.BeginExecuteNonQuery();
            }
            List<Driver> drivers = GetLastDriverInDataBase();
            Driver driver1 = drivers[0];
            return driver1;
        }    
        public List<Driver> GetLastDriverInDataBase()
        {
            Driver driverItems;
            List<Driver> driver = new List<Driver>();
            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT TOP (1) [IdFahrer] ,[Firstname] ,[Sitzplaetze] ,[CarName] ,[ZielOrt] ,[ZielZeit] ,[DeletedOrNot] FROM [Carpool].[dbo].[Fahrer] ORDER BY IdFahrer";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        driver.Add(driverItems = new Driver(Convert.ToInt64(reader["IdFahrer"]), Convert.ToString(reader["Firstname"]), Convert.ToInt32(reader["Sitzplaetze"]), Convert.ToString(reader["CarName"]), Convert.ToString(reader["ZielOrt"]), Convert.ToString(reader["ZielZeit"]), Convert.ToString(reader["DeletedOrNot"])));
                    }

                }
                finally
                {
                     reader.Close();
                }
            }
                return driver;
        }
        /// <summary>
        /// Deliting driver from CSV file
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Driver> DeliteDriver(long id)
        {
            var drivers = new List<Driver>();

            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"DELETE FROM Fahrer WHERE Fahrer.IdFahrer = {id}";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

            }
            return drivers;




        }
        public Driver GetDriverById(int fahrerId)
        {
            Driver driver;

            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"SELECT*FROM Fahrer WHERE IdFahrer = {fahrerId}";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        driver = new Driver(Convert.ToInt64(reader["IdFahrer"]), Convert.ToString(reader["Firstname"]), Convert.ToInt32(reader["Sitzplaetze"]), Convert.ToString(reader["CarName"]), Convert.ToString(reader["ZielOrt"]), Convert.ToString(reader["ZielZeit"]), Convert.ToString(reader["DeletedOrNot"]));
                        return driver;

                    }
                }
                finally
                {
                    reader.Close();

                }
            }

            return null; ;

            
        }
    }
}
