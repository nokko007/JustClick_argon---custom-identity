using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using JustClick.DataAccess.Repository.IRepository;
using JustClick.Models;
using JustClick.Models.Identity;
using JustClick.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;


namespace JustClick.Areas.ADMIN.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signinManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public UserController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signinManager, IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signinManager = signinManager;
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        //public ViewResult Index() => View(_roleManager.Roles);

        public IActionResult Index()
        {

            //ApplicationUser user = _userManager.Users.ToList();





            return View();
        }


        public async Task<IActionResult> Upsert(string id)
        {

            var parameter = new DynamicParameters();
            if (id != null)
            {
                ApplicationUser user1 = await _userManager.FindByIdAsync(id);
                var rolenameparam = await _userManager.GetRolesAsync(user1);
                foreach (var r in rolenameparam)
                {
                     parameter.Add("@ROLE", r.ToString());
                }
 
            }
            else
            {
                parameter.Add("@ROLE", "");

            }
            IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
            IEnumerable<TitleModel> titlelist = _unitOfWork.Title.GetAll().OrderBy(u => u.SEQ);
            var roleNameLists = _roleManager.Roles.ToList();
            var leaderlist = _unitOfWork.SP_Call.List<RoleLeaderModel>("SP_ROLELEADER", parameter);

            RegisterViewModel registerViewModel = new RegisterViewModel()

            {
                PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                {
                    Text = i.PROJECT_CODE,
                    //Value = i.PROJECT_CODE.ToString()
                }),


                ROLE_LIST = roleNameLists.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    //Value = i.PROJECT_CODE.ToString()
                }),



                TITLE_LIST = titlelist.Select(i => new SelectListItem
                {
                    Text = i.TITLE_THAI,
                    //Value = i.PROJECT_CODE.ToString()
                }),


                TEAMLEADER_LIST = leaderlist.Select(i => new SelectListItem
                {
                    Text = i.TEAMLEADER_NAME,
                    Value = i.ID.ToString()
                }),




            };
            if (id == null)
            {
                //this is for create
                return View(registerViewModel);
            }

            //this is for edit



            ApplicationUser user = await _userManager.FindByIdAsync(id);
            var rolename = await _userManager.GetRolesAsync(user);

         

            registerViewModel.Id = user.Id;
            registerViewModel.PROJECT_CODE = user.PROJECT_CODE;
            foreach (var r in rolename)
            {
                registerViewModel.ROLE = r.ToString();
            }
            var teamleadername = await _userManager.FindByIdAsync(user.TEAMLEADER_ID);


            if (teamleadername != null)
            { 
            registerViewModel.TEAMLEADER_ID = user.TEAMLEADER_ID;
            registerViewModel.TEAMLEADER_NAME = teamleadername.FNAME_THAI + ' ' + teamleadername.LNAME_THAI;
            }
            registerViewModel.UserName = user.UserName;
            registerViewModel.TITLE_THAI = user.TITLE_THAI;
            registerViewModel.FNAME_THAI = user.FNAME_THAI;
            registerViewModel.LNAME_THAI = user.LNAME_THAI;
            registerViewModel.ACCESSSTATUS = user.ACCESSSTATUS;
            registerViewModel.TSR_PICTURE = user.TSR_PICTURE;


            return View(registerViewModel);




        }





        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Upsert(RegisterViewModel model)
        {

            TempData["Duplicate"] = null;
            ViewBag.Message = null;


            if (ModelState.IsValid )
            {
                if (model.Id != null)//update
                {

                    string uniqueFileName = null;
                    if (model.TSR_IMAGE != null)
                    {
                        uniqueFileName = UploadedFile(model);
                    }
                    else
                    {
                        uniqueFileName = model.TSR_PICTURE;
                    }


                    var user1 = await _userManager.FindByNameAsync(model.UserName.ToUpper());
                    user1.PROJECT_CODE = model.PROJECT_CODE;
                    user1.ACCESSSTATUS = model.ACCESSSTATUS;
                    user1.TITLE_THAI = model.TITLE_THAI;
                    user1.FNAME_THAI = model.FNAME_THAI;
                    user1.LNAME_THAI = model.LNAME_THAI;
                    user1.UserName = model.UserName.ToUpper();
                    user1.Email = model.UserName.ToUpper() + "imit@imit.co.th";
                    user1.TEAMLEADER_ID = model.TEAMLEADER_ID;
                    user1.TSR_PICTURE = uniqueFileName;
                    //user1.PasswordH = model.Password;

                    //var user = new ApplicationUser
                    //{
                    //    PROJECT_CODE = model.PROJECT_CODE,
                    //    ACCESSSTATUS = model.ACCESSSTATUS,
                    //    TITLE_THAI = model.TITLE_THAI,
                    //    FNAME_THAI = model.FNAME_THAI,
                    //    LNAME_THAI = model.LNAME_THAI,
                    //    UserName = model.UserName.ToUpper(),
                    //    Email = model.UserName.ToUpper() + "imit@imit.co.th",
                    //    TEAMLEADER_ID = model.TEAMLEADER_ID,
                    //    TSR_PICTURE = uniqueFileName
                    //};


                    await _userManager.UpdateAsync(user1);
                    await _userManager.AddToRoleAsync(user1, model.ROLE);
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user1);

                    await _userManager.ResetPasswordAsync(user1,token, model.Password);
                    return RedirectToAction(nameof(Index));
                }
                else //create
                {

                    // checkdup
                    ApplicationUser UserDupModel = await _userManager.FindByNameAsync(model.UserName.ToUpper());
                    //dup
                    if (UserDupModel != null)
                    {
                        ViewBag.Message = "Login นี้มีอยูในระบบแล้ว ไม่สามารถเพิ่ม/แก้ไขได้";
                        goto Returnerror;
                    }

                    // ไม่ dup

                    string uniqueFileName = null;
                    if (model.TSR_IMAGE != null)
                    {
                        uniqueFileName = UploadedFile(model);
                    }
                    else
                    {
                        uniqueFileName = model.TSR_PICTURE;
                    }

                    var user = new ApplicationUser
                    {
                        PROJECT_CODE = model.PROJECT_CODE,
                        ACCESSSTATUS = model.ACCESSSTATUS,
                        TITLE_THAI = model.TITLE_THAI,
                        FNAME_THAI = model.FNAME_THAI,
                        LNAME_THAI = model.LNAME_THAI,
                        UserName = model.UserName.ToUpper(),
                        Email = model.UserName.ToUpper() + "imit@imit.co.th",
                        TEAMLEADER_ID = model.TEAMLEADER_ID,
                        TSR_PICTURE = uniqueFileName
                    };


                    // สำหรับ APP user
        
                    await _userManager.CreateAsync(user, model.Password);

                    // สำหรับ AD user
                    //await _userManager.CreateAsync(user, "Imit@12345678");
                    await _userManager.AddToRoleAsync(user, model.ROLE);
                    return RedirectToAction(nameof(Index));

                }



            }
    

                Returnerror:
                    IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
                    IEnumerable<TitleModel> titlelist = _unitOfWork.Title.GetAll().OrderBy(u => u.SEQ);
                    var roleNameLists = _roleManager.Roles.ToList();

                    var parameter = new DynamicParameters();

                    parameter.Add("@ROLE", model.ROLE);

                    var leaderlist = _unitOfWork.SP_Call.List<RoleLeaderModel>("SP_ROLELEADER", parameter);

                    model.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                    {
                        Text = i.PROJECT_CODE,
                        //Value = i.PROJECT_CODE.ToString()
                    });


                    model.ROLE_LIST = roleNameLists.Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        //Value = i.PROJECT_CODE.ToString()
                    });



                    model.TITLE_LIST = titlelist.Select(i => new SelectListItem
                    {
                        Text = i.TITLE_THAI,
                        //Value = i.PROJECT_CODE.ToString()
                    });


                    model.TEAMLEADER_LIST = leaderlist.Select(i => new SelectListItem
                    {
                        Text = i.TEAMLEADER_NAME,
                        Value = i.ID.ToString()
                    });


                    //// ต่อตรงนี้

                    return View(model);

            //}
        }


        /////////////////////





        //private string Checkexistinguser(RegisterViewModel model)
        //{
        //    string existinguser = null;

        //    if (model.UserName != null)
        //    {
        //        ApplicationUser UserDupModel =  await _userManager.FindByNameAsync(model.UserName.ToUpper());

        //        if (UserDupModel != null)
        //        { existinguser = null; }
        //        else
        //        { existinguser = "DUP"; }

               
        //    }
        //    return existinguser;
        //}
        private string UploadedFile(RegisterViewModel model)
        {
            string uniqueFileName = null;

            if (model.TSR_IMAGE != null)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "img\\users");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.UserName.ToUpper() +  model.TSR_IMAGE.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.TSR_IMAGE.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> test(testModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string uniqueFileName = UploadedFile(model);

              
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View();
        //}











    #region API CALLS

    [HttpPost]
        public ActionResult GetroleLeader(string role)
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            var parameter = new DynamicParameters();
            parameter.Add("@ROLE", role);
            if (!string.IsNullOrEmpty(role))
            { 
                var leaderlist = _unitOfWork.SP_Call.List<RoleLeaderModel>("SP_ROLELEADER", parameter).ToList();


                leaderlist.ForEach(x =>
                {
                    selectListItems.Add(new SelectListItem { Text = x.TEAMLEADER_NAME , Value = x.ID.ToString() });
                });
            }
            //return Json(new { data = leaderlist });
            return Json(selectListItems);


        }


          



        [HttpGet]
        public  IActionResult GetAll()
        {
            var allObj = _userManager.Users.ToList();
           
            return Json(new { data = allObj });



            //var allObj = _unitOfWork.SQLRAW_Call.Listraw<CreditCardTypeModel>("SELECT * FROM TBL_CARDTYPE", null);
            //return Json(new { data = allObj });


        }


        //[HttpPost]
        //public ActionResult GetRoleLeaderbyRole(string role)
        //{
        //    var parameter = new DynamicParameters();
        //    parameter.Add("@ROLE", role);
        //    var leaderlist = _unitOfWork.SP_Call.List<RoleLeaderModel>("SP_ROLELEADER", parameter).ToList();



        //    return Json(new { data = leaderlist });




        //}


    }
    #endregion
}       