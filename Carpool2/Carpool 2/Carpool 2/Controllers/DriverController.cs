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

        


        [HttpPost]
        public async Task<ActionResult<DriverDto>> CreateDriver(DriverDto driverDto)
        {
            var driver = new Driver(driverDto.Id, driverDto.Name, driverDto.Sitzplaetze, driverDto.AutoMarke, driverDto.FahrtZiehl, driverDto.AbfahrtZeit);
            return Ok(driver);
            
        }


    }
    
}