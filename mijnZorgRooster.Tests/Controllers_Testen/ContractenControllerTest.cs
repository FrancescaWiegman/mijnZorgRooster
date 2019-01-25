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
using Microsoft.AspNetCore.Mvc.Internal;
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
        public async Task DetailsTest()
        {
            //Arrange
            var ContractID = 1;
            var mockRepo = new Mock<ICalculationsService>();
            var mockRepo2 = new Mock<IContractRepository>();
            //var mockRepo3 = new Mock<ContractRepository>();
            var contracten = (GetContracts().FirstOrDefault(m => m.ContractID == ContractID));
            var medewerkers = GetMedewerkers();
            var medewerkerDTO = new MedewerkerDTO(medewerkers[1]);
            contracten.medewerker = medewerkerDTO;
            //mockRepo2.Setup(repo => repo.)
            var mockRepo1 = new Mock<IUnitOfWork>();

            var controller = new ContractenController(mockRepo.Object, mockRepo1.Object, mockRepo2.Object);

            //Act
            var result = controller.Details(ContractID);

            //Assert
            //var viewResult = Assert.IsType<ViewResult>(result);
            //var model = Assert.IsType<ContractDTO>(
            //        viewResult.ViewData.Model);

            Assert.Equal(1, contracten.ContractID);
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

     
        private List<Medewerker> GetMedewerkers()
        {
            var medewerkers = new List<Medewerker>();
            medewerkers.Add(new Medewerker()
            {
                MedewerkerID = 1,
                Voornaam = "Francesca",
                Achternaam = "Wiegman",
                Adres = "Hunenborg 6",
                Postcode = "7556MR",
                Woonplaats = "Hengelo",
                Emailadres = "francescawiegman@ziggo.nl",
                Telefoonnummer = "0652526090",
                Geboortedatum = DateTime.Parse("23-06-1979")
            });

            medewerkers.Add(new Medewerker()
            {
                MedewerkerID = 2,
                Voornaam = "Sylvester",
                Achternaam = "Dooren",
                Tussenvoegsels = "van",
                Adres = "Hunenborg 6",
                Postcode = "7556MR",
                Woonplaats = "Hengelo",
                Geboortedatum = DateTime.Parse("27-12-2002")
            });

            return medewerkers;
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
               // medewerker = 
                

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
    



