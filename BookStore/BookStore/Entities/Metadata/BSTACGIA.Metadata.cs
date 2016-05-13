using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities.Metadata
{
    [MetadataTypeAttribute(typeof(BSTACGIAMetadata))]
    public partial class BSTACGIA
    {
        internal sealed class BSTACGIAMetadata
        {
            [Display(Name="Họ tên")]
            public string HOTEN { get; set; }

            [Display(Name= "Giới tính")]
            public string GT { get; set; }

            [Display (Name= "Giới thiệu")]
            public string GIOITHIEU { get; set; }

            [Display (Name= "Bút danh")]
            public string BUTDANH { get; set; }

            [Display(Name= "Ngày sinh")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            [DataType(DataType.Date)]
            public DateTime? NGSINH { get; set; }
        }
    }
}