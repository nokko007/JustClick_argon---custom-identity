using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
namespace JustClick.Models
{
    public class ScriptModel
    {
        [Key]
        [JsonProperty("scriptid")]
        public int SCRIPTID { get; set; }



        [JsonProperty ("project_code")]
        [Display(Name = "Project Code")]
        [Required]
        [MaxLength(10)]
        public string PROJECT_CODE { get; set; }

        [Display(Name = "หัวข้อ  Script")]
        [Required]
        [MaxLength(100)]
        [JsonProperty("scriptheader")]
        public string SCRIPTHEADER { get; set; }
		
		
		[Display(Name = "Script")]
        [Required]
        [MaxLength(2000)]
        [JsonProperty("scriptdesc")]
        public string SCRIPTDESC { get; set; }
		
		
		
    }
}
