using FluentAssertions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Reflection.Metadata.Ecma335;
using TecAlliance.Carpool.Bussines.Models;
using TecAlliance.Carpool.Bussines.Services;
using TecAlliance.Carpool.Data.Models;
using TecAlliance.Carpool.Data.Services;

namespace TestProject3
{
    [TestClass]
    public class UnitTest1
    {
        //private ICarpoolBussinesService carpoolBussines;
        //private CarpoolBussinesService carpoolBussinesService = new CarpoolBussinesService();
        private CarpoolDataService carpoolDataService = new CarpoolDataService();


        [TestMethod]

        public void AddCarpool()
        {
            int counter = 0;
            while (counter <= 1000)
            {
                var finalString = Randomentry();
                int randomintnumber = Randointmnumber();
                long randomlongnumber = Randolongmnumber();

                long id = randomlongnumber;
                string nameBeifahrer = finalString;
                string nameFahrer = finalString;
                int stitzplaetze = randomintnumber;
                string automarke = finalString;
                string autoZiel = finalString;
                string abfahrtzeit = finalString;
                var carpool = new CarPool(id, nameBeifahrer, nameFahrer, stitzplaetze, automarke, autoZiel, abfahrtzeit);

                counter++;
            }
        }
        static string Randomentry()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789;.-;.-= 0";
            var stringChars = new char[1];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;

        }
        static int Randointmnumber()
        {
            var chars = "1234567890";
            int[] stringChars = new int[1];
            var random = new Random();
            int finalint = 0;

            for (int i = 0; i < stringChars.Length; i++)
            {
                finalint = random.Next(chars.Length);
            }
            return finalint;
        }
        static long Randolongmnumber()
        {
            var chars = "1234567890";
            long[] stringChars = new long[1];
            var random = new Random();
            long finalint = 0;

            for (int i = 0; i < stringChars.Length; i++)
            {
                finalint = random.Next(chars.Length);
            }
            return finalint;
        }
        [TestMethod]
        public void FindCarpool()
        {
            string autoZiel = "wkh";
            string notexist = $"Das Auto, dass nach {autoZiel} fährt ist schon voll.";
            string notexist1 = $"No one is driving to {autoZiel}. You can see al carpools in 'Zeige Fahrer'.";
            CarpoolDataService carpoolDataService = new CarpoolDataService();
            carpoolDataService.FindCarpool(autoZiel);

            var b = carpoolDataService.FindCarpool("wkh");
            b.Should().NotBe(notexist).And.Be(notexist1);


        }

        
        [TestMethod]
        public void DeleteList()
        {
            int randomintnumber = Randointmnumber();
            int saver = randomintnumber;
            List<CarPool> carPools = new List<CarPool>();
            CarpoolDataService carpoolDataService = new CarpoolDataService();
            var b = carpoolDataService.DelitedList(randomintnumber);
            //int b21 = 0;
            foreach (CarPool carPool in carPools)
            {
                if (carPool.Id == saver)
                {
                    carPool.Id.Should().Be(saver);
                }
            }
        }
        
    }
    //var carpools = carpoolDataService.Showcarpool();
    //int b = 0;
    //carpools.Should().NotBeNull().And.HaveCountGreaterThan(0);
    
}