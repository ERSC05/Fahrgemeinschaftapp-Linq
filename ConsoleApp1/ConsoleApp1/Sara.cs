using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Sara : Fahrer
    {
        


        public Sara(string firstName, string lastName, string carType, string zielOrt, int sitzplaetze)
        {
            FirstName = firstName;
            LastName = lastName;
            CarType = carType;
            ZielOrt = zielOrt;
            Sitzplaetze = sitzplaetze;
        }
        public override void FahrersucheSara(string ort)
        {
            base.FahrersucheSara(ort);
        }
    }
}
