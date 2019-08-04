namespace Akili_Imza_Si.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblOgr_Duyrular
    {
        public int id { get; set; }

        [StringLength(50)]
        public string AkedimisyenID { get; set; }

        [StringLength(50)]
        public string DersKod { get; set; }

        [StringLength(50)]
        public string BolumKod { get; set; }

        [StringLength(10)]
        public string OgrNo { get; set; }

        public string Baslik { get; set; }

        [Required]
        public string Mesaj { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tarih { get; set; }

        [StringLength(8)]
        public string Saat { get; set; }
    }
}
