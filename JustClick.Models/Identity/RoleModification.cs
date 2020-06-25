using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JustClick.Models.Identity
{
    public class RoleModification
    {
     

        public IEnumerable<SelectListItem> Role_list { get; set; }

        [Required]
        public string RoleName { get; set; }
        public string RoleId { get; set; }

    }
}
