using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
namespace JustClick.Models
{
    public class FailModel
    {

        [Key]
        [JsonProperty("failcode")]
        public int FAILCODE { get; set; }



        [JsonProperty("project_code")]
        [Display(Name = "Project Code")]
        [Required]
        [MaxLength(10)]
        public string PROJECT_CODE { get; set; }

        [Display(Name = "Fail Reason")]
        [Required]
        [MaxLength(50)]
        [JsonProperty("failreason")]
        public string FAILREASON { get; set; }


        [Display(Name = "Terminate Record")]
        [Required]
        [MaxLength(3)]
        [JsonProperty("needterminate")]
        public string NEEDTERMINATE { get; set; }

    }
}
