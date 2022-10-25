using Swashbuckle.AspNetCore.Filters;
using TecAlliance.Carpool.Bussines.Models;

namespace TecAlliance.Carpool.Bussines
{
    public class CarpoolDtoProvider : IExamplesProvider<CarpoolDto>
    {
        public CarpoolDto GetExamples()
        {
            return new CarpoolDto(1, "Name deines Beifahrers", "Name des Fahrers", 5, "Auto Marke", "Zielort", "Wann fährst du");
        }

    }
}
