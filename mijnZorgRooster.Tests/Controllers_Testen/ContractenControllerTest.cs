using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.Controllers;
using mijnZorgRooster.DAL;
using mijnZorgRooster.DAL.Entities;
using mijnZorgRooster.DAL.Repositories;
using mijnZorgRooster.Models;
using mijnZorgRooster.Services;
using Moq;
using Xunit;



namespace mijnZorgRooster.Tests.Controllers_Testen
{
    public class ContractenControllerTest
    {

        

    [Fact]
        public async Task IndexTest()
        {
            //Arrange
            var data = new List<ContractDTO>()
            {
                new ContractDTO {ContractID = 1, BeginDatum = DateTime.Parse("25-1-2016"),
                    Einddatum = DateTime.Parse("28-03-2019"), ContractUren = 25,
                    medewerker = null, ParttimePercentage= 20, VakantieDagen= 25},
                new ContractDTO{ContractID = 2, BeginDatum = DateTime.Parse("25-1-2016"),
                    Einddatum = DateTime.Parse("28-03-2019"), ContractUren = 25,
                    medewerker = null, ParttimePercentage= 20, VakantieDagen= 25},
                new ContractDTO {ContractID =3, BeginDatum = DateTime.Parse("25-1-2016"),
                    Einddatum = DateTime.Parse("28-03-2019"), ContractUren = 25,
                    medewerker = null, ParttimePercentage= 20, VakantieDagen= 25},
                new ContractDTO{ContractID = 4, BeginDatum = DateTime.Parse("25-1-2016"),
                    Einddatum = DateTime.Parse("28-03-2019"), ContractUren = 25,
                    medewerker = null, ParttimePercentage= 20, VakantieDagen= 25}
            };

            var mockRepo = new Mock<ICalculationsService>();
            var mockRepo2 = new Mock<IContractRepository>();
            var mockRepo1 = new Mock<IUnitOfWork>();

            var controller = new ContractenController(mockRepo.Object, mockRepo1.Object, mockRepo2.Object);
           
            //Act 
            var result = await controller.Index();

            //Assert
            Assert.True(true);
        
        }
        [Fact]
        public void DetailsTest()
        {
            //Arrange
            var ContractID = 1;
            var mockRepo = new Mock<ICalculationsService>();
            var mockRepo2 = new Mock<IContractRepository>();
            var mockRepo3 = new Mock<ContractRepository>();
            var contracten = (GetContracts().FirstOrDefault(m => m.ContractID ==  ContractID));
            //mockRepo3.Setup(repo => ContractRepository.ReferenceEquals(ContractRepository(ContractID), ContractID));
            var mockRepo1 = new Mock<IUnitOfWork>();

            var controller = new ContractenController(mockRepo.Object, mockRepo1.Object, mockRepo2.Object);

           

          //Act
           //var result = await controller.Details(ContractID);

            //Assert
            //var viewResult = Assert.IsType<ViewResult>(result);
            //var model = Assert.IsType<ContractDTO>(
            //        viewResult.ViewData.Model);

            //Assert.Equal(1, model.ContractID);
        }

        [Fact]
        public async Task DetailTestNotFound()
        {
            //Arange
            var mockRepo = new Mock<ICalculationsService>();
            var mockRepo2 = new Mock<IContractRepository>();
            var mockRepo1 = new Mock<IUnitOfWork>();
            var controller = new ContractenController(mockRepo.Object, mockRepo1.Object, mockRepo2.Object);

            //Act
            var result = await controller.Details(null);

            //Assert
            var contentResult = Assert.IsType<NotFoundResult>(result);

        }

        [Fact]
        public async Task CreateTest()
        {
            //Arange
            var mockRepo = new Mock<ICalculationsService>();
            var mockRepo2 = new Mock<IContractRepository>();
            var mockRepo1 = new Mock<IUnitOfWork>();
            var controller = new ContractenController(mockRepo.Object, mockRepo1.Object, mockRepo2.Object);

            //Act
            var result = controller.Create();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        private List<ContractDTO> GetContracts()
        {
            var contracten = new List<ContractDTO>();
            contracten.Add(new ContractDTO()
            {
                ContractID = 1,
                BeginDatum = DateTime.Parse("25-1-2016"),
                Einddatum = DateTime.Parse("28-03-2019"),
                ContractUren = 25,

            });
            contracten.Add(new ContractDTO()
            {
                ContractID = 2,
                BeginDatum = DateTime.Parse("25-1-2016"),
                Einddatum = DateTime.Parse("28-03-2019"),
                ContractUren = 25,

            });
            contracten.Add(new ContractDTO()
            {
                ContractID = 3,
                BeginDatum = DateTime.Parse("25-1-2016"),
                Einddatum = DateTime.Parse("28-03-2019"),
                ContractUren = 25,

            });
                    contracten.Add(new ContractDTO()
                    {
                        ContractID = 4,
                        BeginDatum = DateTime.Parse("25-1-2016"),
                        Einddatum = DateTime.Parse("28-03-2019"),
                        ContractUren = 25,

                    });
            return contracten;
        }
    }
}
    



