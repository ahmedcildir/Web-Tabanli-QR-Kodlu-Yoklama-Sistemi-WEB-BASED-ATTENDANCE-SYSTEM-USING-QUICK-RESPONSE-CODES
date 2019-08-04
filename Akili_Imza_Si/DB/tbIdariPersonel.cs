namespace Akili_Imza_Si.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbIdariPersonel")]
    public partial class tbIdariPersonel
    {
        [Key]
        public int PID { get; set; }

        [StringLength(100)]
        public string Kullanici_Ad { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(100)]
        public string Ad { get; set; }

        [StringLength(100)]
        public string Soyad { get; set; }

        [StringLength(11)]
        public string Tc { get; set; }

        [StringLength(50)]
        public string D_Tarihi { get; set; }

        [StringLength(100)]
        public string Baba_Ad { get; set; }

        [StringLength(100)]
        public string Anne_Ad { get; set; }

        [StringLength(13)]
        public string Telefon { get; set; }

        [StringLength(100)]
        public string E_posta { get; set; }

        [StringLength(20)]
        public string FakulteKod { get; set; }

        [StringLength(100)]
        public string Gorev { get; set; }

        [StringLength(300)]
        public string Fotograf { get; set; }
    }
}
