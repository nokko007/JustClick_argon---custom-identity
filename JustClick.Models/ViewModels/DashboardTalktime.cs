using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JustClick.Models.ViewModels
{
    public class DashboardTalktime
    {
 

        public string NOTSR { get; set; }
        public string OUTCALL { get; set; }
        public string SALECALL { get; set; }
        public string AVGCALL { get; set; }
        public string MAXCALL { get; set; }
        public string MINCALL { get; set; }

    }
}
