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
        public async Task<ActionResult<List <DriverDto>>> GetDriver()
        {
            var test = driverBussinesService.ReadDriver();
            return test;
        }
        [HttpGet("{id}")]        //Liste mit Usern befpllen und nach der eingegebenne Id checken
        public async Task<ActionResult<List<DriverDto>>> GetDriverId(long id)
        {
            if (id == 0)
                throw new Exception("id = 0");
            else
            {
                var test = driverBussinesService.Get(id);

                if (test.Count == 0)
                {
                    throw new Exception($"{id} does not exist. You have to create a drivre first.");
                }

                return test;
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

            var newlist= driverBussinesService.DeliteDriver(id);

            return newlist;
        }

    }
    
}