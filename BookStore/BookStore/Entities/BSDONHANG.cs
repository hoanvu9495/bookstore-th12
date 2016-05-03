namespace BookStore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BSDONHANG")]
    public partial class BSDONHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BSDONHANG()
        {
            BSCTDHs = new HashSet<BSCTDH>();
        }

        [Key]
        public int MADH { get; set; }

        public int? MAKHACHHANG { get; set; }

        public DateTime NGDAT { get; set; }

        public DateTime NGGIAO { get; set; }

        public bool DATHANHTOAN { get; set; }

        public bool TINHTRANGGH { get; set; }

        public int TONGTIEN { get; set; }

        public bool? ISDELETE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSCTDH> BSCTDHs { get; set; }

        public virtual BSUSER BSUSER { get; set; }
    }
}
