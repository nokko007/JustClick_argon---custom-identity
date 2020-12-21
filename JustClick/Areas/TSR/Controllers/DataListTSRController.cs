using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using JustClick.DataAccess.Repository.IRepository;
using JustClick.Infrastructure.ApplicationUserClaims.Extensions;
using JustClick.Models;
using JustClick.Models.ViewModels;
using JustClick.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace JustClick.Areas.ADMIN.Controllers
{
    [Area("TSR")]
    public class DataListTSRController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public DataListTSRController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        ///  assign new starts here <summary>
        //public IActionResult Assignnew()
        //{



        //    var parameter = new DynamicParameters();
        //    //if (source != null)
        //    //{

        //    //    parameter.Add("@SOURCE", source.ToString());


        //    //}
        //    //else
        //    //{
        //        parameter.Add("@SOURCE", null);

        //    //}




        //    IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
        //    List<DataProfileViewModel> sourceresult = _unitOfWork.SP_Call.List<DataProfileViewModel>("[SP_DATA_SOURCE]", null).ToList();

        //    List<DataProfileViewModel> result = _unitOfWork.SP_Call.List<DataProfileViewModel>("[SP_DATA_PROFILE]", parameter).ToList();

        //    List<DataProfileViewModel> tsrlist = _unitOfWork.SP_Call.List<DataProfileViewModel>("[SP_SELECTAGENT_LIST]", null).ToList();

        //    DataProfileViewModel dataProfileViewModel = new DataProfileViewModel()


          
        //    {
        //        PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
        //        {
        //            Text = i.PROJECT_CODE,
        //            //Value = i.PROJECT_CODE.ToString()
        //        }),

        //        SOURCE_LIST = sourceresult.Select(i => new SelectListItem
        //        {
        //            Text = i.SOURCE,
        //            Value = i.SOURCE
        //        }),


        //        TSR_LIST = tsrlist.Select(i => new SelectListItem
        //        {
        //            Text = i.TSR_LOGINNAME + " => New Call " + i.NEWCALL + " Recs. "  ,
        //            Value = i.TSR_LOGINNAME
        //        })
        //    };

        //    foreach ( var i in result )

        //    {
          
        //        dataProfileViewModel.TOTALINDATABASE = i.TOTALINDATABASE;
        //        dataProfileViewModel.TRANSFERDATA = i.TRANSFERDATA;
        //        dataProfileViewModel.FREEDATA = i.FREEDATA;
        //        dataProfileViewModel.FREEDATABYCRITERIA = i.FREEDATABYCRITERIA;

        //    };

        //    return View(dataProfileViewModel);
                
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult AssignNew(DataProfileViewModel model)

        //{

        //    //ViewBag.Message = null;


        //    if (ModelState.IsValid)
        //    {
        //        var parameter = new DynamicParameters();

        //        parameter.Add("@SOURCE", model.SOURCE.ToString());
        //        parameter.Add("@TSR", model.TSR_SELECTEDLIST.ToString());
        //        parameter.Add("@REC", model.RECTOTSR.ToString());

        //        var allObj = _unitOfWork.SP_Call.List<DataProfileViewModel>("[SP_ASSIGN_NEWCALL]", parameter);


        //        /////////////////
        //        ///
        //        ViewBag.Message = "โอนรายชื่อให้ TSR เรียบร้อยแล้ว";
        //        goto RETURN1;

        //        ///////////////


        //    }

        //    ViewBag.Message = "ไม่สามารถโอนรายชื่อให้ TSR ได้";

        //RETURN1:

        //    var parameter1 = new DynamicParameters();

        //    parameter1.Add("@SOURCE", model.SOURCE.ToString());

        //    IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
        //    List<DataProfileViewModel> sourceresult = _unitOfWork.SP_Call.List<DataProfileViewModel>("[SP_DATA_SOURCE]", null).ToList();

        //    List<DataProfileViewModel> result = _unitOfWork.SP_Call.List<DataProfileViewModel>("[SP_DATA_PROFILE]", parameter1).ToList();

        //    List<DataProfileViewModel> tsrlist = _unitOfWork.SP_Call.List<DataProfileViewModel>("[SP_SELECTAGENT_LIST]", null).ToList();

        //    DataProfileViewModel dataProfileViewModel = new DataProfileViewModel()


          
        //    {
        //        PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
        //        {
        //            Text = i.PROJECT_CODE,
        //            //Value = i.PROJECT_CODE.ToString()
        //        }),

        //        SOURCE_LIST = sourceresult.Select(i => new SelectListItem
        //        {
        //            Text = i.SOURCE,
        //            Value = i.SOURCE
        //        }),


        //        TSR_LIST = tsrlist.Select(i => new SelectListItem
        //        {
        //            Text = i.TSR_LOGINNAME + " => New Call " + i.NEWCALL + " Recs. "  ,
        //            Value = i.TSR_LOGINNAME
        //        })
        //    };

        //    foreach ( var i in result )

        //    {
          
        //        dataProfileViewModel.TOTALINDATABASE = i.TOTALINDATABASE;
        //        dataProfileViewModel.TRANSFERDATA = i.TRANSFERDATA;
        //        dataProfileViewModel.FREEDATA = i.FREEDATA;
               

        //    };

        //    dataProfileViewModel.PROJECT_CODE = model.PROJECT_CODE;
        //    dataProfileViewModel.SOURCE = model.SOURCE;
        //    dataProfileViewModel.FREEDATABYCRITERIA = 0;
        


        //    return View(dataProfileViewModel);


          


        //}




        ///  assign new ends here </summary>
        /// <returns></returns>



        ///  
        /////  transfer between TSR ends here </summary>starts here <summary>
        //public IActionResult TransferTSRLead()
        //{



        //    var parameter = new DynamicParameters();
        //    //if (source != null)
        //    //{

        //    //    parameter.Add("@SOURCE", source.ToString());


        //    //}
        //    //else
        //    //{
        //    parameter.Add("@SOURCE", null);

        //    //}




        //    IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
        //    List<DataProfileViewModel> sourceresult = _unitOfWork.SP_Call.List<DataProfileViewModel>("[SP_DATA_SOURCE]", null).ToList();

        //    List<DataProfileViewModel> result = _unitOfWork.SP_Call.List<DataProfileViewModel>("[SP_DATA_PROFILE]", parameter).ToList();

        //    List<DataProfileViewModel> tsrlist = _unitOfWork.SP_Call.List<DataProfileViewModel>("[SP_SELECTAGENT_LIST]", null).ToList();

        //    DataProfileViewModel dataProfileViewModel = new DataProfileViewModel()



        //    {
        //        PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
        //        {
        //            Text = i.PROJECT_CODE,
        //            //Value = i.PROJECT_CODE.ToString()
        //        }),

        //        SOURCE_LIST = sourceresult.Select(i => new SelectListItem
        //        {
        //            Text = i.SOURCE,
        //            Value = i.SOURCE
        //        }),


        //        TSR_LIST = tsrlist.Select(i => new SelectListItem
        //        {
        //            Text = i.TSR_LOGINNAME + " => New Call " + i.NEWCALL + " Recs. ",
        //            Value = i.TSR_LOGINNAME
        //        })
        //    };

        //    foreach (var i in result)

        //    {

        //        dataProfileViewModel.TOTALINDATABASE = i.TOTALINDATABASE;
        //        dataProfileViewModel.TRANSFERDATA = i.TRANSFERDATA;
        //        dataProfileViewModel.FREEDATA = i.FREEDATA;
        //        dataProfileViewModel.FREEDATABYCRITERIA = i.FREEDATABYCRITERIA;

        //    };

        //    return View(dataProfileViewModel);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult TransferTSRLead(DataProfileViewModel model)

        //{

        //    //ViewBag.Message = null;


        //    if (ModelState.IsValid)
        //    {
        //        var parameter = new DynamicParameters();

        //        parameter.Add("@SOURCE", model.SOURCE.ToString());
        //        parameter.Add("@TSR", model.TSR_SELECTEDLIST.ToString());
        //        parameter.Add("@REC", model.RECTOTSR.ToString());

        //        var allObj = _unitOfWork.SP_Call.List<DataProfileViewModel>("[SP_ASSIGN_NEWCALL]", parameter);


        //        /////////////////
        //        ///
        //        ViewBag.Message = "โอนรายชื่อให้ TSR เรียบร้อยแล้ว";
        //        goto RETURN1;

        //        ///////////////


        //    }

        //    ViewBag.Message = "ไม่สามารถโอนรายชื่อให้ TSR ได้";

        //RETURN1:

        //    var parameter1 = new DynamicParameters();

        //    parameter1.Add("@SOURCE", model.SOURCE.ToString());

        //    IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();
        //    List<DataProfileViewModel> sourceresult = _unitOfWork.SP_Call.List<DataProfileViewModel>("[SP_DATA_SOURCE]", null).ToList();

        //    List<DataProfileViewModel> result = _unitOfWork.SP_Call.List<DataProfileViewModel>("[SP_DATA_PROFILE]", parameter1).ToList();

        //    List<DataProfileViewModel> tsrlist = _unitOfWork.SP_Call.List<DataProfileViewModel>("[SP_SELECTAGENT_LIST]", null).ToList();

        //    DataProfileViewModel dataProfileViewModel = new DataProfileViewModel()



        //    {
        //        PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
        //        {
        //            Text = i.PROJECT_CODE,
        //            //Value = i.PROJECT_CODE.ToString()
        //        }),

        //        SOURCE_LIST = sourceresult.Select(i => new SelectListItem
        //        {
        //            Text = i.SOURCE,
        //            Value = i.SOURCE
        //        }),


        //        TSR_LIST = tsrlist.Select(i => new SelectListItem
        //        {
        //            Text = i.TSR_LOGINNAME + " => New Call " + i.NEWCALL + " Recs. ",
        //            Value = i.TSR_LOGINNAME
        //        })
        //    };

        //    foreach (var i in result)

        //    {

        //        dataProfileViewModel.TOTALINDATABASE = i.TOTALINDATABASE;
        //        dataProfileViewModel.TRANSFERDATA = i.TRANSFERDATA;
        //        dataProfileViewModel.FREEDATA = i.FREEDATA;


        //    };

        //    dataProfileViewModel.PROJECT_CODE = model.PROJECT_CODE;
        //    dataProfileViewModel.SOURCE = model.SOURCE;
        //    dataProfileViewModel.FREEDATABYCRITERIA = 0;



        //    return View(dataProfileViewModel);





        //}




        /////  transfer between TSR ends here </summary>
        ///// <returns></returns>

        //public IActionResult ImportdatatoProject()
        //{

       

        //    var parameter = new DynamicParameters();
        //    //if (source != null)
        //    //{

        //    //    parameter.Add("@SOURCE", source.ToString());


        //    //}
        //    //else
        //    //{
        //    parameter.Add("@SOURCE", null);

        //    //}




        //    IEnumerable<ProjectConfigModel> Projectcodelist = _unitOfWork.ProjectConfig.GetAll();

        //    List<DataProfileViewModel> result = _unitOfWork.SP_Call.List<DataProfileViewModel>("[SP_DATA_PROFILE]", parameter).ToList();


        //    DataProfileViewModel dataProfileViewModel = new DataProfileViewModel()



        //    {
        //        PROJECT_CODE_LIST = Projectcodelist.Select(i => new SelectListItem
        //        {
        //            Text = i.PROJECT_CODE,
        //            //Value = i.PROJECT_CODE.ToString()
        //        })
        //    };

        //    foreach (var i in result)

        //    {

        //        dataProfileViewModel.TOTALINDATABASE = i.TOTALINDATABASE;
        //        dataProfileViewModel.TRANSFERDATA = i.TRANSFERDATA;
        //        dataProfileViewModel.FREEDATA = i.FREEDATA;
        //        dataProfileViewModel.FREEDATABYCRITERIA = i.FREEDATABYCRITERIA;

        //    };

        //    return View(dataProfileViewModel);

        //}




        #region API CALLS

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public IActionResult Setnode( )
        {
            var parameter = new DynamicParameters();
            var loginname = User.GetUserName().ToString();
            parameter.Add("@TSR_LOGINNAME", loginname);


          
          

         
            var allObj = _unitOfWork.SP_Call.List<SetNodeVM>("[SP_SETNODE]", parameter);

            return Json(new { data = allObj });
        }
       



    }
    #endregion


}

