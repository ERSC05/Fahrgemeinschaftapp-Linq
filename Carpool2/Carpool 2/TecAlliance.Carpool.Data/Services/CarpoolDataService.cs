using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Data.Services
{
    public class CarpoolDataService : ICarpoolDataService
    {
        public void CarpoolAddCsv(CarPool carpool)
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "INSERT INTO Carpools (FirstnameNonDriver,FirstnameDriver,Sitzplaetze,CarName,ZielOrt,ZielZeit,DeletedOrNot)" +
                   $"VALUES('{carpool.NameBeifahrer}','{carpool.NameFahrer}',{carpool.Sitzplaetze},'{carpool.AutoMarke}','{carpool.AutoZiel}',GETDATE(),'No')";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.BeginExecuteNonQuery();


            }
        }

        /// <summary>
        /// Read all Carpools in the CSV file. Return a List<CarPool>
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<CarPool> CarpoolReadCsv()
        {

            var carpools = new List<CarPool>();

            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT*FROM Carpools";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        var carpoolItem = new CarPool(Convert.ToInt64(reader["IdCarpool"]), Convert.ToString(reader["FirstnameNonDriver"]), Convert.ToString(reader["FirstnameDriver"]), Convert.ToInt32(reader["Sitzplaetze"]), Convert.ToString(reader["CarName"]), Convert.ToString(reader["ZielOrt"]), Convert.ToString(reader["ZielZeit"]));
                        carpools.Add(carpoolItem);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }



            return carpools;
        }
        public CarPool GetCarPoolById(int carpoolId)
        {
            CarPool carPool;

            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"SELECT*FROM Carpools WHERE IdCarpool = {carpoolId}";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        carPool = new CarPool(Convert.ToInt64(reader["IdCarpool"]), Convert.ToString(reader["FirstnameNonDriver"]), Convert.ToString(reader["FirstnameDriver"]), Convert.ToInt32(reader["Sitzplaetze"]), Convert.ToString(reader["CarName"]), Convert.ToString(reader["ZielOrt"]), Convert.ToString(reader["ZielZeit"]));
                        return carPool;

                    }
                }
                finally
                {
                    reader.Close();
                    
                }
            }

            return null;
        }
        public List<CarPool> GetCarPoolsByZielOrt(string zielOrt)
        {
            var carpools = new List<CarPool>();

            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"SELECT*FROM Carpools WHERE ZielOrt = '{zielOrt}'";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        var carpoolItem = new CarPool(Convert.ToInt64(reader["IdCarpool"]), Convert.ToString(reader["FirstnameNonDriver"]), Convert.ToString(reader["FirstnameDriver"]), Convert.ToInt32(reader["Sitzplaetze"]), Convert.ToString(reader["CarName"]), Convert.ToString(reader["ZielOrt"]), Convert.ToString(reader["ZielZeit"]));
                        carpools.Add(carpoolItem);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }



            return carpools;
        }
        public string UpdateCarpool(long id)
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"UPDATE Carpools SET Sitzplaetze = Sitzplaetze-1 WHERE IdCarpool = {id}";
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.Add("@IdCarpool", System.Data.SqlDbType.Int);
                //command.Parameters["@IdCarpool"].Value = id;
                connection.Open();
                command.BeginExecuteNonQuery();
            }
            return "Your carpool got created";
        }
        public void DriverToCarpoolAdd(long idCarpool, long idPerson)
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"INSERT INTO DriverToCarpool (IdFahrer, IdCarpool) " +
                   $"VALUES({idPerson},{idCarpool})";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
        /// <summary>
        /// Serach for a specific Carpool in the CSV file
        /// </summary>
        /// <param name="zielort"></param>
        /// <returns></returns>
        public string AddPersonToCarpool(string zielort, int personId)
        {
            string updatedCarpool = "t";
            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"UPDATE Carpools SET Sitzplaetze = Sitzplaetze-1 WHERE ZielOrt = @zielort";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@zielort", System.Data.SqlDbType.VarChar);
                command.Parameters["@zielort"].Value = zielort;
                connection.Open();
                command.BeginExecuteNonQuery();
            }

            var carPools = GetCarPoolsByZielOrt(zielort);
            int test = 0;
            foreach (var item in carPools)
            {
                if (test == 1)
                {
                    break;
                }
                else if (item.Sitzplaetze > 0 && item.AutoZiel == zielort)
                {
                    updatedCarpool = UpdateCarpool(item.Id);
                    DriverToCarpoolAdd(item.Id, personId);
                    test = 1;
                }
                else
                {
                }
            }
            return updatedCarpool;
        }
        /// <summary>
        /// Delete a item from a List at the index of the given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<CarPool> DelitedList(long id)
        {
            var carpools = new List<CarPool>();

            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"DELETE FROM Carpools WHERE Carpools.IdCarpool = @Id";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                command.Parameters["@Id"].Value = id;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

            }
            return carpools;
        }
        public List<string> ReturnCarpoolConections()
        {
            var carpools = new List<CarPool>();
            List<string> ReturnTextWithAllCarpoolConections = new List<string>();

            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT* FROM Fahrer as fahrer JOIN DriverToCarpool as drivertocarpool ON fahrer.IdFahrer = drivertocarpool.IdFahrer JOIN Carpools as carpools ON carpools.IdCarpool = drivertocarpool.IdCarpool ORDER BY fahrer.Firstname ";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        var driveritem = new Driver(Convert.ToInt64(reader["IdFahrer"]), Convert.ToString(reader["Firstname"]), Convert.ToInt32(reader["Sitzplaetze"]), Convert.ToString(reader["CarName"]), Convert.ToString(reader["ZielOrt"]), Convert.ToString(reader["ZielZeit"]), Convert.ToString(reader["DeletedOrNot"]));
                        var carpoolItem = new CarPool(Convert.ToInt64(reader["IdCarpool"]), Convert.ToString(reader["FirstnameNonDriver"]), Convert.ToString(reader["FirstnameDriver"]), Convert.ToInt32(reader["SitzplaetzeCarpool"]), Convert.ToString(reader["CarName"]), Convert.ToString(reader["ZielOrt"]), Convert.ToString(reader["ZielZeit"]));

                        ReturnTextWithAllCarpoolConections.Add($"{carpoolItem.NameFahrer} fährt mit {driveritem.Name} in einem {carpoolItem.AutoMarke} nach {carpoolItem.AutoZiel} und hat noch {carpoolItem.Sitzplaetze} Sitzplaetze frei.");
                    }
                }
                finally
                {
                    reader.Close();
                }
            }



            return ReturnTextWithAllCarpoolConections;

        }
    }
}