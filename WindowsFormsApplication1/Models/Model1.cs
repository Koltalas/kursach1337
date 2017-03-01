namespace WindowsFormsApplication1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<books> books { get; set; }
        public virtual DbSet<themes> themes { get; set; }
        public virtual DbSet<users> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<books>()
                .Property(e => e.bname)
                .IsUnicode(false);

            modelBuilder.Entity<themes>()
                .Property(e => e.tname)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.ulogin)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.upassword)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.uname)
                .IsUnicode(false);
        }
    }
}
