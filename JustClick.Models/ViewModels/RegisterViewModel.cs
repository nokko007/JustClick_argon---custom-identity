using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JustClick.Models.ViewModels
{
    public class RegisterViewModel
    {

        public IEnumerable<SelectListItem> PROJECT_CODE_LIST { get; set; }

        [JsonProperty("project_code")]
        [MaxLength(10)]
        [Required]
        [Display(Name = "Project Code")]
        public string PROJECT_CODE { get; set; }




        public IEnumerable<SelectListItem> ROLE_LIST { get; set; }




        [JsonProperty("role")]
        [MaxLength(20)]
        [Required]
        [Display(Name = "Role")]
        public string ROLE { get; set; }


        public IEnumerable<SelectListItem> TITLE_LIST { get; set; }




        [JsonProperty("title_thai")]
        [MaxLength(10)]
        [Required]
        [Display(Name = "คำนำหน้าชือ")]
        public string TITLE_THAI { get; set; }



        public IEnumerable<SelectListItem> TEAMLEADER_LIST { get; set; }

        [JsonProperty("teamleader_id")]
        [MaxLength(450)]
        [Display(Name = "หัวหน้าทีม")]
        public string TEAMLEADER_ID { get; set; }

     
        public string TEAMLEADER_NAME { get; set; }




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


        [JsonProperty("accessstatus")]
        [Display(Name = "เข้าระบบ(ได้/ไม่ได้)")]
        public bool ACCESSSTATUS { get; set; }

        [Required]
        [MaxLength(30)]
    
        public string UserName { get; set; }


   
    
        public string Id { get; set; }
    //
        [JsonProperty("tsr_picture")]
        [MaxLength(255)]
        [Display(Name = "Picture")]
        public string TSR_PICTURE { get; set; }



        [JsonProperty("license")]
        [MaxLength(10)]
        [Display(Name = "License Code")]
        public string LICENSE { get; set; }

      

           



    }
}