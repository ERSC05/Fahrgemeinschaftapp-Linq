using Moq;
using Xunit;
using System;
using TecAlliance.Carpool.Bussines.Services;
using TecAlliance.Carpool.Data.Services;
using TecAlliance.Carpool.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using TecAlliance.Carpool.Bussines.Models;
using System.Reflection;

namespace TestProject4
{
    public class CarpoolBusinessTestClass
    {
        [TestClass]
        public class CarpoolBussinesServiceTests
        {
            private readonly CarpoolBussinesService _carpoolBussines;
            private readonly Mock<ICarpoolDataService> _CarpoolRepoMock = new Mock<ICarpoolDataService>();
            private readonly Mock<ICarpoolBussinesService> _CarpoolMock = new Mock<ICarpoolBussinesService>();




            public CarpoolBussinesServiceTests()
            {
                _carpoolBussines = new CarpoolBussinesService(_CarpoolRepoMock.Object);

            }
            [TestMethod]
            public void DeleteCarpool_ShouldReturn_DeleteCarpool_WhenIdExist()
            {

                //Arange
                var listeOderSo = new List<CarpoolDto>();
                long carID = 3;
                List<CarPool> finalListWithouDeletedCarpool = new List<CarPool>();
                List<CarPool> carPools = new List<CarPool>(7);
                var carPool = new CarpoolDto(1, $"1", $"1", 1, $"1", $"1", $"1");
                for (int i = 0; i < 6; i++)
                {
                    carPools.Add(new CarPool(1, $"1", $"1", 1, $"1", $"1", $"1"));
                }
                var pfad1 = Assembly.GetEntryAssembly().Location;
                pfad1 = pfad1 + "\\..\\..\\..\\..\\Fahrgemeinschaften.csv";
                _CarpoolMock.Setup(x => x.DeleteCarpool(3)).Returns(listeOderSo);

                _CarpoolRepoMock
                    .Setup(x => x.DelitedList(3))
                    .Returns(carPools);

                //Act
                var carpool = _carpoolBussines.DeleteCarpool(carID);
                //Assert
                var item = carpool[1];
                item.Id.Should().Be(carPool.Id);
                item.Sitzplaetze.Should().Be(carPool.Sitzplaetze);
                item.AutoZiel.Should().Be(carPool.AutoZiel);
                item.AutoMarke.Should().Be(carPool.AutoMarke);
                item.AbfahrtZeit.Should().Be(carPool.AbfahrtZeit);
                item.NameBeifahrer.Should().Be(carPool.NameBeifahrer);
                item.NameFahrer.Should().Be(carPool.NameFahrer);
                item.Should().BeOfType<CarpoolDto>();
            }
            [TestMethod]
            public void ShowAllExistCarpool()
            {
                //Arange
                CarPool carpoolItem = new CarPool(1, "allo", "tschau", 3, "audi0", "weikersheim", "3.00 Uhr und so");
                List<CarPool> eineTolleListe = new List<CarPool>();
                eineTolleListe.Add(carpoolItem);

                _CarpoolRepoMock
                    .Setup(x => x.Showcarpool())
                    .Returns(eineTolleListe);

                //Act
                var listeexist = _carpoolBussines.ShowAllExistCarpool();


                //Assert

                listeexist.Should().NotBeNullOrEmpty();
            }
        }
    }

    public class DriverBusinessTest
    {
        [TestClass]

        public class DriverBusinessTestClassTest
        {
            private readonly DriverBussinesService _driverBussinesService;
            private readonly Mock<IDriverDataService> _driverDataMock = new Mock<IDriverDataService>();
            private readonly Mock<IDriverBussinesService> _driverBuissinesMock = new Mock<IDriverBussinesService>();

            public DriverBusinessTestClassTest()
            {
                _driverBussinesService = new DriverBussinesService(_driverDataMock.Object);
            }

            [TestMethod]
            public void DeleteDriver()
            {
                //Arange
                long driverid = 21313;
                List<Driver> driversListDone = new List<Driver>();
                List<Driver> drivers1 = new List<Driver>();
                var driver = new Driver(1, "", 1, "", "", "", "No");
                for (int i = 0; i < 6; i++)
                {
                    driversListDone.Add(new Driver(i, $"", i, $"", $"", $"", $"No"));
                }
                var pfad1 = Assembly.GetEntryAssembly().Location;
                pfad1 = pfad1 + "\\..\\..\\..\\..\\Fahrer.csv";
                _driverDataMock
                    .Setup(x => x.DeliteDriver(driverid))
                    .Returns(driversListDone);

                //Act
                var driverOderSo = _driverBussinesService.DeliteDriver(driverid);

                //Assert
                driverOderSo.Should().BeOfType<List<DriverDto>>();
            }
            [TestMethod]
            public void ReadDriver()
            {
                //Araneg

                //Act

                //Assert
            }
        }
    }
    [TestClass]
    public class DriverDataTest
    {


        private readonly DriverBussinesService _driverBussinesService;
        private readonly DriverDataService _driverDataService;
        private readonly Mock<IDriverDataService> _driverDataMock = new Mock<IDriverDataService>();
        private readonly Mock<IDriverBussinesService> _driverBuissinesMock = new Mock<IDriverBussinesService>();

        public DriverDataTest()
        {
            _driverBussinesService = new DriverBussinesService(_driverDataMock.Object);
            _driverDataService = new DriverDataService();
        }
        [TestMethod]
        public void DeliteDriver()
        {
            long driverId = 4;
            string boolWert = "No";
            var haaaaaallllllloooooo = _driverDataService.DeliteDriver(driverId);
            foreach (var item in haaaaaallllllloooooo)
            {
                if (boolWert == item.DeletedOrNot && driverId == item.Id)
                {
                    haaaaaallllllloooooo = null;


                }
                else
                {
                    haaaaaallllllloooooo = haaaaaallllllloooooo;
                }
                if (haaaaaallllllloooooo == null)
                {
                    break;
                }
            }
            haaaaaallllllloooooo.Should().NotBeNullOrEmpty();



        }
    }
}