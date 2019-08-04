namespace Akili_Imza_Si.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDuyrular")]
    public partial class tblDuyrular
    {
        [Key]
        public int DİD { get; set; }

        [StringLength(50)]
        public string PresonelID { get; set; }

        [StringLength(20)]
        public string BolumKod { get; set; }

        [StringLength(20)]
        public string FakulteKod { get; set; }

        [StringLength(50)]
        public string AkID { get; set; }

        public string Baslik { get; set; }

        public string Mesaj { get; set; }

        [StringLength(15)]
        public string Tarih { get; set; }

        [StringLength(2)]
        public string Gun { get; set; }

        [StringLength(2)]
        public string Ay { get; set; }
    }
}
