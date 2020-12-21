using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JustClick.Models
{
    public class ContactModel
    {

        [Key]
        [Display(Name = "CUSTID")]

        public int CUSTID { get; set; }


        //[Display(Name = "PROJECT_CODE")]
        //[MaxLength(10)]
        //public string PROJECT_CODE { get; set; }


        //[Display(Name = "ORG_ID")]
        //[MaxLength(50)]
        //public string ORG_ID { get; set; }


        [Display(Name = "THAI_TITLE")]
        [MaxLength(50)]
        public string THAI_TITLE { get; set; }


        [Display(Name = "THAI_NAME")]
        [MaxLength(50)]
        public string THAI_NAME { get; set; }


        [Display(Name = "THAI_SURNAME")]
        [MaxLength(50)]
        public string THAI_SURNAME { get; set; }


        //[Display(Name = "ENG_TITLE")]
        //[MaxLength(50)]
        //public string ENG_TITLE { get; set; }


        //[Display(Name = "ENG_NAME")]
        //[MaxLength(50)]
        //public string ENG_NAME { get; set; }


        //[Display(Name = "ENG_SURNAME")]
        //[MaxLength(50)]
        //public string ENG_SURNAME { get; set; }


        //[Display(Name = "BIRTHDATE")]

        //public DateTime BIRTHDATE { get; set; }



        //[Display(Name = "AGE")]

        //public int AGE { get; set; }


        //[Display(Name = "SEX")]
        //[MaxLength(50)]
        //public string SEX { get; set; }


        //[Display(Name = "SALARY")]
        //[MaxLength(50)]
        //public string SALARY { get; set; }


        //[Display(Name = "HOME_TELNO")]
        //[MaxLength(100)]
        //public string HOME_TELNO { get; set; }


        //[Display(Name = "HOME_EXT")]
        //[MaxLength(50)]
        //public string HOME_EXT { get; set; }


        //[Display(Name = "OFFICE_TELNO")]
        //[MaxLength(100)]
        //public string OFFICE_TELNO { get; set; }


        //[Display(Name = "OFFICE_EXT")]
        //[MaxLength(50)]
        //public string OFFICE_EXT { get; set; }


        //[Display(Name = "MOBILE_TELNO")]
        //[MaxLength(100)]
        //public string MOBILE_TELNO { get; set; }


        //[Display(Name = "FAX_NO")]
        //[MaxLength(50)]
        //public string FAX_NO { get; set; }


        //[Display(Name = "EMAIL")]
        //[MaxLength(50)]
        //public string EMAIL { get; set; }


        //[Display(Name = "HOME_ID")]
        //[MaxLength(250)]
        //public string HOME_ID { get; set; }


        //[Display(Name = "BUILDING")]
        //[MaxLength(100)]
        //public string BUILDING { get; set; }


        //[Display(Name = "FLOOR")]
        //[MaxLength(50)]
        //public string FLOOR { get; set; }


        //[Display(Name = "ROOM_NO")]
        //[MaxLength(50)]
        //public string ROOM_NO { get; set; }


        //[Display(Name = "MOU_BANN")]
        //[MaxLength(100)]
        //public string MOU_BANN { get; set; }


        //[Display(Name = "MOU")]
        //[MaxLength(50)]
        //public string MOU { get; set; }


        //[Display(Name = "SOI")]
        //[MaxLength(100)]
        //public string SOI { get; set; }


        //[Display(Name = "STREET")]
        //[MaxLength(250)]
        //public string STREET { get; set; }


        //[Display(Name = "TUMBOL")]
        //[MaxLength(250)]
        //public string TUMBOL { get; set; }


        //[Display(Name = "AMPER")]
        //[MaxLength(250)]
        //public string AMPER { get; set; }


        //[Display(Name = "PROVINCE")]
        //[MaxLength(50)]
        //public string PROVINCE { get; set; }


        //[Display(Name = "POSTCODE")]
        //[MaxLength(50)]
        //public string POSTCODE { get; set; }


        //[Display(Name = "SEGMENT")]
        //[MaxLength(50)]
        //public string SEGMENT { get; set; }


        //[Display(Name = "MARITALSTATUS")]
        //[MaxLength(50)]
        //public string MARITALSTATUS { get; set; }


        //[Display(Name = "SOURCE")]
        //[MaxLength(50)]
        //public string SOURCE { get; set; }


        //[Display(Name = "SETUP")]
        //[MaxLength(1)]
        //public string SETUP { get; set; }


        [Display(Name = "TSR_LOGINNAME")]
        [MaxLength(50)]
        public string TSR_LOGINNAME { get; set; }


        //[Display(Name = "PREVIOUSCALLSTATUS")]
        //[MaxLength(20)]
        //public string PREVIOUSCALLSTATUS { get; set; }


        //[Display(Name = "CALLSTATUS")]
        //[MaxLength(20)]
        //public string CALLSTATUS { get; set; }

        //[Display(Name = "STATUSREASON")]
        //[MaxLength(250)]
        //public string STATUSREASON { get; set; }


        [Display(Name = "CALLTIMETAG")]

        public DateTime CALLTIMETAG { get; set; }


        [Display(Name = "NUMBEROFCALL")]

        public int NUMBEROFCALL { get; set; }

        //[Display(Name = "OCCUPATION")]
        //[MaxLength(50)]
        //public string OCCUPATION { get; set; }


        //[Display(Name = "NUMCHILD")]

        //public int NUMCHILD { get; set; }


        //[Display(Name = "DATAFORCUST")]
        //[MaxLength(10)]
        //public string DATAFORCUST { get; set; }


        //[Display(Name = "MEMBERCARD")]
        //[MaxLength(10)]
        //public string MEMBERCARD { get; set; }


        //[Display(Name = "ISSUEDBANK")]
        //[MaxLength(50)]
        //public string ISSUEDBANK { get; set; }


        //[Display(Name = "CARDTYPE")]
        //[MaxLength(50)]
        //public string CARDTYPE { get; set; }


        //[Display(Name = "USE_CAR")]
        //[MaxLength(50)]
        //public string USE_CAR { get; set; }


        //[Display(Name = "MEMBERCREDIT")]
        //[MaxLength(50)]
        //public string MEMBERCREDIT { get; set; }


        //[Display(Name = "MEMBERBANK")]
        //[MaxLength(50)]
        //public string MEMBERBANK { get; set; }


        //[Display(Name = "MEMBERMAKE")]
        //[MaxLength(50)]
        //public string MEMBERMAKE { get; set; }



    }
}
