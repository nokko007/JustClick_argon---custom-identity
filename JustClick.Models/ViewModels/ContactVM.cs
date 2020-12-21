using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JustClick.Models.ViewModels
{
    public class ContactVM
    {


        [Key]
        [Display(Name = "CUSTID")]

        public int CUSTID { get; set; }

         


        [Display(Name = "THAI_TITLE")]
        [MaxLength(50)]
        public string THAI_TITLE { get; set; }


        [Display(Name = "THAI_NAME")]
        [MaxLength(50)]
        public string THAI_NAME { get; set; }


        [Display(Name = "THAI_SURNAME")]
        [MaxLength(50)]
        public string THAI_SURNAME { get; set; }


       

        [Display(Name = "TSR_LOGINNAME")]
        [MaxLength(50)]
        public string TSR_LOGINNAME { get; set; }


        [Display(Name = "CALLTIMETAG")]

        public DateTime CALLTIMETAG { get; set; }


        [Display(Name = "NUMBEROFCALL")]

        public int NUMBEROFCALL { get; set; }

    }
}
