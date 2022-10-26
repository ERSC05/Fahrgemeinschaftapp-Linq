using TecAlliance.Carpool.Bussines.Models;

namespace TecAlliance.Carpool.Bussines.Services
{
    public interface IDriverBussinesService
    {
        void AddDriver(DriverDto driverDto);
        List<DriverDto> DeliteDriver(long id);
        List<DriverDto> Get(long id);
        List<DriverDto> ReadDriver();
    }
}