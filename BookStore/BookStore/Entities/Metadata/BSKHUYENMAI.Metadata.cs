using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities.Metadata
{
    [MetadataTypeAttribute(typeof(BSKHUYENMAIMetadata))]
    public partial class BSKHUYENMAI
    {
        internal sealed class BSKHUYENMAIMetadata
        {
            [Display(Name="Khuyến mại")]
            public string TENKM
            {
                get;
                set;
            }
            [Display(Name = "Ngày bắt đầu")]
            [RegularExpression(@"(\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}\.\d{2} )",ErrorMessage="Vui lòng nhập đúng định dạng cho trường này")]
            public DateTime NGBATDAU { get; set; }
            [RegularExpression(@"(\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}\.\d{2} )", ErrorMessage = "Vui lòng nhập đúng định dạng cho trường này")]
            [Display(Name = "Ngày kết thúc")]
            public DateTime NGKETTHUC { get; set; }

            [Display(Name = "Mô tả")]
            public string MOTA { get; set; }
        }
    }
}