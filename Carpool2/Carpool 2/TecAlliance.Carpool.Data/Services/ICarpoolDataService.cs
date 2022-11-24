using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Data.Services
{
    public interface ICarpoolDataService
    {
        /// <summary>
        /// Adding one Carpool in the database/csv file
        /// </summary>
        /// <param name="carpool"></param>
        public void CarpoolAddCsv(CarPool carpool);
        List<CarPool> CarpoolReadDatabase();
        /// <summary>
        /// delete a carpool in the csf/database and shows the rest of the list.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<CarPool> DeletedList(long id);
        /// <summary>
        /// Return a Carpool with the given place you want to drive to
        /// </summary>
        /// <param name="zielort"></param>
        /// <returns></returns>
        public CarPool AddPersonToCarpool(string zielort, int personId);
        public List<CarPool> ReturnCarpoolConections();
        public CarPool GetCarPoolById(int carpoolId);
        public string DeleteCarpoolsByDriverId(int idUser);
        public CarPool UpdateCarpool(long id);
        public void DriverToCarpoolAdd(long idCarpool, long idPerson);
        public List<CarPool> GetAllPassangerById(int id);

    }
}