using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Bastian : Fahrer
    {

        public Bastian(string firstName, string lastName, string carType, string zielOrt, int sitzplaetze)
        {
            FirstName = firstName;
            LastName = lastName;
            CarType = carType;
            ZielOrt = zielOrt;
            Sitzplaetze = sitzplaetze;
        }
    }
}
