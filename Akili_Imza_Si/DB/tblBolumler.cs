namespace Akili_Imza_Si.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblBolumler")]
    public partial class tblBolumler
    {
        [Key]
        public int BId { get; set; }

        [StringLength(100)]
        public string Fakulte_Kodu { get; set; }

        [StringLength(100)]
        public string Bolum_Kod { get; set; }

        [StringLength(200)]
        public string Bolum_Ad { get; set; }

        [StringLength(100)]
        public string Bolum_Tip { get; set; }
    }
}
