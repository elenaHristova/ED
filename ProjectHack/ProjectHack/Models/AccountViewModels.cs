using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectHack.Models
{
    public class LoginViewModel : AccountInfoViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool StayLogged { get; set; }
    }

    public class RegisterViewModel : AccountInfoViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        public string Password { get; set; }
    }
}