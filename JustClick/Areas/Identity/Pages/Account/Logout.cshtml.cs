using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using JustClick.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using JustClick.Infrastructure;
using JustClick.Infrastructure.ApplicationUserClaims.Extensions;
using Microsoft.Extensions.Configuration;

namespace JustClick.Areas.Identity.Pages.Account
{





    [AllowAnonymous]
    
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
      
        private readonly IConfiguration _configuration;
        private UserManager<ApplicationUser> _userManager;
        private readonly IGlobalFunction _globalFunction;

        public LogoutModel(SignInManager<ApplicationUser> signInManager, ILogger<LoginModel> logger, IConfiguration configuration, UserManager<ApplicationUser> userManager
                    , IGlobalFunction globalFunction)
        {
            
            _signInManager = signInManager;
            _logger = logger;
            _configuration = configuration;
            _userManager = userManager;
            _globalFunction = globalFunction;
        }

        public void OnGet()
        {
        }



        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            var loginname = User.GetUserName().ToString();
            _globalFunction.Logout(loginname);
           
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
     

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToPage("/Account/Login");
            }
        }
     
    }
}