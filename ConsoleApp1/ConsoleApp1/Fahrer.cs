using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Fahrer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CarType { get; set; }
        public string ZielOrt { get; set; }
        public int Sitzplaetze { get; set; }
        public virtual void Write()
        {
            Console.WriteLine($"{FirstName} ${LastName} Fährt nach: ${ZielOrt}");
        }
        public virtual void FahrersucheSara(string ort)
        {

            Console.WriteLine("gebe ein wieviel du mitnehmen willst");
            int sitzplaetze = Convert.ToInt32(Console.ReadLine());
            if (sitzplaetze <= this.Sitzplaetze)
            {
                Console.WriteLine("Wann willst du fahren?");


                string wann = Console.ReadLine();
                if (wann == "morgen")
                {
                    Console.WriteLine($"Morgen kannst du mit {this.GetType().Name} fahren");
                }
                else
                {
                    Console.WriteLine($"{this.GetType().Name} färt nicht {wann}. Du darfst also nicht fahren");

                }


            }
            else
            {

                Console.WriteLine($"{this.GetType().Name} hat nur {this.Sitzplaetze} Sitze also kannst du nicht mitfahren.");

            }

        }
        public virtual void FahrersucheFerdinant(string ort)
        {

            if (ort == "mgh")
            {
                Console.WriteLine("gebe ein wieviel du mitnehmen willst");
                int sitzplaetze = Convert.ToInt32(Console.ReadLine());
                if (sitzplaetze <= Sitzplaetze)
                {
                    Console.WriteLine("Wann willst du fahren?");


                    string wann = Console.ReadLine();
                    if (wann == "morgen")
                    {
                        Console.WriteLine($"Morgen kannst du mit {GetType().Name} fahren");
                    }
                    else
                    {
                        Console.WriteLine($"{GetType().Name} färt nicht {wann}. Du darfst also nicht fahren");

                    }


                }
                else
                {

                    Console.WriteLine($"{GetType().Name} hat nur {Sitzplaetze} Sitze also kannst du nicht mitfahren.");

                }
            }
            else
            {
                Console.WriteLine($"Du darfst nicht mit mitfahren fahren");
            }
        }
        public void FahrerEdit()
        {
            string path = @"C:\010Projects\Linq\Fahrgemeinschaft\UserEigenschaft.csv";
            Console.WriteLine("Gib deinen vornamen ein");
            string Uvorname = Console.ReadLine();

            Console.WriteLine("Gib deinen Nachnamen ein");
            string Unachname = Console.ReadLine();
            Console.WriteLine("Gib dein Auto ein");
            string UCartype = Console.ReadLine();
            Console.WriteLine("Gib dien Ziel Ort ein");
            string ZiehlOrt = Console.ReadLine();
            Console.WriteLine("Gib ein wieviele Sitzplätze du hast");
            string splaetze = Console.ReadLine();
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(Uvorname);
                sw.WriteLine(Unachname);
                sw.WriteLine(UCartype);
                sw.WriteLine(ZiehlOrt);
                sw.WriteLine(splaetze);
                sw.WriteLine();
            }
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }




    }
}
