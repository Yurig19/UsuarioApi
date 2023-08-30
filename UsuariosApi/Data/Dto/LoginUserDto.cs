﻿using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dto
{
    public class LoginUserDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
