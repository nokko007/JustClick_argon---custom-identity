using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using JustClick.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace JustClick.Areas.ADMIN.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        //public ViewResult Index() => View(_roleManager.Roles);

        public IActionResult Index()
        {


            var roleNamesLists = _roleManager.Roles.ToList();

            return View(roleNamesLists);
        }


        //public IActionResult Create() => View();



        public async Task<IActionResult> Upsert(string id)
        {
            RoleModification roleModification = new RoleModification();
            if (id == null) 
            {
                //this is for create
                return View(roleModification);
            }

            //this is for edit

            IdentityRole role = await _roleManager.FindByIdAsync(id);
           
            return View(new RoleModification
            {
                RoleId = role.Id,
                RoleName = role.Name

            });







            //RoleEdit roleEdit = await _roleManager.FindByIdAsync(id);
            //if (role == null)
            //{
            //    return NotFound();
            //}
            
            //return View(role);





        }




        [HttpPost]
        [ValidateAntiForgeryToken]
    
        public async Task<IActionResult> Upsert(RoleModification roleModification)
        {
            if (ModelState.IsValid)
            {
               
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(roleModification.RoleName));
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            return View(roleModification);
        }

        //[HttpPost]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    IdentityRole role = await _roleManager.FindByIdAsync(id);
        //    if (role != null)
        //    {
        //        IdentityResult result = await _roleManager.DeleteAsync(role);
        //        if (result.Succeeded)
        //            return RedirectToAction("Index");
        //        else
        //            Errors(result);
        //    }
        //    else
        //        ModelState.AddModelError("", "No role found");
        //    return View("Index", _roleManager.Roles);
        //}

        //public async Task<IActionResult> Update(string id)
        //{
        //    IdentityRole role = await _roleManager.FindByIdAsync(id);
        //    List<ApplicationUser> members = new List<ApplicationUser>();
        //    List<ApplicationUser> nonMembers = new List<ApplicationUser>();
        //    foreach (ApplicationUser user in _userManager.Users)
        //    {
        //        var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
        //        list.Add(user);
        //    }
        //    return View(new RoleEdit
        //    {
        //        Role = role,
        //        Members = members,
        //        NonMembers = nonMembers
        //    });
        //}

        //[HttpPost]
        //public async Task<IActionResult> Update(RoleModification model)
        //{
        //    IdentityResult result;
        //    if (ModelState.IsValid)
        //    {
        //        foreach (string userId in model.AddIds ?? new string[] { })
        //        {
        //            ApplicationUser user = await _userManager.FindByIdAsync(userId);
        //            if (user != null)
        //            {
        //                result = await _userManager.AddToRoleAsync(user, model.RoleName);
        //                if (!result.Succeeded)
        //                    Errors(result);
        //            }
        //        }
        //        foreach (string userId in model.DeleteIds ?? new string[] { })
        //        {
        //            ApplicationUser user = await _userManager.FindByIdAsync(userId);
        //            if (user != null)
        //            {
        //                result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
        //                if (!result.Succeeded)
        //                    Errors(result);
        //            }
        //        }
        //    }

        //    if (ModelState.IsValid)
        //        return RedirectToAction(nameof(Index));
        //    else
        //        return await Update(model.RoleId);
        //}

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}