using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Data.Services
{
    public interface IDriverDataService
    {
        /// <summary>
        /// delete a Driver in the csf/database and shows the rest of the list.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Driver> DeliteDriver(long id);
        /// <summary>
        /// Adding one Driver in the database/csv file
        /// </summary>
        /// <param name="driver"></param>
        public Driver DriverAddCsv(Driver driver);
        public Driver GetDriverById(int fahrerId);
        public List<Driver> ReadDriver();
    }
}