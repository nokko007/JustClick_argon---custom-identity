using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
namespace JustClick.Models
{
    public class IDCardTypeModel
    {


        [JsonProperty ("project_code")]
        [Display(Name = "Project Code")]
        [Required]
        [MaxLength(10)]
        public string PROJECT_CODE { get; set; }


        [Key]
        [JsonProperty("idcard_id")]
        public int IDCARD_ID { get; set; }




        [Display(Name = "ID Card name")]
        [Required]
        [MaxLength(50)]
        [JsonProperty("idcard_name")]
        public string IDCARD_NAME { get; set; }
    }
}
