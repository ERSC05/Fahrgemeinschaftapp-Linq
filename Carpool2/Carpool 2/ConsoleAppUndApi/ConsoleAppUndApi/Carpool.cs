using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppUndApi
{
    public class Carpool
    {
        public long id { get; set; }
        public string nameBeifahrer { get; set; }
        public string nameFahrer { get; set; }
        public int sitzplaetze { get; set; }
        public string autoMarke { get; set; }
        public string autoZiel { get; set; }
        public string abfahrtZeit { get; set; }
        public DriverDtoClass driver { get; set; }

        public Carpool(long id, string nameBeifahrer, string nameFahrer, int sitzplaetze, string autoMarke, string autoZiel, string abfahrtZeit)
        {
            this.id = id;
            this.nameBeifahrer = nameBeifahrer;
            this.nameFahrer = nameFahrer;
            this.sitzplaetze = sitzplaetze;
            this.autoMarke = autoMarke;
            this.autoZiel = autoZiel;
            this.abfahrtZeit = abfahrtZeit;
        }
    }
}
