namespace BookStore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BSKHUYENMAI")]
    public partial class BSKHUYENMAI
    {
        [Key]
        public int MAKM { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGBATDAU { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGKETTHUC { get; set; }

        public int? MASACH { get; set; }

        public int KM { get; set; }

        public bool? ISDELETE { get; set; }

        public virtual BSSACH BSSACH { get; set; }
    }
}
