using Swashbuckle.AspNetCore.Filters;
using TecAlliance.Carpool.Bussines.Models;

namespace TecAlliance.Carpool.Bussines
{
    public class CarpoolDtoProvider : IExamplesProvider<List<CarpoolDto>>
    {
        public List<CarpoolDto> GetExamples()
        {

            return new List<CarpoolDto>
            { new CarpoolDto(1, "NameDeinesBeifahrers", "NameDesFahrers", 5, "AutoMarke", "Zielort", "WannFährstDu")
            };
        }

    }
    public class CarpoolDProvider : IExamplesProvider<CarpoolDto>
    {
        public CarpoolDto GetExamples()
        {
            return new CarpoolDto(1, "NameDeinesBeifahrers", "NameDesFahrers", 5, "AutoMarke", "Zielort", "WannFährstDu");
        }
    }

}



