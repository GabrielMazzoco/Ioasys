using Imdb.Domain.AuthAggregate.Dtos;
using Imdb.Domain.AuthAggregate.Services;
using Imdb.Domain.Shared.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Imdb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers([FromQuery] GenericFilter<UsersForList> filter)
        {
            var result = _userService.GetUsers(filter);

            return Ok(result.Items);
        }

        [HttpPost]
        public IActionResult RegisterAdmin([FromBody] AdminForRegisterDto adminForRegisterDto)
        {
            _userService.RegisterAdmin(adminForRegisterDto);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateAdmin([FromBody] UserForUpdateDto userForUpdateDto)
        {
            _userService.UpdateUser(userForUpdateDto);

            return Ok();
        }

        [HttpDelete("inativar/{userId}")]
        public IActionResult UpdateAdmin([FromRoute] int userId)
        {
            _userService.InactivateUserAsAdmin(userId);

            return Ok();
        }
    }
}
