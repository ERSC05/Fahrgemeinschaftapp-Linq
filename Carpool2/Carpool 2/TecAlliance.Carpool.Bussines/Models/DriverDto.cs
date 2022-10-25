using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecAlliance.Carpool.Bussines.Models
{
    public class DriverDto
    {
        
        public long Id { get; set; }
        public string Name { get; set; }
        public int Sitzplaetze { get; set; }
        public string AutoMarke { get; set; }
        public string FahrtZiehl { get; set; }
        public string AbfahrtZeit { get; set; }

        public DriverDto(long id, string name, int sitzplaetze, string autoMarke, string fahrtZiehl, string abfahrtZeit)
        {
            Id = id;
            Name = name;
            Sitzplaetze = sitzplaetze;
            AutoMarke = autoMarke;
            FahrtZiehl = fahrtZiehl;
            AbfahrtZeit = abfahrtZeit;
        }
    }
}


