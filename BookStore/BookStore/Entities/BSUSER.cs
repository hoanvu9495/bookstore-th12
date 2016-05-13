namespace BookStore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BSUSER")]
    public partial class BSUSER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BSUSER()
        {
            BSDONHANGs = new HashSet<BSDONHANG>();
        }

        [Key]
        public int MAUSR { get; set; }

        [StringLength(30)]
        public string HOTEN { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGSINH { get; set; }

        [Required]
        [StringLength(3)]
        public string GT { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [StringLength(20)]
        public string SDT { get; set; }

        public string DIACHI { get; set; }

        [Required]
        [StringLength(30)]
        public string TAIKHOAN { get; set; }

        [Required]
        [StringLength(30)]
        public string MATKHAU { get; set; }

        public bool? ISDELETE { get; set; }

        public int? USRANK { get; set; }

        public string avatar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSDONHANG> BSDONHANGs { get; set; }
    }
}
