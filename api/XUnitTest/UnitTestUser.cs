using APITest.Presentation.WebAPI.Controllers;
using APITest.Presentation.WebAPI.Mappers;
using APITest.Presentation.WebAPI.Models.Result;
using APITest.Presentation.WebAPI.Models.VM;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace XUnitTest
{
    public class UnitTestUser
    {
        private readonly MapperConfiguration mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new ViewModelToDomainMappingProfile());
            cfg.AddProfile(new DomainToViewModelMappingProfile());
        });

        [Fact]
        internal void TestPostUser_BadRequest()
        {
            var mapper = mockMapper.CreateMapper();
            var ctrl = new UserController(mapper);
            var vm = new UserPostVM();

            var actionResult = ctrl.Post(vm);

            var badRequestObjectResult = actionResult as BadRequestObjectResult;
            Assert.NotNull(badRequestObjectResult);
        }

        [Fact]
        internal void TestPostUser_Ok()
        {
            var mapper = mockMapper.CreateMapper();
            var ctrl = new UserController(mapper);
            var vm = new UserPostVM
            {
                name = "Luciano",
                age = 33
            };

            var actionResult = ctrl.Post(vm);

            var okObjectResult = actionResult as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var model = okObjectResult.Value as UserReturnVM;
            Assert.NotNull(model);

            Assert.NotEqual(0, model.id);
        }

        [Fact]
        internal void TestPutUser_BadRequest()
        {
            var mapper = mockMapper.CreateMapper();
            var ctrl = new UserController(mapper);
            var vm = new UserPutVM
            {
                name = "Luciano de Sousa Pereira",
                age = 15
            };
            var actionResult = ctrl.Put(vm);

            var badRequestObjectResult = actionResult as BadRequestObjectResult;
            Assert.NotNull(badRequestObjectResult);
        }

        [Fact]
        internal void TestPutUser_Ok()
        {
            var mapper = mockMapper.CreateMapper();
            var ctrl = new UserController(mapper);
            var vm = new UserPutVM
            {
                id = 1,
                name = "Luciano",
                age = 33
            };
            var actionResult = ctrl.Put(vm);

            var okResult = actionResult as OkResult;
            Assert.NotNull(okResult);
        }
    }
}
