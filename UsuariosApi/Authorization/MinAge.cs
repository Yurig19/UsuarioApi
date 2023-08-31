using Microsoft.AspNetCore.Authorization;

namespace UsuariosApi.Authorization
{
    public class MinAge: IAuthorizationRequirement
    {
        public MinAge(int age)
        {
            Age = age;
        }

        public int Age { get; set; }
    }
}
