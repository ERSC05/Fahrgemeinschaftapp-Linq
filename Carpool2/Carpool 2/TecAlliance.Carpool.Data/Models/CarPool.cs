using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecAlliance.Carpool.Data.Models
{
    public class CarPool
    {
        public long Id { get; set; }
        public string NameBeifahrer { get; set; }
        public string NameFahrer { get; set; }
        public int Sitzplaetze { get; set; }
        public string AutoMarke { get; set; }
        public string AutoZiel { get; set; }
        public string AbfahrtZeit { get; set; }
        public Driver Driver { get; set; }

        public CarPool(long id, string nameBeifahrer, string nameFahrer, int sitzplaetze, string autoMarke, string autoZiel, string abfahrtZeit)
        {
            Id = id;
            NameBeifahrer = nameBeifahrer;
            NameFahrer = nameFahrer;
            Sitzplaetze = sitzplaetze;
            AutoMarke = autoMarke;
            AutoZiel = autoZiel;
            AbfahrtZeit = abfahrtZeit;

        }

        
    }

}
