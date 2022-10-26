using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Data.Services
{
    public interface ICarpoolDataService
    {
        void CarpoolAddCsv(CarPool carpool);
        List<CarPool> CarpoolReadCsv(string path);
        List<CarPool> DelitedList(long id);
        string FindCarpool(string zielort);
        List<string> ReadCarpoolCsv(string path);
        long ReturnLastId();
    }
}