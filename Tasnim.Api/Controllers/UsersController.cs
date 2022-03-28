using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tasnim.Domain.Entities.Users;
using Tasnim.Service.DTOs;
using Tasnim.Service.Interfaces;

namespace Tasnim.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<User>> Create(UserForRegistrationDto userDto)
        {
            var result = await userService.CreateAsync(userDto);

            return result == null ? BadRequest(result) : Ok(result);
        }
    }
}
