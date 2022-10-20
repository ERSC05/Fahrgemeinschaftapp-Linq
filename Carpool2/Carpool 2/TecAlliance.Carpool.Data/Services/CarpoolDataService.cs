using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Data.Services
{
    public class CarpoolDataService
    {
        public void CarpoolAddCsv(CarPool carpool)
        {

            //int a = 
            using (StreamWriter writer = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer\\Fahrgemeinschaften.csv", true))
            {

                var newLine = $"{carpool.Id};{carpool.NameBeifahrer};{carpool.NameFahrer};{carpool.Sitzplaetze};{carpool.AutoMarke};{carpool.AutoZiel};{carpool.AbfahrtZeit}";
                writer.WriteLine(newLine);
            }
        }
        private static int CountLines(string fileToCount)
        {
            int counter = 0;
            using (StreamReader countReader = new StreamReader(fileToCount))
            {
                while (countReader.ReadLine() != null)
                {
                    counter++;
                }
                return counter;
            }

        }
        public List<CarPool> CarpoolReadCsv(string path)
        {
            List<CarPool> carpoolItems = new List<CarPool>();
            int counter = 1;
            using (StreamReader reader = new StreamReader(path))
            {


                while (counter <= CountLines(path))
                {

                    //2;Lucas;4;bmw;wkh;morgen
                    string csveintraege = reader.ReadLine();
                    string[] splittedstring = csveintraege.Split(';');
                    var id = Convert.ToInt64(splittedstring[0]);
                    string NameBeifahrer = splittedstring[1];
                    string NameFahrer = splittedstring[2];
                    int sitzplaetze = Convert.ToInt32(splittedstring[3]);
                    string automarke = splittedstring[4];
                    string autoziel = splittedstring[5];
                    string abfahrzeit = splittedstring[6];
                    var newcarpool = new CarPool(id,NameBeifahrer,NameFahrer,sitzplaetze,automarke,autoziel,abfahrzeit);
                    carpoolItems.Add(newcarpool);

                    counter++;
                }
            }
            return carpoolItems;
        }
    }
}
