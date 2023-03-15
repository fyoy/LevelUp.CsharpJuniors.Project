using FedorStore.Api.Models;
using FedorStore.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace FedorStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpGet]
        public ActionResult<ProductItem> GetUserId(Guid guid)
        {
            var user = _userService.GetUserById(guid);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }
    }
}
