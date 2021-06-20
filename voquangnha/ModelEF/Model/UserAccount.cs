namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAccount")]
    public partial class UserAccount
    {
        [Display(Name = "Mã tài khoản")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Không được rỗng Tên tài khoản")]
        [Display(Name = "Tên tài khoản")]
        [StringLength(250)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Không được rỗng Mật khẩu")]
        [Display(Name = "Mật khẩu")]
        [StringLength(250)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Không được rỗng Trạng thái")]
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
    }
}
