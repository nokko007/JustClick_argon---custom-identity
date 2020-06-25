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
    public class CreditCardTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public CreditCardTypeController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
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
            CreditCardTypeVM IcreditCardTypeVM = new CreditCardTypeVM()
            {
                CreditCardType = new CreditCardTypeModel(),
                PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                {
                    Text = i.PROJECT_CODE,
                    //Value = i.PROJECT_CODE.ToString()
                }),
               
            };
            if (id == null)
            {
                //this is for create
                return View(IcreditCardTypeVM);
            }
            //this is for edit
            IcreditCardTypeVM.CreditCardType = _unitOfWork.CreditCardType.Get(id.GetValueOrDefault());
            if (IcreditCardTypeVM.CreditCardType == null)
            {
                return NotFound();
            }
            return View(IcreditCardTypeVM);







            ///////////////
            //CreditCardTypeModel creditCardtype = new CreditCardTypeModel();
            //if (id==null)
            //{
            //    //creat
            //    return View(creditCardtype);
            //}

            ////edit
            //creditCardtype = _unitOfWork.CreditCardType.Get(id.GetValueOrDefault());
            //if(creditCardtype == null)
            //{
            //    return NotFound();

            //}


            //return View(creditCardtype);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CreditCardTypeVM creditCardTypeVM)
        {
            TempData["Duplicate"] = null;
            ViewBag.Message = null;
            if (ModelState.IsValid)
            {
                CreditCardTypeModel creditCardType = _unitOfWork.CreditCardType.GetFirstOrDefault(u => u.CARDTYPE == creditCardTypeVM.CreditCardType.CARDTYPE &&
                u.PROJECT_CODE == creditCardTypeVM.CreditCardType.PROJECT_CODE);
                if (creditCardType == null)
                //ไม่ dup
                {

                    if (creditCardTypeVM.CreditCardType.CARDCODE == 0) // ไมได้ pass id มา ให้ insert
                    {
                        _unitOfWork.CreditCardType.Add(creditCardTypeVM.CreditCardType);
                    }
                    else// pass id มา ให้ update
                    {
                        _unitOfWork.CreditCardType.Update(creditCardTypeVM.CreditCardType);
                    }
                    _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
                else // ถ้า Dup
                {


                    if (creditCardTypeVM.CreditCardType.CARDCODE == 0 || creditCardTypeVM.CreditCardType.CARDCODE != creditCardType.CARDCODE) // ไมได้ pass id มา ให้ insert
                    {
                        

                        ViewBag.Message = "ข้อมูลซ้ำ ไม่สามารถเพิ่ม/แก้ไขข้อมูลได้";
                            {
                            IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
                            creditCardTypeVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                            {
                                Text = i.PROJECT_CODE,

                            });

                        if (creditCardTypeVM.CreditCardType.CARDCODE != 0)
                            {
                                creditCardTypeVM.CreditCardType = _unitOfWork.CreditCardType.Get(creditCardTypeVM.CreditCardType.CARDCODE);
                            }
                        }       
                    return View(creditCardTypeVM);
                    }
                    else  // pass id มา ให้ update
                    {
                            _unitOfWork.CreditCardType.Update(creditCardTypeVM.CreditCardType);
                            _unitOfWork.Save();
                            return RedirectToAction(nameof(Index));
                    }

                       

                }
            }
            else
            {
                IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
                creditCardTypeVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                {
                    Text = i.PROJECT_CODE,

                });

                if (creditCardTypeVM.CreditCardType.CARDCODE != 0)
                {
                    creditCardTypeVM.CreditCardType = _unitOfWork.CreditCardType.Get(creditCardTypeVM.CreditCardType.CARDCODE);
                }
            }
            return View(creditCardTypeVM);
        }
            //return View(creditCardTypeVM);
            //    if (creditCardTypeVM.CreditCardType.CARDCODE == 0 && creditCardType.CARDCODE == 0)
            //        {
                      
            //        }

            //        else if (creditCardTypeVM.CreditCardType.CARDCODE != 0 && creditCardTypeVM.CreditCardType.CARDCODE == creditCardType.CARDCODE)
            //        {
                       
            //            _unitOfWork.Save();
            //            return RedirectToAction(nameof(Index));
            //        }

            //        else
            //        {
            //            TempData["Duplicate"] = "YES";
            //            ViewBag.Message = "ข้อมูลซ้ำ ไม่สามารถเพิ่ม/แก้ไขข้อมูลได้";




            //            IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
            //            creditCardTypeVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
            //            {
            //                Text = i.PROJECT_CODE,

            //            });

            //            if (creditCardTypeVM.CreditCardType.CARDCODE != 0)
            //            {
            //                creditCardTypeVM.CreditCardType = _unitOfWork.CreditCardType.Get(creditCardTypeVM.CreditCardType.CARDCODE);
            //            }


            //            //Alert("This is a success message", NotificationType.success);

            //            //return Json(new { success = false, message = "Data Duplicate" });
            //            return View(creditCardTypeVM);


                    //}

            //    }
            //}
           


            
        //}

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.CreditCardType.GetAll(includeProperties: "");
            return Json(new { data = allObj });



            //var allObj = _unitOfWork.SQLRAW_Call.Listraw<CreditCardTypeModel>("SELECT * FROM TBL_CARDTYPE", null);
            //return Json(new { data = allObj });


        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
             var objFromDb =  _unitOfWork.CreditCardType.Get(id);
                if (objFromDb == null)
                {
             
                    return Json(new { success = false, message = "Error while deleting" });
                }

                 _unitOfWork.CreditCardType.Remove(objFromDb);
                _unitOfWork.Save();

               
                return Json(new { success = true, message = "Delete Successful" });

            }
        }
        #endregion

    }
