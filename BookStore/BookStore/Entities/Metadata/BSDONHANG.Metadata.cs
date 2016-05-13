using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities.Metadata
{
    [MetadataTypeAttribute(typeof(BSDONHANGMetadata))]
    public class BSDONHANG
    {
        internal sealed class BSDONHANGMetadata
        {
            [Display(Name="Ngày đặt")]
            public DateTime NGDAT { get; set; }

            [Display(Name = "Ngày giao")]
            public DateTime NGGIAO { get; set; }

            [Display(Name = "Thanh toán")]
            public bool DATHANHTOAN { get; set; }

            [Display(Name = "TT giao hàng")]
            public bool TINHTRANGGH { get; set; }

            [Display(Name = "Tổng tiền")]
            public int TONGTIEN { get; set; }
        }
    }
}