using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JustClick.Models.ViewModels
{
    public class GetdatetimeVM
    {
        public string GETDATETIME { get; set; }

        public string LOGINNAME { get; set; }
    }
}
