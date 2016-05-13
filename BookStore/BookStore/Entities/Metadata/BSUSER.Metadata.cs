using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities.Metadata
{
    [MetadataTypeAttribute(typeof(BSUSERMetadata))]
    public partial class BSUSER
    {
        internal sealed class BSUSERMetadata
        {
            public int MAUSR { get; set; }

            [Display(Name="Họ tên")]
            public string HOTEN { get; set; }

            [Display(Name="Ngày sinh")]
            [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}")]
            [DataType(DataType.Date)]
            public DateTime? NGSINH { get; set; }

            [Required]
            [StringLength(3)]
            [Display(Name = "Giới tính")]
            public string GT { get; set; }

            [StringLength(50)]
            [RegularExpression(@"[_a-z0-9-]+(\\.[_a-z0-9-]+)*@([a-z0-9]+\\.com)",ErrorMessage="Vui lòng nhập đúng định dạng Email")]
            [Required(ErrorMessage="Vui lòng nhập thông tin cho trường này")]
            [Display(Name = "Email")]
            public string EMAIL { get; set; }

            [StringLength(20)]
            [Display(Name = "SĐT")]
            [RegularExpression(@"(\+\d{2,4})?\s?(\d{10})",ErrorMessage="Vui lòng nhập đúng định dạng số điện thoại")]
            public string SDT { get; set; }

            [Display(Name = "Địa chỉ")]
            public string DIACHI { get; set; }

            [Required]
            [StringLength(30)]
            [Display(Name = "Tài khoản")]
            public string TAIKHOAN { get; set; }

            [Required]
            [StringLength(30)]
            [Display(Name="Mật khẩu")]
            public string MATKHAU { get; set; }

            public bool? ISDELETE { get; set; }

            public int? USRANK { get; set; }

            [Display(Name = "Avatar")]
            public string avatar { get; set; }
        }
    }
}