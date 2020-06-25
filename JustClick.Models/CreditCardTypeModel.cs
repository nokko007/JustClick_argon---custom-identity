using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
namespace JustClick.Models
{
    public class CreditCardTypeModel
    {
        [Key]
        [JsonProperty("cardcode")]
        public int CARDCODE { get; set; }



        [JsonProperty ("project_code")]
        [Display(Name = "Project Code")]
        [Required]
        [MaxLength(10)]
        public string PROJECT_CODE { get; set; }

        [Display(Name = "Credit Card Type")]
        [Required]
        [MaxLength(50)]
        [JsonProperty("cardtype")]
        public string CARDTYPE { get; set; }
    }
}
