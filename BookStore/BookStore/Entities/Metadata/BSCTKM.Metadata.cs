using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities.Metadata
{
    [MetadataTypeAttribute(typeof(BSCTKMMetadata))]
    public partial class BSCTKM
    {
        internal sealed class BSCTKMMetadata
        {
            [Display(Name="Khuyến mại(%)")]
            public int PTKM { get; set; }

        }
    }
}