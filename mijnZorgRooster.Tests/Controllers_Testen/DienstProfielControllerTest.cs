using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class DienstProfielControllerTest
    {
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IDienstProfielRepository> _dienstProfielRepository;

        public DienstProfielControllerTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _dienstProfielRepository = new Mock<IDienstProfielRepository>();
        }

        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfDienstProfielDTOs()
        {
            //Arrange
            _dienstProfielRepository.Setup(repo => repo.GetAsync()).Returns(Task.FromResult(GetDienstProfielen()));
            var controller = new DienstProfielController(_unitOfWork.Object, _dienstProfielRepository.Object);

            //Act
            var result = await controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<DienstProfielDTO>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task Detail_ReturnsAViewResult_WithADienstProfielDTO()
        {
            //Arange
            int dienstProfielID = 1;
            DienstProfielDTO dienstProfiel = (GetDienstProfielen().FirstOrDefault(m => m.DienstProfielID == dienstProfielID));
            _dienstProfielRepository.Setup(repo => repo.GetByIdAsync(dienstProfielID)).Returns(Task.FromResult(dienstProfiel));
            var controller = new DienstProfielController(_unitOfWork.Object, _dienstProfielRepository.Object);

            //Act
            var result = await controller.Details(dienstProfielID);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<DienstProfielDTO>(
                    viewResult.ViewData.Model);

            Assert.Equal(1, model.DienstProfielID);
            Assert.Equal("Beschrijving Dienstprofiel", model.Beschrijving);
            Assert.Equal(TimeSpan.Parse("07:00"), model.Begintijd);
            Assert.Equal(TimeSpan.Parse("14:00"), model.Eindtijd);
        }

        private List<DienstProfielDTO> GetDienstProfielen()
        {
            List<DienstProfielDTO> dienstProfielen = new List<DienstProfielDTO>();
            dienstProfielen.Add(new DienstProfielDTO()
            {
                DienstProfielID = 1,
                Beschrijving = "Beschrijving Dienstprofiel",
                Begintijd = TimeSpan.Parse("07:00"),
                Eindtijd = TimeSpan.Parse("14:00"),
                MinimaleBezetting = 5

            });
            dienstProfielen.Add(new DienstProfielDTO()
            {
                DienstProfielID = 2,
                Beschrijving = "Beschrijving Dienstprofiel",
                Begintijd = TimeSpan.Parse("07:00"),
                Eindtijd = TimeSpan.Parse("14:00"),
                MinimaleBezetting = 5

            });
            return dienstProfielen;
        }
    }
}
