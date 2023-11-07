﻿// <auto-generated />
using System;
using Financial_DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Financial_DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240525140212_StartEndDate")]
    partial class StartEndDate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Financial_DAL.Assign", b =>
                {
                    b.Property<int>("AssignId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignId"), 1L, 1);

                    b.Property<string>("AssignedTo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssignId");

                    b.ToTable("Assigns");
                });

            modelBuilder.Entity("Financial_DAL.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("Sale_Id")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.HasIndex("Sale_Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Financial_DAL.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Company")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastContact")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NextAction")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("NextContact")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Owner")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Sales")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Source_Id")
                        .HasColumnType("int");

                    b.Property<int>("Statu_Id")
                        .HasColumnType("int");

                    b.Property<string>("WorkFunction")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CustomerId");

                    b.HasIndex("Source_Id");

                    b.HasIndex("Statu_Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Financial_DAL.MainCategory", b =>
                {
                    b.Property<int>("MCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MCategoryId"), 1L, 1);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MCategoryName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MCategoryId");

                    b.ToTable("MainCategories");
                });

            modelBuilder.Entity("Financial_DAL.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"), 1L, 1);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<Guid>("Transaction_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("link")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentId");

                    b.HasIndex("Transaction_Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Financial_DAL.Priority", b =>
                {
                    b.Property<int>("PriorityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PriorityId"), 1L, 1);

                    b.Property<string>("PriorityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PriorityId");

                    b.ToTable("Priority");
                });

            modelBuilder.Entity("Financial_DAL.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"), 1L, 1);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Financial_DAL.Sale", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleId"), 1L, 1);

                    b.Property<string>("Category_Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SaleId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Financial_DAL.Source", b =>
                {
                    b.Property<int>("SourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SourceId"), 1L, 1);

                    b.Property<string>("SourceName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SourceId");

                    b.ToTable("Sources");
                });

            modelBuilder.Entity("Financial_DAL.Statu", b =>
                {
                    b.Property<int>("StatutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatutId"), 1L, 1);

                    b.Property<string>("StatutName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StatutId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Financial_DAL.SubCategory", b =>
                {
                    b.Property<int>("SCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SCategoryId"), 1L, 1);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("MCategory_Id")
                        .HasColumnType("int");

                    b.Property<string>("SCategoryName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SCategoryId");

                    b.HasIndex("MCategory_Id");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("Financial_DAL.ToDoList", b =>
                {
                    b.Property<Guid>("ListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Assign_Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("Priority_Id")
                        .HasColumnType("int");

                    b.Property<int>("Project_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Statu")
                        .HasColumnType("bit");

                    b.HasKey("ListId");

                    b.HasIndex("Assign_Id");

                    b.HasIndex("Priority_Id");

                    b.HasIndex("Project_Id");

                    b.ToTable("ToDoLists");
                });

            modelBuilder.Entity("Financial_DAL.Transaction", b =>
                {
                    b.Property<Guid>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Address2")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("Category_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("InvoiceID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("Paid")
                        .HasColumnType("bit");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Taxes")
                        .HasColumnType("int");

                    b.Property<int>("Zip")
                        .HasColumnType("int");

                    b.HasKey("TransactionId");

                    b.HasIndex("Category_Id");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Financial_DAL.UserDatabase", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BoyBirthPlace")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("BoyBirthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("BoyName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Comment")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("GirlBirthPlace")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("GirlBirthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("GirlName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("MCategory_Id")
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("SCategory_Id")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("MCategory_Id");

                    b.HasIndex("SCategory_Id");

                    b.ToTable("UserDatabases");
                });

            modelBuilder.Entity("Financial_DAL.Category", b =>
                {
                    b.HasOne("Financial_DAL.Sale", "Sales")
                        .WithMany()
                        .HasForeignKey("Sale_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Financial_DAL.Customer", b =>
                {
                    b.HasOne("Financial_DAL.Source", "Sources")
                        .WithMany()
                        .HasForeignKey("Source_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Financial_DAL.Statu", "Status")
                        .WithMany()
                        .HasForeignKey("Statu_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sources");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Financial_DAL.Payment", b =>
                {
                    b.HasOne("Financial_DAL.Transaction", "Transactions")
                        .WithMany("Payments")
                        .HasForeignKey("Transaction_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Financial_DAL.SubCategory", b =>
                {
                    b.HasOne("Financial_DAL.MainCategory", "MainCategoryies")
                        .WithMany("SubCategories")
                        .HasForeignKey("MCategory_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainCategoryies");
                });

            modelBuilder.Entity("Financial_DAL.ToDoList", b =>
                {
                    b.HasOne("Financial_DAL.Assign", "Assigns")
                        .WithMany()
                        .HasForeignKey("Assign_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Financial_DAL.Priority", "Priority")
                        .WithMany()
                        .HasForeignKey("Priority_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Financial_DAL.Project", "Projects")
                        .WithMany()
                        .HasForeignKey("Project_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assigns");

                    b.Navigation("Priority");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Financial_DAL.Transaction", b =>
                {
                    b.HasOne("Financial_DAL.Category", "Categories")
                        .WithMany()
                        .HasForeignKey("Category_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Financial_DAL.UserDatabase", b =>
                {
                    b.HasOne("Financial_DAL.MainCategory", "MainCategories")
                        .WithMany("UserDatabases")
                        .HasForeignKey("MCategory_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Financial_DAL.SubCategory", "SubCategories")
                        .WithMany("UserDatabases")
                        .HasForeignKey("SCategory_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainCategories");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("Financial_DAL.MainCategory", b =>
                {
                    b.Navigation("SubCategories");

                    b.Navigation("UserDatabases");
                });

            modelBuilder.Entity("Financial_DAL.SubCategory", b =>
                {
                    b.Navigation("UserDatabases");
                });

            modelBuilder.Entity("Financial_DAL.Transaction", b =>
                {
                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
