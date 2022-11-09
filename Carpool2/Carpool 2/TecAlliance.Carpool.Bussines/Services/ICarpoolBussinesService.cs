using TecAlliance.Carpool.Bussines.Models;
using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Bussines.Services
{
    public interface ICarpoolBussinesService
    {
        /// <summary>
        /// Adding Carpool in CSV file
        /// </summary>
        /// <param name="carPool"></param>
        void AddCarpool(CarPool carPool);
        /// <summary>
        /// A Carpool is getting delete. The bool is going to set to yes. else it's set to no
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<CarpoolDto> DeleteCarpool(long id);
        /// <summary>
        /// search for a Carpool, which is driving to the giving place
        /// </summary>
        /// <param name="Zielort"></param>
        /// <returns></returns>
        string FindCarpool(string Zielort);
        /// <summary>
        /// Shows all Carpools. All that exist and all that existed.
        /// </summary>
        /// <returns></returns>
        List<CarpoolDto> ShowAllExistCarpool();
    }
}