using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dto;
using UsuariosApi.Models;

namespace UsuariosApi.Service
{
    public class LoginService
    {
        public SignInManager<User> _signInManager;

        public LoginService(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task Login(LoginUserDto userDto)
        {
            var result = await _signInManager.PasswordSignInAsync(userDto.Username, userDto.Password, false, false);
            if (!result.Succeeded)
            {
                throw new ApplicationException("Usuário não autenticado"); 
            }
        }
    }
}
