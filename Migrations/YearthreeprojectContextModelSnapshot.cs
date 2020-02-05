﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Yearthreeproject.Models;

namespace Yearthreeproject.Migrations
{
    [DbContext(typeof(YearthreeprojectContext))]
    partial class YearthreeprojectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Yearthreeproject.Models.Consultation", b =>
                {
                    b.Property<string>("PatientID");

                    b.Property<string>("ConsultationID");

                    b.HasKey("PatientID", "ConsultationID");

                    b.HasIndex("ConsultationID");

                    b.ToTable("Consultation");
                });

            modelBuilder.Entity("Yearthreeproject.Models.Doctors", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<DateTime>("NextAppointment");

                    b.Property<string>("phone");

                    b.HasKey("ID");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Yearthreeproject.Models.Patients", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Gender");

                    b.Property<string>("History");

                    b.Property<string>("NRIC");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Yearthreeproject.Models.Consultation", b =>
                {
                    b.HasOne("Yearthreeproject.Models.Doctors", "Doctors")
                        .WithMany("Consultations")
                        .HasForeignKey("ConsultationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Yearthreeproject.Models.Patients", "Patients")
                        .WithMany("Consultations")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
