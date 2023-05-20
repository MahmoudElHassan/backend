﻿// <auto-generated />
using System;
using Financial_DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Financial_DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .IsRequired()
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
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("LastContact")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NextAction")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("NextContact")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Sales")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Source_Id")
                        .HasColumnType("int");

                    b.Property<int>("Statu_Id")
                        .HasColumnType("int");

                    b.Property<string>("WorkFunction")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CustomerId");

                    b.HasIndex("Source_Id");

                    b.HasIndex("Statu_Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Financial_DAL.Priority", b =>
                {
                    b.Property<int>("PriorityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PriorityId"), 1L, 1);

                    b.Property<string>("PriorityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PriorityId");

                    b.ToTable("Priority");
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

            modelBuilder.Entity("Financial_DAL.ToDoList", b =>
                {
                    b.Property<Guid>("ListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Assign_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority_Id")
                        .HasColumnType("int");

                    b.Property<bool>("Statu")
                        .HasColumnType("bit");

                    b.HasKey("ListId");

                    b.HasIndex("Assign_Id");

                    b.HasIndex("Priority_Id");

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
                        .IsRequired()
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

            modelBuilder.Entity("Financial_DAL.Category", b =>
                {
                    b.HasOne("Financial_DAL.Sale", "Sales")
                        .WithMany("Categories")
                        .HasForeignKey("Sale_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Financial_DAL.Customer", b =>
                {
                    b.HasOne("Financial_DAL.Source", "Sources")
                        .WithMany("Customers")
                        .HasForeignKey("Source_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Financial_DAL.Statu", "Status")
                        .WithMany("Customers")
                        .HasForeignKey("Statu_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sources");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Financial_DAL.ToDoList", b =>
                {
                    b.HasOne("Financial_DAL.Assign", "Assigns")
                        .WithMany("ToDoLists")
                        .HasForeignKey("Assign_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Financial_DAL.Priority", "Priority")
                        .WithMany("ToDoLists")
                        .HasForeignKey("Priority_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assigns");

                    b.Navigation("Priority");
                });

            modelBuilder.Entity("Financial_DAL.Transaction", b =>
                {
                    b.HasOne("Financial_DAL.Category", "Categories")
                        .WithMany("Transactions")
                        .HasForeignKey("Category_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Financial_DAL.Assign", b =>
                {
                    b.Navigation("ToDoLists");
                });

            modelBuilder.Entity("Financial_DAL.Category", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Financial_DAL.Priority", b =>
                {
                    b.Navigation("ToDoLists");
                });

            modelBuilder.Entity("Financial_DAL.Sale", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Financial_DAL.Source", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("Financial_DAL.Statu", b =>
                {
                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
