﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _145213.kdramasApp.Models;

#nullable disable

namespace _145213.kdramasApp.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("_145213.kdramasApp.Models.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Pseudonym")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Pseudonym")
                        .IsUnique();

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("_145213.kdramasApp.Models.KDrama", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("KDramas");
                });

            modelBuilder.Entity("_145213.kdramasApp.Models.KDramaActor", b =>
                {
                    b.Property<int>("ActorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("KDramaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ActorId", "KDramaId");

                    b.HasIndex("KDramaId");

                    b.ToTable("KDramaActors");
                });

            modelBuilder.Entity("_145213.kdramasApp.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("KDramaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("KDramaId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("_145213.kdramasApp.Models.KDramaActor", b =>
                {
                    b.HasOne("_145213.kdramasApp.Models.Actor", "Actor")
                        .WithMany("KDramaActors")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_145213.kdramasApp.Models.KDrama", "KDrama")
                        .WithMany("KDramaActors")
                        .HasForeignKey("KDramaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("KDrama");
                });

            modelBuilder.Entity("_145213.kdramasApp.Models.Status", b =>
                {
                    b.HasOne("_145213.kdramasApp.Models.KDrama", "KDrama")
                        .WithMany("Statuses")
                        .HasForeignKey("KDramaId");

                    b.Navigation("KDrama");
                });

            modelBuilder.Entity("_145213.kdramasApp.Models.Actor", b =>
                {
                    b.Navigation("KDramaActors");
                });

            modelBuilder.Entity("_145213.kdramasApp.Models.KDrama", b =>
                {
                    b.Navigation("KDramaActors");

                    b.Navigation("Statuses");
                });
#pragma warning restore 612, 618
        }
    }
}
