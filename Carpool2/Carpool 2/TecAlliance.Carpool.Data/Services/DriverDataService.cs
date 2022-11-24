using System;
using System.Collections.Generic;
using System.Data;
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
        /// Driver are getting add to CSV file
        /// </summary>
        /// <param name="driver"></param>
        public Driver DriverAddCsv(Driver driver)
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "INSERT INTO Fahrer (Firstname,Sitzplaetze,CarName,ZielOrt,ZielZeit,DeletedOrNot) " +
                                    $"VALUES(@Name,@Sitzplaetze,@AutoMarke,@FahrtZiehl,GETDATE(),'No')";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@Name", SqlDbType.VarChar);
                command.Parameters["@Name"].Value = driver.Name;
                command.Parameters.Add("@Sitzplaetze", SqlDbType.Int);
                command.Parameters["@Sitzplaetze"].Value = driver.Sitzplaetze;
                command.Parameters.Add("@AutoMarke", SqlDbType.VarChar);
                command.Parameters["@AutoMarke"].Value = driver.AutoMarke;
                command.Parameters.Add("@FahrtZiehl", SqlDbType.VarChar);
                command.Parameters["@FahrtZiehl"].Value = driver.FahrtZiehl;
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
        /// Deliting Driver from CSV file
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Driver> DeliteDriver(long id)
        {
            var drivers = new List<Driver>();

            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"DELETE Fahrer FROM Fahrer WHERE Fahrer.IdFahrer = @id";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

            }
            
            drivers.Add(GetDriverById(Convert.ToInt32(id)));

            return drivers;




        }
        public Driver GetDriverById(int fahrerId)
        {
            Driver driver;

            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"SELECT*FROM Fahrer WHERE IdFahrer = @fahrerId";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("fahrerId", SqlDbType.Int);
                command.Parameters["fahrerId"].Value = fahrerId;
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

            return null;

            
        }
        /// <summary>
        /// Read all Driver in CSV file
        /// </summary>
        /// <returns></returns>
        public List<Driver> ReadDriver()
        {
            var driverdto = new List<Driver>();

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
                        var driverdtoItems = new Driver(Convert.ToInt64(reader["IdFahrer"]), Convert.ToString(reader["Firstname"]), Convert.ToInt32(reader["Sitzplaetze"]), Convert.ToString(reader["CarName"]), Convert.ToString(reader["ZielOrt"]), Convert.ToString(reader["ZielZeit"]), Convert.ToString(reader["DeletedOrNot"]));
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
    }
}