using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
namespace JustClick.Models
{
    public class NonTargetModel
    {

        [Key]
        [JsonProperty("nontargetcode")]
        public int NONTARGETCODE { get; set; }



        [JsonProperty("project_code")]
        [Display(Name = "Project Code")]
        [Required]
        [MaxLength(10)]
        public string PROJECT_CODE { get; set; }

        [Display(Name = "Non Target Reason")]
        [Required]
        [MaxLength(50)]
        [JsonProperty("nontargetreason")]
        public string NONTARGETREASON { get; set; }
    }
}
