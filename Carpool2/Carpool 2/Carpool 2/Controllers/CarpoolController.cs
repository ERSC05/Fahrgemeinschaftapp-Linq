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

        [HttpPost("Fahrgemeinschaft finden")]
        public string FindCarpool(string Zielort)
        {
            var returntext = carpoolBussinesService.FindCarpool(Zielort);

            return returntext;
        }

        [HttpPost("{Eine Fahrgemeinschaft Bilden}")]
        public IActionResult CreateCarpool(CarPool carPool)
        {
            carpoolBussinesService.AddCarpool(carPool);
            return CreatedAtAction("AddCarpool", new { id = carPool.Id }, carPool);
        }
        [HttpGet("Zeige Fahrer")]
        public ActionResult<List<CarpoolDto>> ShowingCarpool()
        {
            var done = carpoolBussinesService.ShowCarpool();
            return done;
        }
        [HttpDelete("{Id eingeben}")]
        public ActionResult<List<CarpoolDto>> DeliteCarpool(long id)
        {
            long idcheck = id;
            try
            {

                var delitedList = carpoolBussinesService.DeliteCarpool(id);
                return delitedList;
            }
            catch
            {
                return BadRequest($"Deine id ist {id} und diese gibt es nicht. Du kannst diese Id also nicht deliten.");
            }
        }
    }
}
