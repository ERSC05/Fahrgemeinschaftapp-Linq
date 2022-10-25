using Swashbuckle.AspNetCore.Filters;
using TecAlliance.Carpool.Bussines.Models;

namespace TecAlliance.Carpool.Bussines
{
    public class DriverDtoDtoProvider : IExamplesProvider<DriverDto>
    {
        public DriverDto GetExamples()
        {
            return new DriverDto(
                1, "Name", 5, "marke",  "ankunfts Ziel", "abfahrt Zeit");
        }

    }
}
