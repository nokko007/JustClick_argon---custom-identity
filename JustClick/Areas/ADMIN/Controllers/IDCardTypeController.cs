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
    public class IDCardTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public IDCardTypeController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
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
            IDCardTypeVM IIDCardTypeVM = new IDCardTypeVM()
            {
                IDCardType = new IDCardTypeModel(),
                PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                {
                    Text = i.PROJECT_CODE,
                    //Value = i.PROJECT_CODE.ToString()
                }),
               
            };
            if (id == null)
            {
                //this is for create
                return View(IIDCardTypeVM);
            }
            //this is for edit
            IIDCardTypeVM.IDCardType = _unitOfWork.IDCardType.Get(id.GetValueOrDefault());
            if (IIDCardTypeVM.IDCardType == null)
            {
                return NotFound();
            }
            return View(IIDCardTypeVM);







            ///////////////
            //IDCardTypeModel IDCardType = new IDCardTypeModel();
            //if (id==null)
            //{
            //    //creat
            //    return View(IDCardType);
            //}

            ////edit
            //IDCardType = _unitOfWork.IDCardType.Get(id.GetValueOrDefault());
            //if(IDCardType == null)
            //{
            //    return NotFound();

            //}


            //return View(IDCardType);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(IDCardTypeVM IDCardTypeVM)
        {
            TempData["Duplicate"] = null;
            ViewBag.Message = null;
            if (ModelState.IsValid)
            {
                IDCardTypeModel IDCardType = _unitOfWork.IDCardType.GetFirstOrDefault(u => u.IDCARD_NAME == IDCardTypeVM.IDCardType.IDCARD_NAME &&
                u.PROJECT_CODE == IDCardTypeVM.IDCardType.PROJECT_CODE);
                if (IDCardType == null)
                //ไม่ dup
                {

                    if (IDCardTypeVM.IDCardType.IDCARD_ID == 0) // ไมได้ pass id มา ให้ insert
                    {
                        _unitOfWork.IDCardType.Add(IDCardTypeVM.IDCardType);
                    }
                    else// pass id มา ให้ update
                    {
                        _unitOfWork.IDCardType.Update(IDCardTypeVM.IDCardType);
                    }
                    _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
                else // ถ้า Dup
                {


                    if (IDCardTypeVM.IDCardType.IDCARD_ID == 0 || IDCardTypeVM.IDCardType.IDCARD_ID != IDCardType.IDCARD_ID) // ไมได้ pass id มา ให้ insert
                    {
                        

                        ViewBag.Message = "ข้อมูลซ้ำ ไม่สามารถเพิ่ม/แก้ไขข้อมูลได้";
                            {
                            IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
                            IDCardTypeVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                            {
                                Text = i.PROJECT_CODE,

                            });

                        if (IDCardTypeVM.IDCardType.IDCARD_ID != 0)
                            {
                                IDCardTypeVM.IDCardType = _unitOfWork.IDCardType.Get(IDCardTypeVM.IDCardType.IDCARD_ID);
                            }
                        }       
                    return View(IDCardTypeVM);
                    }
                    else  // pass id มา ให้ update
                    {
                            _unitOfWork.IDCardType.Update(IDCardTypeVM.IDCardType);
                            _unitOfWork.Save();
                            return RedirectToAction(nameof(Index));
                    }

                       

                }
            }
            else
            {
                IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
                IDCardTypeVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                {
                    Text = i.PROJECT_CODE,

                });

                if (IDCardTypeVM.IDCardType.IDCARD_ID != 0)
                {
                    IDCardTypeVM.IDCardType = _unitOfWork.IDCardType.Get(IDCardTypeVM.IDCardType.IDCARD_ID);
                }
            }
            return View(IDCardTypeVM);
        }
            //return View(IDCardTypeVM);
            //    if (IDCardTypeVM.IDCardType.CARDCODE == 0 && IDCardType.CARDCODE == 0)
            //        {
                      
            //        }

            //        else if (IDCardTypeVM.IDCardType.CARDCODE != 0 && IDCardTypeVM.IDCardType.CARDCODE == IDCardType.CARDCODE)
            //        {
                       
            //            _unitOfWork.Save();
            //            return RedirectToAction(nameof(Index));
            //        }

            //        else
            //        {
            //            TempData["Duplicate"] = "YES";
            //            ViewBag.Message = "ข้อมูลซ้ำ ไม่สามารถเพิ่ม/แก้ไขข้อมูลได้";




            //            IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
            //            IDCardTypeVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
            //            {
            //                Text = i.PROJECT_CODE,

            //            });

            //            if (IDCardTypeVM.IDCardType.CARDCODE != 0)
            //            {
            //                IDCardTypeVM.IDCardType = _unitOfWork.IDCardType.Get(IDCardTypeVM.IDCardType.CARDCODE);
            //            }


            //            //Alert("This is a success message", NotificationType.success);

            //            //return Json(new { success = false, message = "Data Duplicate" });
            //            return View(IDCardTypeVM);


                    //}

            //    }
            //}
           


            
        //}

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.IDCardType.GetAll(includeProperties: "");
            return Json(new { data = allObj });



            //var allObj = _unitOfWork.SQLRAW_Call.Listraw<IDCardTypeModel>("SELECT * FROM TBL_CARDTYPE", null);
            //return Json(new { data = allObj });


        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
             var objFromDb =  _unitOfWork.IDCardType.Get(id);
                if (objFromDb == null)
                {
             
                    return Json(new { success = false, message = "Error while deleting" });
                }

                 _unitOfWork.IDCardType.Remove(objFromDb);
                _unitOfWork.Save();

               
                return Json(new { success = true, message = "Delete Successful" });

            }
        }
        #endregion

    }
