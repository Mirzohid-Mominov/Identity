using Identity.Application.Common.Identity.Services;
using Identity.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("users/userId")]
        public async ValueTask<IActionResult> GetById([FromRoute] Guid userId)
        {
            var data = await _userService.GetByIdAsync(userId);

            return Ok(data);
        }

        [HttpPost]
        public async ValueTask<IActionResult> Create([FromBody] User user)
        {
            var data = await _userService.CreateAsync(user);

            return Ok(data); 
        }

        [HttpPut]
        public async ValueTask<IActionResult> Update([FromBody] User user, CancellationToken cancellationToken)
        {
            var data = await _userService.UpdateAsync(user);

            return Ok(data);
        }
    }
}
