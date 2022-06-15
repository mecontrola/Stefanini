﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stefanini.ViaReport.DataStorage;

#nullable disable

namespace Stefanini.ViaReport.DataStorage.Migrations
{
    [DbContext(typeof(DbAppContext))]
    [Migration("20220607172701_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("Stefanini.ViaReport.Data.Entities.Issue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Incident")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IssueTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Resolved")
                        .HasColumnType("TEXT");

                    b.Property<long>("StatusId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Uuid")
                        .HasMaxLength(36)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IssueTypeId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StatusId");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("Stefanini.ViaReport.Data.Entities.IssueStatusHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<long>("IssueId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("StatusId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("Uuid")
                        .HasMaxLength(36)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IssueId");

                    b.HasIndex("StatusId");

                    b.ToTable("IssueStatusHistories");
                });

            modelBuilder.Entity("Stefanini.ViaReport.Data.Entities.IssueType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("Key")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Uuid")
                        .HasMaxLength(36)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("IssueTypes");
                });

            modelBuilder.Entity("Stefanini.ViaReport.Data.Entities.Project", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("Key")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<long>("ProjectCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Selected")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("Uuid")
                        .HasMaxLength(36)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectCategoryId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Stefanini.ViaReport.Data.Entities.ProjectCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("Key")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Uuid")
                        .HasMaxLength(36)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProjectCategories");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Key = 12904L,
                            Name = "Aplicativos",
                            Uuid = new Guid("15792637-4496-4e0f-8848-e3ee2b077711")
                        },
                        new
                        {
                            Id = 2L,
                            Key = 11404L,
                            Name = "Decisão",
                            Uuid = new Guid("975a10e5-74fa-4529-baf7-c08d79d62c9a")
                        },
                        new
                        {
                            Id = 3L,
                            Key = 11104L,
                            Name = "Descoberta",
                            Uuid = new Guid("b1c8348f-aa66-46fd-97bd-2ffe97d681bb")
                        },
                        new
                        {
                            Id = 4L,
                            Key = 12905L,
                            Name = "Fidelização",
                            Uuid = new Guid("dc5e09d1-610d-4ced-9c06-e014fc2b2beb")
                        });
                });

            modelBuilder.Entity("Stefanini.ViaReport.Data.Entities.Status", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("Key")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<long>("StatusCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("Uuid")
                        .HasMaxLength(36)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StatusCategoryId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Stefanini.ViaReport.Data.Entities.StatusCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("Key")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Uuid")
                        .HasMaxLength(36)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("StatusCategories");
                });

            modelBuilder.Entity("Stefanini.ViaReport.Data.Entities.Issue", b =>
                {
                    b.HasOne("Stefanini.ViaReport.Data.Entities.IssueType", "IssueType")
                        .WithMany("Issues")
                        .HasForeignKey("IssueTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stefanini.ViaReport.Data.Entities.Project", "Project")
                        .WithMany("Issues")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stefanini.ViaReport.Data.Entities.Status", "Status")
                        .WithMany("Issues")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IssueType");

                    b.Navigation("Project");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Stefanini.ViaReport.Data.Entities.IssueStatusHistory", b =>
                {
                    b.HasOne("Stefanini.ViaReport.Data.Entities.Issue", "Issue")
                        .WithMany("Statuses")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stefanini.ViaReport.Data.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Issue");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Stefanini.ViaReport.Data.Entities.Project", b =>
                {
                    b.HasOne("Stefanini.ViaReport.Data.Entities.ProjectCategory", "ProjectCategory")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectCategory");
                });

            modelBuilder.Entity("Stefanini.ViaReport.Data.Entities.Status", b =>
                {
                    b.HasOne("Stefanini.ViaReport.Data.Entities.StatusCategory", "StatusCategory")
                        .WithMany("Statuses")
                        .HasForeignKey("StatusCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatusCategory");
                });

            modelBuilder.Entity("Stefanini.ViaReport.Data.Entities.Issue", b =>
                {
                    b.Navigation("Statuses");
                });

            modelBuilder.Entity("Stefanini.ViaReport.Data.Entities.IssueType", b =>
                {
                    b.Navigation("Issues");
                });

            modelBuilder.Entity("Stefanini.ViaReport.Data.Entities.Project", b =>
                {
                    b.Navigation("Issues");
                });

            modelBuilder.Entity("Stefanini.ViaReport.Data.Entities.ProjectCategory", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Stefanini.ViaReport.Data.Entities.Status", b =>
                {
                    b.Navigation("Issues");
                });

            modelBuilder.Entity("Stefanini.ViaReport.Data.Entities.StatusCategory", b =>
                {
                    b.Navigation("Statuses");
                });
#pragma warning restore 612, 618
        }
    }
}
