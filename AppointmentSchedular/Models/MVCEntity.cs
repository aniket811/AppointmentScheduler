using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AppointmentSchedular.Models
{
    public partial class MVCEntity : DbContext
    {
        public MVCEntity()
        {
            
        }

        public virtual DbSet<Authentication> Authentications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authentication>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Authentication>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Authentication>()
                .Property(e => e.passwords)
                .IsUnicode(false);

            modelBuilder.Entity<Authentication>()
                .Property(e => e.conpassword)
                .IsUnicode(false);
        }
    }
}
