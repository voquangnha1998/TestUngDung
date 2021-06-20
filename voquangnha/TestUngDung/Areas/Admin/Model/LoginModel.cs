using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestUngDung.Areas.Admin.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Chưa nhập tài khoản")]
        [StringLength(250)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Chưa nhập mật khẩu")]
        [StringLength(250)]
        public string Password { get; set; }

    }
}