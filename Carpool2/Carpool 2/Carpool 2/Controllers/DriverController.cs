using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using TecAlliance.Carpool.Bussines.Models;
using TecAlliance.Carpool.Bussines.Services;
using TecAlliance.Carpool.Data.Models;
using TecAlliance.Carpool.Data.Services;

namespace Carpool_2.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class DriverController : ControllerBase
    {
        IDriverBussinesService driverBussinesService;


        public DriverController(IDriverBussinesService driverBussinesService)
        {
            this.driverBussinesService = driverBussinesService;
        }


        [HttpGet]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<DriverDto>>> GetDriver()
        {
            //try
            //{
                var test = driverBussinesService.ReadDriver();
                return test;
            //}
            //catch 
            //{ 
                return BadRequest($"Driver does not exist"); 
            //}
        }
        [HttpGet("{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<DriverDto>>> GetDriverId(long id)
        {
            try
            {
                var test = driverBussinesService.Get(id);

                if (test.Count == 0)
                {
                    return BadRequest($"{id} does not exist");
                }
                return test;
            }
            catch
            {
                return BadRequest($"{id} does not exist");
            }
        }

        [HttpPost]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateDriver(DriverDto driverdto)
        {
            try
            {
                //Driver driver = new Driver(driverdto.Id,driverdto.Name,driverdto.Sitzplaetze,driverdto.AutoMarke, driverdto.FahrtZiehl,driverdto.AbfahrtZeit);
                driverBussinesService.AddDriver(driverdto);
                return CreatedAtAction("AddDriver", new { id = driverdto.Id }, driverdto);
            }
            catch
            {
                return BadRequest($"{driverdto} it not a driver");
            }
        }
        [HttpDelete("{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<DriverDto>> DeliteDriver(long id)
        {
            try
            {


                var newlist = driverBussinesService.DeliteDriver(id);

                return newlist;
            }
            catch
            {
                return BadRequest($"{id} does not exist");
            }
        }

    }

}