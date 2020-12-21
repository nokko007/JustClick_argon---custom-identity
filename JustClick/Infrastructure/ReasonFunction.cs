
using Dapper;
using JustClick.DataAccess.Data;
using JustClick.DataAccess.Repository.IRepository;

using JustClick.Models.Identity;
using JustClick.Models.ViewModels;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace JustClick.Infrastructure
{




    public  class ReasonFunction : IReasonFunction
    {


        private readonly IUnitOfWork _unitOfWork;
    
        public ReasonFunction(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
          
        }



 

        public void Dispose()
        {
            _unitOfWork.Dispose();
            
        }



        public List<T> SelectCallbackReason<T>(int id, string reason)
        {
            var sqlstr = "SELECT   PROJECT_CODE " +
                        " ,CALLBACKCODE " +
                        " ,CALLBACKREASON " +
                        " ,NEEDTERMINATE " +
                        " FROM TBL_CALLBACK WITH(NOLOCK) " +
                        "  WHERE 0=0 ";

            if (id != 0 && reason == null) //return ไปหน้า upsert
            {
                sqlstr = sqlstr + " AND  CALLBACKCODE = " + id;
            }

            else if (id != 0  && reason != null) // check dup กรณี update
            {
                sqlstr = sqlstr + " AND  CALLBACKCODE <> " + id;
                sqlstr = sqlstr + " AND  CALLBACKREASON =  '" + reason + "'";
            }
            else if  (id == 0 && reason != null)// check dup กรณี insert
            {
                sqlstr = sqlstr + " AND  CALLBACKREASON =  '" + reason + "'";
            }

          
            IEnumerable<T> selectListItems = _unitOfWork.SQLRAW_Call.Listraw<T>(sqlstr, null);
            return (selectListItems.ToList());

        }


        public void  Updatecallback(CallbackVM CallbackVM)
        {
            var sqlstr = "UPDATE TBL_CALLBACK " +
                        " SET PROJECT_CODE=  '" + CallbackVM.Callback.PROJECT_CODE + "'" +
                       " ,CALLBACKREASON=  '" + CallbackVM.Callback.CALLBACKREASON + "'" +
                       " ,NEEDTERMINATE=  '" + CallbackVM.Callback.NEEDTERMINATE + "'" +
                       "" +
                       "  WHERE CALLBACKCODE  = '" + CallbackVM.Callback.CALLBACKCODE + "'";
                        _unitOfWork.SQLRAW_Call.Execute(sqlstr,null);

        }


        public void InsertCallback(CallbackVM CallbackVM)
        {
            var sqlstr = "INSERT INTO  TBL_CALLBACK " +
                        " (PROJECT_CODE " +
                        " ,CALLBACKREASON " +
                        " ,NEEDTERMINATE )" +
                        " VALUES" +
                        " (  '" + CallbackVM.Callback.PROJECT_CODE + "'" +
                       " , '" + CallbackVM.Callback.CALLBACKREASON + "'" +
                       " ,  '" + CallbackVM.Callback.NEEDTERMINATE + "')";
            _unitOfWork.SQLRAW_Call.Execute(sqlstr, null);

        }

        public void DeleteCallback(int id)
        {
            var sqlstr = " DELETE  FROM  TBL_CALLBACK " +
                         " WHERE CALLBACKCODE = '" + id + "' ";
            _unitOfWork.SQLRAW_Call.Execute(sqlstr, null);

        }


        /// fail
        public List<T> SelectFailReason<T>(int id, string reason)
        {
            var sqlstr = "SELECT   PROJECT_CODE " +
                        " ,FAILCODE " +
                        " ,FAILREASON " +
                        " ,NEEDTERMINATE " +
                        " FROM TBL_FAIL WITH(NOLOCK) " +
                        "  WHERE 0=0 ";

            if (id != 0 && reason == null) //return ไปหน้า upsert
            {
                sqlstr = sqlstr + " AND  FAILCODE = " + id;
            }

            else if (id != 0 && reason != null) // check dup กรณี update
            {
                sqlstr = sqlstr + " AND  FAILCODE <> " + id;
                sqlstr = sqlstr + " AND  FAILREASON =  '" + reason + "'";
            }
            else if (id == 0 && reason != null)// check dup กรณี insert
            {
                sqlstr = sqlstr + " AND  FAILREASON =  '" + reason + "'";
            }


            IEnumerable<T> selectListItems = _unitOfWork.SQLRAW_Call.Listraw<T>(sqlstr, null);
            return (selectListItems.ToList());

        }


        public void UpdateFail(FailVM FAILVM)
        {
            var sqlstr = "UPDATE TBL_FAIL " +
                        " SET PROJECT_CODE=  '" + FAILVM.Fail.PROJECT_CODE + "'" +
                       " ,FAILREASON=  '" + FAILVM.Fail.FAILREASON + "'" +
                       " ,NEEDTERMINATE=  '" + FAILVM.Fail.NEEDTERMINATE + "'" +
                       "" +
                       "  WHERE FAILCODE  = '" + FAILVM.Fail.FAILCODE + "'";
            _unitOfWork.SQLRAW_Call.Execute(sqlstr, null);

        }


        public void InsertFail(FailVM FAILVM)
        {
            var sqlstr = "INSERT INTO  TBL_FAIL " +
                        " (PROJECT_CODE " +
                        " ,FAILREASON " +
                        " ,NEEDTERMINATE )" +
                        " VALUES" +
                        " (  '" + FAILVM.Fail.PROJECT_CODE + "'" +
                       " , '" + FAILVM.Fail.FAILREASON + "'" +
                       " ,  '" + FAILVM.Fail.NEEDTERMINATE + "')";
            _unitOfWork.SQLRAW_Call.Execute(sqlstr, null);

        }

        public void DeleteFail(int id)
        {
            var sqlstr = " DELETE  FROM  TBL_FAIL " +
                         " WHERE FAILCODE = '" + id + "' ";
            _unitOfWork.SQLRAW_Call.Execute(sqlstr, null);

        }














        /// Nontarget
        public List<T> SelectNonTargetReason<T>(int id, string reason)
        {
            var sqlstr = "SELECT   PROJECT_CODE " +
                        " ,NONTARGETCODE " +
                        " ,NONTARGETREASON " +
                        " FROM TBL_NONTARGET WITH(NOLOCK) " +
                        "  WHERE 0=0 ";

            if (id != 0 && reason == null) //return ไปหน้า upsert
            {
                sqlstr = sqlstr + " AND  NONTARGETCODE = " + id;
            }

            else if (id != 0 && reason != null) // check dup กรณี update
            {
                sqlstr = sqlstr + " AND  NONTARGETCODE <> " + id;
                sqlstr = sqlstr + " AND  NONTARGETREASON =  '" + reason + "'";
            }
            else if (id == 0 && reason != null)// check dup กรณี insert
            {
                sqlstr = sqlstr + " AND  NONTARGETREASON =  '" + reason + "'";
            }


            IEnumerable<T> selectListItems = _unitOfWork.SQLRAW_Call.Listraw<T>(sqlstr, null);
            return (selectListItems.ToList());

        }


        public void UpdateNonTarget(NonTargetVM NonTargetVM)
        {
            var sqlstr = "UPDATE TBL_NONTARGET " +
                        " SET PROJECT_CODE=  '" + NonTargetVM.NonTarget.PROJECT_CODE + "'" +
                       " ,NONTARGETREASON=  '" + NonTargetVM.NonTarget.NONTARGETREASON + "'" +
                       "  WHERE NONTARGETCODE  = '" + NonTargetVM.NonTarget.NONTARGETCODE + "'";
            _unitOfWork.SQLRAW_Call.Execute(sqlstr, null);

        }


        public void InsertNonTarget(NonTargetVM NonTargetVM)
        {
            var sqlstr = "INSERT INTO  TBL_NONTARGET " +
                        " (PROJECT_CODE " +
                        " ,NONTARGETREASON " +
                        " )" +
                        " VALUES" +
                        " (  '" + NonTargetVM.NonTarget.PROJECT_CODE + "'" +
                       " , '" + NonTargetVM.NonTarget.NONTARGETREASON + "'" +
                       " )";
            _unitOfWork.SQLRAW_Call.Execute(sqlstr, null);

        }

        public void DeleteNonTarget(int id)
        {
            var sqlstr = " DELETE  FROM  TBL_NONTARGET " +
                         " WHERE NONTARGETCODE = '" + id + "' ";
            _unitOfWork.SQLRAW_Call.Execute(sqlstr, null);

        }




        /// <summary>
        /// refuse
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="reason"></param>
        /// <returns></returns>




        /// Refuse
        public List<T> SelectRefuseReason<T>(int id, string reason)
        {
            var sqlstr = "SELECT   PROJECT_CODE " +
                        " ,REFUSECODE " +
                        " ,REFUSEREASON " +
                        " FROM TBL_REFUSE WITH(NOLOCK) " +
                        "  WHERE 0=0 ";

            if (id != 0 && reason == null) //return ไปหน้า upsert
            {
                sqlstr = sqlstr + " AND  REFUSECODE = " + id;
            }

            else if (id != 0 && reason != null) // check dup กรณี update
            {
                sqlstr = sqlstr + " AND  REFUSECODE <> " + id;
                sqlstr = sqlstr + " AND  REFUSEREASON =  '" + reason + "'";
            }
            else if (id == 0 && reason != null)// check dup กรณี insert
            {
                sqlstr = sqlstr + " AND  REFUSEREASON =  '" + reason + "'";
            }


            IEnumerable<T> selectListItems = _unitOfWork.SQLRAW_Call.Listraw<T>(sqlstr, null);
            return (selectListItems.ToList());

        }


        public void UpdateRefuse(RefuseVM RefuseVM)
        {
            var sqlstr = "UPDATE TBL_REFUSE " +
                        " SET PROJECT_CODE=  '" + RefuseVM.Refuse.PROJECT_CODE + "'" +
                       " ,REFUSEREASON=  '" + RefuseVM.Refuse.REFUSEREASON + "'" +
                       "  WHERE REFUSECODE  = '" + RefuseVM.Refuse.REFUSECODE + "'";
            _unitOfWork.SQLRAW_Call.Execute(sqlstr, null);

        }


        public void InsertRefuse(RefuseVM RefuseVM)
        {
            var sqlstr = "INSERT INTO  TBL_REFUSE " +
                        " (PROJECT_CODE " +
                        " ,REFUSEREASON " +
                        " )" +
                        " VALUES" +
                        " (  '" + RefuseVM.Refuse.PROJECT_CODE + "'" +
                       " , '" + RefuseVM.Refuse.REFUSEREASON + "'" +
                       " )";
            _unitOfWork.SQLRAW_Call.Execute(sqlstr, null);

        }

        public void DeleteRefuse(int id)
        {
            var sqlstr = " DELETE  FROM  TBL_REFUSE " +
                         " WHERE REFUSECODE = '" + id + "' ";
            _unitOfWork.SQLRAW_Call.Execute(sqlstr, null);

        }











        /// Success
        public List<T> SelectSuccessReason<T>(int id, string reason)
        {
            var sqlstr = "SELECT   PROJECT_CODE " +
                        " ,SUCCESSCODE " +
                        " ,SUCCESSREASON " +
                        " FROM TBL_SUCCESS WITH(NOLOCK) " +
                        "  WHERE 0=0 ";

            if (id != 0 && reason == null) //return ไปหน้า upsert
            {
                sqlstr = sqlstr + " AND  SUCCESSCODE = " + id;
            }

            else if (id != 0 && reason != null) // check dup กรณี update
            {
                sqlstr = sqlstr + " AND  SUCCESSCODE <> " + id;
                sqlstr = sqlstr + " AND  SUCCESSREASON =  '" + reason + "'";
            }
            else if (id == 0 && reason != null)// check dup กรณี insert
            {
                sqlstr = sqlstr + " AND  SUCCESSREASON =  '" + reason + "'";
            }


            IEnumerable<T> selectListItems = _unitOfWork.SQLRAW_Call.Listraw<T>(sqlstr, null);
            return (selectListItems.ToList());

        }


        public void UpdateSuccess(SuccessVM SuccessVM)
        {
            var sqlstr = "UPDATE TBL_SUCCESS " +
                        " SET PROJECT_CODE=  '" + SuccessVM.Success.PROJECT_CODE + "'" +
                       " ,SUCCESSREASON=  '" + SuccessVM.Success.SUCCESSREASON + "'" +
                       "  WHERE SUCCESSCODE  = '" + SuccessVM.Success.SUCCESSCODE + "'";
            _unitOfWork.SQLRAW_Call.Execute(sqlstr, null);

        }


        public void InsertSuccess(SuccessVM SuccessVM)
        {
            var sqlstr = "INSERT INTO  TBL_SUCCESS " +
                        " (PROJECT_CODE " +
                        " ,SUCCESSREASON " +
                        " )" +
                        " VALUES" +
                        " (  '" + SuccessVM.Success.PROJECT_CODE + "'" +
                       " , '" + SuccessVM.Success.SUCCESSREASON + "'" +
                       " )";
            _unitOfWork.SQLRAW_Call.Execute(sqlstr, null);

        }

        public void DeleteSuccess(int id)
        {
            var sqlstr = " DELETE  FROM  TBL_SUCCESS " +
                         " WHERE SUCCESSCODE = '" + id + "' ";
            _unitOfWork.SQLRAW_Call.Execute(sqlstr, null);

        }

    }
}
