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
        #region ReturnCarpoolConections
        [HttpGet]//("Zeige Fahrer")]
        [Route("api/Carpool_2/Zeige_Alle_Beifahrer_Und_Fahrer_In_Einem_Bestimmtem_Carpool")]
        public List<string> ReturnCarpoolConections()
        {
            return carpoolBussinesService.ReturnCarpoolConections(); ;
        }
        #endregion
        #region GetCarPoolById
        [HttpGet]
        [Route("api/Carpool_2/ZeigeFahrerById{id}")]
        public ActionResult<List<CarpoolDto>> GetCarPoolById(int id)
        {
            var carpoolDtos = carpoolBussinesService.GetCarPoolById(id);
            if (carpoolDtos == null)
                return NotFound($"Carpool with Id: {id} does not exist");
            return carpoolDtos;
        }

        #endregion
        #region ShowAllExistCarpool
        [HttpGet]//("Zeige Fahrer")]
        [Route("api/Carpool_2/ZeigeFahrer")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<CarpoolDto>> ShowingCarpool()
        {           
            return carpoolBussinesService.ShowAllExistCarpool(); ;
        }
        #endregion
        #region FindCarpool
        [HttpPost]//("FahrgemeinschaftFinden")]
        [Route("api/Carpool_2/FahrgemeinschaftFinden{Zielort} {DeineId}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<List<CarpoolDto>> FindCarpool(string Zielort, int DeineId)
        {
            var a = carpoolBussinesService.FindCarpool(Zielort, DeineId);
            if(a.Count == 0)
            {
                return BadRequest("Carpool could not be found");
               
            }           

            else { return a; }
        }
        #endregion
        #region CreateCarpool
        [HttpPost]//("{EineFahrgemeinschaftBilden")]
        [Route("api/Carpool_2/EineFahrgemeinschaftBilden")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public string CreateCarpool(CarPool carPool)
        {
            carpoolBussinesService.AddCarpool(carPool);
            return "Carpool got created";
        }
        #endregion
        #region DeliteCarpool
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
        #endregion

        [HttpDelete]//("{Id eingeben}")]
        [Route("api/Carpool_2/IdEingebenUmDichAusAllenCarpoolsZuDeleten{driverId}")]
        public ActionResult<List<string>> DeleteAllCarpoolsByDriverId(int driverId)
        {
            var responseMessage = carpoolBussinesService.DeleteCarpoolsByDriverId(driverId);
            if (responseMessage.Count == 0)
            {
                return BadRequest("Deine Id gibt es nicht");
            }
            else 
            return responseMessage;
            
        }
        
    }
}
