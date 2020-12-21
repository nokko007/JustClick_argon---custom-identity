using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace JustClick.Models
{
    public class testModel
    {

        public IFormFile TSR_IMAGE { get; set; }
    }
}
