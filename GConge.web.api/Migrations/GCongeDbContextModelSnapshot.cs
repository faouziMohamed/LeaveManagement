﻿// <auto-generated />
using System;
using GConge.web.api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GConge.web.api.Migrations
{
    [DbContext(typeof(GCongeDbContext))]
    partial class GCongeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GConge.Models.Models.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Service")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Service = "IT",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("GConge.Models.Models.Entities.LeaveRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRequested")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LeaveType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RequestingEmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("RequestingEmployeeId");

                    b.ToTable("LeaveRequests");
                });

            modelBuilder.Entity("GConge.Models.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin.email@email.com",
                            Firstname = "Admin",
                            Lastname = "Admin",
                            Password = new byte[] { 68, 61, 82, 135, 73, 64, 49, 151, 129, 182, 74, 237, 17, 214, 59, 174, 20, 242, 10, 215, 231, 92, 45, 116, 236, 195, 203, 93, 239, 119, 68, 167, 25, 107, 217, 50, 230, 247, 23, 18, 230, 169, 176, 127, 35, 185, 141, 84, 180, 183, 36, 228, 133, 88, 6, 75, 105, 238, 94, 152, 202, 253, 249, 97 },
                            PasswordSalt = new byte[] { 65, 109, 126, 87, 113, 135, 188, 251, 138, 61, 112, 80, 91, 198, 42, 90, 196, 31, 222, 187, 165, 250, 138, 226, 69, 29, 17, 89, 11, 213, 46, 161, 113, 20, 15, 86, 61, 191, 145, 119, 70, 142, 231, 69, 73, 213, 166, 26, 214, 192, 170, 246, 164, 17, 186, 234, 191, 113, 97, 26, 241, 35, 120, 225, 129, 8, 102, 121, 98, 140, 111, 81, 193, 191, 237, 25, 252, 16, 170, 217, 196, 198, 128, 104, 56, 169, 117, 94, 161, 51, 180, 163, 88, 197, 33, 251, 253, 152, 72, 244, 9, 80, 23, 179, 31, 77, 145, 120, 81, 133, 145, 184, 219, 243, 97, 135, 223, 72, 181, 36, 67, 236, 255, 150, 162, 77, 78, 170 },
                            Role = "Admin"
                        });
                });

            modelBuilder.Entity("GConge.Models.Models.Entities.Employee", b =>
                {
                    b.HasOne("GConge.Models.Models.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GConge.Models.Models.Entities.LeaveRequest", b =>
                {
                    b.HasOne("GConge.Models.Models.Entities.Employee", "RequestingEmployee")
                        .WithMany()
                        .HasForeignKey("RequestingEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequestingEmployee");
                });
#pragma warning restore 612, 618
        }
    }
}
