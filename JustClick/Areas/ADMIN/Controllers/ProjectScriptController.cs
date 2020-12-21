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
    public class ProjectScriptController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProjectScriptController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
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


            ProjectConfigVM projectConfigVM = new ProjectConfigVM();
            if (id == null)
            {
                //creat
                return View(projectConfigVM);
            }

            //edit
            projectConfigVM.projectConfigModel = _unitOfWork.ProjectConfig.Get(id.GetValueOrDefault());
            if (projectConfigVM.projectConfigModel == null)
            {
                return NotFound();

            }



        

            return View(projectConfigVM);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProjectConfigVM projectConfigVM)
        {
            TempData["Duplicate"] = null;
            ViewBag.Message = null;
            if (ModelState.IsValid) 

            {
                ProjectConfigModel projectConfigChkdup = _unitOfWork.ProjectConfig.GetFirstOrDefault(u =>  u.PROJECT_CODE == projectConfigVM.projectConfigModel.PROJECT_CODE );
                if (projectConfigChkdup == null)
                //ไม่ dup
                {

                    if (projectConfigVM.projectConfigModel.URN == 0) // ไมได้ pass id มา ให้ insert
                    {
                        projectConfigVM.projectConfigModel.ENDOFPROJECT = Convert.ToDateTime(projectConfigVM.TEXTENDDATE);
                        _unitOfWork.ProjectConfig.Add(projectConfigVM.projectConfigModel);
                    }
                    else// pass id มา ให้ update
                    {
                        projectConfigVM.projectConfigModel.ENDOFPROJECT = Convert.ToDateTime(projectConfigVM.TEXTENDDATE);
                        _unitOfWork.ProjectConfig.Update(projectConfigVM.projectConfigModel);
                    }
                    _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
                else // ถ้า Dup
                {


                    if (projectConfigVM.projectConfigModel.URN == 0 || projectConfigVM.projectConfigModel.PROJECT_CODE != projectConfigChkdup.PROJECT_CODE) // ไมได้ pass id มา ให้ insert
                    {
                        

                        ViewBag.Message = "ข้อมูลซ้ำ ไม่สามารถเพิ่ม/แก้ไขข้อมูลได้";
                            {
                           

                        if (projectConfigVM.projectConfigModel.URN != 0)
                            {
                                projectConfigVM.projectConfigModel = _unitOfWork.ProjectConfig.Get(projectConfigVM.projectConfigModel.URN);
                            }
                        }

                        if (projectConfigVM.projectConfigModel.ENDOFPROJECT != null)
                        {
                            projectConfigVM.TEXTENDDATE = projectConfigVM.projectConfigModel.ENDOFPROJECT.ToString("dd-mm-yyyy");
                        }
                        return View(projectConfigVM);
                    }
                    else  // pass id มา ให้ update
                    {
                        projectConfigVM.projectConfigModel.ENDOFPROJECT = Convert.ToDateTime(projectConfigVM.TEXTENDDATE);
                        _unitOfWork.ProjectConfig.Update(projectConfigVM.projectConfigModel);
                        _unitOfWork.Save();
                            return RedirectToAction(nameof(Index));
                    }

                       

                }
            }
            else
            {


                if (projectConfigVM.projectConfigModel.URN != 0)
                {
                    projectConfigVM.projectConfigModel = _unitOfWork.ProjectConfig.Get(projectConfigVM.projectConfigModel.URN);
                }

            if (projectConfigVM.projectConfigModel.ENDOFPROJECT != null)
                {
                    projectConfigVM.TEXTENDDATE = projectConfigVM.projectConfigModel.ENDOFPROJECT.ToString("dd-mm-yyyy");
                }

            }


           
            return View(projectConfigVM);
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
