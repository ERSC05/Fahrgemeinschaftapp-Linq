using Moq;
using Xunit;
using System;
using TecAlliance.Carpool.Bussines.Services;
using TecAlliance.Carpool.Data.Services;
using TecAlliance.Carpool.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using TecAlliance.Carpool.Bussines.Models;

namespace TestProject4
{
    public class UnitTest1
    {
        [TestClass]
        public class CarpoolBussinesServiceTests
        {
            private readonly CarpoolBussinesService _sut;
            private readonly Mock<ICarpoolDataService> _CarpoolRepoMock = new Mock<ICarpoolDataService>();
            private readonly Mock<ICarpoolBussinesService> _CarpoolMock = new Mock<ICarpoolBussinesService>();

            public CarpoolBussinesServiceTests()
            {
                _sut = new CarpoolBussinesService(_CarpoolRepoMock.Object);
            }
            [TestMethod]
            public void DeleteCarpool_ShouldReturn_DeleteCarpool_WhenIdExist()
            {

                //Arange
                long carID = 3;

                List<CarPool> carPools = new List<CarPool>(7);
                for (int i = 0; i < 6; i++)
                {
                    carPools.Add(new CarPool(i, $"wad{i}", $"wad{i}", i, $"wad{i}", $"wad{i}", $"wad{i}"));
                }

                //List<CarpoolDto> carPools3 = new List<CarpoolDto>();

                _CarpoolRepoMock
                    .Setup(x => x.DelitedList(carID))
                    .Returns(carPools);

                //Act

                var carpool = _sut.DeleteCarpool(carID);
                //Assert
                carpool.Should().BeNullOrEmpty();

            }
        }
    }
}