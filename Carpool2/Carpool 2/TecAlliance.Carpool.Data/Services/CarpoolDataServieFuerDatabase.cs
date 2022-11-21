using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TecAlliance.Carpool.Data.Models;
using System.Data.SqlClient;

namespace TecAlliance.Carpool.Data.Services
{
    public class CarpoolDataServieFuerDatabase : ICarpoolDataService
    {
        /// <summary>
        /// Return the last Id from Carpool List
        /// </summary>
        /// <returns></returns>
        public long ReturnLastId()
        {
            return CarpoolReadCsv($"{Assembly.GetEntryAssembly().Location}\\..\\..\\..\\..\\Fahrgemeinschaften.csv").Last().Id;
        }
        /// <summary>
        /// Carpools are added in to the CSV file
        /// </summary>
        /// <param name="carpool"></param>
        public void CarpoolAddCsv(CarPool carpool)
        {

            var carpools = new List<CarPool>();

            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"INSERT INTO [dbo].[Carpools] ([FirstnameNonDriver],[FirstnameDriver],[Sitzplaetze],[CarName],[ZielOrt],[ZielZeit],[DeletedOrNot])" +
                    $"VALUES ({carpool.NameBeifahrer},{carpool.NameFahrer},{carpool.Sitzplaetze},{carpool.AutoMarke},{carpool.AutoZiel},GETDATE(),No)";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                   while(reader.Read());
                }
                finally
                {
                    reader.Close();
                }

            }
        }
        /// <summary>
        /// Count lines in CSV file
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
        /// Read all Carpools in the CSV file. Return a List<CarPool>
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<CarPool> CarpoolReadCsv(string path)
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
        /// <summary>
        /// Read all Carpools in the CSV file. Return a string
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<string> ReadCarpoolCsv(string path)
        {
            int counter = 1;
            List<string> liststring = new List<string>();
            using (StreamReader reader = new StreamReader(path))
            {
                while (counter <= CountLines(path))
                {
                    string linereader = reader.ReadLine();
                    string finalread = linereader + ";";
                    liststring.Add(finalread);
                    counter++;
                }
            }
            return liststring;
        }
        /// <summary>
        /// Serach for a specific Carpool in the CSV file
        /// </summary>
        /// <param name="zielort"></param>
        /// <returns></returns>
        public string FindCarpool(string zielort)
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=Carpool;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"UPDATE [dbo].[Carpools] SET Sitzplaetze = Sitzplaetze-1 WHERE ZielOrt = {zielort}";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.BeginExecuteNonQuery();
            }

            return connectionString;
        }
        private List<CarPool> SortList(List<CarPool> carpool)
        {
            List<CarPool> sortetdriverlist = new List<CarPool>();
            sortetdriverlist = carpool.OrderBy(s => s.Id).ToList();
            return sortetdriverlist;
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
                string queryString = $"DELETE FROM Carpools WHERE Carpools.IdCarpool = {id}";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
            }
            return carpools;
        }
        public List<CarPool> Showcarpool()
        {
            int counter = 0;
            List<CarPool> carPooldto = new List<CarPool>();
            var pfad1 = Assembly.GetEntryAssembly().Location;
            pfad1 = pfad1 + "\\..\\..\\..\\..\\Fahrgemeinschaften.csv"; ///////////////
            List<CarPool> carPool = CarpoolReadCsv(pfad1);
            List<string> liststring = new List<string>();
            liststring = ReadCarpoolCsv(pfad1);
            string[] strings = new string[6];
            string[] allItems = liststring.ToArray();
            return carPool;
        }
    }
}
