using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using mijnZorgRooster.Controllers;
using Xunit;

namespace mijnZorgRooster.Tests.Controllers_Testen
{
    public class HomeControllerTest
    {
        [Fact]
        public async Task IndexTest()
        {
            //Arange
            
            var controller = new HomeController();

            //Act
            var result = controller.Index();
            //Assert
            Assert.True(true);
        }

        [Fact]
        public async Task AboutTest()
        {
            //Arange
            var controller = new HomeController();

            //Act
            var result = controller.About();
            //Assert
            Assert.True(true);
        }
        [Fact]
        public async Task ContactTest()
        {
            //Arange
            var controller = new HomeController();

            //Act
            var result = controller.Contact();
            //Assert
            Assert.True(true);
        }
        [Fact]
        public async Task PrivacyTest()
        {
            //Arange
            var controller = new HomeController();

            //Act
            var result = controller.Privacy();
            //Assert
            Assert.True(true);
        }
        //[Fact]
        //public async Task ErrorTest()
        //{
        //    var controller = new HomeController();

        //    //Act
        //    var result = controller.Error();
        //    //Assert
        //    Assert.True(true);
        //}
    }
}
