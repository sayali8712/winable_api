﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using winable_api.DataDB;

#nullable disable

namespace winable_api.Migrations
{
    [DbContext(typeof(CollegeContext))]
    [Migration("20231214154527_initial1")]
    partial class initial1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("winable_api.DataDB.College", b =>
                {
                    b.Property<long>("CollegeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("college_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CollegeId"), 1L, 1);

                    b.Property<string>("CollegeName")
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("College_name");

                    b.HasKey("CollegeId");

                    b.ToTable("Colleges");
                });

            modelBuilder.Entity("winable_api.DataDB.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long?>("CollegeId")
                        .HasColumnType("bigint")
                        .HasColumnName("College_Id");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CollegeId");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("winable_api.DataDB.Student", b =>
                {
                    b.HasOne("winable_api.DataDB.College", "College")
                        .WithMany("Students")
                        .HasForeignKey("CollegeId")
                        .HasConstraintName("FK_Student_Colleges");

                    b.Navigation("College");
                });

            modelBuilder.Entity("winable_api.DataDB.College", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
