using Microsoft.AspNetCore.Mvc;
using TecAlliance.Carpool.Bussines.Models;
using TecAlliance.Carpool.Bussines.Services;
using TecAlliance.Carpool.Data.Models;

namespace Carpool_2.Controllers
{
    public class CarpoolController : Controller
    {
        CarpoolBussinesService carpoolBussinesService;

        public CarpoolController()
        {
            carpoolBussinesService = new CarpoolBussinesService();
        }


        [HttpPost("{Fahrgemeinschaft}")]
        public IActionResult CreateCarpool(CarPool carPool)
        {
            carpoolBussinesService.AddCarpool(carPool);
            return CreatedAtAction("AddCarpool", new { id = carPool.Id }, carPool);
        }
        [HttpPost("{Zeige Fahrer}")]
        public ActionResult<List<CarpoolDto>> ShowCarpool(CarPool carpool)
        {
            var done = carpoolBussinesService.ShowCarpool();
            return done;
        }

    }
}
