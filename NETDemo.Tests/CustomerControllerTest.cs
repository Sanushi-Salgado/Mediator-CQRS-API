using NETDemo.Service.Controllers;
using Xunit;

namespace NETDemo.Tests
{
    public class CustomerControllerTest
    {
        private readonly CustomerV1_0Controller _controller;
        public CustomerControllerTest()
        {
            //_controller = new CustomerV1_0Controller();
        }
        [Fact]
        public void GetAll_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAllCustomers();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange & Act
            var okResult = _controller.GetCustomer(1);

            // Assert
            //Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
    }
}
