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
    public class IntranetController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public IntranetController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
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
            IntranetVM IIntranetVM = new IntranetVM()
            {
                Intranet = new IntranetModel(),
                PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                {
                    Text = i.PROJECT_CODE,
                    //Value = i.PROJECT_CODE.ToString()
                }),
               
            };
            if (id == null)
            {
                //this is for create
                return View(IIntranetVM);
            }
            //this is for edit
            IIntranetVM.Intranet = _unitOfWork.Intranet.Get(id.GetValueOrDefault());
            if (IIntranetVM.Intranet == null)
            {
                return NotFound();
            }
            return View(IIntranetVM);








        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(IntranetVM IntranetVM)
        {
            TempData["Duplicate"] = null;
            ViewBag.Message = null;
            if (ModelState.IsValid)
            {
               

                    if (IntranetVM.Intranet.INTRANET_ID == 0) // ไมได้ pass id มา ให้ insert
                    {
                        _unitOfWork.Intranet.Add(IntranetVM.Intranet);
                    }
                    else// pass id มา ให้ update
                    {
                        _unitOfWork.Intranet.Update(IntranetVM.Intranet);
                    }
                    _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
               
            }
            else
            {
                IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
                IntranetVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                {
                    Text = i.PROJECT_CODE,

                });

                if (IntranetVM.Intranet.INTRANET_ID != 0)
                {
                    IntranetVM.Intranet = _unitOfWork.Intranet.Get(IntranetVM.Intranet.INTRANET_ID);
                }
            }
            return View(IntranetVM);
        }
          

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Intranet.GetAll(includeProperties: "");
            return Json(new { data = allObj });



            //var allObj = _unitOfWork.SQLRAW_Call.Listraw<IntranetModel>("SELECT * FROM TBL_CARDTYPE", null);
            //return Json(new { data = allObj });


        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
             var objFromDb =  _unitOfWork.Intranet.Get(id);
                if (objFromDb == null)
                {
             
                    return Json(new { success = false, message = "Error while deleting" });
                }

                 _unitOfWork.Intranet.Remove(objFromDb);
                _unitOfWork.Save();

               
                return Json(new { success = true, message = "Delete Successful" });

            }
        }
        #endregion

    }
