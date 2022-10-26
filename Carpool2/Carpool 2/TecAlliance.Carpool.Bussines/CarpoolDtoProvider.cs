using Swashbuckle.AspNetCore.Filters;
using TecAlliance.Carpool.Bussines.Models;

namespace TecAlliance.Carpool.Bussines
{
    public class CarpoolDtoProvider : IExamplesProvider<CarpoolDto>
    {
        public CarpoolDto GetExamples()
        {
            return new CarpoolDto(
                1, "NameDeinesBeifahrers", "NameDesFahrers", 5, "AutoMarke", "Zielort", "WannFährstDu");
        }

    }
}
