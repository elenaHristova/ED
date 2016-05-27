using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectHack.Models
{
    public class NewUserViewModel : AccountInfoViewModel
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}