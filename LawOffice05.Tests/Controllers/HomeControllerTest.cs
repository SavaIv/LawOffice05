using LawOffice05.Controllers;
using LawOffice05.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace LawOffice05.Tests.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void ErrorShouldReturnView()
        {
            // Arrange
            var homeController = new HomeController(null, null, null);

            // Act
            var result = homeController.Error();
            //IActionResult result = null;

            // Assert            
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
    }
}
