namespace BookStore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BSCTKM")]
    public partial class BSCTKM
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAKM { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MASACH { get; set; }

        public int PTKM { get; set; }

        public bool? ISDELETE { get; set; }

        public virtual BSKHUYENMAI BSKHUYENMAI { get; set; }

        public virtual BSSACH BSSACH { get; set; }
    }
}
