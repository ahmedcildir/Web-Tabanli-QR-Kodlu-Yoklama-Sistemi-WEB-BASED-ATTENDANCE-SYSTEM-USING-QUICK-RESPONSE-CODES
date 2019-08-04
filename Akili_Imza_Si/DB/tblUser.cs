namespace Akili_Imza_Si.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblUser")]
    public partial class tblUser
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Kullanici_Adi { get; set; }

        [StringLength(30)]
        public string Password { get; set; }

        [StringLength(100)]
        public string Ad { get; set; }

        [StringLength(100)]
        public string Soyad { get; set; }

        [StringLength(20)]
        public string Tc { get; set; }

        [StringLength(30)]
        public string D_Tarihi { get; set; }

        [StringLength(100)]
        public string Baba_Ad { get; set; }

        [StringLength(100)]
        public string Anne_Ad { get; set; }

        [StringLength(20)]
        public string Telefon { get; set; }

        [StringLength(100)]
        public string E_posta { get; set; }

        [StringLength(20)]
        public string BolumKod { get; set; }

        [StringLength(20)]
        public string FakulteKod { get; set; }

        [StringLength(200)]
        public string Unvani { get; set; }

        [StringLength(400)]
        public string Fotograf { get; set; }
    }
}
