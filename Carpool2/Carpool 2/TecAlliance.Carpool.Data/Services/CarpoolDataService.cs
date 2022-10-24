﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Data.Services
{
    public class CarpoolDataService
    {
        public long ReturnLastId()
        {
            var carpool1 = new CarpoolDataService();
            List<CarPool> carpool2 = carpool1.CarpoolReadCsv("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer\\Fahrgemeinschaften.csv");
            //long id = 0;
            //foreach (CarPool car in carpool2)
            //{
            //    id = car.Id;
            //}
            return carpool2.Last().Id;



        }
        public void CarpoolAddCsv(CarPool carpool)
        {
            using (StreamWriter writer = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer\\Fahrgemeinschaften.csv", true))
            {
                writer.WriteLine($"{carpool.Id};{carpool.NameBeifahrer};{carpool.NameFahrer};{carpool.Sitzplaetze};{carpool.AutoMarke};{carpool.AutoZiel};{carpool.AbfahrtZeit}");
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
                    var newcarpool = new CarPool(id, NameBeifahrer, NameFahrer, sitzplaetze, automarke, autoziel, abfahrzeit);
                    carpoolItems.Add(newcarpool);
                    counter++;
                }
            }
            return carpoolItems;
        }
        public List<string> ReadCarpoolCsv(string path)
        {
            int counter = 1;
            List<string> liststring = new List<string>();
            using (StreamReader reader = new StreamReader(path))
            {
                while (counter <= CountLines(path))
                {
                    string linereader = reader.ReadLine();
                    string finalread = linereader + ";";
                    liststring.Add(finalread);
                    counter++;
                }
            }
            return liststring;
        }
        public string FindCarpool(string zielort)
        {
            string a = "";              //tell me which return should be trow out
            long id = 0;                //id from the driver
            string nameBeifahrer = "";  //name of the 
            string nameFahrer = "";     //name from the driver
            int sitzte = 0;             //seats from the car
            string automarke = "";      //car brand from the driver
            string autoZiel = "";       //Shows me where the car is driving to
            string abfahrtzeit = "";    //shows when the car is driving

            //return werte
            string sitzarefull = "";    //shows if the seats are full
            string foundandsitz = "";   //shows if there is a car for the user and the seats are still avalible

            List<string> allCarpool = ReadCarpoolCsv("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer\\Fahrgemeinschaften.csv");
            //string[] strings = new string[6];
            string[] allItems = allCarpool.ToArray();
            List<CarPool> carPoolsAllNew = new List<CarPool>();

            foreach (string item in allItems)
            {

                string[] strings = item.Split(';');
                id = Convert.ToInt64(strings[0]);
                nameBeifahrer = strings[1];
                nameFahrer = strings[2];
                sitzte = Convert.ToInt32(strings[3]);
                automarke = strings[4];
                autoZiel = strings[5];
                abfahrtzeit = strings[6];
                if (zielort == autoZiel)
                {
                    if (sitzte <= 0)
                    {
                        a = "sitzarefull";
                        sitzarefull = $"Das Auto, dass nach {autoZiel} fährt ist schon voll.";

                    }
                }
                else if (zielort != autoZiel)
                {
                    var carPoolOne = new CarPool(id, nameBeifahrer, nameFahrer, sitzte, automarke, autoZiel, abfahrtzeit);
                    carPoolsAllNew.Add(carPoolOne);
                }
                if (zielort == autoZiel && sitzte >= 1)
                {
                    var carPoolOne = new CarPool(id, nameBeifahrer, nameFahrer, sitzte - 1, automarke, autoZiel, abfahrtzeit);
                    carPoolsAllNew.Add(carPoolOne);
                    //carpoolfound.Add(found);
                    a = "foundandsitz";
                    foundandsitz = $"You found a Carpool. you are now driving with {nameFahrer}. The car is called {automarke} and got {sitzte - 1} left. you are driving to {autoZiel}. the time is {abfahrtzeit}.";
                }
            }
            using (StreamWriter writer = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer\\Fahrgemeinschaften.csv"))
            {
                foreach (var carPool in carPoolsAllNew)
                {
                    writer.WriteLine($"{carPool.Id};{carPool.NameBeifahrer};{carPool.NameFahrer};{carPool.Sitzplaetze};{carPool.AutoMarke};{carPool.AutoZiel};{carPool.AbfahrtZeit}");
                }
            }
            if (a == "foundandsitz")
            {
                return foundandsitz;
            }
            else if (a == "sitzarefull")
            {
                return sitzarefull;
            }
            else
            {
                return $"No one is driving to {zielort}. You can see al carpools in 'Zeige Fahrer'.";
            }
        }
        private List<CarPool> SortList(List<CarPool> carpool)
        {
            List<CarPool> sortetdriverlist = new List<CarPool>();
            sortetdriverlist = carpool.OrderBy(s => s.Id).ToList();
            return sortetdriverlist;
        }
        public List<CarPool> DelitedList(long id)
        {

            CarpoolDataService sorter = new CarpoolDataService();
            List<CarPool> carpool = new List<CarPool>();
            List<string> trash = new List<string>();
            var oldcsv = CarpoolReadCsv("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer\\Fahrgemeinschaften.csv");
            foreach (CarPool carPool in oldcsv)
            {
                if (carPool.Id == id)
                {
                    trash.Add(Convert.ToString(carPool));
                }
                else
                {
                    carpool.Add(carPool);
                }
            }
            sorter.SortList(carpool);
            using (StreamWriter writer = new StreamWriter("C:\\010Projects\\Linq\\Fahrgemeinschaft\\Carpool2\\Fahrer\\Fahrgemeinschaften.csv"))
            {
                foreach (CarPool carPool in carpool)
                {
                    writer.WriteLine($"{carPool.Id};{carPool.NameBeifahrer};{carPool.NameFahrer};{carPool.Sitzplaetze};{carPool.AutoMarke};{carPool.AutoZiel};{carPool.AbfahrtZeit}");
                }
            }

            return carpool;

        }
    }
}