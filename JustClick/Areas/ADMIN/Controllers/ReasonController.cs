using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using JustClick.DataAccess.Repository.IRepository;
using JustClick.Infrastructure;
using JustClick.Models;
using JustClick.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JustClick.Areas.ADMIN.Controllers
{
    [Area("Admin")]
    public class ReasonController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IReasonFunction _reasonFunction;
        private readonly IProjectConfigFunction _projectConfigFunction;

        public ReasonController(
            IUnitOfWork unitOfWork
            , IWebHostEnvironment hostEnvironment
            , IReasonFunction reasonFunction
            , IProjectConfigFunction projectConfigFunction
            )
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
            _reasonFunction = reasonFunction;
            _projectConfigFunction = projectConfigFunction;

        }

        //callback
        public IActionResult CallBackIndex(
               string currentFilter,
               string searchString,
               int? pageNumber,
               string popup
            )
        {
            ViewBag.Message = null;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            List<CallbackModel> callbackModels = _reasonFunction.SelectCallbackReason<CallbackModel>(0, null);
            if (popup != null)
            { ViewBag.Message = popup; }

            var result = callbackModels.AsQueryable();
            int pageSize = 10;
            return View(PaginatedList<CallbackModel>.Create(result, pageNumber ?? 1, pageSize));

        }

        public IActionResult CallBackUpsert(int id)
        {

            IEnumerable<ProjectConfigModel> Projectcodelist = _projectConfigFunction.SelectProjectCode<ProjectConfigModel>();
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
                NEEDTERMINATE_LIST = types

            };
            if (id == 0)
            {
                //this is for create
                return View(CallbackVM);
            }
            //this is for edit

            IEnumerable<CallbackModel> callbackModels = _reasonFunction.SelectCallbackReason<CallbackModel>(id, null);

            var result = callbackModels.ToList();
            foreach (var r in result)
            {
                CallbackVM.Callback.PROJECT_CODE = r.PROJECT_CODE;
                CallbackVM.Callback.CALLBACKCODE = r.CALLBACKCODE;
                CallbackVM.Callback.CALLBACKREASON = r.CALLBACKREASON.ToString();
                CallbackVM.Callback.NEEDTERMINATE = r.NEEDTERMINATE.ToString();
            }


            if (CallbackVM.Callback == null)
            {
                return NotFound();
            }
            return View(CallbackVM);



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CallBackUpsert(CallbackVM CallbackVM)
        {
            TempData["Duplicate"] = null;
            ViewBag.Message = null;
            if (ModelState.IsValid)

            {
                // check dup ก่อน
                List<CallbackModel> selectListItems = _reasonFunction.SelectCallbackReason<CallbackModel>(CallbackVM.Callback.CALLBACKCODE, CallbackVM.Callback.CALLBACKREASON);

                if (selectListItems.Count() > 0) //เจอ dup
                {
                    //dup

                    ViewBag.Message = "ข้อมูลซ้ำ ไม่สามารถเพิ่ม/แก้ไขข้อมูลได้";
                    goto returnerror;
                }
                else
                {
                    if (CallbackVM.Callback.CALLBACKCODE == 0)
                    {
                        //insert
                        _reasonFunction.InsertCallback(CallbackVM);

                        return RedirectToAction(nameof(CallBackIndex), new { popup = "Success" });
                    }
                    else
                    {

                        //update
                        _reasonFunction.Updatecallback(CallbackVM);

                        return RedirectToAction(nameof(CallBackIndex), new { popup = "Success" });
                    }
                }

            }
        returnerror:
            IEnumerable<ProjectConfigModel> Projectcodelist = _projectConfigFunction.SelectProjectCode<ProjectConfigModel>();
            var types = new List<SelectListItem>();

            types.Add(new SelectListItem() { Text = "YES" });
            types.Add(new SelectListItem() { Text = "NO " });

            CallbackVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
            {
                Text = i.PROJECT_CODE,
            });

            CallbackVM.NEEDTERMINATE_LIST = types;
            return View(CallbackVM);

        }

        //


        public IActionResult CallbackDelete(int id)

        {

      
            if (id != 0)

            {
     
                _reasonFunction.DeleteCallback(id);
                return Json(new { success = true, message = "Delete Successful" });

      
            }


            else
            {

                return Json(new { success = false, message = "Error while deleting" });

            }
         
   
        }

        //Fail
        public IActionResult FailIndex(
                 string currentFilter,
                 string searchString,
                 int? pageNumber,
                 string popup
              )
        {
            ViewBag.Message = null;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            List<FailModel> FailModels = _reasonFunction.SelectFailReason<FailModel>(0, null);
            if (popup != null)
            { ViewBag.Message = popup; }

            var result = FailModels.AsQueryable();
            int pageSize = 10;
            return View(PaginatedList<FailModel>.Create(result, pageNumber ?? 1, pageSize));

        }

        public IActionResult FailUpsert(int id)
        {

            IEnumerable<ProjectConfigModel> Projectcodelist = _projectConfigFunction.SelectProjectCode<ProjectConfigModel>();
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
                NEEDTERMINATE_LIST = types

            };
            if (id == 0)
            {
                //this is for create
                return View(FailVM);
            }
            //this is for edit

            IEnumerable<FailModel> FailModels = _reasonFunction.SelectFailReason<FailModel>(id, null);

            var result = FailModels.ToList();
            foreach (var r in result)
            {
                FailVM.Fail.PROJECT_CODE = r.PROJECT_CODE;
                FailVM.Fail.FAILCODE = r.FAILCODE;
                FailVM.Fail.FAILREASON = r.FAILREASON.ToString();
                FailVM.Fail.NEEDTERMINATE = r.NEEDTERMINATE.ToString();
            }


            if (FailVM.Fail == null)
            {
                return NotFound();
            }
            return View(FailVM);



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FailUpsert(FailVM FailVM)
        {
            TempData["Duplicate"] = null;
            ViewBag.Message = null;
            if (ModelState.IsValid)

            {
                // check dup ก่อน
                List<FailModel> selectListItems = _reasonFunction.SelectFailReason<FailModel>(FailVM.Fail.FAILCODE, FailVM.Fail.FAILREASON);

                if (selectListItems.Count() > 0) //เจอ dup
                {
                    //dup

                    ViewBag.Message = "ข้อมูลซ้ำ ไม่สามารถเพิ่ม/แก้ไขข้อมูลได้";
                    goto returnerror;
                }
                else
                {
                    if (FailVM.Fail.FAILCODE == 0)
                    {
                        //insert
                        _reasonFunction.InsertFail(FailVM);

                        return RedirectToAction(nameof(FailIndex), new { popup = "Success" });
                    }
                    else
                    {

                        //update
                        _reasonFunction.UpdateFail(FailVM);

                        return RedirectToAction(nameof(FailIndex), new { popup = "Success" });
                    }
                }

            }
        returnerror:
            IEnumerable<ProjectConfigModel> Projectcodelist = _projectConfigFunction.SelectProjectCode<ProjectConfigModel>();
            var types = new List<SelectListItem>();

            types.Add(new SelectListItem() { Text = "YES" });
            types.Add(new SelectListItem() { Text = "NO " });

            FailVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
            {
                Text = i.PROJECT_CODE,
            });

            FailVM.NEEDTERMINATE_LIST = types;
            return View(FailVM);

        }

        //


        public IActionResult FailDelete(int id)

        {


            if (id != 0)

            {

                _reasonFunction.DeleteFail(id);
                return Json(new { success = true, message = "Delete Successful" });


            }


            else
            {

                return Json(new { success = false, message = "Error while deleting" });

            }


        }

        //





        /// non target
        /// <returns></returns>
       //NonTarget
        public IActionResult NonTargetIndex(
               string currentFilter,
               string searchString,
               int? pageNumber,
               string popup
            )
        {
            ViewBag.Message = null;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            List<NonTargetModel> NonTargetModels = _reasonFunction.SelectNonTargetReason<NonTargetModel>(0, null);
            if (popup != null)
            { ViewBag.Message = popup; }

            var result = NonTargetModels.AsQueryable();
            int pageSize = 10;
            return View(PaginatedList<NonTargetModel>.Create(result, pageNumber ?? 1, pageSize));

        }

        public IActionResult NonTargetUpsert(int id)
        {

            IEnumerable<ProjectConfigModel> Projectcodelist = _projectConfigFunction.SelectProjectCode<ProjectConfigModel>();
            var types = new List<SelectListItem>();

            types.Add(new SelectListItem() { Text = "YES" });
            types.Add(new SelectListItem() { Text = "NO " });

            NonTargetVM NonTargetVM = new NonTargetVM()
            {
                NonTarget = new NonTargetModel(),
                PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                {
                    Text = i.PROJECT_CODE,
                    //Value = i.PROJECT_CODE.ToString()
                })
            

            };
            if (id == 0)
            {
                //this is for create
                return View(NonTargetVM);
            }
            //this is for edit

            IEnumerable<NonTargetModel> NonTargetModels = _reasonFunction.SelectNonTargetReason<NonTargetModel>(id, null);

            var result = NonTargetModels.ToList();
            foreach (var r in result)
            {
                NonTargetVM.NonTarget.PROJECT_CODE = r.PROJECT_CODE;
                NonTargetVM.NonTarget.NONTARGETCODE = r.NONTARGETCODE;
                NonTargetVM.NonTarget.NONTARGETREASON = r.NONTARGETREASON.ToString();
             
            }


            if (NonTargetVM.NonTarget == null)
            {
                return NotFound();
            }
            return View(NonTargetVM);



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NonTargetUpsert(NonTargetVM NonTargetVM)
        {
            TempData["Duplicate"] = null;
            ViewBag.Message = null;
            if (ModelState.IsValid)

            {
                // check dup ก่อน
                List<NonTargetModel> selectListItems = _reasonFunction.SelectNonTargetReason<NonTargetModel>(NonTargetVM.NonTarget.NONTARGETCODE, NonTargetVM.NonTarget.NONTARGETREASON);

                if (selectListItems.Count() > 0) //เจอ dup
                {
                    //dup

                    ViewBag.Message = "ข้อมูลซ้ำ ไม่สามารถเพิ่ม/แก้ไขข้อมูลได้";
                    goto returnerror;
                }
                else
                {
                    if (NonTargetVM.NonTarget.NONTARGETCODE == 0)
                    {
                        //insert
                        _reasonFunction.InsertNonTarget(NonTargetVM);

                        return RedirectToAction(nameof(NonTargetIndex), new { popup = "Success" });
                    }
                    else
                    {

                        //update
                        _reasonFunction.UpdateNonTarget(NonTargetVM);

                        return RedirectToAction(nameof(NonTargetIndex), new { popup = "Success" });
                    }
                }

            }
        returnerror:
            IEnumerable<ProjectConfigModel> Projectcodelist = _projectConfigFunction.SelectProjectCode<ProjectConfigModel>();
            var types = new List<SelectListItem>();

            types.Add(new SelectListItem() { Text = "YES" });
            types.Add(new SelectListItem() { Text = "NO " });

            NonTargetVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
            {
                Text = i.PROJECT_CODE,
            });

    
            return View(NonTargetVM);

        }

        //


        public IActionResult NonTargetDelete(int id)

        {


            if (id != 0)

            {

                _reasonFunction.DeleteNonTarget(id);
                return Json(new { success = true, message = "Delete Successful" });


            }


            else
            {

                return Json(new { success = false, message = "Error while deleting" });

            }


        }






        /// refuse
        /// <returns></returns>
       //Refuse
        public IActionResult RefuseIndex(
               string currentFilter,
               string searchString,
               int? pageNumber,
               string popup
            )
        {
            ViewBag.Message = null;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            List<RefuseModel> RefuseModels = _reasonFunction.SelectRefuseReason<RefuseModel>(0, null);
            if (popup != null)
            { ViewBag.Message = popup; }

            var result = RefuseModels.AsQueryable();
            int pageSize = 10;
            return View(PaginatedList<RefuseModel>.Create(result, pageNumber ?? 1, pageSize));

        }

        public IActionResult RefuseUpsert(int id)
        {

            IEnumerable<ProjectConfigModel> Projectcodelist = _projectConfigFunction.SelectProjectCode<ProjectConfigModel>();
            var types = new List<SelectListItem>();

            types.Add(new SelectListItem() { Text = "YES" });
            types.Add(new SelectListItem() { Text = "NO " });

            RefuseVM RefuseVM = new RefuseVM()
            {
                Refuse = new RefuseModel(),
                PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                {
                    Text = i.PROJECT_CODE,
                    //Value = i.PROJECT_CODE.ToString()
                })


            };
            if (id == 0)
            {
                //this is for create
                return View(RefuseVM);
            }
            //this is for edit

            IEnumerable<RefuseModel> RefuseModels = _reasonFunction.SelectRefuseReason<RefuseModel>(id, null);

            var result = RefuseModels.ToList();
            foreach (var r in result)
            {
                RefuseVM.Refuse.PROJECT_CODE = r.PROJECT_CODE;
                RefuseVM.Refuse.REFUSECODE = r.REFUSECODE;
                RefuseVM.Refuse.REFUSEREASON = r.REFUSEREASON.ToString();

            }


            if (RefuseVM.Refuse == null)
            {
                return NotFound();
            }
            return View(RefuseVM);



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RefuseUpsert(RefuseVM RefuseVM)
        {
            TempData["Duplicate"] = null;
            ViewBag.Message = null;
            if (ModelState.IsValid)

            {
                // check dup ก่อน
                List<RefuseModel> selectListItems = _reasonFunction.SelectRefuseReason<RefuseModel>(RefuseVM.Refuse.REFUSECODE, RefuseVM.Refuse.REFUSEREASON);

                if (selectListItems.Count() > 0) //เจอ dup
                {
                    //dup

                    ViewBag.Message = "ข้อมูลซ้ำ ไม่สามารถเพิ่ม/แก้ไขข้อมูลได้";
                    goto returnerror;
                }
                else
                {
                    if (RefuseVM.Refuse.REFUSECODE == 0)
                    {
                        //insert
                        _reasonFunction.InsertRefuse(RefuseVM);

                        return RedirectToAction(nameof(RefuseIndex), new { popup = "Success" });
                    }
                    else
                    {

                        //update
                        _reasonFunction.UpdateRefuse(RefuseVM);

                        return RedirectToAction(nameof(RefuseIndex), new { popup = "Success" });
                    }
                }

            }
        returnerror:
            IEnumerable<ProjectConfigModel> Projectcodelist = _projectConfigFunction.SelectProjectCode<ProjectConfigModel>();
            var types = new List<SelectListItem>();

            types.Add(new SelectListItem() { Text = "YES" });
            types.Add(new SelectListItem() { Text = "NO " });

            RefuseVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
            {
                Text = i.PROJECT_CODE,
            });


            return View(RefuseVM);

        }

        //


        public IActionResult RefuseDelete(int id)

        {


            if (id != 0)

            {

                _reasonFunction.DeleteRefuse(id);
                return Json(new { success = true, message = "Delete Successful" });


            }


            else
            {

                return Json(new { success = false, message = "Error while deleting" });

            }


        }










        /// Success
        /// <returns></returns>
       //Success
        public IActionResult SuccessIndex(
               string currentFilter,
               string searchString,
               int? pageNumber,
               string popup
            )
        {
            ViewBag.Message = null;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            List<SuccessModel> SuccessModels = _reasonFunction.SelectSuccessReason<SuccessModel>(0, null);
            if (popup != null)
            { ViewBag.Message = popup; }

            var result = SuccessModels.AsQueryable();
            int pageSize = 10;
            return View(PaginatedList<SuccessModel>.Create(result, pageNumber ?? 1, pageSize));

        }

        public IActionResult SuccessUpsert(int id)
        {

            IEnumerable<ProjectConfigModel> Projectcodelist = _projectConfigFunction.SelectProjectCode<ProjectConfigModel>();
            var types = new List<SelectListItem>();

            types.Add(new SelectListItem() { Text = "YES" });
            types.Add(new SelectListItem() { Text = "NO " });

            SuccessVM SuccessVM = new SuccessVM()
            {
                Success = new SuccessModel(),
                PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
                {
                    Text = i.PROJECT_CODE,
                    //Value = i.PROJECT_CODE.ToString()
                })


            };
            if (id == 0)
            {
                //this is for create
                return View(SuccessVM);
            }
            //this is for edit

            IEnumerable<SuccessModel> SuccessModels = _reasonFunction.SelectSuccessReason<SuccessModel>(id, null);

            var result = SuccessModels.ToList();
            foreach (var r in result)
            {
                SuccessVM.Success.PROJECT_CODE = r.PROJECT_CODE;
                SuccessVM.Success.SUCCESSCODE = r.SUCCESSCODE;
                SuccessVM.Success.SUCCESSREASON = r.SUCCESSREASON.ToString();

            }


            if (SuccessVM.Success == null)
            {
                return NotFound();
            }
            return View(SuccessVM);



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuccessUpsert(SuccessVM SuccessVM)
        {
            TempData["Duplicate"] = null;
            ViewBag.Message = null;
            if (ModelState.IsValid)

            {
                // check dup ก่อน
                List<SuccessModel> selectListItems = _reasonFunction.SelectSuccessReason<SuccessModel>(SuccessVM.Success.SUCCESSCODE, SuccessVM.Success.SUCCESSREASON);

                if (selectListItems.Count() > 0) //เจอ dup
                {
                    //dup

                    ViewBag.Message = "ข้อมูลซ้ำ ไม่สามารถเพิ่ม/แก้ไขข้อมูลได้";
                    goto returnerror;
                }
                else
                {
                    if (SuccessVM.Success.SUCCESSCODE == 0)
                    {
                        //insert
                        _reasonFunction.InsertSuccess(SuccessVM);

                        return RedirectToAction(nameof(SuccessIndex), new { popup = "Success" });
                    }
                    else
                    {

                        //update
                        _reasonFunction.UpdateSuccess(SuccessVM);

                        return RedirectToAction(nameof(SuccessIndex), new { popup = "Success" });
                    }
                }

            }
        returnerror:
            IEnumerable<ProjectConfigModel> Projectcodelist = _projectConfigFunction.SelectProjectCode<ProjectConfigModel>();
            var types = new List<SelectListItem>();

            types.Add(new SelectListItem() { Text = "YES" });
            types.Add(new SelectListItem() { Text = "NO " });

            SuccessVM.PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
            {
                Text = i.PROJECT_CODE,
            });


            return View(SuccessVM);

        }

        //


        public IActionResult SuccessDelete(int id)

        {


            if (id != 0)

            {

                _reasonFunction.DeleteSuccess(id);
                return Json(new { success = true, message = "Delete Successful" });


            }


            else
            {

                return Json(new { success = false, message = "Error while deleting" });

            }


        }






    }
}

