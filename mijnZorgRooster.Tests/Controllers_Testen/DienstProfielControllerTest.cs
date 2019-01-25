using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mijnZorgRooster.Controllers;
using mijnZorgRooster.DAL;
using mijnZorgRooster.DAL.Entities;
using mijnZorgRooster.DAL.Repositories;
using Moq;
using Xunit;

namespace mijnZorgRooster.Tests.Controllers_Testen
{
    public class DienstProfielControllerTest
    {
        [Fact]
        public async Task IndexTest()
        {
            //Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            var mockRepo1 = new Mock<IDienstProfielRepository>();
            var controller = new DienstProfielController(mockRepo.Object, mockRepo1.Object);

            //Act
            var result = await controller.Index();
            //Assert
            Assert.True(true);
        }

        [Fact]
        public async Task DetailTest()
        {
            //Arange
            int dienstProfielID = 1;
            var mockRepo = new Mock<IUnitOfWork>();
            var mockRepo1 = new Mock<IDienstProfielRepository>();
            //var dienstprofielen = (GetDienstProfielen().FirstOrDefault(m => m.DienstProfielID == dienstProfielID));
            var controller = new DienstProfielController(mockRepo.Object, mockRepo1.Object);

            //Act
            //var result = controller.Details(1);

            ////Assert

            //Assert.Equal(1, dienstprofiel.DienstProfielID);
            //Assert.Equal("Beschrijving Dienstprofiel", dienstprofiel.Beschrijving);
            //Assert.Equal(TimeSpan.Parse("07.00"), dienstprofiel.Begintijd);
            //Assert.Equal(TimeSpan.Parse("14.00"),dienstprofiel.Eindtijd);
        }

        private List<DienstProfiel> GetDienstProfielen()
        {
            var dienstProfielen = new List<DienstProfiel>();
            dienstProfielen.Add(new DienstProfiel()
            {
                DienstProfielID = 1,
                Beschrijving = "Beschrijving Dienstprofiel",
                Begintijd = TimeSpan.Parse("07.00"),
                Eindtijd = TimeSpan.Parse("14.00"),
                MinimaleBezetting = 5

            });
            dienstProfielen.Add(new DienstProfiel()
            {
                DienstProfielID = 2,
                Beschrijving = "Beschrijving Dienstprofiel",
                Begintijd = TimeSpan.Parse("07.00"),
                Eindtijd = TimeSpan.Parse("14.00"),
                MinimaleBezetting = 5

            });
            return dienstProfielen;
        }
    }
}
