using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JustClick.Models.ViewModels
{
    public class DashboardGraphWeeklyVM

    {

     

        public string tsr { get; set; }

        public string Id { get; set; }


        public string ddate { get; set; }
        public int sales { get; set; }
        public int newsales { get; set; }

        public int renewsales { get; set; }

        public int totalsales { get; set; }
        //public string today4 { get; set; }
        //public string today3 { get; set; }
        //public string today2 { get; set; }
        //public string today1 { get; set; }
        //public string today { get; set; }

    }
}
