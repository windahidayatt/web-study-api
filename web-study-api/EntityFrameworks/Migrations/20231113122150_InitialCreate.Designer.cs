﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using web_study_api.EntityFrameworks.Context;

#nullable disable

namespace web_study_api.EntityFrameworks.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231113122150_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("web_study_api.EntityFrameworks.Entities.MoleculeEntity", b =>
                {
                    b.Property<Guid>("IdMolecules")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MolDescription")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<string>("MoleculesName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMolecules");

                    b.ToTable("m_molecules");
                });

            modelBuilder.Entity("web_study_api.EntityFrameworks.Entities.StudyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("MoleculesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProtocolCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProtocolTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudyStatusID")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VersionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MoleculesId");

                    b.HasIndex("StudyStatusID");

                    b.ToTable("m_study");
                });

            modelBuilder.Entity("web_study_api.EntityFrameworks.Entities.StudyStatusEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("m_study_status");
                });

            modelBuilder.Entity("web_study_api.EntityFrameworks.Entities.StudyEntity", b =>
                {
                    b.HasOne("web_study_api.EntityFrameworks.Entities.MoleculeEntity", "Molecule")
                        .WithMany("Studies")
                        .HasForeignKey("MoleculesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("web_study_api.EntityFrameworks.Entities.StudyStatusEntity", "StudyStatus")
                        .WithMany("Studies")
                        .HasForeignKey("StudyStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Molecule");

                    b.Navigation("StudyStatus");
                });

            modelBuilder.Entity("web_study_api.EntityFrameworks.Entities.MoleculeEntity", b =>
                {
                    b.Navigation("Studies");
                });

            modelBuilder.Entity("web_study_api.EntityFrameworks.Entities.StudyStatusEntity", b =>
                {
                    b.Navigation("Studies");
                });
#pragma warning restore 612, 618
        }
    }
}
