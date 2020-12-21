
using Dapper;
using JustClick.DataAccess.Data;
using JustClick.DataAccess.Repository.IRepository;

using JustClick.Models.Identity;
using JustClick.Models.ViewModels;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace JustClick.Infrastructure
{




    public  class GlobalFunction : IGlobalFunction
    {


        private readonly IUnitOfWork _unitOfWork;
    
        public  GlobalFunction(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
          
        }



      

        public string serverdatetime { get; set; }

        public void Dispose()
        {
            _unitOfWork.Dispose();
       
            
        }

        public string Getdatetime()
        {
            //Output yyyy-mm-dd hh:mi:ss
            IEnumerable<GetdatetimeVM> getdatetimeVM  = _unitOfWork.SQLRAW_Call.Listraw<GetdatetimeVM>("SELECT CONVERT(VARCHAR(19),GETDATE(),120) AS GETDATETIME", null);
          
            var result = getdatetimeVM.ToList();

            string s = "";

            foreach (var r in result)
            {
                s=  r.GETDATETIME.ToString();
            }

            return (s);

        }


         
        public void UpdateAgentmonitoring(string loginname,string screen, string startcalltime,string cust)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@TSR_LOGINNAME",loginname );
            parameter.Add("@SCREEN",screen);
            parameter.Add("@CUST",cust );
            parameter.Add("@STARTCALLTIME",startcalltime);

            var allObj = _unitOfWork.SP_Call.List<DataProfileViewModel>("[SP_INSERT_AGENTMONITORING]", parameter);
        }


        public void InsertLogin(string loginname, string role, string ext,string project_code)
        {
            //ถ้าลืม logpff ให้ลงเวลา logoff ก่อน
            string sqlstr = "SELECT * FROM TBL_LOGINTIME WHERE TSR_LOGINNAME = '" + loginname + "' AND LOGOUTTIME = ''";
            IEnumerable<GetdatetimeVM> getdatetimeVM = _unitOfWork.SQLRAW_Call.Listraw<GetdatetimeVM>(sqlstr, null);
            var result = getdatetimeVM.ToList();
            if (result.Count >0)
            {
                sqlstr = "UPDATE TBL_LOGINTIME SET LOGOUTTIME = getdate() WHERE TSR_LOGINNAME = '" + loginname + "' AND convert(varchar(10),LOGOUTTIME,20) = '1900-01-01' ";
                _unitOfWork.SQLRAW_Call.Execute(sqlstr, null);
            }


            // insert
            sqlstr = "INSERT INTO TBL_LOGINTIME(PROJECT_CODE,TSR_LOGINNAME" +
                      ",LEVEL_ID,LOGINTIME,LOGOUTTIME,EXT) values('" + project_code + "' , '" + loginname + "' " +
                      ",'" + role + "', getdate() ,'','" + ext + "')";
                    
            _unitOfWork.SQLRAW_Call.Execute(sqlstr, null);

            //ลบจาก monitoring
            sqlstr = "DELETE FROM TBL_MONITOR WHERE LOGINNAME = '" + loginname + "'";
            _unitOfWork.SQLRAW_Call.Execute(sqlstr, null);

        }

        public void Logout(string loginname)
        {
            //ถ้าลืม logpff ให้ลงเวลา logoff ก่อน
            string sqlstr = "SELECT * FROM TBL_LOGINTIME WHERE TSR_LOGINNAME = '" + loginname + "' AND LOGOUTTIME = ''";
            IEnumerable<GetdatetimeVM> getdatetimeVM = _unitOfWork.SQLRAW_Call.Listraw<GetdatetimeVM>(sqlstr, null);
            var result = getdatetimeVM.ToList();
            if (result.Count > 0)
            {
                sqlstr = "UPDATE TBL_LOGINTIME SET LOGOUTTIME = getdate() WHERE TSR_LOGINNAME = '" + loginname + "' AND convert(varchar(10),LOGOUTTIME,20) = '1900-01-01' ";
                _unitOfWork.SQLRAW_Call.Execute(sqlstr, null);
            }


            //ลบจาก monitoring
            sqlstr = "DELETE FROM TBL_MONITOR WHERE LOGINNAME = '" + loginname + "'";
            _unitOfWork.SQLRAW_Call.Execute(sqlstr, null);

        }
    }
}
