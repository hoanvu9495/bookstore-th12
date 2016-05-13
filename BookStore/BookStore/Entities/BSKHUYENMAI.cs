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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BSKHUYENMAI()
        {
            BSCTKMs = new HashSet<BSCTKM>();
        }

        [Key]
        public int MAKM { get; set; }

        public string TENKM { get; set;
        }
        [Column(TypeName = "date")]
        public DateTime NGBATDAU { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGKETTHUC { get; set; }

        public string MOTA { get; set; }

        public bool? ISDELETE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSCTKM> BSCTKMs { get; set; }
    }
}
