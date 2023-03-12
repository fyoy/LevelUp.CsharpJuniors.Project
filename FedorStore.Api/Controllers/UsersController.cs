using FedorStore.Api.Models;
using FedorStore.Api.Service;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FedorStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        private IUsersService _usersService;

        public UsersController(IUsersService userService)
        {
            _usersService = userService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _usersService.GetAll();
            return Ok(users);
        }

        //Добавлен метод получения продукта по его guid
        [HttpPost("user/add")]
        public async Task<IActionResult> AddUser(User user)
        {
            await _usersService.AddUser(user);
            return Ok();
        }
    }
}
