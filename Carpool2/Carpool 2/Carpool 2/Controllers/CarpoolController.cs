using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using TecAlliance.Carpool.Bussines.Models;
using TecAlliance.Carpool.Bussines.Services;
using TecAlliance.Carpool.Data.Models;

namespace Carpool_2.Controllers
{
    [ApiController]

    public class CarpoolController : Controller
    {
        ICarpoolBussinesService carpoolBussinesService;

        public CarpoolController(ICarpoolBussinesService carpoolBussinesService)
        {
            this.carpoolBussinesService = carpoolBussinesService;
        }        


        [HttpGet]//("Zeige Fahrer")]
        [Route("api/Carpool_2/ZeigeFahrer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<CarpoolDto>> ShowingCarpool()
        {
            var done = carpoolBussinesService.ShowCarpool();
            return done;
        }

        [HttpPost]//("FahrgemeinschaftFinden")]
        [Route("api/Carpool_2/FahrgemeinschaftFinden{Zielort}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public string FindCarpool(string Zielort)
        {
            var returntext = carpoolBussinesService.FindCarpool(Zielort);

            return returntext;
        }

        [HttpPost]//("{EineFahrgemeinschaftBilden")]
        [Route("api/Carpool_2/EineFahrgemeinschaftBilden")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<List<CarpoolDto>> CreateCarpool(CarPool carPool)
        {
            carpoolBussinesService.AddCarpool(carPool);
            return CreatedAtAction("AddCarpool", new { id = carPool.Id }, carPool);
        }





        [HttpDelete]//("{Id eingeben}")]
        [Route("api/Carpool_2/IdEingeben")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<CarpoolDto>> DeliteCarpool(long id)
        {
            long idcheck = id;
            try
            {

                var delitedList = carpoolBussinesService.DeleteCarpool(id);
                return delitedList;
            }
            catch
            {
                return BadRequest($"Deine id ist {id} und diese gibt es nicht. Du kannst diese Id also nicht deliten.");
            }
        }
    }
}
