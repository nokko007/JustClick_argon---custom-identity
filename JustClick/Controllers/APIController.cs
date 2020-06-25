using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustClick.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace JustClick.Controllers
{
    public class APIController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;


        public APIController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
     

        #region API CALLS

        [HttpGet]
        public  IActionResult GetTitle()
        {
            //var allObj = await _unitOfWork.Nontarget.GetAllAsync(includeProperties: "");
            //return Json(new { data = allObj });



            var allObj = _unitOfWork.SQLRAW_Call.Listraw<string>("SELECT TITLE_THAI FROM TBL_TITLE ORDER BY SEQ ", null);
            return Json(new { data = allObj });


        }





        #endregion

    }
}
