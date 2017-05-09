namespace ProjetoSuporte
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("login")]
    public partial class login
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public login()
        {
            dt_os = new HashSet<dt_os>();
            os = new HashSet<os>();
        }

        [Key]
        public int login_id { get; set; }

        [Required]
        [StringLength(20)]
        public string login_login { get; set; }

        [Required]
        [StringLength(20)]
        public string login_senha { get; set; }

        [Required]
        [StringLength(20)]
        public string login_acesso { get; set; }

        public bool login_situacao { get; set; }

        public int login_matricula { get; set; }

        [Required]
        [StringLength(100)]
        public string login_setor { get; set; }

        public DateTime login_data_criacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dt_os> dt_os { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<os> os { get; set; }
    }
}
