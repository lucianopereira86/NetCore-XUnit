using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using APITest.Presentation.WebAPI.Models.VM;
using APITest.Presentation.WebAPI.Models.Result;
using APITest.Presentation.WebAPI.Validations;
using AutoMapper;
using APITest.Presentation.WebAPI.Models.Domain;
using Swashbuckle.AspNetCore.Examples;
using APITest.Presentation.WebAPI.SwaggerDocs.Examples;

namespace APITest.Presentation.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IMapper mapper;
        public UserController(IMapper m)
        {
            mapper = m;
        }

        /// <summary>
        /// Post user
        /// </summary>
        [HttpPost]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        [SwaggerResponse(500)]
        [SwaggerRequestExample(typeof(UserPostVM), typeof(UserPostEX))]
        public IActionResult Post([FromBody] UserPostVM vm)
        {
            var _vm = mapper.Map<User>(vm);
            var val = new PostUserValidation().Validate(_vm);
            if (!val.IsValid)
                return BadRequest(val.Errors);

            _vm.id = 1;

            var _vmReturn = mapper.Map<UserReturnVM>(_vm);
            return Ok(_vmReturn);
        }

        /// <summary>
        /// Put user
        /// </summary>
        [HttpPut]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        [SwaggerResponse(500)]
        [SwaggerRequestExample(typeof(UserPutVM), typeof(UserPutEX))]
        public IActionResult Put([FromBody] UserPutVM vm)
        {
            var _vm = mapper.Map<User>(vm);
            var val = new PutUserValidation().Validate(_vm);
            if (!val.IsValid)
                return BadRequest(val.Errors);
            return Ok();
        }
    }
}