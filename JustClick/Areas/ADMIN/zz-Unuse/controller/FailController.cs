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
    public class FailController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public FailController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }




        public IActionResult Index()

        {

            return View();
        }
        public async Task<IActionResult> Upsert(int? id)
        {
            IEnumerable<ProjectConfigModel> Projectcodelist =  _unitOfWork.ProjectConfig.GetAll();
            var types = new List<SelectListItem>();
     
            types.Add(new SelectListItem() { Text = "YES" });
            types.Add(new SelectListItem() { Text = "NO " });

            FailVM FailVM = new FailVM()

            {
                Fail = new FailModel(),
                PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                {
                    Text = i.PROJECT_CODE,
                    //Value = i.PROJECT_CODE.ToString()
                }),
                NEEDTERMINATE_LIST= types



            };
            if (id == null)
            {
                //this is for create
                return View(FailVM);
            }
            //this is for edit
            FailVM.Fail = await _unitOfWork.Fail.GetAsync(id.GetValueOrDefault());
            if (FailVM.Fail == null)
            {
                return NotFound();
            }
            return View(FailVM);





        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(FailVM FailVM)
        {
            TempData["Duplicate"] = null;
            ViewBag.Message = null;
            if (ModelState.IsValid)
            {
                FailModel Fail = await _unitOfWork.Fail.GetFirstOrDefaultAsync(u => u.FAILREASON == FailVM.Fail.FAILREASON &&
                u.PROJECT_CODE == FailVM.Fail.PROJECT_CODE);
                if (Fail == null)
                //ไม่ dup
                {

                    if (FailVM.Fail.FAILCODE == 0) // ไมได้ pass id มา ให้ insert
                    {
                        await _unitOfWork.Fail.AddAsync(FailVM.Fail);
                    }
                    else// pass id มา ให้ update
                    {
                        _unitOfWork.Fail.Update(FailVM.Fail);
                    }
                    _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
                else // ถ้า Dup
                {


                    if (FailVM.Fail.FAILCODE == 0 || FailVM.Fail.FAILCODE != Fail.FAILCODE) // ไมได้ pass id มา ให้ insert
                    {
                        

                        ViewBag.Message = "ข้อมูลซ้ำ ไม่สามารถเพิ่ม/แก้ไขข้อมูลได้";
                            {
                            IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
                            var types = new List<SelectListItem>();

                            types.Add(new SelectListItem() { Text = "YES" });
                            types.Add(new SelectListItem() { Text = "NO " });
                            FailVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                            {
                                Text = i.PROJECT_CODE,

                            });
                            FailVM.NEEDTERMINATE_LIST = types;

                        if (FailVM.Fail.FAILCODE != 0)
                            {
                                FailVM.Fail = await _unitOfWork.Fail.GetAsync(FailVM.Fail.FAILCODE);
                            }
                        }       
                    return View(FailVM);
                    }
                    else  // pass id มา ให้ update
                    {
                            _unitOfWork.Fail.Update(FailVM.Fail);
                            _unitOfWork.Save();
                            return RedirectToAction(nameof(Index));
                    }

                       

                }
            }
            else
            {
                IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
                var types = new List<SelectListItem>();

                types.Add(new SelectListItem() { Text = "YES" });
                types.Add(new SelectListItem() { Text = "NO " });
                FailVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                {
                    Text = i.PROJECT_CODE,

                });
                FailVM.NEEDTERMINATE_LIST = types;


                if (FailVM.Fail.FAILCODE != 0)
                {
                    FailVM.Fail = await _unitOfWork.Fail.GetAsync(FailVM.Fail.FAILCODE);
                }
            }
            return View(FailVM);
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
            var allObj = await _unitOfWork.Fail.GetAllAsync(includeProperties: "");
            return Json(new { data = allObj });



            //var allObj = _unitOfWork.SQLRAW_Call.Listraw<CreditCardTypeModel>("SELECT * FROM TBL_CARDTYPE", null);
            //return Json(new { data = allObj });


        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
             var objFromDb = await _unitOfWork.Fail.GetAsync(id);
                if (objFromDb == null)
                {
             
                    return Json(new { success = false, message = "Error while deleting" });
                }

                await _unitOfWork.Fail.RemoveAsync(objFromDb);
                _unitOfWork.Save();

               
                return Json(new { success = true, message = "Delete Successful" });

            }
        }
        #endregion

    }
