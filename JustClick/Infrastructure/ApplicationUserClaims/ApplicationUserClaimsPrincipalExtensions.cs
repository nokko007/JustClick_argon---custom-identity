using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace JustClick.Infrastructure.ApplicationUserClaims.Extensions
{
    public static class ApplicationUserClaimsPrincipalExtensions
    {
        public static string GetFullNameOrEmail(this ClaimsPrincipal principal)
        {
            var fullName = principal.Claims.FirstOrDefault(c => c.Type == "FNAME_THAI");
            return fullName?.Value ?? principal.Identity?.Name;
        }

        public static string GetFullName(this ClaimsPrincipal principal)
        {
            var fullName = principal.Claims.FirstOrDefault(c => c.Type == "FullName");
            return fullName?.Value;
        }
        public static string GetExtension(this ClaimsPrincipal principal)
        {
            var ext = principal.Claims.FirstOrDefault(c => c.Type == "EXT");
            return ext?.Value;
        }
      

        // You can add other extension methods here to access user properties exposed
        // via the ApplicationUserClaimsPrincipalFactory class



    }
}
