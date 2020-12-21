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
    public class NonTargetController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public NonTargetController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }


        //public async Task<IActionResult> Index(string sortOrder)

        //{



        //    IEnumerable<NonTargetModel> nonTargetModels = await _unitOfWork.Nontarget.GetAllAsync(includeProperties: ""); ;
        //    //return Json(new { data = allObj });


        //    return View(nonTargetModels);

        //}


        public IActionResult Index()

        {

            return View();
        }
        public async Task<IActionResult> Upsert(int? id)
        {
            //IEnumerable<ProjectConfigModel> Projectcodelist =  _unitOfWork.ProjectConfig.GetAll();
            //NonTargetVM nonTargetVM = new NonTargetVM()
            //{
            //    NonTarget = new NonTargetModel(),
            //    PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
            //    {
            //        Text = i.PROJECT_CODE,
            //        //Value = i.PROJECT_CODE.ToString()
            //    }),
               
            //};
            //if (id == null)
            //{
            //    //this is for create
            //    return View(nonTargetVM);
            //}
            ////this is for edit
            //nonTargetVM.NonTarget = await _unitOfWork.Nontarget.GetAsync(id.GetValueOrDefault());
            //if (nonTargetVM.NonTarget == null)
            //{
            //    return NotFound();
            //}
            //return View(nonTargetVM);

return View();



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(NonTargetVM nonTargetVM)
        {
            TempData["Duplicate"] = null;
            ViewBag.Message = null;
            if (ModelState.IsValid)
            {
                NonTargetModel nonTarget = await _unitOfWork.Nontarget.GetFirstOrDefaultAsync(u => u.NONTARGETREASON == nonTargetVM.NonTarget.NONTARGETREASON &&
                u.PROJECT_CODE == nonTargetVM.NonTarget.PROJECT_CODE);
                if (nonTarget == null)
                //ไม่ dup
                {

                    if (nonTargetVM.NonTarget.NONTARGETCODE == 0) // ไมได้ pass id มา ให้ insert
                    {
                        await _unitOfWork.Nontarget.AddAsync(nonTargetVM.NonTarget);
                    }
                    else// pass id มา ให้ update
                    {
                        _unitOfWork.Nontarget.Update(nonTargetVM.NonTarget);
                    }
                    _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
                else // ถ้า Dup
                {


                    if (nonTargetVM.NonTarget.NONTARGETCODE == 0 || nonTargetVM.NonTarget.NONTARGETCODE != nonTarget.NONTARGETCODE) // ไมได้ pass id มา ให้ insert
                    {
                        

                        ViewBag.Message = "ข้อมูลซ้ำ ไม่สามารถเพิ่ม/แก้ไขข้อมูลได้";
                            {
                            IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
                            nonTargetVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                            {
                                Text = i.PROJECT_CODE,

                            });

                        if (nonTargetVM.NonTarget.NONTARGETCODE != 0)
                            {
                                nonTargetVM.NonTarget = await _unitOfWork.Nontarget.GetAsync(nonTargetVM.NonTarget.NONTARGETCODE);
                            }
                        }       
                    return View(nonTargetVM);
                    }
                    else  // pass id มา ให้ update
                    {
                            _unitOfWork.Nontarget.Update(nonTargetVM.NonTarget);
                            _unitOfWork.Save();
                            return RedirectToAction(nameof(Index));
                    }

                       

                }
            }
            else
            {
                IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
                nonTargetVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                {
                    Text = i.PROJECT_CODE,

                });

                if (nonTargetVM.NonTarget.NONTARGETCODE != 0)
                {
                    nonTargetVM.NonTarget = await _unitOfWork.Nontarget.GetAsync(nonTargetVM.NonTarget.NONTARGETCODE);
                }
            }
            return View(nonTargetVM);
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
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _unitOfWork.Nontarget.GetAllAsync(includeProperties: "");
            return Json(new { data = allObj });



            //var allObj = _unitOfWork.SQLRAW_Call.Listraw<CreditCardTypeModel>("SELECT * FROM TBL_CARDTYPE", null);
            //return Json(new { data = allObj });


        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
             var objFromDb = await _unitOfWork.Nontarget.GetAsync(id);
                if (objFromDb == null)
                {
             
                    return Json(new { success = false, message = "Error while deleting" });
                }

                await _unitOfWork.Nontarget.RemoveAsync(objFromDb);
                _unitOfWork.Save();

               
                return Json(new { success = true, message = "Delete Successful" });

            }
        }
        #endregion

    }
