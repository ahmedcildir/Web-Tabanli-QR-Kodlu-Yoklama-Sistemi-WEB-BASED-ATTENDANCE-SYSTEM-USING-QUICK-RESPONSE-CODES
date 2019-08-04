namespace Akili_Imza_Si.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblDersKaydı
    {
        [Key]
        public int Ogr_ID { get; set; }

        [StringLength(50)]
        public string Ogr_No { get; set; }

        [StringLength(200)]
        public string Ogr_Ad { get; set; }

        [StringLength(200)]
        public string Ogr_Soyad { get; set; }

        [StringLength(50)]
        public string Drs_S_Z { get; set; }

        [StringLength(200)]
        public string Ders_Kod { get; set; }

        [StringLength(200)]
        public string Sinif { get; set; }
    }
}
