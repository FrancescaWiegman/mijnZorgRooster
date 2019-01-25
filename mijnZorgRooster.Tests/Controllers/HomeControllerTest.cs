using Microsoft.AspNetCore.Mvc;
using mijnZorgRooster.Controllers;
using Xunit;

namespace mijnZorgRooster.Tests.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void Index_ReturnsAViewResult()
        {
            //Arange
            
            var controller = new HomeController();

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void About_ReturnsAViewResult()
        {
            //Arange
            var controller = new HomeController();

            //Act
            var result = controller.About();
            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Contact_ReturnsAViewResult()
        {
            //Arange
            var controller = new HomeController();

            //Act
            var result = controller.Contact();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Privacy_ReturnsAViewResult()
        {
            //Arange
            var controller = new HomeController();

            //Act
            var result = controller.Privacy();

            //Assert
            Assert.IsType<ViewResult>(result);
        }
      
    }
}
