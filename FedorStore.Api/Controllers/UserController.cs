using FedorStore.Api.Models;
using FedorStore.Api.Service;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FedorStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        
            private IUserService _userService;

            public UserController(IUserService userService)
            {
                _userService = userService;
            }

            [HttpGet("all")]
            public ActionResult<IEnumerable<User>> GetAllUsers()
            {
                return Ok(_userService.GetAllUsers());
            }

            //Добавлен метод получения продукта по его guid
            [HttpGet("getById")]
            public ActionResult<ProductItem> GetProductId(Guid guid)
            {
                var act = _userService.GetUserById(guid);
                return Ok(act);
            }
    }
}
