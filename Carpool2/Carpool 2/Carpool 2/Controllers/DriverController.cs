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
        DriverBussinesService driverBussinesService;


        public DriverController()
        {
            driverBussinesService = new DriverBussinesService();
        }


        [HttpGet]       /////////
        public async Task<ActionResult<List<DriverDto>>> GetDriver()
        {
            var test = driverBussinesService.ReadDriver();
            return test;
        }
        [HttpGet("{id}")]        /////////
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

        [HttpPost]      /////////
        public IActionResult CreateDriver(DriverDto driverdto)
        {
            //Driver driver = new Driver(driverdto.Id,driverdto.Name,driverdto.Sitzplaetze,driverdto.AutoMarke, driverdto.FahrtZiehl,driverdto.AbfahrtZeit);
            driverBussinesService.AddDriver(driverdto);
            return CreatedAtAction("AddDriver", new { id = driverdto.Id }, driverdto);
        }

        [HttpDelete("{id}")]
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