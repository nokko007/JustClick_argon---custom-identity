using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JustClick.Models.ViewModels
{
    public class DashboardRetention
    {
 

        public string SOURCE { get; set; }
        public int LOADED { get; set; }
        public int LOADED_PREMIUM { get; set; }
        public int SUCCESS { get; set; }
        public int SUCCESS_PREMIUM { get; set; }
        public string RETENTIONPERCENT{ get; set; }



    }
}
