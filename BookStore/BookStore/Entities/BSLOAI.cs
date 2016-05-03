namespace BookStore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BSLOAI")]
    public partial class BSLOAI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BSLOAI()
        {
            BSSACHes = new HashSet<BSSACH>();
        }

        [Key]
        public int MALOAI { get; set; }

        [Required]
        [StringLength(20)]
        public string TENLOAI { get; set; }

        public string GHICHU { get; set; }

        public bool? ISDELETE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSSACH> BSSACHes { get; set; }
    }
}
