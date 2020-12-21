using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JustClick.Models.ViewModels
{
    public class DashboardMTDPerformanceVM

    {

     

        public string tsr { get; set; }

      
        public int salesubmit { get; set; }
        public int approved { get; set; }

        public int notapproved { get; set; }

      
    }
} 
