﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AccessController: ControllerBase
    {
        [HttpGet]
        [Authorize(Policy = "MinAge")]

        public IActionResult Get()
        {
            return Ok("Acesso Permitido");
        }
    }
}
