using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace JustClick.Models.ViewModels
{
    public class DataImportViewModel


    {

        public string TOTALINDATABASE { get; set; }

        public string TRANSFERDATA { get; set; }

        public string FREEDATA { get; set; }

        public string FTPus { get; set; }

        public string FTP_TYPE { get; set; }

        public string FTP_IP{ get; set; }

        public string FTP_UID { get; set; }

        public string FTP_PW { get; set; }

        public string FTP_PATH { get; set; }

        public string FTP_ACTION { get; set; }

        public string FTP_FINGERPRINT { get; set; }




        //[Display(Name = "Free Data")]
        //[Range(1, Int32.MaxValue, ErrorMessage = "Data ต้องมีจำนวนมากกว่า 0")]
        //[Required(ErrorMessage =   "Please click search data")]
        //public int FREEDATABYCRITERIA { get; set; }

        //public IEnumerable<SelectListItem> PROJECT_CODE_LIST { get; set; }

        ////[JsonProperty("project_code")]
        //[MaxLength(10)]
        //[Required]
        //[Display(Name = "Project Code")]
        //public string PROJECT_CODE { get; set; }

        //public IEnumerable<SelectListItem> SOURCE_LIST { get; set; }


        //[JsonProperty("source")]
        //[Required]
        //[Display(Name = "Data Source")]
        //public string SOURCE { get; set; }





        //public IEnumerable<SelectListItem> TSR_LIST { get; set; }

        ////[JsonProperty("project_code")]
        ////[MaxLength(10)]
        ////[Required]
        ////[Display(Name = "Project Code")]
        //public string TSR_LOGINNAME { get; set; }


        //public string NEWCALL { get; set; }

        //[Required]
        //[Range(1, 1000, ErrorMessage = "Data ต้องมีจำนวนมากกว่า 0")]
        //[Display(Name = "จำนวน list ต่อ TSR 1 คน")]
        //public int RECTOTSR { get; set; }


        //[Required(ErrorMessage = "ยังไม่ได้เลือกชื่อ TSR ที่ต้องการ")]

        //public string TSR_SELECTEDLIST { get; set; }

    }
}