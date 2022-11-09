using TecAlliance.Carpool.Bussines.Models;

namespace TecAlliance.Carpool.Bussines.Services
{
    public interface IDriverBussinesService
    {
        /// <summary>
        /// Create a new Driver with the given informations
        /// </summary>
        /// <param name="carPool"></param>
        void AddDriver(DriverDto driverDto);
        /// <summary>
        /// Delete Driver at given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<DriverDto> DeliteDriver(long id);
        /// <summary>
        /// Show u a List with one Drive with the given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<DriverDto> Get(long id);
        /// <summary>
        /// Read all Driver from database for further processing
        /// </summary>
        /// <returns></returns>
        List<DriverDto> ReadDriver();
    }
}