namespace BookStore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BSSACH")]
    public partial class BSSACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BSSACH()
        {
            BSCTDHs = new HashSet<BSCTDH>();
            BSKHUYENMAIs = new HashSet<BSKHUYENMAI>();
        }

        [Key]
        public int MASACH { get; set; }

        public int? MALOAI { get; set; }

        public int? MANXB { get; set; }

        [Required]
        [StringLength(50)]
        public string TENSACH { get; set; }

        public int? MATG { get; set; }

        public int SOLUONG { get; set; }

        public double? TRONGLUONG { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGXB { get; set; }

        public int GIABIA { get; set; }

        public int SOTRANG { get; set; }

        [Required]
        [StringLength(15)]
        public string KHO { get; set; }

        public string BIA { get; set; }

        public string GIOITHIEU { get; set; }

        public bool? ISDELETE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSCTDH> BSCTDHs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSKHUYENMAI> BSKHUYENMAIs { get; set; }

        public virtual BSLOAI BSLOAI { get; set; }

        public virtual BSNXB BSNXB { get; set; }

        public virtual BSTACGIA BSTACGIA { get; set; }
    }
}
