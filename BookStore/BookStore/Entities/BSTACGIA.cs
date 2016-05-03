namespace BookStore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BSTACGIA")]
    public partial class BSTACGIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BSTACGIA()
        {
            BSSACHes = new HashSet<BSSACH>();
        }

        [Key]
        public int MATG { get; set; }

        [StringLength(30)]
        public string HOTEN { get; set; }

        [Required]
        [StringLength(3)]
        public string GT { get; set; }

        public string GIOITHIEU { get; set; }

        [Required]
        [StringLength(50)]
        public string BUTDANH { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGSINH { get; set; }

        public bool? ISDELETE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSSACH> BSSACHes { get; set; }
    }
}
