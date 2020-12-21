using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
namespace JustClick.Models
{
    public class RefuseModel
    {

        [Key]
        [JsonProperty("refusecode")]
        public int REFUSECODE { get; set; }



        [JsonProperty("project_code")]
        [Display(Name = "Project Code")]
        [Required]
        [MaxLength(10)]
        public string PROJECT_CODE { get; set; }

        [Display(Name = "refuse Reason")]
        [Required]
        [MaxLength(50)]
        [JsonProperty("refusereason")]
        public string REFUSEREASON { get; set; }
    }
}
