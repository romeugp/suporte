namespace ProjetoSuporte
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DadosSuporte : DbContext
    {
        public DadosSuporte()
            : base("name=DadosSuporte")
        {
        }

        public virtual DbSet<dt_os> dt_os { get; set; }
        public virtual DbSet<login> login { get; set; }
        public virtual DbSet<os> os { get; set; }
        public virtual DbSet<manutencao> manutencao { get; set;}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
