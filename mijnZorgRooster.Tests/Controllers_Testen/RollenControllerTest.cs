using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IRolRepository> _rolRepository;

        public RollenControllerTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _rolRepository = new Mock<IRolRepository>();
        }

        [Fact]
        public async Task IndexTest()
        {
            //Arrange
            _rolRepository.Setup(repo => repo.GetAsync()).Returns(Task.FromResult(GetRollen()));
            var controller = new RollenController(_unitOfWork.Object, _rolRepository.Object);

            //Act
            var result = await controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<RolDTO>>(
                viewResult.ViewData.Model);
            Assert.Equal(4, model.Count());
        }

        [Fact]
        public async Task DetailTest()
        {
            //Arrange
            var rolID = 2;

            RolDTO rol = (GetRollen().FirstOrDefault(m => m.RolID == rolID));

            _rolRepository.Setup(repo => repo.GetByIdAsync(rolID)).Returns(Task.FromResult(rol));
            var controller = new RollenController(_unitOfWork.Object, _rolRepository.Object);

            //Act
            var result = await controller.Details(rolID);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<RolDTO>(
                    viewResult.ViewData.Model);

            Assert.Equal(2, model.RolID);
            Assert.Equal("Leidinggevende", model.Naam);
        }

        private List<RolDTO> GetRollen()
        {
            List<RolDTO> rollen = new List<RolDTO>()
            {
                new RolDTO()
                {
                    RolID = 1,
                    Naam = "Beheerder"
                },
                new RolDTO()
                {
                    RolID = 2,
                    Naam = "Leidinggevende"
                },
                new RolDTO()
                {
                    RolID = 3,
                    Naam = "Planner"
                },
                new RolDTO()
                {
                    RolID = 4,
                    Naam = "Zorgverlener"
                }
            };

            return rollen;
        }

    }
}