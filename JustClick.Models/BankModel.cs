using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
namespace JustClick.Models
{
    public class BankModel
    {


        [JsonProperty ("project_code")]
        [Display(Name = "Project Code")]
        [Required]
        [MaxLength(10)]
        public string PROJECT_CODE { get; set; }


        [Key]
        [JsonProperty("urn")]
        public int URN { get; set; }




        [Display(Name = "Bank name")]
        [Required]
        [MaxLength(50)]
        [JsonProperty("bankname")]
        public string BANKNAME { get; set; }
    }
}
