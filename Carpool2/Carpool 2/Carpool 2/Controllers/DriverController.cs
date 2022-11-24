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

        #region GetDriver
        [HttpGet]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<DriverDto>>> GetDriver()
        {
            return driverBussinesService.ReadDriver();
        }
        #endregion
        #region GetDriverById
        [HttpGet("{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<DriverDto>>> GetDriverId(int id)
        {
            try
            {
                var driverByIdList = driverBussinesService.GetDriverById(id);

                if (driverByIdList.Count == 0)
                {
                    return BadRequest($"{id} does not exist");
                }
                return driverByIdList;
            }
            catch
            {
                return BadRequest($"{id} does not exist");
            }
        }
        #endregion
        #region CreateDriver
        [HttpPut]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DriverDto>> CreateDriver(DriverDto driverdto)
        {
            try
            {
                //Driver Driver = new Driver(driverdto.Id,driverdto.Name,driverdto.Sitzplaetze,driverdto.AutoMarke, driverdto.FahrtZiehl,driverdto.AbfahrtZeit);
                var addedDriver = driverBussinesService.AddDriver(driverdto);
                return addedDriver;
            }
            catch
            {
                return BadRequest($"{driverdto} it not a Driver");
            }
        }
        #endregion
        #region DeleteDrive
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
        #endregion
    }

}