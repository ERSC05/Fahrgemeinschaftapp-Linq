using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Data.Services
{
    public interface IDriverDataService
    {
        List<Driver> DeliteDriver(long id);
        void DriverAddCsv(Driver driver);
        List<Driver> DriverReadCsv(string path);
    }
}