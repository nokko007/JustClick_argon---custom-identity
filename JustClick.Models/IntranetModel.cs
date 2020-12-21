using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
namespace JustClick.Models
{
    public class IntranetModel
    {
        [Key]
        [JsonProperty("intranet_id")]
        public int INTRANET_ID { get; set; }



        [JsonProperty ("project_code")]
        [Display(Name = "Project Code")]
        [Required]
        [MaxLength(10)]
        public string PROJECT_CODE { get; set; }

        [Display(Name = "หัวข้อ  Intranet")]
        [Required]
        [MaxLength(100)]
        [JsonProperty("intranet_header")]
        public string  INTRANET_HEADER { get; set; }
		
		
		[Display(Name = "Link/url")]
        [Required]
        [MaxLength(150)]
        [JsonProperty("intranet_url")]
        public string INTRANET_URL { get; set; }
		
		
		
    }
}
