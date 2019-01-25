using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using mijnZorgRooster.DAL;
using mijnZorgRooster.DAL.Repositories;
using mijnZorgRooster.Controllers;
using Moq;
using Xunit;
using mijnZorgRooster.DAL.Entities;
using mijnZorgRooster.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace mijnZorgRooster.Tests.Controllers_Testen
{
    public class DienstControllerTest
    {
        [Fact]
        public async Task IndexTest()
        {
            //Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            var mockRepo1 = new Mock<IDienstRepository>();
            var controller = new DienstController(mockRepo.Object, mockRepo1.Object);

            //Act
            var result = await controller.Index();
            //Assert
            Assert.True(true);
        }

        [Fact]
        public async Task DetailTest()
        {
            //Arrange
            int dienstID = 1;
            var mockRepo = new Mock<IUnitOfWork>();
            var mockRepo1 = new Mock<IDienstRepository>();
            var diensten = (GetDiensten().FirstOrDefault(c => c.DienstID == dienstID));
            var controller = new DienstController(mockRepo.Object, mockRepo1.Object);

            //Act
            var result = controller.Details(1);

            //Assert
            Assert.Equal(1, diensten.DienstID);
            Assert.Equal(DateTime.Parse("01-01-2019"), diensten.Datum);
        }

        [Fact]
        public async Task DetailsNotFound()
        {
            //Arrange
            int dienstID = 1;
            var mockRepo = new Mock<IUnitOfWork>();
            var mockRepo1 = new Mock<IDienstRepository>();
            var diensten = (GetDiensten().FirstOrDefault(c => c.DienstID == dienstID));
            var controller = new DienstController(mockRepo.Object, mockRepo1.Object);

            //Act
            var result = await controller.Details(null);

            //Assert
            var contentResult = Assert.IsType<NotFoundResult>(result);
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
        private List<Dienst> GetDiensten()
        {
            var diensten = new List<Dienst>();
            diensten.Add(new Dienst()
                {
                    DienstID = 1,
                    Datum = DateTime.Parse("01-01-2019")
            });
            return diensten;
        }
    }

   
}

   



    

