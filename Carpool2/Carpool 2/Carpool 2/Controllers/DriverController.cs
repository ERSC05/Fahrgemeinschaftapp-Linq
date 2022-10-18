using Microsoft.AspNetCore.Mvc;
using TecAlliance.Carpool.Bussines.Models;
using TecAlliance.Carpool.Bussines.Services;
using TecAlliance.Carpool.Data.Models;

namespace Carpool_2.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class DriverController : ControllerBase
    {
        DriverBussinesService driverBussinesService;



        public DriverController()
        {
            driverBussinesService = new DriverBussinesService();
        }


        //[HttpGet]
        //public List<DriverDto> Get() =>
        //    _repository.GetProducts();



        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DriverDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            return Ok(id);
        }

        public IActionResult GetById(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else if (id == null)
            {
                return NotFound();
            }
            else
            {
                return NotFound();
            }
        }




        [HttpPost]
        public static Task<ActionResult<DriverDto>> CreateDriver(DriverDto driverDto)
        {
            var driver = new Driver(driverDto.Id, driverDto.Name, driverDto.Sitzplaetze, driverDto.AutoMarke, driverDto.FahrtZiehl, driverDto.AbfahrtZeit);
            return driver;

        }


    }
    
}