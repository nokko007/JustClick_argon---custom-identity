using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
namespace JustClick.Models.ViewModels
{
    public class ProjectConfigVM
    {
      
        public IEnumerable<ProjectConfigModel> PROJECT_CODE_LIST { get; set; }

    }
}
