using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JustClick.Models.ViewModels
{
    public class DashboardMTDdetail
    {
 

        public string STARTDATE { get; set; }
        public string ENDDATE { get; set; }
        public string WORKINGDAY { get; set; }
        public string MONTHLABEL { get; set; }

    }
}
