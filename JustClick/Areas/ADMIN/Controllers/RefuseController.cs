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
    public class RefuseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public RefuseController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }


        //public async Task<IActionResult> Index(string sortOrder)

        //{



        //    IEnumerable<RefuseModel> RefuseModels = await _unitOfWork.Refuse.GetAllAsync(includeProperties: ""); ;
        //    //return Json(new { data = allObj });


        //    return View(RefuseModels);

        //}


        public IActionResult Index()

        {

            return View();
        }
        public async Task<IActionResult> Upsert(int? id)
        {
            IEnumerable<ProjectConfigModel> Projectcodelist =  _unitOfWork.ProjectConfig.GetAll();
            RefuseVM RefuseVM = new RefuseVM()
            {
                Refuse = new RefuseModel(),
                PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                {
                    Text = i.PROJECT_CODE,
                    //Value = i.PROJECT_CODE.ToString()
                }),
               
            };
            if (id == null)
            {
                //this is for create
                return View(RefuseVM);
            }
            //this is for edit
            RefuseVM.Refuse = await _unitOfWork.Refuse.GetAsync(id.GetValueOrDefault());
            if (RefuseVM.Refuse == null)
            {
                return NotFound();
            }
            return View(RefuseVM);





        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(RefuseVM RefuseVM)
        {
            TempData["Duplicate"] = null;
            ViewBag.Message = null;
            if (ModelState.IsValid)
            {
                RefuseModel Refuse = await _unitOfWork.Refuse.GetFirstOrDefaultAsync(u => u.RefuseREASON == RefuseVM.Refuse.RefuseREASON &&
                u.PROJECT_CODE == RefuseVM.Refuse.PROJECT_CODE);
                if (Refuse == null)
                //ไม่ dup
                {

                    if (RefuseVM.Refuse.RefuseCODE == 0) // ไมได้ pass id มา ให้ insert
                    {
                        await _unitOfWork.Refuse.AddAsync(RefuseVM.Refuse);
                    }
                    else// pass id มา ให้ update
                    {
                        _unitOfWork.Refuse.Update(RefuseVM.Refuse);
                    }
                    _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
                else // ถ้า Dup
                {


                    if (RefuseVM.Refuse.RefuseCODE == 0 || RefuseVM.Refuse.RefuseCODE != Refuse.RefuseCODE) // ไมได้ pass id มา ให้ insert
                    {
                        

                        ViewBag.Message = "ข้อมูลซ้ำ ไม่สามารถเพิ่ม/แก้ไขข้อมูลได้";
                            {
                            IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
                            RefuseVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                            {
                                Text = i.PROJECT_CODE,

                            });

                        if (RefuseVM.Refuse.RefuseCODE != 0)
                            {
                                RefuseVM.Refuse = await _unitOfWork.Refuse.GetAsync(RefuseVM.Refuse.RefuseCODE);
                            }
                        }       
                    return View(RefuseVM);
                    }
                    else  // pass id มา ให้ update
                    {
                            _unitOfWork.Refuse.Update(RefuseVM.Refuse);
                            _unitOfWork.Save();
                            return RedirectToAction(nameof(Index));
                    }

                       

                }
            }
            else
            {
                IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
                RefuseVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                {
                    Text = i.PROJECT_CODE,

                });

                if (RefuseVM.Refuse.RefuseCODE != 0)
                {
                    RefuseVM.Refuse = await _unitOfWork.Refuse.GetAsync(RefuseVM.Refuse.RefuseCODE);
                }
            }
            return View(RefuseVM);
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
            var allObj = await _unitOfWork.Refuse.GetAllAsync(includeProperties: "");
            return Json(new { data = allObj });



            //var allObj = _unitOfWork.SQLRAW_Call.Listraw<CreditCardTypeModel>("SELECT * FROM TBL_CARDTYPE", null);
            //return Json(new { data = allObj });


        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
             var objFromDb = await _unitOfWork.Refuse.GetAsync(id);
                if (objFromDb == null)
                {
             
                    return Json(new { success = false, message = "Error while deleting" });
                }

                await _unitOfWork.Refuse.RemoveAsync(objFromDb);
                _unitOfWork.Save();

               
                return Json(new { success = true, message = "Delete Successful" });

            }
        }
        #endregion

    }
