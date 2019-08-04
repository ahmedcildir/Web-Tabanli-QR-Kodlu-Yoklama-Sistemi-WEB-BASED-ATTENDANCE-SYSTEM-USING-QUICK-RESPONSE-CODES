namespace Akili_Imza_Si.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblAkedimisyen_Al_Dersler
    {
        public int id { get; set; }

        public int? AkedimisyenID { get; set; }

        [StringLength(100)]
        public string Ders_Kod { get; set; }

        [StringLength(200)]
        public string Derslik_Ad { get; set; }
    }
}
