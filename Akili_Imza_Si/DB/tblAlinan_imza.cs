namespace Akili_Imza_Si.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblAlinan_imza
    {
        public int Id { get; set; }

        [StringLength(13)]
        public string Tc { get; set; }

        [StringLength(100)]
        public string Ad { get; set; }

        [StringLength(100)]
        public string Soyad { get; set; }

        [StringLength(150)]
        public string Ders_Kod { get; set; }

        [StringLength(50)]
        public string Ders_Haftasi { get; set; }

        [StringLength(50)]
        public string Ders_Tipi { get; set; }

        [StringLength(50)]
        public string Ders_Saat { get; set; }

        [StringLength(20)]
        public string imza_Tarihi { get; set; }

        [StringLength(20)]
        public string imza_Saat { get; set; }

        public int? IslenenDersSuresi { get; set; }
    }
}
