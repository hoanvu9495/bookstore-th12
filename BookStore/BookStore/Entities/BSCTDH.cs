namespace BookStore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BSCTDH")]
    public partial class BSCTDH
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MADH { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MASACH { get; set; }

        public int SOLUONG { get; set; }

        public int DONGIA { get; set; }

        public int KM { get; set; }

        public int THANHTIEN { get; set; }

        public bool? ISDELETE { get; set; }

        public virtual BSDONHANG BSDONHANG { get; set; }

        public virtual BSSACH BSSACH { get; set; }
    }
}
