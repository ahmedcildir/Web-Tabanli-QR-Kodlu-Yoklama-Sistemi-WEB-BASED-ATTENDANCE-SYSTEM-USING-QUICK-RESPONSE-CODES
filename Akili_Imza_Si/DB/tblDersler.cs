namespace Akili_Imza_Si.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDersler")]
    public partial class tblDersler
    {
        [Key]
        public int DId { get; set; }

        [StringLength(50)]
        public string Bolum_Kod { get; set; }

        [StringLength(50)]
        public string Ders_Kod { get; set; }

        [StringLength(200)]
        public string Ders_Ad { get; set; }

        [StringLength(50)]
        public string Teori_Saati { get; set; }

        [StringLength(50)]
        public string Piratik_Saati { get; set; }

        [StringLength(50)]
        public string Ekleme_Tarihi { get; set; }
    }
}
