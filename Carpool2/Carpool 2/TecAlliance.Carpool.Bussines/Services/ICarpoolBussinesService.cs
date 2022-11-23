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
        /// search for a Carpool, which is driving to the giving place
        /// </summary>
        /// <param name="Zielort"></param>
        /// <returns></returns>
        public List<CarpoolDto> FindCarpool(string Zielort, int id);
        /// <summary>
        /// Shows all Carpools. All that exist and all that existed.
        /// </summary>
        /// <returns></returns>
        public List<CarpoolDto> ShowAllExistCarpool();
        public List<string> ReturnCarpoolConections();
        public List<CarpoolDto> GetCarPoolById(int id);
        public List<string> DeleteCarpoolsByDriverId(int idUser);
        public List<CarpoolDto> DeleteCarpool(long id);

    }
}