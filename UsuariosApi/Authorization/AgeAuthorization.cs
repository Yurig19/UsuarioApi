using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UsuariosApi.Authorization
{
    public class AgeAuthorization : AuthorizationHandler<MinAge>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinAge requirement)
        {
            var birthDateClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);
            if (birthDateClaim == null)

                return Task.CompletedTask;

            var birthDate = Convert.ToDateTime(birthDateClaim.Value);

            var ageUser = DateTime.Today.Year - birthDate.Year;

            if (birthDate > DateTime.Today.AddYears(-ageUser))
                ageUser--;
            if (ageUser >= requirement.Age) context.Succeed(requirement);
                
            return Task.CompletedTask;

        }
    }
}
