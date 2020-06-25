using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
namespace JustClick.Models
{
    public class ProjectConfigModel
    {
        [Key]
        [JsonProperty("urn")]
        [Display(Name = "URN")]
        public int URN { get; set; }

        [JsonProperty("project_code")]
        [MaxLength(10)]
        [Required]
        [Display(Name = "PROJECT CODE")]
        public string PROJECT_CODE { get; set; }

        [JsonProperty("project_name")]

        [Required]
        [Display(Name = "ชื่อโครงการ")]
        public string PROJECT_NAME { get; set; }

        [JsonProperty("owner")]
        [Required]
        [Display(Name = "OWNER")]
        public string OWNER { get; set; }

        [JsonProperty("script_1")]
        [Required]
        [Display(Name = "บทเปิดตัว")]
       
        public string SCRIPT_1 { get; set; }

        [JsonProperty("script_2")]
        [Required]
        [Display(Name = "ลูกค้าไม่อยู่/ไม่สะดวกคุย")]
        public string SCRIPT_2 { get; set; }

        [JsonProperty("script_3")]

        [Required]
        [Display(Name = "ลูกค้าไม่สนใจ")]
        public string SCRIPT_3 { get; set; }

        [JsonProperty("script_4")]
        [Required]
        [Display(Name = "Legal (บัตรเครดิต/รายปี)")]
        public string SCRIPT_4 { get; set; }

        [JsonProperty("script_5")]
        [Required]
        [Display(Name = "Legal (บัตรเครดิต/ราย 4 เดือน)")]
        public string SCRIPT_5 { get; set; }

        [JsonProperty("script_6")]
        [Required]
        [Display(Name = "Legal (โอนเงิน/รายปี)")]
        public string SCRIPT_6 { get; set; }

        [JsonProperty("script_7")]
        [Required]
        [Display(Name = "Legal (บัตรเครดิต/ราย 6 เดือน")]
        public string SCRIPT_7 { get; set; }

        [JsonProperty("script_8")]
        [Required]
        [Display(Name = "Legal (โอนเงิน/ราย 4 เดือน)")]
        public string SCRIPT_8 { get; set; }

        [JsonProperty("script_9")]
        [Required]
        [Display(Name = "Legal (โอนเงิน/ราย 6 เดือน)")]
        public string SCRIPT_9 { get; set; }

        [JsonProperty("script_10")]
        [Required]
        [Display(Name = "(บัตรเครดิต/ราย 12 เดือน)")]
        public string SCRIPT_10 { get; set; }

        [JsonProperty("warningcall")]
        [Required]
        [Display(Name = "WARNINGCALL")]
        public int WARNINGCALL { get; set; }

        [JsonProperty("maxcall")]
        [Required]
        [Display(Name = "MAXCALL")]
        public int MAXCALL { get; set; }

        [JsonProperty("maxcallback")]
        [Required]
        [Display(Name = "MAXCALLBACK")]
        public int MAXCALLBACK { get; set; }

        [JsonProperty("endofproject")]
        [Required]
        [Display(Name = "ENDOFPROJECT")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        public DateTime? ENDOFPROJECT { get; set; }


        //[JsonProperty("dcrs")]
        //[MaxLength(200)]
        //[Required]
        //[Display(Name = "DCRS")]
        //public string DCRS { get; set; }

        [JsonProperty("pathreport")]
        [MaxLength(200)]
        [Required]
        [Display(Name = "PATHREPORT")]
        public string PATHREPORT { get; set; }

        [JsonProperty("maxnocontact")]
        [Required]
        [Display(Name = "MAXNOCONTACT")]
        public int MAXNOCONTACT { get; set; }

        [JsonProperty("pbxip")]
        [MaxLength(40)]
        [Required]
        [Display(Name = "PBXIP")]
        public string PBXIP { get; set; }

        [JsonProperty("sp_status")]
        [MaxLength(2)]
        [Required]
        [Display(Name = "API Call Status")]
        public string SP_STATUS { get; set; }


}
}
