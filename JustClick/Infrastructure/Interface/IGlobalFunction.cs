using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustClick.Infrastructure
{ 
   public interface IGlobalFunction : IDisposable
    {
        string Getdatetime();



        void UpdateAgentmonitoring(string loginname, string screen, string startcalltime, string cust);
         void InsertLogin(string loginname, string role,  string ext, string project_code);

        void Logout(string loginname);


    }
}
