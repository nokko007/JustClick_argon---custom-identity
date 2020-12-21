using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
namespace JustClick.Models
{
    public class CallbackModel
    {

        [Key]
        [JsonProperty("callbackcode")]
        public int CALLBACKCODE { get; set; }



        [JsonProperty("project_code")]
        [Display(Name = "Project Code")]
        [Required]
        [MaxLength(10)]
        public string PROJECT_CODE { get; set; }

        [Display(Name = "Callback Reason")]
        [Required]
        [MaxLength(50)]
        [JsonProperty("callbackreason")]
        public string CALLBACKREASON { get; set; }


        [Display(Name = "Terminate Record")]
        [Required]
        [MaxLength(3)]
        [JsonProperty("needterminate")]
        public string NEEDTERMINATE { get; set; }

    }
}
