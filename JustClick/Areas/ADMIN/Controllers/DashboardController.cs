using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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



namespace JustClick.Areas.ADMIN.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        private UserManager<ApplicationUser> _userManager;
        public DashboardController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Profile(string id)
        {
            if ( id != null)
            {

            RegisterViewModel registerViewModel = new RegisterViewModel();
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            var rolename = await _userManager.GetRolesAsync(user);



            registerViewModel.Id = user.Id;
            registerViewModel.PROJECT_CODE = user.PROJECT_CODE;
            foreach (var r in rolename)
            {
                registerViewModel.ROLE = r.ToString();
            }
            var teamleadername = await _userManager.FindByIdAsync(user.TEAMLEADER_ID);


            if (teamleadername != null)
            {
                registerViewModel.TEAMLEADER_ID = user.TEAMLEADER_ID;
                registerViewModel.TEAMLEADER_NAME = teamleadername.FNAME_THAI + ' ' + teamleadername.LNAME_THAI;
            }
            registerViewModel.UserName = user.UserName;
            registerViewModel.TITLE_THAI = user.TITLE_THAI;
            registerViewModel.FNAME_THAI = user.FNAME_THAI;
            registerViewModel.LNAME_THAI = user.LNAME_THAI;
            registerViewModel.ACCESSSTATUS = user.ACCESSSTATUS;
            registerViewModel.TSR_PICTURE = user.TSR_PICTURE;


            return View(registerViewModel);

            }
            return NotFound();
        }

        #region API CALLS

        [HttpGet]
        public IActionResult Getweekly()
        {
 
            var allObj = _unitOfWork.SP_Call.List<DashboardGraphWeeklyVM>("[SP_REPORT_GRAPH_WEEKLY]", null);
            return Json(new { data = allObj });

        }


        public IActionResult Getdailysalebytsr()
        {
          
            var allObj = _unitOfWork.SP_Call.List<DashboardDailysalebyTSRVM>("[SP_REPORT_DAILY_TOPSALE]", null);
            return Json(new { data = allObj });

        }


        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Getweeklysalebytsr()
        {
       
            var allObj = _unitOfWork.SP_Call.List<DashboardGraphWeeklyVM>("[SP_REPORT_GRAPH_WEEKLY_BYTSR]", null);
            return Json(new { data = allObj });

        }


        public IActionResult Getagentmonitoring()
        {


            var allObj = _unitOfWork.SP_Call.List<DashboardAgentMonitoringVM>("[SP_REPORT_AGENTMONITOR]", null);
             return Json(new { data = allObj });

        }


   
        public IActionResult GetmtdPerformance()
        {
            var allObj = _unitOfWork.SP_Call.List<DashboardMTDPerformanceVM>("[SP_REPORT_MTD_NEW]", null);
             return Json(new { data = allObj });

        }

    
        public IActionResult GetmtdPerformancerenew()
        {
            var allObj = _unitOfWork.SP_Call.List<DashboardMTDPerformanceVM>("[SP_REPORT_MTD_RENEW]", null);
            return Json(new { data = allObj });

        }
  
        public IActionResult GetTopSalenewMTD()
        {

            var allObj = _unitOfWork.SP_Call.List<DashboardDailysalebyTSRVM>("[SP_REPORT_TOPSALE_NEW_MTD]", null);
            return Json(new { data = allObj });

        }
        public IActionResult GetTopSalenewtoday()
        {
 
            var allObj = _unitOfWork.SP_Call.List<DashboardDailysalebyTSRVM>("[SP_REPORT_TOPSALE_NEW_TODAY]", null);
            return Json(new { data = allObj });

        }

        public IActionResult GetTopSalerenewMTD()
        {
            var allObj = _unitOfWork.SP_Call.List<DashboardDailysalebyTSRVM>("[SP_REPORT_TOPSALE_RENEW_MTD]", null);
            return Json(new { data = allObj });


        }
        public IActionResult GetTopSalerenewtoday()
        {
            var allObj = _unitOfWork.SP_Call.List<DashboardDailysalebyTSRVM>("[SP_REPORT_TOPSALE_RENEW_TODAY]", null);
            return Json(new { data = allObj });

        }


        // second sale
        public IActionResult GetsecondSalenewMTD()
        {
        


            var allObj = _unitOfWork.SP_Call.List<DashboardDailysalebyTSRVM>("[SP_REPORT_SECONDSALE_NEW_MTD]", null);
            return Json(new { data = allObj });

        }
        public IActionResult GetsecondSalenewtoday()
        {

            var allObj = _unitOfWork.SP_Call.List<DashboardDailysalebyTSRVM>("[SP_REPORT_SECONDSALE_NEW_TODAY]", null);
            return Json(new { data = allObj });



        }

        public IActionResult GetsecondSalerenewMTD()
        {
        
            var allObj = _unitOfWork.SP_Call.List<DashboardDailysalebyTSRVM>("[SP_REPORT_SECONDSALE_RENEW_MTD]", null);
            return Json(new { data = allObj });

        }
        public IActionResult GetsecondSalerenewtoday()
        {
          var allObj = _unitOfWork.SP_Call.List<DashboardDailysalebyTSRVM>("[SP_REPORT_SECONDSALE_RENEW_TODAY]", null);
          return Json(new { data = allObj });

        }

        public IActionResult Getlogoutagent()
        {

            var allObj = _unitOfWork.SP_Call.List<DashboardAgentMonitoringVM>("[SP_LOGOUTAGENT]", null);
            return Json(new { data = allObj });

        }

        // below code id for header

        public IActionResult GetTalktime()
        {
 

            var allObj = _unitOfWork.SP_Call.List<DashboardTalktime>("[SP_REPORT_TALKTIME]", null);
            return Json(new { data = allObj });


        }
        public IActionResult Getmtddetail()
        {


            var allObj = _unitOfWork.SP_Call.List<DashboardMTDdetail>("[SP_REPORT_MTD_DETAIL]", null);
            return Json(new { data = allObj });


        }
        public IActionResult Getretentioncurrent()
        {


            var allObj = _unitOfWork.SP_Call.List<DashboardRetention>("[SP_REPORT_MTD_RENEW_HEADER]", null);
            return Json(new { data = allObj });


        }

        public IActionResult Getretentionprevious()
        {


            var allObj = _unitOfWork.SP_Call.List<DashboardRetention>("[SP_REPORT_MTD_RENEW_HEADER_PREVIOUS]", null);
            return Json(new { data = allObj });


        }

    }
    #endregion
}
