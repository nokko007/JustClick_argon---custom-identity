using System.Security.Claims;
using System.Threading.Tasks;
using JustClick.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace JustClick.Infrastructure.ApplicationUserClaims
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager
            , RoleManager<IdentityRole> roleManager
            , IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        { }

        public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            //var principal = await base.CreateAsync(user);

          var principal = await base.CreateAsync(user);
   



            if (!string.IsNullOrWhiteSpace(user.FNAME_THAI))
            {
                ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
                    new Claim("FNAME_THAI", user.FNAME_THAI)
                });

          

            }



            if (!string.IsNullOrWhiteSpace(user.LNAME_THAI))
            {
                ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
                    new Claim("LNAME_THAI", user.LNAME_THAI)
                });



            }

            // You can add more properties that you want to expose on the User object below

            if (!string.IsNullOrWhiteSpace(user.EXT))
            {
              

                ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
                    new Claim("EXT", user.EXT)
                });

            }




            return principal;
        }

      

    }
}
