using Microsoft.AspNetCore.Mvc;
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


        [HttpGet]
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

                return test;
            }
        }






        [HttpPost]
        public IActionResult CreateDriver(DriverDto driverdto)
        {            
            Driver driver = new Driver(driverdto.Id,driverdto.Name,driverdto.Sitzplaetze,driverdto.AutoMarke, driverdto.FahrtZiehl,driverdto.AbfahrtZeit);
            driverBussinesService.AddDriver(driverdto);
            return CreatedAtAction("AddDriver", new { id = driverdto.Id }, driverdto);
        }

    }
    
}