namespace BookStore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BSTACGIASACH")]
    public partial class BSTACGIASACH
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MASACH { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MATG { get; set; }

        public string VAITRO { get; set; }

        public bool? ISDELETE { get; set; }

        public virtual BSSACH BSSACH { get; set; }

        public virtual BSTACGIA BSTACGIA { get; set; }
    }
}
