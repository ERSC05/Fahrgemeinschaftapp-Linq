using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using TecAlliance.Carpool.Bussines.Models;
using TecAlliance.Carpool.Bussines.Services;
using TecAlliance.Carpool.Data.Models;
using TecAlliance.Carpool.Data.Services;

namespace Carpool_2.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class CarpoolController : Controller
    {
        ICarpoolBussinesService carpoolBussinesService;

        public CarpoolController(ICarpoolBussinesService carpoolBussinesService)
        {
            this.carpoolBussinesService = carpoolBussinesService;
        }

        [HttpGet]//("Zeige Fahrer")]
        [Route("api/Carpool_2/Zeige_Alle_Beifahrer_Und_Fahrer_In_Einem_Bestimmtem_Carpool")]
        public List<string> ReturnCarpoolConections()
        {
            
            return carpoolBussinesService.ReturnCarpoolConections(); ;
        }
        [HttpGet]
        [Route("api/Carpool_2/ZeigeFahrerById{id}")]
        public ActionResult<List<CarpoolDto>> GetCarPoolById(int id)
        {
            return carpoolBussinesService.GetCarPoolById(id);
        }

        [HttpGet]//("Zeige Fahrer")]
        [Route("api/Carpool_2/ZeigeFahrer")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<CarpoolDto>> ShowingCarpool()
        {
            var done = carpoolBussinesService.ShowAllExistCarpool();
            return done;
        }

        [HttpPost]//("FahrgemeinschaftFinden")]
        [Route("api/Carpool_2/FahrgemeinschaftFinden{Zielort} {DeineId}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public string FindCarpool(string Zielort, int DeineId)
        {
            var returntext = carpoolBussinesService.FindCarpool(Zielort, DeineId);

            return returntext;
        }

        [HttpPost]//("{EineFahrgemeinschaftBilden")]
        [Route("api/Carpool_2/EineFahrgemeinschaftBilden")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<List<CarpoolDto>> CreateCarpool(CarPool carPool)
        {
            carpoolBussinesService.AddCarpool(carPool);
            return CreatedAtAction("AddCarpool", new { id = carPool.Id }, carPool);
        }


        


        [HttpDelete]//("{Id eingeben}")]
        [Route("api/Carpool_2/IdEingeben")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
