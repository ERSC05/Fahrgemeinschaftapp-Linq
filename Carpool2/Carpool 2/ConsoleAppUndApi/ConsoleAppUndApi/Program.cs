using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ConsoleAppUndApi
{
    public class Program
    {
        static string baseUri = "https://localhost:7137/";
        static async Task Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("1: ReturnCarpoolConections");
                Console.WriteLine("2: GetAllPassanger");
                Console.WriteLine("3: GetCarPoolById");
                Console.WriteLine("4: ShowAllDriverWithCarpool");

                string counter = Console.ReadLine();
                switch (counter)
                {

                    #region case1
                    case ("1"):
                        Console.WriteLine("gebe deine id ein");
                        int id = Convert.ToInt32(Console.ReadLine());
                        var carpoolsById = GetUserByIdAsync(id).Result;
                        foreach (var carpool in carpoolsById)
                        {
                            int CarpoolCounter = 1;
                            Console.WriteLine($"id : {carpool.id}");
                            Console.WriteLine($"name Fahrer : {carpool.nameFahrer}");
                            Console.WriteLine($"Sitze : {carpool.sitzplaetze}");
                            Console.WriteLine($"Automarke : {carpool.autoMarke}");
                            Console.WriteLine($"Ziel Ort : {carpool.autoZiel}");
                            Console.WriteLine($"Abfahrts Zeit : {carpool.abfahrtZeit}");
                            Thread.Sleep(2000);
                            Console.Clear();
                        }
                        Console.ReadLine();
                        //carpoolsById;
                        break;
                    #endregion
                    #region case2
                    case ("2"):

                        var carpoolAll = GetAllPassanger().Result;
                        foreach (var carpool in carpoolAll)
                        {
                            Console.WriteLine($"id : {carpool.id}");
                            Console.WriteLine($"name Beifaher : {carpool.nameBeifahrer}");
                            Console.WriteLine($"name Fahrer : {carpool.nameFahrer}");
                            Console.WriteLine($"Sitze : {carpool.sitzplaetze}");
                            Console.WriteLine($"Automarke : {carpool.autoMarke}");
                            Console.WriteLine($"Ziel Ort : {carpool.autoZiel}");
                            Console.WriteLine($"Abfahrts Zeit : {carpool.abfahrtZeit}");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                        //carpoolAll;
                        break;
                    #endregion
                    #region case3
                    case "3":
                        Console.WriteLine("Gebe die id ein ");

                        int idFromCarpoo = Convert.ToInt32(Console.ReadLine());
                        //var carPoolById = new List<Carpool>();

                        var carPoolById = await GetCarPoolById(idFromCarpoo);

                        foreach (var carPool in carPoolById)
                        {
                            Console.WriteLine($"id = {carPool.id}");
                            Console.WriteLine($"name Fahrer : {carPool.nameFahrer}");
                            Console.WriteLine($"Anzahl Sitze : {carPool.sitzplaetze}");
                            Console.WriteLine($"Automarke : {carPool.autoMarke}");
                            Console.WriteLine($"Auto Ziel : {carPool.autoZiel}");
                            Console.WriteLine($"Abfahrt Zeit : {carPool.abfahrtZeit}");
                        }
                        Thread.Sleep(2000);
                        break;
                    #endregion
                    #region case4
                    case ("4"):

                        var driverWithCarpool = await ShowAllDriverWithCarpool();
                        foreach (var carpool in driverWithCarpool)
                        {
                            Console.Clear();
                            Console.WriteLine($"id = {carpool.id}");
                            Console.WriteLine($"name Fahrer : {carpool.nameFahrer}");
                            Console.WriteLine($"Anzahl Sitze : {carpool.sitzplaetze}");
                            Console.WriteLine($"Automarke : {carpool.autoMarke}");
                            Console.WriteLine($"Auto Ziel : {carpool.autoZiel}");
                            Console.WriteLine($"Abfahrt Zeit : {carpool.abfahrtZeit}");
                            Thread.Sleep(1000);
                        }

                        break;
                    #endregion
                    #region case5
                    case "5":
                        Console.Clear();
                        Console.WriteLine("gebe an wo du hinfahren willst");
                        string zielOrt = Console.ReadLine();
                        Console.WriteLine("gebe deine id ein");
                        var idUser = Convert.ToInt32(Console.ReadLine());
                        var foundedCarpool = await FahrgemeinschaftFinden(zielOrt, idUser);
                        foreach (var carpool in foundedCarpool)
                        {
                            Console.WriteLine($"id = {carpool.id}");
                            Console.WriteLine($"name Fahrer : {carpool.nameFahrer}");
                            Console.WriteLine($"Anzahl Sitze : {carpool.sitzplaetze}");
                            Console.WriteLine($"Automarke : {carpool.autoMarke}");
                            Console.WriteLine($"Auto Ziel : {carpool.autoZiel}");
                            Console.WriteLine($"Abfahrt Zeit : {carpool.abfahrtZeit}");
                            Thread.Sleep(1000);
                        }
                        break;

                    #endregion
                    #region  case6
                    case "6":
                        Console.Clear();
                        Console.WriteLine("gebe die Daten ein");
                        Thread.Sleep(2000);
                        Console.Write($"name Fahrer: ");
                        var nameFahrer = Console.ReadLine();
                        Console.Clear();
                        Console.Write("Anzahl sitze: ");
                        int sitze = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        Console.Write("Automarke: ");
                        var autoMarke = Console.ReadLine();
                        Console.Clear();
                        Console.Write("ZielOrt: ");
                        var ort = Console.ReadLine();
                        Console.Clear();
                        Console.Write("Abfahrt Zeit: ");
                        var Zeit = Console.ReadLine();

                        var carpool1 = new Carpool(1, "memmet", nameFahrer, sitze, autoMarke, ort, Zeit);
                        carpool1.driver = new DriverDtoClass(0, "_", 0, "_", "_", "_", "_");
                        Console.Clear();
                        CreateCarpool(carpool1);
                        Console.WriteLine();
                        Thread.Sleep(2000);
                        break;
                    #endregion
                    #region case7
                    case "7":

                        break;
                    #endregion
                    case "8":
                        WriteCharacterStrings(1, 1000000000, true);
                        break;
                    default:
                        break;
                }
            } while (true);
        }



        public void Kuh()
        {
            WriteCharacterStrings(1, 1000000000, true);
        }
        static void WriteCharacterStrings(int start, float end, bool changeColor)
        {
            for (int ctr = start; ctr <= end; ctr++)
            {
                if (changeColor)
                {
                    Console.BackgroundColor = (ConsoleColor)((ctr - 1) % 16);
                    Console.ForegroundColor = (ConsoleColor)((ctr - 1) % 5);
                }
                //Thread.Sleep(100);
                Console.WriteLine("                                                                               \r\n                                           @@                                   \r\n                                         /%(&,                                  \r\n                                         @(((@ .,,,       @(@                   \r\n                             &@.    .@@  @&         ,@@@@@((@.                  \r\n                            @   ......              @@@@@@@@&                   \r\n                            ,@   ....                   .@@@@% */*.             \r\n                                &@@@                    %@@@@@@....@@@@         \r\n                                   @    @,@             (, @@@@......@@@        \r\n                                  */   ,   #           @@/@ %@@@&#%@@@@         \r\n                                  ,(         ,/((*.     *     &                 \r\n                                   @  (@*............../@/    @                 \r\n                                   .@...,@@&.........,@@,..@.@                  \r\n                            &@@*   @.....#&..........,@@,...*%                  \r\n                         @         %*........................%                  \r\n                       .%       @@@  @,......@....@........&#      ,&@@@@       \r\n                        &       (/  ....&@/............/@@@@@@@      @@@@*      \r\n                        #*        @,..................               @@@@&      \r\n                         ,&     @@@@@..................              %@@@(      \r\n                           @%@@@@@@@....................  ##%&@@@&#,            \r\n                           *&@@@@,......................  ./                    \r\n                         *@     ........................  (*                    \r\n                       &(        ......................   @                     \r\n                    /@.              ................    @                      \r\n                   @@@@/      .%@@@/                   ,&                       \r\n                    @@@@@(,@.          ,&@@             @*   &@@,               \r\n                      @@@                  ,#        *#@@. (@%%&@               \r\n                                            @        @                          \r\n                                            @       @                           \r\n                                            @@@@@@@@&                           \r\n                                           ,@@@@@@@@*                           \r\n                                                                              ");
                Thread.Sleep(100);
                Console.Clear();
                Console.WriteLine("                                                                                \r\n                                                                                \r\n                                                                                \r\n                                    @@                                          \r\n                                   &((@                                         \r\n                   /%%%      .,,,. @(((%                                        \r\n                   ##((@@@@@          @@  @@     *@,                            \r\n                    @@@@@@@@@              ......   @                           \r\n              ,//, @@@@@                    ....   @                            \r\n          @@@#...,@@@@@@.                   #@@@#                               \r\n         @@#......@@@@ /*            (%*@    @                                  \r\n          @@@@##@@@@, @%@@           #   .   @                                  \r\n                 #,    ..     .*((/.         @                                  \r\n                  @    %@*..............(@.  @                                  \r\n                   &##..%@@..........@@@...*@                                   \r\n                   @....%@&...........&*....,%   (@@#                           \r\n                   @........................&.        .@                        \r\n        @@@@#       @/.......(&...*@......(@  @@(       @                       \r\n       @@@@@      @@@@@@@,............#@#...   @.       @                       \r\n       @@@@*              .................../@        &                        \r\n       @@@@               .................*@@@@&     @                         \r\n             *%&@@@&#@   ....................@@@@@@@%#                          \r\n                     @   ....................../@@@&@                           \r\n                     %   ........................     @                         \r\n                      @   .....................         @/                      \r\n                       &   .................              &@                    \r\n                        @                    %@@@#       &@@@@                  \r\n                (@@#   %@            .@@%.          (@ @@@@@@                   \r\n               .@%%%@  *@%@         @                  ,@@@                     \r\n                           @       .%                                           \r\n                           */      ,#                                           \r\n                            @@@@@@@@@                                           \r\n                            &@@@@@@@@                                           \r\n                                                                                ");
                Thread.Sleep(100);
                Console.Clear();
            }
            Console.ResetColor();
            Console.Clear();
        }//Der Flex


        public static async Task<List<Carpool>> GetCarPoolById(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(baseUri + "Carpool/api/Carpool_2/ZeigeFahrerById" + id.ToString());
            var userJsomString = responseMessage.Content.ReadAsStringAsync().Result;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Carpool>>(userJsomString);
        }


        public static async Task<List<Carpool>> GetUserByIdAsync(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(baseUri + "Carpool/api/Carpool_2/GetAllPassengerById?id=" + id.ToString());
            var UserJsonString = response.Content.ReadAsStringAsync().Result;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Carpool>>(UserJsonString);
        }
        public static async Task<List<Carpool>> GetAllPassanger()
        {
            var carpools = new List<Carpool>();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(baseUri + "Carpool/api/Carpool_2/GetAllPassenger");
            carpools = await response.Content.ReadAsAsync<List<Carpool>>();
            return carpools;
        }
        public static async Task<List<Carpool>> ShowAllDriverWithCarpool()
        {
            var carpools = new List<Carpool>();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(baseUri + "Carpool/api/Carpool_2/ZeigeFahrer");
            carpools = await response.Content.ReadAsAsync<List<Carpool>>();
            return carpools;
        }
        public static async Task<List<Carpool>> FahrgemeinschaftFinden(string zielOrt, int userId)
        {
            var carpools = new List<Carpool>();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(baseUri + "Carpool/api/Carpool_2/FahrgemeinschaftFinden/" + zielOrt + "/" + userId, new StringContent(""));
            carpools = await response.Content.ReadAsAsync<List<Carpool>>();
            return carpools;
        }
        public static async Task CreateCarpool(Carpool carpool)
        {
            HttpClient client = new HttpClient();
            var userString = JsonConvert.SerializeObject(carpool);
            HttpResponseMessage response = await client.PutAsync(baseUri + "Carpool/api/Carpool_2/EineFahrgemeinschaftBilden", new StringContent(userString, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Put successful:^)!");
            }
            else
            {
                Console.WriteLine($"(statuscode): {response.StatusCode}");
            }

        }
        public static async Task DeliteCarpool(long id)
        {
            var carpools = new List<Carpool>();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(baseUri + "Carpool/api/Carpool_2/IdEingeben?id=" + id);
            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine();
            }
        }
    }
}