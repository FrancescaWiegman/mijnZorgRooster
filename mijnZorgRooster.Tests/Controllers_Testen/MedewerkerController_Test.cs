using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    public class MedewerkerController_Test

    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private ICalculationsService _calculationsService;

        public MedewerkerController_Test()
        {
               
        }

        [Fact]
        public async Task IndexTest()
        {
            //Arange
            //var mockRepo = new Mock<ICalculationsService>();
            //var mockRepo1 = new Mock<IUnitOfWork>();
            var mockRepo2 = new Mock<IMedewerkerRepository>();
            mockRepo2.Setup(repo => repo.GetAsync()).Returns(Task.FromResult(GetMedewerkers()));

            var controller = new MedewerkersController(_calculationsService, _mockUnitOfWork.Object, mockRepo2.Object);

            //Act
            var result = await controller.Index();
            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<MedewerkerDTO>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task DetailTest()
        {
            //Arange
            int medewerkerID = 1;
            var mockRepo = new Mock<ICalculationsService>();

            var mockRepo1 = new Mock<IUnitOfWork>();
            var mockRepo2 = new Mock<IMedewerkerRepository>();
            var medewerker = (GetMedewerkers().FirstOrDefault(m => m.MedewerkerID == medewerkerID));
            mockRepo.Setup(repo => repo.BerekenLeeftijdInJaren(medewerker.Geboortedatum)).Returns(39);

            var controller = new MedewerkersController(mockRepo.Object, mockRepo1.Object, mockRepo2.Object);

            //Act
            var result = await controller.Details(1);

            //Assert

            Assert.Equal(1, medewerker.MedewerkerID);
            Assert.Equal("Francesca", medewerker.Voornaam);
            Assert.Equal(DateTime.Parse("23-06-1979"), medewerker.Geboortedatum);
        }

        [Fact]
        public async Task DetailTestNotFound()
        {
            //Arange
            var mockRepo = new Mock<ICalculationsService>();
            var mockRepo1 = new Mock<IUnitOfWork>();
            var mockRepo2 = new Mock<IMedewerkerRepository>();
            var controller = new MedewerkersController(mockRepo.Object, mockRepo1.Object, mockRepo2.Object);

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
            var mockRepo1 = new Mock<IUnitOfWork>();
            var mockRepo2 = new Mock<IMedewerkerRepository>();
            var controller = new MedewerkersController(mockRepo.Object, mockRepo1.Object, mockRepo2.Object);

            //Act
            var result = controller.Create();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);

        }

        [Fact]
        public async Task CreateFilledInInvalidTest()
        {
            //Arange
            int MedewerkerID = 1;
            var mockRepo = new Mock<IUnitOfWork>();
            var mockRepo1 = new Mock<IMedewerkerRepository>();
            var mockRepo2 = new Mock<ICalculationsService>();
            var medewerker = (GetMedewerkers().FirstOrDefault(m => m.MedewerkerID == MedewerkerID));
            //mockRepo1.Setup(repo => repo.Insert(Medewerker);
            var controller = new MedewerkersController(mockRepo2.Object, mockRepo.Object, mockRepo1.Object);
            controller.ModelState.AddModelError("Achternaam", "Required");

            //Act
            var result = await controller.Create(null);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

       

        private List<MedewerkerDTO> GetMedewerkers()
        {
            var medewerkers = new List<MedewerkerDTO>();
            medewerkers.Add(new MedewerkerDTO()
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

            medewerkers.Add(new MedewerkerDTO()
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
    }
}


