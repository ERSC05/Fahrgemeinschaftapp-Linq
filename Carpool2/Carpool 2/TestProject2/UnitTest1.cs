using Moq;
using TecAlliance.Carpool.Bussines.Models;
using TecAlliance.Carpool.Bussines.Services;
using TecAlliance.Carpool.Data.Models;
using TecAlliance.Carpool.Data.Services;

namespace TestProject2
{
    public class UnitTest1
    {

        [Fact]
        public void Test1()
        {
            var carpoolBussinesServiceMock = new Mock<ICarpoolBussinesService>();
        }
    }
}