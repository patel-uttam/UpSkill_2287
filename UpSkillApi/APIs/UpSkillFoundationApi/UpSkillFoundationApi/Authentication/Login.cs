using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace UpSkillFoundationApi.Models
{
    public class LoginCredential
    {
        [Required(ErrorMessage ="Username required")]
        [MinLength(5)]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Password required")]
        public string Password { get; set; }
    }
}
