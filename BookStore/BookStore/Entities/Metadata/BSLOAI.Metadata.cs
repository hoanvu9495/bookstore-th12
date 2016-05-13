using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities.Metadata
{
    [MetadataTypeAttribute(typeof(BSLOAIMetadata))]
    public partial class BSLOAI
    {
        internal sealed class BSLOAIMetadata
        {
            public int MALOAI { get; set; }

            [Display(Name="Tên")]
            public string TENLOAI { get; set; }

            [Display(Name = "Ghi chú")]
            public string GHICHU { get; set; }

            [Display(Name = "Giới thiệu")]
            public string GIOITHIEU { get; set; }

            public bool? ISDELETE { get; set; }
        }
    }
}