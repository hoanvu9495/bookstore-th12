using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities.Metadata
{
    [MetadataTypeAttribute(typeof(BSNXBMetadata))]
    public partial class BSNXB
    {
        internal sealed class BSNXBMetadata
        {
            [Display(Name="Tên")]
            public string TENNXB { get; set; }

            [RegularExpression(@"(\+\d{2,4})?\s?(\d{10})", ErrorMessage = "Vui lòng nhập đúng định dạng số điện thoại")]
            [Display(Name = "SĐT")]
            public string SDT { get; set; }

            [Display(Name = "Địa chỉ")]
            public string DIACHI { get; set; }

            [Display(Name = "Giới thiệu")]
            public string GIOITHIEU { get; set; }
        }
    }
}