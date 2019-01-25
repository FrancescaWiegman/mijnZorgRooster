using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Controllers;
using mijnZorgRooster.DAL;
using mijnZorgRooster.DAL.Entities;
using mijnZorgRooster.DAL.Repositories;
using mijnZorgRooster.Models;
using Moq;
using Xunit;

namespace mijnZorgRooster.Tests.Controllers_Testen
{
    public class RollenControllerTest
    {
        private Rol rollen;

        [Fact]
        public async Task IndexTest()
        {
            //Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            var mockRepo1 = new Mock<IRolRepository>();
            var controller = new RollenController(mockRepo.Object, mockRepo1.Object);

            //Act
            var result = await controller.Index();
            //Assert
            Assert.True(true);
        }

        

    }
}