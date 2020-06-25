using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JustClick.Models
{
    public class RoleLeaderModel
    {

        public IEnumerable<SelectListItem> ROLELEADER_LIST { get; set; }



        [Key]
        [JsonProperty("id")]
        public string ID { get; set; }



        [JsonProperty("teamleader_name")]
       
        public string TEAMLEADER_NAME { get; set; }

        [JsonProperty("rolename")]
       
        public string ROLENAME { get; set; }


    }
}
