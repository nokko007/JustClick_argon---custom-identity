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
        [Required]
        public string TEXTENDDATE { get; set; }

        public ProjectConfigModel projectConfigModel { get; set; }

    }
}
