namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên tài khoản")]
        public string UserName { get; set; }

        [StringLength(50)]
        [Display(Name = "Mật khẩu")]
        public string PassWord { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên người dùng")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? ModifledDate { get; set; }

        [StringLength(50)]
        public string ModifledBy { get; set; }

        public bool Status { get; set; }
    }
}
