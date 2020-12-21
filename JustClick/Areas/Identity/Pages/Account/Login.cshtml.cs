using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using JustClick.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using JustClick.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using JustClick.Utility;
using System.DirectoryServices.Protocols;
using Microsoft.Extensions.Configuration;
using System.Net;
using JustClick.Infrastructure;

//using Novell.Directory.Ldap;


namespace JustClick.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private UserManager<ApplicationUser> _userManager;
        private readonly IGlobalFunction _globalFunction;

        public LoginModel(SignInManager<ApplicationUser> signInManager, ILogger<LoginModel> logger, IUnitOfWork unitOfWork, IConfiguration configuration, UserManager<ApplicationUser> userManager
                    , IGlobalFunction globalFunction)
        {
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
            _logger = logger;
            _configuration = configuration;
            _userManager = userManager;
            _globalFunction = globalFunction;

        }
      
        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            //[EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

       ////////////////////
   
        public async  Task<IActionResult> OnPost(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)

            {

                string domainName = "I-MIT";
                string userDn = Input.Email.ToUpper();


                //using (var connection = new LdapConnection { SecureSocketLayer = false })
                LdapConnection connection = new LdapConnection(_configuration.GetConnectionString("LDAPConnection"));

                try
                {
                    //    // authenticate the username and password

                    //connection.AuthType = AuthType.Basic;
                    //connection.SessionOptions.ProtocolVersion = 3;
                    //var credential = new NetworkCredential(userDn, Input.Password, domainName);
                    //connection.Bind(credential);


                }
                catch (LdapException ex)
                {
                    //throw ex;
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return Page();
                    //Authentication failed, exception will dictate why
                }

                //for APP User
                var result = await _signInManager.PasswordSignInAsync(userDn, Input.Password,false ,lockoutOnFailure: false);

                if (result.Succeeded)
               

                {
                //for AD User
                var user = await _signInManager.UserManager.FindByNameAsync(userDn);
                    if (user != null)
                        {
                          
                            if (!user.ACCESSSTATUS)
                            {
                                ModelState.AddModelError(string.Empty, "Username ถูกระงับการใช้งาน");
                                return Page();
                            }

                


                            else
                            {
                                await _signInManager.SignInAsync(user, true);

                                _logger.LogInformation("User logged in.");

                            string startcalltime = _globalFunction.Getdatetime();



                            _globalFunction.InsertLogin(userDn, user.RoleNames, user.EXT,user.PROJECT_CODE);
                            _globalFunction.UpdateAgentmonitoring(userDn, "", startcalltime, "");

                            //return LocalRedirect("/TSR/Home");

                            //var roles = await _userManager.GetRolesAsync(user);
                            return LocalRedirect(returnUrl);

                            //if (User.IsInRole(SD.Role_TSR))

                            //{
                            //    return LocalRedirect("/TSR/DashboardTSR");
                            //}
                            //else
                            //{
                            //    return LocalRedirect("/Admin/Dashboard");
                            //}

                        }

              
                        }
                        else 
                
                        {
                            ModelState.AddModelError(string.Empty, "Username not found");
                            return Page();

                        }
                }
                  

            }
            
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            

           


        }

    }

}
                   
            
          