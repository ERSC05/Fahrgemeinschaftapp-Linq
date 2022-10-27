using TecAlliance.Carpool.Bussines.Models;
using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Bussines.Services
{
    public interface ICarpoolBussinesService1
    {
        void AddCarpool(CarPool carPool);
        List<CarpoolDto> DeleteCarpool(long id);
        string FindCarpool(string Zielort);
        List<CarpoolDto> ShowCarpool();
    }
}