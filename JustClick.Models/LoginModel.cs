using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
namespace JustClick.Models
{
    public class LoginModel
    {
        [Key]
        [JsonProperty("officer_id")]

        [Required]
        [Display(Name = "OFFICER ID")]
        public int OFFICER_ID { get; set; }


        [JsonProperty("loginname")]
        [MaxLength(50)]
        [Required]
        [Display(Name = "LOGINNAME")]
        public string LOGINNAME { get; set; }


        [JsonProperty("title_thai")]
        [MaxLength(10)]
        [Required]
        [Display(Name = "คำนำหน้าชือ")]
        public string TITLE_THAI { get; set; }

        [JsonProperty("fname_thai")]
        [MaxLength(30)]
        [Required]
        [Display(Name = "ชื่อ")]
        public string FNAME_THAI { get; set; }


        [JsonProperty("lname_thai")]
        [MaxLength(50)]
        [Required]
        [Display(Name = "นามสกุล")]
        public string LNAME_THAI { get; set; }

        [JsonProperty("nickname")]
        [MaxLength(20)]
        [Required]
        [Display(Name = "ชื่อเล่น")]
        public string NICKNAME { get; set; }

        [JsonProperty("title_eng")]
        [MaxLength(10)]
        [Required]
        [Display(Name = "Title")]
        public string TITLE_ENG { get; set; }
        

        [JsonProperty("fname_eng")]
        [MaxLength(30)]
        [Required]
        [Display(Name = "Name")]
        public string FNAME_ENG { get; set; }


        [JsonProperty("lname_eng")]
        [MaxLength(50)]
        [Required]
        [Display(Name = "Surname")]
        public string LNAME_ENG { get; set; }


       
        /*
        [JsonProperty("password")]
        [MaxLength(16)]
        [Required]
        [Display(Name = "PASSWORD")]
        public string PASSWORD { get; set; }
        */


        [JsonProperty("level_id")]
        [MaxLength(50)]
        [Required]
        [Display(Name = "LEVEL_ID")]
        public string LEVEL_ID { get; set; }


        [JsonProperty("teamleader_id")]
        [MaxLength(50)]
        [Required]
        [Display(Name = "TEAMLEADER_ID")]
        public string TEAMLEADER_ID { get; set; }


        [JsonProperty("startdate")]

        [Required]
        [Display(Name = "วันที่เริ่มงาน")]
        public string STARTDATE { get; set; }


        [JsonProperty("stopdate")]

        [Required]
        [Display(Name = "วันที่สิ้นสุด")]
        public string STOPDATE { get; set; }


        [JsonProperty("accessstatus")]

        [Required]
        [Display(Name = "สถานะการเข้าระบบ")]
        public string ACCESSSTATUS { get; set; }


        [JsonProperty("project_code")]
        [MaxLength(10)]
        [Required]
        [Display(Name = "PROJECT_CODE")]
        public string PROJECT_CODE { get; set; }


        [JsonProperty("tsr_picture")]
        [MaxLength(100)]
        [Required]
        [Display(Name = "TSR_PICTURE")]
        public string TSR_PICTURE { get; set; }


        [JsonProperty("lastcallid")]
        [MaxLength(10)]
        [Required]
        [Display(Name = "LASTCALLID")]
        public string LASTCALLID { get; set; }


        [JsonProperty("ext")]
        [MaxLength(10)]
        [Required]
        [Display(Name = "EXT")]
        public string EXT { get; set; }


        [JsonProperty("tier")]
        [MaxLength(10)]
        [Required]
        [Display(Name = "TIER")]
        public string TIER { get; set; }


        [JsonProperty("superman")]
        [MaxLength(10)]
        [Required]
        [Display(Name = "SUPERMAN")]
        public string SUPERMAN { get; set; }


        [JsonProperty("license")]
        [MaxLength(10)]
        [Required]
        [Display(Name = "LICENSE")]
        public string LICENSE { get; set; }



    }
}
