using Dapper;
using JustClick.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustClick.Infrastructure
{ 
   public interface IReasonFunction : IDisposable
    {
 
        List<T> SelectCallbackReason<T>(int id, string reason);
        void Updatecallback(CallbackVM CallbackVM);
        void InsertCallback(CallbackVM CallbackVM);
        void DeleteCallback(int id);



        List<T> SelectFailReason<T>(int id, string reason);
        void UpdateFail(FailVM FailVM);
        void InsertFail(FailVM FailVM);
        void DeleteFail(int id);



        List<T> SelectNonTargetReason<T>(int id, string reason);
        void UpdateNonTarget(NonTargetVM NonTargetVM);
        void InsertNonTarget(NonTargetVM NonTargetVM);
        void DeleteNonTarget(int id);








        List<T> SelectRefuseReason<T>(int id, string reason);
        void UpdateRefuse(RefuseVM RefuseVM);
        void InsertRefuse(RefuseVM RefuseVM);
        void DeleteRefuse(int id);





        List<T> SelectSuccessReason<T>(int id, string reason);
        void UpdateSuccess(SuccessVM SuccessVM);
        void InsertSuccess(SuccessVM SuccessVM);
        void DeleteSuccess(int id);


    }
}
