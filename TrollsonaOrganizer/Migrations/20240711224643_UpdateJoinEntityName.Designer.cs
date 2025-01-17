﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrollsonaOrganizer.Models;

#nullable disable

namespace TrollsonaOrganizer.Migrations
{
    [DbContext(typeof(TrollsonaOrganizerContext))]
    [Migration("20240711224643_UpdateJoinEntityName")]
    partial class UpdateJoinEntityName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TrollsonaOrganizer.Models.Allocation", b =>
                {
                    b.Property<int>("AllocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("StrifeSpecibusId")
                        .HasColumnType("int");

                    b.Property<int>("TrollId")
                        .HasColumnType("int");

                    b.HasKey("AllocationId");

                    b.HasIndex("StrifeSpecibusId");

                    b.HasIndex("TrollId");

                    b.ToTable("Allocations");
                });

            modelBuilder.Entity("TrollsonaOrganizer.Models.BloodCaste", b =>
                {
                    b.Property<int>("BloodCasteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ColorHex")
                        .HasColumnType("longtext");

                    b.Property<string>("ColorName")
                        .HasColumnType("longtext");

                    b.Property<string>("Division")
                        .HasColumnType("longtext");

                    b.HasKey("BloodCasteId");

                    b.ToTable("BloodCastes");
                });

            modelBuilder.Entity("TrollsonaOrganizer.Models.StrifeSpecibus", b =>
                {
                    b.Property<int>("StrifeSpecibusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("KindAbstratus")
                        .HasColumnType("longtext");

                    b.HasKey("StrifeSpecibusId");

                    b.ToTable("StrifeSpecibi");
                });

            modelBuilder.Entity("TrollsonaOrganizer.Models.Troll", b =>
                {
                    b.Property<int>("TrollId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("BloodCasteId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Sign")
                        .HasColumnType("longtext");

                    b.HasKey("TrollId");

                    b.HasIndex("BloodCasteId");

                    b.ToTable("Trolls");
                });

            modelBuilder.Entity("TrollsonaOrganizer.Models.Allocation", b =>
                {
                    b.HasOne("TrollsonaOrganizer.Models.StrifeSpecibus", "StrifeSpecibus")
                        .WithMany("JoinEntities")
                        .HasForeignKey("StrifeSpecibusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrollsonaOrganizer.Models.Troll", "Troll")
                        .WithMany("JoinEntities")
                        .HasForeignKey("TrollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StrifeSpecibus");

                    b.Navigation("Troll");
                });

            modelBuilder.Entity("TrollsonaOrganizer.Models.Troll", b =>
                {
                    b.HasOne("TrollsonaOrganizer.Models.BloodCaste", "BloodCaste")
                        .WithMany("Trolls")
                        .HasForeignKey("BloodCasteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BloodCaste");
                });

            modelBuilder.Entity("TrollsonaOrganizer.Models.BloodCaste", b =>
                {
                    b.Navigation("Trolls");
                });

            modelBuilder.Entity("TrollsonaOrganizer.Models.StrifeSpecibus", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("TrollsonaOrganizer.Models.Troll", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
