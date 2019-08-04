namespace Akili_Imza_Si.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblFakulteler")]
    public partial class tblFakulteler
    {
        [Key]
        public int FId { get; set; }

        [StringLength(50)]
        public string Fakulte_Kod { get; set; }

        [StringLength(200)]
        public string Fakulte_Adi { get; set; }
    }
}
