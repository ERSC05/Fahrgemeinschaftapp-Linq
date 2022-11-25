using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppUndApi
{
    public class DriverDtoClass
    {
        public long id { get; set; }
        public string name { get; set; }
        public int sitzplaetze { get; set; }
        public string autoMarke { get; set; }
        public string fahrtZiehl { get; set; }
        public string abfahrtZeit { get; set; }
        public string deletedOrNot { get; set; }


        public DriverDtoClass(long id, string name, int sitzplaetze, string autoMarke, string fahrtZiehl, string abfahrtZeit, string deletedOrNot)
        {
            this.id = id;
            this.name = name;
            this.sitzplaetze = sitzplaetze;
            this.autoMarke = autoMarke;
            this.fahrtZiehl = fahrtZiehl;
            this.abfahrtZeit = abfahrtZeit;
            this.deletedOrNot = deletedOrNot;
        }
    }
}
