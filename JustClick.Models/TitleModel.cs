using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustClick.Models
{
    public class TitleModel
    {
    
        [Key]
        [JsonProperty("id")]
        public int ID { get; set; }


        public string TITLE_THAI { get; set; }
        public string TITLE_ENG { get; set; }
        public int SEQ { get; set; }
    }
}
