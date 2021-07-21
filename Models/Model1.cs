using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BigSchool.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=BigSchoolContext")
        {
        }

        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Following> Following { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Course)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Attendance)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);
        }
    }
}
