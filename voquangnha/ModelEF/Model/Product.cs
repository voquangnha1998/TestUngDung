namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            Image = "~/Content/upload/addproduct.jpg";
        }
        [Display(Name = "Mã sản phẩm")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Không được rỗng Tên SP")]
        [Display(Name = "Tên sản phẩm")]
        [StringLength(250)]
        public string Name { get; set; }


        
        [Required(ErrorMessage = "Không được rỗng giá SP")]
        [Display(Name = "Giá")]
        public decimal UnitCost { get; set; }

        [Required(ErrorMessage = "Không được rỗng Số lượng SP")]
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Không được rỗng Hình ảnh SP")]
        [Display(Name = "Hình ảnh")]
        [StringLength(250)]
        public string Image { get; set; }

        [Required(ErrorMessage = "Không được rỗng Mô tả SP")]
        [Display(Name = "Mô tả sản phẩm")]
        [StringLength(250)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Không được rỗng Trạng thái SP")]
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "Không được rỗng Loại SP")]
        [Display(Name = "Loại sản phẩm")]
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
        [NotMapped]
        public HttpPostedFileBase Imgfile { get; set; }

        
    }
}
