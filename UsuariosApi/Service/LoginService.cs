using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dto;
using UsuariosApi.Models;

namespace UsuariosApi.Service
{
    public class LoginService
    {
        private SignInManager<User> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<User> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<string> Login(LoginUserDto userDto)
        {
            var result = await _signInManager.PasswordSignInAsync(userDto.Username, userDto.Password, false, false);
            if (!result.Succeeded)
            {
                throw new ApplicationException("Usuário não autenticado"); 
            }

            var user = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == userDto.Username.ToUpper());

            var token = _tokenService.GenerateToken(user);
                return token;
        }
    }
}
