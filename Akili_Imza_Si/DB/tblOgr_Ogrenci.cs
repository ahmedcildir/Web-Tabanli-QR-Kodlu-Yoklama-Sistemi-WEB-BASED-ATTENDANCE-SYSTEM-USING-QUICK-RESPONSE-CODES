namespace Akili_Imza_Si.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblOgr_Ogrenci
    {
        [Key]
        public int Ogr_ID { get; set; }

        [StringLength(50)]
        public string Ogr_MacAddres { get; set; }

        [StringLength(50)]
        public string Ogr_No { get; set; }

        [StringLength(50)]
        public string Ogr_Password { get; set; }

        [StringLength(50)]
        public string Ogr_Tc { get; set; }

        [StringLength(100)]
        public string Ogr_Ad { get; set; }

        [StringLength(100)]
        public string Ogr_SoyAd { get; set; }

        [StringLength(50)]
        public string Ogr_Eposta { get; set; }

        [StringLength(13)]
        public string Ogr_telefon { get; set; }

        [StringLength(100)]
        public string Ogr_BabaAd { get; set; }

        [StringLength(100)]
        public string Ogr_AnneAd { get; set; }

        [StringLength(300)]
        public string Ogr_DogumYer { get; set; }

        [StringLength(50)]
        public string Ogr_DogumTarihi { get; set; }

        [StringLength(250)]
        public string Ogr_Fakulte { get; set; }

        [StringLength(400)]
        public string Ogr_Program { get; set; }

        [StringLength(2)]
        public string Ogr_Sinif { get; set; }

        [StringLength(100)]
        public string Ogr_OgrenimSekli { get; set; }

        public string Ogr_Fotograf { get; set; }
    }
}
