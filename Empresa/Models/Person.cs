namespace Guia10_RB140362.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Person : DbContext
    {
        public Person()
            : base("name=Person")
        {
        }

        public virtual DbSet<Listado> Listado { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Listado>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Listado>()
                .Property(e => e.apellido)
                .IsUnicode(false);
        }
    }
}
