using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Using thư viện cho metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities
{
    [MetadataTypeAttribute(typeof(BSSACHMetadata))]
    public partial class BSSACH
    {
        internal sealed class BSSACHMetadata
        {

            //Code validation tại đây        
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")] //Kiểm tra rỗng
            [Display(Name = "Mã Sách")] // Đặt lại tên hiển thị cho các cột.
            public int MASACH { get; set; }
            public int? MALOAI { get; set; }

            public int? MANXB { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            [StringLength(50)]
            [DisplayName("Tên sách")]
            public string TENSACH { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập trường này")]
            [Display(Name = "Mã tác giả")]
            public int? MATG { get; set; }

            [Display(Name = "Số lượng")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "Vui lòng nhập số cho trường này")]
            public int SOLUONG { get; set; }

            [Display(Name = "Trọng lượng (gram)")]
            public double? TRONGLUONG { get; set; }

            [Display(Name = "Ngày xuất bản")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            [DataType(DataType.Date)]
            public DateTime NGXB { get; set; }

            [RegularExpression(@"[0-9]+", ErrorMessage = "Vui lòng nhập số cho trường này")]
            [Display(Name = "Giá bìa")]
            public int GIABIA { get; set; }

            [Display(Name = "Số trang")]
            [RegularExpression(@"[0-9]+", ErrorMessage = "Vui lòng nhập số cho trường này")]
            public int SOTRANG { get; set; }

            [Required]
            [StringLength(15)]
            [Display(Name = "Khổ giấy")]
            public string KHO { get; set; }

            [Display(Name = "Ảnh bìa")]
            public string BIA { get; set; }

            [Display(Name = "Giới thiệu")]
            public string GIOITHIEU { get; set; }
        }
    }
}