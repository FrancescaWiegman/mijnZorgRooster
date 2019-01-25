using Microsoft.AspNetCore.Mvc;
using mijnZorgRooster.Controllers;
using mijnZorgRooster.DAL;
using mijnZorgRooster.DAL.Entities;
using mijnZorgRooster.DAL.Repositories;
using mijnZorgRooster.Models;
using mijnZorgRooster.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;



namespace mijnZorgRooster.Tests.Controllers_Testen
{
    public class ContractenControllerTest
    {

        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IContractRepository> _contractRepository;
        private ICalculationsService _calculationsService;


        public ContractenControllerTest()
        {
            _calculationsService = new CalculationsService();
            _unitOfWork = new Mock<IUnitOfWork>();
            _contractRepository = new Mock<IContractRepository>();
        }

        [Fact]
        public async Task IndexTest()
        {
            _contractRepository.Setup(repo => repo.GetAsync()).Returns(Task.FromResult(GetContracts()));
            var controller = new ContractenController(_calculationsService, _unitOfWork.Object, _contractRepository.Object);

            //Act 
            var result = await controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ContractDTO>>(
                viewResult.ViewData.Model);
            Assert.Equal(4, model.Count());
        }

        [Fact]
        public async Task DetailsTest()
        {
            //Arrange
            var contractID = 1;

            ContractDTO contract = (GetContracts().FirstOrDefault(m => m.ContractID == contractID));
            var medewerkers = GetMedewerkers();
            var medewerkerDTO = new MedewerkerDTO(medewerkers[1]);
            contract.medewerker = medewerkerDTO;

            _contractRepository.Setup(repo => repo.GetByIdAsync(contractID)).Returns(Task.FromResult(contract));
            var controller = new ContractenController(_calculationsService, _unitOfWork.Object, _contractRepository.Object);

            //Act
            var result = await controller.Details(contractID);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ContractDTO>(
                    viewResult.ViewData.Model);

            Assert.Equal(1, model.ContractID);
        }

        [Fact]
        public async Task DetailTestNotFound()
        {
            //Arange
            var controller = new ContractenController(_calculationsService, _unitOfWork.Object, _contractRepository.Object);

            //Act
            var result = await controller.Details(null);

            //Assert
            var contentResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void CreateTest()
        {
            //Arange
            var controller = new ContractenController(_calculationsService, _unitOfWork.Object, _contractRepository.Object);

            //Act
            var result = controller.Create();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }


        private List<Medewerker> GetMedewerkers()
        {
            var medewerkers = new List<Medewerker>
            {
                new Medewerker()
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
                },

                new Medewerker()
                {
                    MedewerkerID = 2,
                    Voornaam = "Sylvester",
                    Achternaam = "Dooren",
                    Tussenvoegsels = "van",
                    Adres = "Hunenborg 6",
                    Postcode = "7556MR",
                    Woonplaats = "Hengelo",
                    Geboortedatum = DateTime.Parse("27-12-2002")
                }
            };

            return medewerkers;
        }

        private List<ContractDTO> GetContracts()
        {
            var contracten = new List<ContractDTO>
            {
                new ContractDTO()
                {
                    ContractID = 1,
                    BeginDatum = DateTime.Parse("25-1-2016"),
                    Einddatum = DateTime.Parse("28-03-2019"),
                    ContractUren = 25,
                },
                new ContractDTO()
                {
                    ContractID = 2,
                    BeginDatum = DateTime.Parse("25-1-2016"),
                    Einddatum = DateTime.Parse("28-03-2019"),
                    ContractUren = 25,
                },
                new ContractDTO()
                {
                    ContractID = 3,
                    BeginDatum = DateTime.Parse("25-1-2016"),
                    Einddatum = DateTime.Parse("28-03-2019"),
                    ContractUren = 25,
                },
                new ContractDTO()
                {
                    ContractID = 4,
                    BeginDatum = DateTime.Parse("25-1-2016"),
                    Einddatum = DateTime.Parse("28-03-2019"),
                    ContractUren = 25,
                }
            };
            return contracten;
        }
    }
}




