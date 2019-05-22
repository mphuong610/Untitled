using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Untitled.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "PassWord")]
        public string PassWord { get; set; }

        public bool RememberMe { get; set; }
    }
}