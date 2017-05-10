namespace ProjetoSuporte
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class manutencao
    {
        [Key]
        public int os_id { get; set; }

        public int login_id { get; set; }

        public int os_escolha { get; set; }

        [Required]
        [StringLength(254)]
        public string os_detalhe { get; set; }

        public DateTime os_dataa { get; set; }

        public DateTime os_dataf { get; set; }

        public int os_nos { get; set; }

        public int os_situacao { get; set; }

        public int os_resolvendo_id { get; set; }

        public DateTime os_data_resolvendo { get; set; }

        public string os_solucao { get; set; }

        public bool os_ok_usuario { get; set; }

        public DateTime os_data_ok_usuario { get; set; }

        public bool os_ok_administrador { get; set; }

        public DateTime os_data_ok_administrador { get; set; }

        public virtual login login { get; set; } 

    }
}
