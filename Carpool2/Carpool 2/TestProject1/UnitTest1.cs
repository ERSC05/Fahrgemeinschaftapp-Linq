using Moq;
using UnitTest_Mock.Controllers;
using UnitTest_Mock.Model;
using UnitTest_Mock.Services;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public async void GetEmployeebyId()
        {
            mock.Setup(p => p.GetEmployeebyId(1)).ReturnsAsync("JK");
            EmployeeController emp = new EmployeeController(mock.Object);
            string result = await emp.GetEmployeeById(1);
            Assert.Equal("JK", result);
        }
    }
}