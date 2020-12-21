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
    public class CallbackController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public CallbackController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }


        //public async Task<IActionResult> Index(string sortOrder)

        //{



        //IEnumerable<CallbackModel> CallbackModels = await _unitOfWork.Callback.GetAllAsync(includeProperties: ""); 
        //    //return Json(new { data = allObj });


        //    return View(CallbackModels);

        //}


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

            CallbackVM CallbackVM = new CallbackVM()

            {
                Callback = new CallbackModel(),
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
                return View(CallbackVM);
            }
            //this is for edit
            CallbackVM.Callback = await _unitOfWork.Callback.GetAsync(id.GetValueOrDefault());
            if (CallbackVM.Callback == null)
            {
                return NotFound();
            }
            return View(CallbackVM);





        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(CallbackVM CallbackVM)
        {
            TempData["Duplicate"] = null;
            ViewBag.Message = null;
            if (ModelState.IsValid)
            {
                CallbackModel Callback = await _unitOfWork.Callback.GetFirstOrDefaultAsync(u => u.CALLBACKREASON == CallbackVM.Callback.CALLBACKREASON &&
                u.PROJECT_CODE == CallbackVM.Callback.PROJECT_CODE);
                if (Callback == null)
                //ไม่ dup
                {

                    if (CallbackVM.Callback.CALLBACKCODE == 0) // ไมได้ pass id มา ให้ insert
                    {
                        await _unitOfWork.Callback.AddAsync(CallbackVM.Callback);
                    }
                    else// pass id มา ให้ update
                    {
                        _unitOfWork.Callback.Update(CallbackVM.Callback);
                    }
                    _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
                else // ถ้า Dup
                {


                    if (CallbackVM.Callback.CALLBACKCODE == 0 || CallbackVM.Callback.CALLBACKCODE != Callback.CALLBACKCODE) // ไมได้ pass id มา ให้ insert
                    {
                        

                        ViewBag.Message = "ข้อมูลซ้ำ ไม่สามารถเพิ่ม/แก้ไขข้อมูลได้";
                            {
                            IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
                            var types = new List<SelectListItem>();

                            types.Add(new SelectListItem() { Text = "YES" });
                            types.Add(new SelectListItem() { Text = "NO " });
                            CallbackVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                            {
                                Text = i.PROJECT_CODE,

                            });
                            CallbackVM.NEEDTERMINATE_LIST = types;

                        if (CallbackVM.Callback.CALLBACKCODE != 0)
                            {
                                CallbackVM.Callback = await _unitOfWork.Callback.GetAsync(CallbackVM.Callback.CALLBACKCODE);
                            }
                        }       
                    return View(CallbackVM);
                    }
                    else  // pass id มา ให้ update
                    {
                            _unitOfWork.Callback.Update(CallbackVM.Callback);
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
                CallbackVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                {
                    Text = i.PROJECT_CODE,

                });
                CallbackVM.NEEDTERMINATE_LIST = types;


                if (CallbackVM.Callback.CALLBACKCODE != 0)
                {
                    CallbackVM.Callback = await _unitOfWork.Callback.GetAsync(CallbackVM.Callback.CALLBACKCODE);
                }
            }
            return View(CallbackVM);
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
            var allObj = await _unitOfWork.Callback.GetAllAsync(includeProperties: "");
            return Json(new { data = allObj });



            //var allObj = _unitOfWork.SQLRAW_Call.Listraw<CreditCardTypeModel>("SELECT * FROM TBL_CARDTYPE", null);
            //return Json(new { data = allObj });


        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
             var objFromDb = await _unitOfWork.Callback.GetAsync(id);
                if (objFromDb == null)
                {
             
                    return Json(new { success = false, message = "Error while deleting" });
                }

                await _unitOfWork.Callback.RemoveAsync(objFromDb);
                _unitOfWork.Save();

               
                return Json(new { success = true, message = "Delete Successful" });

            }
        }
        #endregion

    }
