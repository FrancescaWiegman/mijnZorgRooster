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
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IMedewerkerRepository> _medewerkerRepository;
        private ICalculationsService _calculationsService;

        public MedewerkerController_Test()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _medewerkerRepository = new Mock<IMedewerkerRepository>();
            _calculationsService = new CalculationsService();
        }

        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfMedewerkerDTOs()
        {
            //Arange
            _medewerkerRepository.Setup(repo => repo.GetAsync()).Returns(Task.FromResult(GetMedewerkers()));
            var controller = new MedewerkersController(_calculationsService, _unitOfWork.Object, _medewerkerRepository.Object);

            //Act
            var result = await controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<MedewerkerDTO>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task Detail_ReturnsAViewResult_WithAMedewerkerDTO()
        {
            //Arange
            int medewerkerID = 1;
            var medewerker = (GetMedewerkers().FirstOrDefault(m => m.MedewerkerID == medewerkerID));
            _medewerkerRepository.Setup(repo => repo.GetByIdAsync(medewerkerID)).Returns(Task.FromResult(medewerker));

            var controller = new MedewerkersController(_calculationsService, _unitOfWork.Object, _medewerkerRepository.Object);

            //Act
            var result = await controller.Details(1);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<MedewerkerDTO>(
                    viewResult.ViewData.Model);

            Assert.Equal(1, model.MedewerkerID);
            Assert.Equal("Francesca", model.Voornaam);
            Assert.Equal(DateTime.Parse("23-06-1979"), model.Geboortedatum);
        }

        [Fact]
        public async Task Detail_ReturnsANotFound()
        {
            //Arange
            var controller = new MedewerkersController(_calculationsService, _unitOfWork.Object, _medewerkerRepository.Object);

            //Act
            var result = await controller.Details(null);

            //Assert
            var contentResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Create_ReturnsAViewResult()
        {
            //Arange
            var controller = new MedewerkersController(_calculationsService, _unitOfWork.Object, _medewerkerRepository.Object);

            //Act
            var result = controller.Create();

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


