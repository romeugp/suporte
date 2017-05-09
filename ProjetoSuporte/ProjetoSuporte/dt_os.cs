namespace ProjetoSuporte
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dt_os
    {
        [Key]
        public int dtos_id { get; set; }

        public int login_id { get; set; }

        public int? dt1 { get; set; }

        public int? dt2 { get; set; }

        public int? dt3 { get; set; }

        public int? dt4 { get; set; }

        public int? dt5 { get; set; }

        public int? dt6 { get; set; }

        public int? dt7 { get; set; }

        public int? dt8 { get; set; }

        public int? dt9 { get; set; }

        public int? dt0 { get; set; }

        public virtual login login { get; set; }
    }
}
