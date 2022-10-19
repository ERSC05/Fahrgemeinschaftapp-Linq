
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecAlliance.Carpool.Data.Models
{
    public class Fahrgemeinschaften
    {
        public int? Sitzplaetze { get; set; }
        public string? AutoMarke { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? ZielOrt { get; set; }
        public string? ZielZeit { get; set; }

        public Fahrgemeinschaften(int? sitzplaetze, string? autoMarke, string? name, string? lastname, string? zielOrt, string? zielZeit)
        {
            Sitzplaetze = sitzplaetze;
            AutoMarke = autoMarke;
            Name = name;
            Lastname = lastname;
            ZielOrt = zielOrt;
            ZielZeit = zielZeit;
        }

    }
}
