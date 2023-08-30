using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dto;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("{Controller}")]
    public class UserController: ControllerBase
    {
        [HttpPost]
        public IActionResult AddUser(CreateUserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
