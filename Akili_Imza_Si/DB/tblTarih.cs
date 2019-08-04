namespace Akili_Imza_Si.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblTarih")]
    public partial class tblTarih
    {
        [Key]
        public int TID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tarih { get; set; }

        [StringLength(5)]
        public string Yil { get; set; }

        [StringLength(2)]
        public string Ay { get; set; }

        [StringLength(2)]
        public string Gun { get; set; }

        [StringLength(50)]
        public string X { get; set; }
    }
}
