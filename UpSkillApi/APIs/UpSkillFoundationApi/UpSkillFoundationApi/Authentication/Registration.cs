using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UpSkillFoundationApi.Authentication
{
    public class Registration
    {
        [Required(ErrorMessage ="username required for registration")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "password required for new user registration")]
        public string Password { get; set; }
        [Required(ErrorMessage = "password confirmation must!!")]
        public string ConfirmPassword { get; set; }
    }
}
