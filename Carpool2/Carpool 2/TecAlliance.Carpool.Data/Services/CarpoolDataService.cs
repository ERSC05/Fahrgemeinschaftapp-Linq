using System;
using System.Collections.Generic;
using System.Data;
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
                string queryString = "INSERT INTO Carpools (FirstnameNonDriver,FirstnameDriver,SitzplaetzeCarpool,CarName,ZielOrt,ZielZeit,DeletedOrNot) " +
                   $"VALUES (@NameBeifahrer, @NameFahrer, @SitzplaetzeCarpool, @AutoMarke, @AutoZiel, GETDATE(), 'No')";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@NameBeifahrer", SqlDbType.VarChar);
                command.Parameters["@NameBeifahrer"].Value = carpool.NameBeifahrer;
                command.Parameters.Add("@NameFahrer", SqlDbType.VarChar);
                command.Parameters["@NameFahrer"].Value = carpool.NameFahrer;
                command.Parameters.Add("@SitzplaetzeCarpool", SqlDbType.Int);
                command.Parameters["@SitzplaetzeCarpool"].Value = carpool.Sitzplaetze;
                command.Parameters.Add("@AutoMarke", SqlDbType.VarChar);
                command.Parameters["@AutoMarke"].Value = carpool.AutoMarke;
                command.Parameters.Add("@AutoZiel", SqlDbType.VarChar);
                command.Parameters["@AutoZiel"].Value = carpool.AutoZiel;

                connection.Open();
                command.BeginExecuteNonQuery();


            }
        }
        /// <summary>
        /// Read all Carpools in the CSV file. Return a List<CarPool>
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<CarPool> CarpoolReadDatabase()
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
                        var carpoolItem = new CarPool(Convert.ToInt64(reader["IdCarpool"]), Convert.ToString(reader["FirstnameNonDriver"]), Convert.ToString(reader["FirstnameDriver"]), Convert.ToInt32(reader["SitzplaetzeCarpool"]), Convert.ToString(reader["CarName"]), Convert.ToString(reader["ZielOrt"]), Convert.ToString(reader["ZielZeit"]));
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
                string queryString = $"SELECT*FROM Carpools WHERE IdCarpool = @carpoolId";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@carpoolId", SqlDbType.Int);
                command.Parameters["@carpoolId"].Value = carpoolId;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        carPool = new CarPool(Convert.ToInt64(reader["IdCarpool"]), Convert.ToString(reader["FirstnameNonDriver"]), Convert.ToString(reader["FirstnameDriver"]), Convert.ToInt32(reader["SitzplaetzeCarpool"]), Convert.ToString(reader["CarName"]), Convert.ToString(reader["ZielOrt"]), Convert.ToString(reader["ZielZeit"]));
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
                string queryString = $"SELECT*FROM Carpools WHERE ZielOrt = @zielOrt";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@zielOrt", SqlDbType.VarChar);
                command.Parameters["@zielOrt"].Value = zielOrt;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        var carpoolItem = new CarPool(Convert.ToInt64(reader["IdCarpool"]), Convert.ToString(reader["FirstnameNonDriver"]), Convert.ToString(reader["FirstnameDriver"]), Convert.ToInt32(reader["SitzplaetzeCarpool"]), Convert.ToString(reader["CarName"]), Convert.ToString(reader["ZielOrt"]), Convert.ToString(reader["ZielZeit"]));
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
        public CarPool UpdateCarpool(long id)
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"UPDATE Carpools SET SitzplaetzeCarpool = SitzplaetzeCarpool-1 WHERE IdCarpool = {id}";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.BeginExecuteNonQuery();
            }
            return GetCarPoolById(Convert.ToInt32(id));
        }
        public void DriverToCarpoolAdd(long idCarpool, long idPerson)
        {
            try
            {
                string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string queryString = $"INSERT INTO DriverToCarpool (IdFahrer, IdCarpool) " +
                       $"VALUES(@idPerson,@idCarpool)";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    command.Parameters.Add("@idPerson", SqlDbType.Int);
                    command.Parameters["@idPerson"].Value = Convert.ToInt64(idPerson);
                    command.Parameters.Add("@idCarpool", SqlDbType.Int);
                    command.Parameters["@idCarpool"].Value = Convert.ToInt64(idCarpool);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch { }

        }
        /// <summary>
        /// Serach for a specific Carpool in the CSV file
        /// </summary>
        /// <param name="zielort"></param>
        /// <returns></returns>
        public CarPool AddPersonToCarpool(string zielort, int personId)
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"UPDATE Carpools SET SitzplaetzeCarpool = SitzplaetzeCarpool-1 WHERE ZielOrt = @zielort";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@zielort", System.Data.SqlDbType.VarChar);
                command.Parameters["@zielort"].Value = zielort;
                connection.Open();
                command.BeginExecuteNonQuery();
            }

            var updatedCarpool = GetCarPoolById(personId);
            var carPools = GetCarPoolsByZielOrt(zielort);
            int count = 0;
            foreach (var item in carPools)
            {
                if (count == 1)
                {
                    break;
                }
                else if (item.Sitzplaetze >= 0 && item.AutoZiel == zielort)
                {
                    updatedCarpool = UpdateCarpool(item.Id);
                    DriverToCarpoolAdd(item.Id, personId);
                    count = 1;
                }
                else
                {
                    updatedCarpool = null;
                }
            }
            return updatedCarpool;
        }
        /// <summary>
        /// Delete a item from a List at the index of the given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<CarPool> DeletedList(long id)
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
        public List<CarPool> ReturnCarpoolConections()
        {

            var carpools = new List<CarPool>();
            //List<string> ReturnTextWithAllCarpoolConections = new List<string>();

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
                        carpoolItem.Driver = driveritem;
                        carpools.Add(carpoolItem);
                        //ReturnTextWithAllCarpoolConections.Add($"{carpoolItem.NameFahrer} fährt mit {driveritem.Name} in einem {carpoolItem.AutoMarke} nach {carpoolItem.AutoZiel} und hat noch {carpoolItem.Sitzplaetze} Sitzplaetze frei.");

                    }
                }
                finally
                {
                    reader.Close();
                }
            }



            return carpools;

        }
        private void DeleteFromCarpools(int idUser)
        {
            var carpools = new List<CarPool>();
            List<string> ReturnTextWithAllCarpoolConections = new List<string>();

            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"DELETE drivertocarpool FROM Carpools C INNER JOIN DriverToCarpool as drivertocarpool On C.IdCarpool = drivertocarpool.IdCarpool WHERE drivertocarpool.IdFahrer = @idUser ";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@idUser", SqlDbType.Int);
                command.Parameters["@idUser"].Value = idUser;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

            }
        }
        private void DeleteFromFahrer(int idUser)
        {
            var carpools = new List<CarPool>();
            List<string> ReturnTextWithAllCarpoolConections = new List<string>();

            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"DELETE FROM  Fahrer WHERE IdFahrer = @idUser ";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@idUser", SqlDbType.Int);
                command.Parameters["@idUser"].Value = idUser;

                connection.Open();
                command.ExecuteNonQuery();

            }
        }
        private void DeleteFromConvertList(int idUser)
        {
            var carpools = new List<CarPool>();
            List<string> ReturnTextWithAllCarpoolConections = new List<string>();

            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"DELETE FROM DriverToCarpool WHERE IdFahrer = @idUser ";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@idUser", SqlDbType.Int);
                command.Parameters["@idUser"].Value = idUser;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

            }
        }
        public string DeleteCarpoolsByDriverId(int idUser)
        {
            try
            {
                DeleteFromFahrer(idUser);
                DeleteFromCarpools(idUser);
                DeleteFromConvertList(idUser);
                return "Your carpoolconections got deleted";
            }
            catch
            {
                return null;
            }


        }
        public List<CarPool> GetAllPassangerById(int id)
        {
            List<CarPool> carPools = new List<CarPool>();

            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"SELECT* FROM Fahrer as fahrer JOIN DriverToCarpool as drivertocarpool ON fahrer.IdFahrer = drivertocarpool.IdFahrer JOIN Carpools as carpools ON carpools.IdCarpool = drivertocarpool.IdCarpool ORDER BY fahrer.Firstname ";
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        var carPoolItem = new CarPool(Convert.ToInt64(reader["IdCarpool"]), Convert.ToString(reader["FirstnameNonDriver"]), Convert.ToString(reader["FirstnameDriver"]), Convert.ToInt32(reader["SitzplaetzeCarpool"]), Convert.ToString(reader["CarName"]), Convert.ToString(reader["ZielOrt"]), Convert.ToString(reader["ZielZeit"]));
                        var driverItem = new Driver(Convert.ToInt64(reader["IdFahrer"]), Convert.ToString(reader["Firstname"]), Convert.ToInt32(reader["Sitzplaetze"]), Convert.ToString(reader["CarName"]), Convert.ToString(reader["ZielOrt"]), Convert.ToString(reader["ZielZeit"]), Convert.ToString(reader["DeletedOrNot"]));

                        if (driverItem.Id == id)
                        {
                            carPoolItem.Driver = driverItem;
                            carPools.Add(carPoolItem);
                        }
                        

                    }
                    return carPools;
                }
                finally
                {
                    reader.Close();

                }
            }

            return null;
        }
    }
}