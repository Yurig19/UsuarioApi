using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dto;
using UsuariosApi.Models;

namespace UsuariosApi.Service
{
    public class RegistrationService
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;

        public RegistrationService(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task Registered(CreateUserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);
            if (!result.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar o usuário");
            }
        }
    }
}
