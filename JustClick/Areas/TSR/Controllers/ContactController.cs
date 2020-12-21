using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using JustClick.DataAccess.Repository.IRepository;
using JustClick.Models;
using JustClick.Models.Identity;
using JustClick.Models.ViewModels;
using JustClick.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using JustClick.Infrastructure.ApplicationUserClaims.Extensions;
using JustClick.Infrastructure;

namespace JustClick.Areas.TSR.Controllers
{
    [Area("TSR")]
    public class ContactController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        private UserManager<ApplicationUser> _userManager;
        private readonly IGlobalFunction _globalFunction;
        public ContactController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment, UserManager<ApplicationUser> userManager
            , IGlobalFunction globalFunction)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
            _userManager = userManager;
            _globalFunction = globalFunction;
        }

        public IActionResult SelectNewCall(
    
                string currentFilter,
                string searchString,
                int? pageNumber)
        {

       
  
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            //ViewData["CurrentFilter"] = searchString;

            var loginname = User.GetUserName().ToString();
            var sqlstr = "SELECT * FROM V_SELECT_NEWCALL WHERE TSR_LOGINNAME ='" + loginname + "'";

            var parameter = new DynamicParameters();
       
            IEnumerable<ContactVM> contactVMs = _unitOfWork.SQLRAW_Call.Listraw<ContactVM>(sqlstr, parameter);


            var result = contactVMs.AsQueryable();



            if (!String.IsNullOrEmpty(searchString))
            {
                result = result.Where(s => s.THAI_NAME.StartsWith(searchString)
                                       || s.THAI_SURNAME.StartsWith(searchString));
            }

            int pageSize = 10;

            //return View(contactVMs);
            return View( PaginatedList<ContactVM>.Create(result, pageNumber ?? 1,pageSize));

        }
        public IActionResult SelectCallBack(

               string currentFilter,
               string searchString,
               int? pageNumber)
        {



            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            //ViewData["CurrentFilter"] = searchString;

            var loginname = User.GetUserName().ToString();
            var screen = "Select CallBack List";
            var sqlstr = "SELECT * FROM V_SELECT_CALLBACK WHERE TSR_LOGINNAME ='" + loginname + "' ORDER BY CALLTIMETAG";

            var parameter = new DynamicParameters();

            IEnumerable<ContactVM> contactVMs = _unitOfWork.SQLRAW_Call.Listraw<ContactVM>(sqlstr, parameter);


            var result = contactVMs.AsQueryable();



            if (!String.IsNullOrEmpty(searchString))
            {
                result = result.Where(s => s.THAI_NAME.StartsWith(searchString)
                                       || s.THAI_SURNAME.StartsWith(searchString));
            }

            int pageSize = 10;


            string startcalltime = _globalFunction.Getdatetime();
            _globalFunction.UpdateAgentmonitoring(loginname, screen, startcalltime, "");

            return View(PaginatedList<ContactVM>.Create(result, pageNumber ?? 1, pageSize));

        }
        public IActionResult SelectNoContact(

               string currentFilter,
               string searchString,
               int? pageNumber)
        {



            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            //ViewData["CurrentFilter"] = searchString;

            var loginname = User.GetUserName().ToString();
            var screen = "Select No Contact List";
            var sqlstr = "SELECT * FROM V_SELECT_NOCONTACT WHERE TSR_LOGINNAME ='" + loginname + "' ORDER BY CALLTIMETAG";

            var parameter = new DynamicParameters();

            IEnumerable<ContactVM> contactVMs = _unitOfWork.SQLRAW_Call.Listraw<ContactVM>(sqlstr, parameter);


            var result = contactVMs.AsQueryable();



            if (!String.IsNullOrEmpty(searchString))
            {
                result = result.Where(s => s.THAI_NAME.StartsWith(searchString)
                                       || s.THAI_SURNAME.StartsWith(searchString));
            }

            int pageSize = 10;


            string startcalltime = _globalFunction.Getdatetime();
            _globalFunction.UpdateAgentmonitoring(loginname, screen, startcalltime, "");

            return View(PaginatedList<ContactVM>.Create(result, pageNumber ?? 1, pageSize));

        }



        public IActionResult SelectFollowUp(

               string currentFilter,
               string searchString,
               int? pageNumber)
        {



            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            //ViewData["CurrentFilter"] = searchString;

            var loginname = User.GetUserName().ToString();
            var screen = "Select Follow Up List";
            var sqlstr = "SELECT * FROM V_SELECT_FOLLOWUP WHERE TSR_LOGINNAME ='" + loginname + "' ORDER BY CALLTIMETAG";

            var parameter = new DynamicParameters();

            IEnumerable<ContactVM> contactVMs = _unitOfWork.SQLRAW_Call.Listraw<ContactVM>(sqlstr, parameter);


            var result = contactVMs.AsQueryable();



            if (!String.IsNullOrEmpty(searchString))
            {
                result = result.Where(s => s.THAI_NAME.StartsWith(searchString)
                                       || s.THAI_SURNAME.StartsWith(searchString));
            }

            int pageSize = 10;


            string startcalltime = _globalFunction.Getdatetime();
            _globalFunction.UpdateAgentmonitoring(loginname, screen, startcalltime, "");

            return View(PaginatedList<ContactVM>.Create(result, pageNumber ?? 1, pageSize));

        }
        public IActionResult SelectFollowDoc(

              string currentFilter,
              string searchString,
              int? pageNumber)
        {



            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            //ViewData["CurrentFilter"] = searchString;

            var loginname = User.GetUserName().ToString();
            var screen = "Select Follow Doc List";
            var sqlstr = "SELECT * FROM V_SELECT_FOLLOWDOC WHERE TSR_LOGINNAME ='" + loginname + "' ORDER BY CALLTIMETAG";

            var parameter = new DynamicParameters();

            IEnumerable<ContactVM> contactVMs = _unitOfWork.SQLRAW_Call.Listraw<ContactVM>(sqlstr, parameter);


            var result = contactVMs.AsQueryable();



            if (!String.IsNullOrEmpty(searchString))
            {
                result = result.Where(s => s.THAI_NAME.StartsWith(searchString)
                                       || s.THAI_SURNAME.StartsWith(searchString));
            }

            int pageSize = 10;


            string startcalltime = _globalFunction.Getdatetime();
            _globalFunction.UpdateAgentmonitoring(loginname, screen, startcalltime, "");

            return View(PaginatedList<ContactVM>.Create(result, pageNumber ?? 1, pageSize));

        }
        public IActionResult SelectFollowPay(

             string currentFilter,
             string searchString,
             int? pageNumber)
        {



            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            //ViewData["CurrentFilter"] = searchString;

            var loginname = User.GetUserName().ToString();
            var screen = "Select Follow Payment List";
            var sqlstr = "SELECT * FROM V_SELECT_FOLLOWPAYMENT WHERE TSR_LOGINNAME ='" + loginname + "' ORDER BY CALLTIMETAG";

            var parameter = new DynamicParameters();

            IEnumerable<ContactVM> contactVMs = _unitOfWork.SQLRAW_Call.Listraw<ContactVM>(sqlstr, parameter);


            var result = contactVMs.AsQueryable();



            if (!String.IsNullOrEmpty(searchString))
            {
                result = result.Where(s => s.THAI_NAME.StartsWith(searchString)
                                       || s.THAI_SURNAME.StartsWith(searchString));
            }

            int pageSize = 10;


            string startcalltime = _globalFunction.Getdatetime();
            _globalFunction.UpdateAgentmonitoring(loginname, screen, startcalltime, "");

            return View(PaginatedList<ContactVM>.Create(result, pageNumber ?? 1, pageSize));

        }
        public IActionResult SelectRedetail(

             string currentFilter,
             string searchString,
             int? pageNumber)
        {



            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            //ViewData["CurrentFilter"] = searchString;

            var loginname = User.GetUserName().ToString();
            var screen = "Select Redetil List";
            var sqlstr = "SELECT * FROM V_SELECT_REDETAIL WHERE TSR_LOGINNAME ='" + loginname + "' ORDER BY CALLTIMETAG";

            var parameter = new DynamicParameters();

            IEnumerable<ContactVM> contactVMs = _unitOfWork.SQLRAW_Call.Listraw<ContactVM>(sqlstr, parameter);


            var result = contactVMs.AsQueryable();



            if (!String.IsNullOrEmpty(searchString))
            {
                result = result.Where(s => s.THAI_NAME.StartsWith(searchString)
                                       || s.THAI_SURNAME.StartsWith(searchString));
            }

            int pageSize = 10;


            string startcalltime = _globalFunction.Getdatetime();
            _globalFunction.UpdateAgentmonitoring(loginname, screen, startcalltime, "");

            return View(PaginatedList<ContactVM>.Create(result, pageNumber ?? 1, pageSize));

        }

    }
}
