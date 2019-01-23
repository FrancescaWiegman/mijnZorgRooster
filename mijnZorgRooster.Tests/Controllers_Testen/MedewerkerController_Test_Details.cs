//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using mijnZorgRooster.Controllers;
//using mijnZorgRooster.DAL;
//using mijnZorgRooster.Models.DTO;
//using mijnZorgRooster.Models.Entities;
//using mijnZorgRooster.Services;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using Xunit;

//namespace mijnZorgRooster.Tests.Controllers_Testen
//{
//    public partial class MedewerkerController_Test
//    {
//        [Fact]
//        public async Task DetailsTest()
//        {
//            //Arange
//            //Dit nogmaals testen maar dan met een 0 en één keer met een niet bestaande waarde als 
//            //bijvoorbeeld 33;
//            //int medewerkerID = 1;
//            Mock<IUnitOfWork> mockRepo = new Mock<IUnitOfWork>();
//            mockRepo.Setup(repo => repo.MedewerkerRepository.GetByIdAsync(1))
//                .ReturnsAsync(GetMedewerker());
//            Mock<ICalculationsService> mockRepo2 = new Mock<ICalculationsService>();
//            //mockRepo2.Setup()
//            MedewerkersController controller = new MedewerkersController(mockRepo2.Object, mockRepo.Object);

//            //Act
//            Task<IActionResult> result = controller.Details(1);

//            //Assert

//            var viewResult = Assert.IsType<ViewResult>(result);
//            var model = Assert.IsAssignableFrom<MedewerkerBasisDto>(
//             viewResult.ViewData.Model);

//        }

    

//    private Medewerker GetMedewerker()
//            {
//                var medewerker = new Medewerker()
//                {
//                    MedewerkerID = 1,
//                    Voornaam = "Francesca",
//                    Achternaam = "Wiegman",
//                    Telefoonnummer = "0748513535",
//                    MobielNummer = "0652526090",
//                    Emailadres = "francescawiegman@ziggo.nl",
//                    Adres = "Hunenborg 6",
//                    Postcode = "7556MR",
//                    Woonplaats = "Hengelo",
//                    Geboortedatum = DateTime.Parse("23-06-1979")
//                };
//                return medewerker;
//            }

//        }
//    }


