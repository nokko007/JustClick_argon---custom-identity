using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JustClick.Models
{
    public class LoginModel
    {

        [Key]
        public int NONTARGETCODE { get; set; }


        //[Display(Name = "Project Code")]
        //[Required]
        //[MaxLength(10)]
        public string PROJECT_CODE { get; set; }

        [Display(Name = "Non Target Reason")]
        [Required]
        [MaxLength(100)]
        public string NONTARGETREASON { get; set; }
    }
}
