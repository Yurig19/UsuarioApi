using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using UsuariosApi.Data.Dto;
using UsuariosApi.Models;
using UsuariosApi.Service;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController: ControllerBase
    {
        private RegistrationService _registrationService;
        private LoginService _loginService;

        public UserController(RegistrationService registrationService, LoginService loginService)
        {
            _registrationService = registrationService;
            _loginService = loginService;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> AddUser(CreateUserDto userDto)
        {
            await _registrationService.Registered(userDto);
            return Ok("Usuário cadastrado com sucesso!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto userDto)
        {
          var token = await _loginService.Login(userDto);
            return Ok(token);
        }
    }
}
