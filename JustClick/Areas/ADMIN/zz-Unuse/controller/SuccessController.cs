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
    public class SuccessController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public SuccessController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }


        //public async Task<IActionResult> Index(string sortOrder)

        //{



        //    IEnumerable<SuccessModel> SuccessModels = await _unitOfWork.Success.GetAllAsync(includeProperties: ""); ;
        //    //return Json(new { data = allObj });


        //    return View(SuccessModels);

        //}


        public IActionResult Index()

        {

            return View();
        }
        public async Task<IActionResult> Upsert(int? id)
        {
            IEnumerable<ProjectConfigModel> Projectcodelist =  _unitOfWork.ProjectConfig.GetAll();
            SuccessVM SuccessVM = new SuccessVM()
            {
                Success = new SuccessModel(),
                PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                {
                    Text = i.PROJECT_CODE,
                    //Value = i.PROJECT_CODE.ToString()
                }),
               
            };
            if (id == null)
            {
                //this is for create
                return View(SuccessVM);
            }
            //this is for edit
            SuccessVM.Success = await _unitOfWork.Success.GetAsync(id.GetValueOrDefault());
            if (SuccessVM.Success == null)
            {
                return NotFound();
            }
            return View(SuccessVM);





        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(SuccessVM SuccessVM)
        {
            TempData["Duplicate"] = null;
            ViewBag.Message = null;
            if (ModelState.IsValid)
            {
                SuccessModel Success = await _unitOfWork.Success.GetFirstOrDefaultAsync(u => u.SUCCESSREASON == SuccessVM.Success.SUCCESSREASON &&
                u.PROJECT_CODE == SuccessVM.Success.PROJECT_CODE);
                if (Success == null)
                //ไม่ dup
                {

                    if (SuccessVM.Success.SUCCESSCODE == 0) // ไมได้ pass id มา ให้ insert
                    {
                        await _unitOfWork.Success.AddAsync(SuccessVM.Success);
                    }
                    else// pass id มา ให้ update
                    {
                        _unitOfWork.Success.Update(SuccessVM.Success);
                    }
                    _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
                else // ถ้า Dup
                {

                    
                    if (SuccessVM.Success.SUCCESSCODE == 0 || SuccessVM.Success.SUCCESSCODE != Success.SUCCESSCODE) // ไมได้ pass id มา ให้ insert
                    {
                        

                        ViewBag.Message = "ข้อมูลซ้ำ ไม่สามารถเพิ่ม/แก้ไขข้อมูลได้";
                            {
                            IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
                            SuccessVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                            {
                                Text = i.PROJECT_CODE,

                            });

                        if (SuccessVM.Success.SUCCESSCODE != 0)
                            {
                                SuccessVM.Success = await _unitOfWork.Success.GetAsync(SuccessVM.Success.SUCCESSCODE);
                            }
                        }       
                    return View(SuccessVM);
                    }
                    else  // pass id มา ให้ update
                    {
                            _unitOfWork.Success.Update(SuccessVM.Success);
                            _unitOfWork.Save();
                            return RedirectToAction(nameof(Index));
                    }

                       

                }
            }
            else
            {
                IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
                SuccessVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                {
                    Text = i.PROJECT_CODE,

                });

                if (SuccessVM.Success.SUCCESSCODE != 0)
                {
                    SuccessVM.Success = await _unitOfWork.Success.GetAsync(SuccessVM.Success.SUCCESSCODE);
                }
            }
            return View(SuccessVM);
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
            var allObj = await _unitOfWork.Success.GetAllAsync(includeProperties: "");
            return Json(new { data = allObj });



            //var allObj = _unitOfWork.SQLRAW_Call.Listraw<CreditCardTypeModel>("SELECT * FROM TBL_CARDTYPE", null);
            //return Json(new { data = allObj });


        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
             var objFromDb = await _unitOfWork.Success.GetAsync(id);
                if (objFromDb == null)
                {
             
                    return Json(new { success = false, message = "Error while deleting" });
                }

                await _unitOfWork.Success.RemoveAsync(objFromDb);
                _unitOfWork.Save();

               
                return Json(new { success = true, message = "Delete Successful" });

            }
        }
        #endregion

    }
