using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace winable_api.DataDB
{
    public partial class CollegeContext : DbContext
    {
        protected readonly IConfiguration _config;
        public CollegeContext(IConfiguration config)
        {
            _config = config;
        }

        //public CollegeContext(DbContextOptions<CollegeContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<College> Colleges { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<College>(entity =>
            {
                entity.Property(e => e.CollegeId).HasColumnName("college_Id");

                entity.Property(e => e.CollegeName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("College_name");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.CollegeId).HasColumnName("College_Id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.College)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.CollegeId)
                    .HasConstraintName("FK_Student_Colleges");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
