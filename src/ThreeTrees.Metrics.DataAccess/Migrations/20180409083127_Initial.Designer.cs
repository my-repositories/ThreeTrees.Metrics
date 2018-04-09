﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using ThreeTrees.Metrics.DataAccess;
using ThreeTrees.Metrics.Domain.Employees.Entities;

namespace ThreeTrees.Metrics.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180409083127_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ThreeTrees.Metrics.Domain.Employees.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthday");

                    b.Property<int>("Branch");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ThreeTrees.Metrics.Domain.EmployeeStatistics.Entities.EmployeeStatistic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BilledHours");

                    b.Property<int>("CompletedTasks");

                    b.Property<int>("DrunkedCups");

                    b.Property<int>("EmployeeId");

                    b.Property<int>("Month");

                    b.Property<int>("PlayedMCGames");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("EmployeeStatistics");
                });

            modelBuilder.Entity("ThreeTrees.Metrics.Domain.EmployeeStatistics.Entities.EmployeeStatistic", b =>
                {
                    b.HasOne("ThreeTrees.Metrics.Domain.Employees.Entities.Employee", "Employee")
                        .WithOne()
                        .HasForeignKey("ThreeTrees.Metrics.Domain.EmployeeStatistics.Entities.EmployeeStatistic", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}