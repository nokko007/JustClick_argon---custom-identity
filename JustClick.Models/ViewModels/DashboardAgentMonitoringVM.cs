using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JustClick.Models.ViewModels
{
    public class DashboardAgentMonitoringVM
    {
        //public string TSR { get; set; }

        public string Id { get; set; }


        public string tsr { get; set; }

        public string tsr_picture { get; set; }

        public string STARTCALLTIME { get; set; }
        public string TALKTIME { get; set; }
        public string SCREEN { get; set; }
        public string CUSTOMER { get; set; }
        public string PROJECT { get; set; }

        public string LASTLOGOUT { get; set; }

    }
}
