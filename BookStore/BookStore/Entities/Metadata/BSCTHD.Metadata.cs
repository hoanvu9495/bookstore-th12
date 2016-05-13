using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities.Metadata
{
    [MetadataTypeAttribute(typeof(BSCTHDMetadata))]
    public partial class BSCTHD
    {
        internal sealed class BSCTHDMetadata
        {
            public int MASACH { get; set; }

            [Display(Name="Số lượng")]
            [RegularExpression(@"[0-9]", ErrorMessage = "Vui lòng nhập số cho trường này")]
            public int SOLUONG { get; set; }

            [Display(Name="Đơn giá")]
            [RegularExpression(@"[0-9]", ErrorMessage = "Vui lòng nhập số cho trường này")]
            public int DONGIA { get; set; }

            [Display(Name = "Khuyến mại")]
            [RegularExpression(@"[0-9]", ErrorMessage = "Vui lòng nhập số cho trường này")]
            public int KM { get; set; }

            [RegularExpression(@"[0-9]", ErrorMessage = "Vui lòng nhập số cho trường này")]
            [Display(Name = "Thành tiền")]
            public int THANHTIEN { get; set; }

        }
    }
}