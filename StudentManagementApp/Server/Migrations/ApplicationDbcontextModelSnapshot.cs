﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentManagementApp.Server.Context;

#nullable disable

namespace StudentManagementApp.Server.Migrations
{
    [DbContext(typeof(ApplicationDbcontext))]
    partial class ApplicationDbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("sonaelizebeth")
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentManagementApp.DataShared.Department", b =>
                {
                    b.Property<int>("DeptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeptId"));

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeptId");

                    b.ToTable("SonaDepartmentwasmTask2", "sonaelizebeth");

                    b.HasData(
                        new
                        {
                            DeptId = 401,
                            DeptName = "Artificial Intelligence"
                        },
                        new
                        {
                            DeptId = 402,
                            DeptName = "Computer Science"
                        });
                });

            modelBuilder.Entity("StudentManagementApp.DataShared.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.Property<int>("FirstMark")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SecondMark")
                        .HasColumnType("int");

                    b.Property<int>("TotalMark")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeptId");

                    b.ToTable("SonaStudentwasmTask2", "sonaelizebeth");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            DeptId = 401,
                            FirstMark = 90,
                            Name = "Arjun Mahadevan",
                            SecondMark = 91,
                            TotalMark = 181
                        },
                        new
                        {
                            Id = 102,
                            DeptId = 402,
                            FirstMark = 90,
                            Name = "Mathew Anil",
                            SecondMark = 91,
                            TotalMark = 181
                        });
                });

            modelBuilder.Entity("StudentManagementApp.DataShared.Student", b =>
                {
                    b.HasOne("StudentManagementApp.DataShared.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
