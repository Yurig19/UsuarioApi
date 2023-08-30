using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.Data
{
    public class UserDbContext : IdentityDbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
    }
}
