using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JustClick.Models.ViewModels
{
    public class IntranetVM
    {
        public IntranetModel Intranet { get; set; }
        public IEnumerable<SelectListItem> PROJECT_CODE_LIST { get; set; }

    }
}
