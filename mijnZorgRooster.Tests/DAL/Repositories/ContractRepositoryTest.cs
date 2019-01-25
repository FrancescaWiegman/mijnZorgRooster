//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using mijnZorgRooster.Controllers;
//using mijnZorgRooster.DAL;
//using mijnZorgRooster.DAL.Repositories;
//using mijnZorgRooster.Models;
//using mijnZorgRooster.Services;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Moq;
//using Xunit;

//namespace mijnZorgRooster.Tests.DAL.Repositories
//{
//    public class ContractRepositoryTest
//    {

//        [Fact]
//        public void GetTestTask()
//        {
//            {
//                //Arrange

//                var mock = new Mock<ZorginstellingDbContext>();

//                var mockRepo = new Mock<ICalculationsService>();
//                var mockRepo2 = new Mock<IContractRepository>();
//                mockRepo2.SetupGet(m => m.GetAsync());
//                var mockRepo1 = new Mock<IUnitOfWork>();

//                var controller = new ContractenController(mockRepo.Object, mockRepo1.Object, mockRepo2.Object);

//                //Act
//                var result = controller.Details(1);

//                //Assert
//                var viewResult = Assert.IsType<ViewResult>(result);
//                var model = Assert.IsType<ContractDTO>(
//                    viewResult.ViewData.Model);
//                Assert.Equal(1, model.ContractID);
//                Assert.Equal(DateTime.Parse("25-1-2016"), model.BeginDatum);
//                Assert.Equal(DateTime.Parse("28-03-2019"), model.Einddatum);
//                Assert.Equal(25, model.ContractUren);

//            }



//        }
//    }
//}
