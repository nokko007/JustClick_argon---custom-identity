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
    public class BankController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public BankController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
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
            BankVM IBankVM = new BankVM()
            {
                Bank = new BankModel(),
                PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                {
                    Text = i.PROJECT_CODE,
                    //Value = i.PROJECT_CODE.ToString()
                }),
               
            };
            if (id == null)
            {
                //this is for create
                return View(IBankVM);
            }
            //this is for edit
            IBankVM.Bank = _unitOfWork.Bank.Get(id.GetValueOrDefault());
            if (IBankVM.Bank == null)
            {
                return NotFound();
            }
            return View(IBankVM);







            ///////////////
            //BankModel Bank = new BankModel();
            //if (id==null)
            //{
            //    //creat
            //    return View(Bank);
            //}

            ////edit
            //Bank = _unitOfWork.Bank.Get(id.GetValueOrDefault());
            //if(Bank == null)
            //{
            //    return NotFound();

            //}


            //return View(Bank);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(BankVM BankVM)
        {
            TempData["Duplicate"] = null;
            ViewBag.Message = null;
            if (ModelState.IsValid)
            {
                BankModel Bank = _unitOfWork.Bank.GetFirstOrDefault(u => u.BANKNAME == BankVM.Bank.BANKNAME &&
                u.PROJECT_CODE == BankVM.Bank.PROJECT_CODE);
                if (Bank == null)
                //ไม่ dup
                {

                    if (BankVM.Bank.URN == 0) // ไมได้ pass id มา ให้ insert
                    {
                        _unitOfWork.Bank.Add(BankVM.Bank);
                    }
                    else// pass id มา ให้ update
                    {
                        _unitOfWork.Bank.Update(BankVM.Bank);
                    }
                    _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
                else // ถ้า Dup
                {


                    if (BankVM.Bank.URN == 0 || BankVM.Bank.URN != Bank.URN) // ไมได้ pass id มา ให้ insert
                    {
                        

                        ViewBag.Message = "ข้อมูลซ้ำ ไม่สามารถเพิ่ม/แก้ไขข้อมูลได้";
                            {
                            IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
                            BankVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                            {
                                Text = i.PROJECT_CODE,

                            });

                        if (BankVM.Bank.URN != 0)
                            {
                                BankVM.Bank = _unitOfWork.Bank.Get(BankVM.Bank.URN);
                            }
                        }       
                    return View(BankVM);
                    }
                    else  // pass id มา ให้ update
                    {
                            _unitOfWork.Bank.Update(BankVM.Bank);
                            _unitOfWork.Save();
                            return RedirectToAction(nameof(Index));
                    }

                       

                }
            }
            else
            {
                IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
                BankVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                {
                    Text = i.PROJECT_CODE,

                });

                if (BankVM.Bank.URN != 0)
                {
                    BankVM.Bank = _unitOfWork.Bank.Get(BankVM.Bank.URN);
                }
            }
            return View(BankVM);
        }
            //return View(BankVM);
            //    if (BankVM.Bank.CARDCODE == 0 && Bank.CARDCODE == 0)
            //        {
                      
            //        }

            //        else if (BankVM.Bank.CARDCODE != 0 && BankVM.Bank.CARDCODE == Bank.CARDCODE)
            //        {
                       
            //            _unitOfWork.Save();
            //            return RedirectToAction(nameof(Index));
            //        }

            //        else
            //        {
            //            TempData["Duplicate"] = "YES";
            //            ViewBag.Message = "ข้อมูลซ้ำ ไม่สามารถเพิ่ม/แก้ไขข้อมูลได้";




            //            IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
            //            BankVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
            //            {
            //                Text = i.PROJECT_CODE,

            //            });

            //            if (BankVM.Bank.CARDCODE != 0)
            //            {
            //                BankVM.Bank = _unitOfWork.Bank.Get(BankVM.Bank.CARDCODE);
            //            }


            //            //Alert("This is a success message", NotificationType.success);

            //            //return Json(new { success = false, message = "Data Duplicate" });
            //            return View(BankVM);


                    //}

            //    }
            //}
           


            
        //}

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Bank.GetAll(includeProperties: "");
            return Json(new { data = allObj });



            //var allObj = _unitOfWork.SQLRAW_Call.Listraw<BankModel>("SELECT * FROM TBL_CARDTYPE", null);
            //return Json(new { data = allObj });


        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
             var objFromDb =  _unitOfWork.Bank.Get(id);
                if (objFromDb == null)
                {
             
                    return Json(new { success = false, message = "Error while deleting" });
                }

                 _unitOfWork.Bank.Remove(objFromDb);
                _unitOfWork.Save();

               
                return Json(new { success = true, message = "Delete Successful" });

            }
        }
        #endregion

    }
