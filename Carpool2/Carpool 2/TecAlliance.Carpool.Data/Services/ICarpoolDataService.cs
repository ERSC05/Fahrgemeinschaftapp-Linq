using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Data.Services
{
    public interface ICarpoolDataService
    {
        /// <summary>
        /// Adding one Carpool in the database/csv file
        /// </summary>
        /// <param name="carpool"></param>
        void CarpoolAddCsv(CarPool carpool);
        List<CarPool> CarpoolReadCsv(string path);
        /// <summary>
        /// delete a carpool in the csf/database and shows the rest of the list.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<CarPool> DelitedList(long id);
        /// <summary>
        /// Return a Carpool with the given place you want to drive to
        /// </summary>
        /// <param name="zielort"></param>
        /// <returns></returns>
        string FindCarpool(string zielort);
        /// <summary>
        /// read all Carpools from the database/csv file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        List<string> ReadCarpoolCsv(string path);
        /// <summary>
        /// Return a List with all existing and Carpools that existed in the past
        /// </summary>
        /// <returns></returns>
        public List<CarPool>? Showcarpool();
    }
}