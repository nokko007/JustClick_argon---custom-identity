using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JustClick.Models.ViewModels
{
    public class DashboardDailysalebyTSRVM
    {
        //public string TSR { get; set; }

        public string Id { get; set; }


        public string tsr { get; set; }

        public string tsr_picture { get; set; }

        public string sales { get; set; }
        public string newsales { get; set; }
        public string renewsales { get; set; }

        public string bounce { get; set; }
        public string tsr_loginname { get; set; }
        public int rank_no { get; set; }



    }
}
