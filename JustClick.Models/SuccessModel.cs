using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
namespace JustClick.Models
{
    public class SuccessModel
    {

        [Key]
        [JsonProperty("successcode")]
        public int SUCCESSCODE { get; set; }



        [JsonProperty("project_code")]
        [Display(Name = "Project Code")]
        [Required]
        [MaxLength(10)]
        public string PROJECT_CODE { get; set; }

        [Display(Name = "Success Reason")]
        [Required]
        [MaxLength(50)]
        [JsonProperty("successreason")]
        public string SUCCESSREASON { get; set; }
    }
}
