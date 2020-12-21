using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace JustClick.Models.Identity
{
 [NotMapped]
    public class ApplicationUser : IdentityUser

    {

        [JsonProperty("ext")]
        public string EXT { get; set; }

        [JsonProperty("title_thai")]
        public string TITLE_THAI { get; set; }

        [JsonProperty("fname_thai")]
        public string FNAME_THAI { get; set; }

        [JsonProperty("lname_thai")]
        public string LNAME_THAI { get; set; }

        [JsonProperty("accessstatus")]
        public bool ACCESSSTATUS { get; set; }

        //
        [JsonProperty("tsr_picture")]
        public string TSR_PICTURE { get; set; }



        [JsonProperty("license")]
        public string LICENSE { get; set; }

        [JsonProperty("teamleader_id")]
        public string TEAMLEADER_ID { get; set; }

        [JsonProperty("project_code")]
         public string  PROJECT_CODE { get; set; }




        [NotMapped]
        public string RoleNames { get; set; }

    }
}
