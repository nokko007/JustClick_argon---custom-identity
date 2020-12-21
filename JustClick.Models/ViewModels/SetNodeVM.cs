using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JustClick.Models.ViewModels
{
    public class SetNodeVM
    {



        public string TSR_LOGINNAME { get; set; }
        public string NEWCALLCNT { get; set; }
        public string CALLBACKCNT { get; set; }
        public string NOCONTACTCNT { get; set; }
        public string FOLLOWUPCNT { get; set; }
        public string FOLLOWDOCCNT { get; set; }
        public string FOLLOWPAYCNT { get; set; }
        public string REDETAILCNT { get; set; }







    }
}
