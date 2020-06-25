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
    public class ProjectConfigController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProjectConfigController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
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


            ProjectConfigModel projectConfig = new ProjectConfigModel();
            if (id == null)
            {
                //creat
                return View(projectConfig);
            }

            //edit
            projectConfig = _unitOfWork.ProjectConfig.Get(id.GetValueOrDefault());
            if (projectConfig == null)
            {
                return NotFound();

            }


            return View(projectConfig);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProjectConfigModel projectConfig)
        {
            TempData["Duplicate"] = null;
            ViewBag.Message = null;
            if (ModelState.IsValid) 

            {
                ProjectConfigModel projectConfigChkdup = _unitOfWork.ProjectConfig.GetFirstOrDefault(u =>  u.PROJECT_CODE == projectConfig.PROJECT_CODE );
                if (projectConfigChkdup == null)
                //ไม่ dup
                {

                    if (projectConfig.URN == 0) // ไมได้ pass id มา ให้ insert
                    {
                        _unitOfWork.ProjectConfig.Add(projectConfig);
                    }
                    else// pass id มา ให้ update
                    {
                        _unitOfWork.ProjectConfig.Update(projectConfig);
                    }
                    _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
                else // ถ้า Dup
                {


                    if (projectConfig.URN == 0 || projectConfig.PROJECT_CODE != projectConfigChkdup.PROJECT_CODE) // ไมได้ pass id มา ให้ insert
                    {
                        

                        ViewBag.Message = "ข้อมูลซ้ำ ไม่สามารถเพิ่ม/แก้ไขข้อมูลได้";
                            {
                           

                        if (projectConfig.URN != 0)
                            {
                                projectConfig = _unitOfWork.ProjectConfig.Get(projectConfig.URN);
                            }
                        }       
                    return View(projectConfig);
                    }
                    else  // pass id มา ให้ update
                    {
                            _unitOfWork.ProjectConfig.Update(projectConfig);
                            _unitOfWork.Save();
                            return RedirectToAction(nameof(Index));
                    }

                       

                }
            }
            else
            {


                if (projectConfig.URN != 0)
                {
                    projectConfig = _unitOfWork.ProjectConfig.Get(projectConfig.URN);
                }
            }
            return View(projectConfig);
        }
           

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.ProjectConfig.GetAll();
            return Json(new { data = allObj });



            //var allObj = _unitOfWork.SQLRAW_Call.Listraw<CreditCardTypeModel>("SELECT * FROM TBL_CARDTYPE", null);
            //return Json(new { data = allObj });


        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
             var objFromDb =  _unitOfWork.ProjectConfig.Get(id);
                if (objFromDb == null)
                {
             
                    return Json(new { success = false, message = "Error while deleting" });
                }

                 _unitOfWork.ProjectConfig.Remove(objFromDb);
                _unitOfWork.Save();

               
                return Json(new { success = true, message = "Delete Successful" });

            }
        }
        #endregion

    }
