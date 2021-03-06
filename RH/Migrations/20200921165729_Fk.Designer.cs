﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RH.Data;

namespace RH.Migrations
{
    [DbContext(typeof(RHContext))]
    [Migration("20200921165729_Fk")]
    partial class Fk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RH.Models.Cand_Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CandidateId");

                    b.Property<int?>("JobId");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("JobId");

                    b.ToTable("Cand_Job");
                });

            modelBuilder.Entity("RH.Models.Cand_Tech", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CandidateId");

                    b.Property<int>("TechnologyId");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("TechnologyId");

                    b.ToTable("Cand_Tech");
                });

            modelBuilder.Entity("RH.Models.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("Age");

                    b.Property<string>("City");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<int>("JobId");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("Candidate");
                });

            modelBuilder.Entity("RH.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("RH.Models.Tech_Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("JobId");

                    b.Property<int?>("TechnologyId");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.HasIndex("TechnologyId");

                    b.ToTable("Tech_Job");
                });

            modelBuilder.Entity("RH.Models.Technology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CheckboxAwnser");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Technology");
                });

            modelBuilder.Entity("RH.Models.Cand_Job", b =>
                {
                    b.HasOne("RH.Models.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId");

                    b.HasOne("RH.Models.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId");
                });

            modelBuilder.Entity("RH.Models.Cand_Tech", b =>
                {
                    b.HasOne("RH.Models.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RH.Models.Technology", "Technology")
                        .WithMany()
                        .HasForeignKey("TechnologyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RH.Models.Candidate", b =>
                {
                    b.HasOne("RH.Models.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RH.Models.Tech_Job", b =>
                {
                    b.HasOne("RH.Models.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId");

                    b.HasOne("RH.Models.Technology", "Technology")
                        .WithMany()
                        .HasForeignKey("TechnologyId");
                });
#pragma warning restore 612, 618
        }
    }
}
