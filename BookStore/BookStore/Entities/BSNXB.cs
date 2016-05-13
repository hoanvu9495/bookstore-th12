namespace BookStore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BSNXB")]
    public partial class BSNXB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BSNXB()
        {
            BSSACHes = new HashSet<BSSACH>();
        }

        [Key]
        public int MANXB { get; set; }

        [Required]
        [StringLength(100)]
        public string TENNXB { get; set; }

        [StringLength(20)]
        public string SDT { get; set; }

        public string DIACHI { get; set; }

        public string GIOITHIEU { get; set; }

        public bool? ISDELETE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSSACH> BSSACHes { get; set; }
    }
}
