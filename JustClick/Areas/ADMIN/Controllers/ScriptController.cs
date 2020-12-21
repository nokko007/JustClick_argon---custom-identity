using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustClick.DataAccess.Repository.IRepository;
using JustClick.Models;
using JustClick.Models.ViewModels;
using JustClick.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace JustClick.Areas.ADMIN.Controllers
{
    [Area("Admin")]
    public class ScriptController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ScriptController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }


        public IActionResult Index()
        {
            return View();
        }


        public  IActionResult Upsert(int? id)
        {
            IEnumerable<ProjectConfigModel> Projectcodelist =  _unitOfWork.ProjectConfig.GetAll();
            ScriptVM IScriptVM = new ScriptVM()
            {
                Script = new ScriptModel(),
                PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                {
                    Text = i.PROJECT_CODE,
                    //Value = i.PROJECT_CODE.ToString()
                }),
               
            };
            if (id == null)
            {
                //this is for create
                return View(IScriptVM);
            }
            //this is for edit
            IScriptVM.Script = _unitOfWork.Script.Get(id.GetValueOrDefault());
            if (IScriptVM.Script == null)
            {
                return NotFound();
            }
            return View(IScriptVM);








        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ScriptVM ScriptVM)
        {
            TempData["Duplicate"] = null;
            ViewBag.Message = null;
            if (ModelState.IsValid)
            {
               

                    if (ScriptVM.Script.SCRIPTID == 0) // ไมได้ pass id มา ให้ insert
                    {
                        _unitOfWork.Script.Add(ScriptVM.Script);
                    }
                    else// pass id มา ให้ update
                    {
                        _unitOfWork.Script.Update(ScriptVM.Script);
                    }
                    _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
               
            }
            else
            {
                IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
                ScriptVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                {
                    Text = i.PROJECT_CODE,

                });

                if (ScriptVM.Script.SCRIPTID != 0)
                {
                    ScriptVM.Script = _unitOfWork.Script.Get(ScriptVM.Script.SCRIPTID);
                }
            }
            return View(ScriptVM);
        }
          

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Script.GetAll(includeProperties: "");
            return Json(new { data = allObj });



            //var allObj = _unitOfWork.SQLRAW_Call.Listraw<ScriptModel>("SELECT * FROM TBL_CARDTYPE", null);
            //return Json(new { data = allObj });


        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
             var objFromDb =  _unitOfWork.Script.Get(id);
                if (objFromDb == null)
                {
             
                    return Json(new { success = false, message = "Error while deleting" });
                }

                 _unitOfWork.Script.Remove(objFromDb);
                _unitOfWork.Save();

               
                return Json(new { success = true, message = "Delete Successful" });

            }
        }
        #endregion

    }
