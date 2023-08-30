using AutoMapper;
using UsuariosApi.Data.Dto;
using UsuariosApi.Models;

namespace UsuariosApi.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
        }
    }
}
