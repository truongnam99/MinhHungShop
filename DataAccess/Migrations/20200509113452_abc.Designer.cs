﻿// <auto-generated />
using System;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(MinhHungShopContext))]
    [Migration("20200509113452_abc")]
    partial class abc
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccess.Entities.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .HasMaxLength(32)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .HasMaxLength(50);

                    b.Property<bool?>("Status");

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("DataAccess.Entities.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasMaxLength(250);

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<long?>("Idcus")
                        .HasColumnName("IDCus");

                    b.Property<bool?>("Status");

                    b.HasKey("Id");

                    b.HasIndex("Idcus");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("DataAccess.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DisplayOrder");

                    b.Property<string>("Link")
                        .HasMaxLength(250);

                    b.Property<bool?>("Status");

                    b.Property<string>("Target")
                        .HasMaxLength(50);

                    b.Property<string>("Text")
                        .HasMaxLength(50);

                    b.Property<int?>("TypeId")
                        .HasColumnName("TypeID");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("DataAccess.Entities.MenuType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("MenuType");
                });

            modelBuilder.Entity("DataAccess.Entities.OrderDetail", b =>
                {
                    b.Property<long>("OrderId")
                        .HasColumnName("OrderID");

                    b.Property<long>("ProductId")
                        .HasColumnName("ProductID");

                    b.Property<decimal?>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 0)")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("Quantity");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("DataAccess.Entities.Orders", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<long?>("CustomerId")
                        .HasColumnName("CustomerID");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime");

                    b.Property<bool?>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DataAccess.Entities.Producer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Logo")
                        .HasMaxLength(250);

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Producer");
                });

            modelBuilder.Entity("DataAccess.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CategoryId")
                        .HasColumnName("CategoryID");

                    b.Property<string>("Code")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("CodeColor")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<string>("Image")
                        .HasMaxLength(250);

                    b.Property<bool?>("IncludeVat")
                        .HasColumnName("IncludeVAT");

                    b.Property<string>("MetaTitle")
                        .HasMaxLength(250)
                        .IsUnicode(false);

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("MoreImages")
                        .HasColumnType("xml");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 0)")
                        .HasDefaultValueSql("((0))");

                    b.Property<long?>("ProducerId")
                        .HasColumnName("ProducerID");

                    b.Property<decimal?>("PromotionPrice")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<int?>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<bool?>("Status")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<int?>("ViewCount")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProducerId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("DataAccess.Entities.ProductCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("DisplayOrder")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("MetaTitle")
                        .HasMaxLength(250)
                        .IsUnicode(false);

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<long?>("ParentId")
                        .HasColumnName("ParentID");

                    b.Property<bool?>("ShowOnHome")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<bool?>("Status")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.HasKey("Id");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("DataAccess.Entities.ReceivingInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(500);

                    b.Property<long?>("Idcus")
                        .HasColumnName("IDCus");

                    b.Property<string>("Phone")
                        .HasMaxLength(50);

                    b.Property<string>("RecipientName")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("Idcus");

                    b.ToTable("ReceivingInfo");
                });

            modelBuilder.Entity("DataAccess.Entities.SalesReports", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateReport")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("Revenue")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("Id");

                    b.ToTable("SalesReports");
                });

            modelBuilder.Entity("DataAccess.Entities.SystemConfig", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("ID")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<bool?>("Status");

                    b.Property<string>("Type")
                        .HasMaxLength(50);

                    b.Property<string>("Value")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("SystemConfig");
                });

            modelBuilder.Entity("DataAccess.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(500);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .HasMaxLength(32)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .HasMaxLength(50);

                    b.Property<bool?>("Status");

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DataAccess.Entities.Feedback", b =>
                {
                    b.HasOne("DataAccess.Entities.Customer", "IdcusNavigation")
                        .WithMany("Feedback")
                        .HasForeignKey("Idcus")
                        .HasConstraintName("FK_Feedback_Customer");
                });

            modelBuilder.Entity("DataAccess.Entities.Menu", b =>
                {
                    b.HasOne("DataAccess.Entities.MenuType", "Type")
                        .WithMany("Menu")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("FK_Menu_MenuType");
                });

            modelBuilder.Entity("DataAccess.Entities.OrderDetail", b =>
                {
                    b.HasOne("DataAccess.Entities.Orders", "Order")
                        .WithMany("OrderDetail")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_OrderDetail_Orders");

                    b.HasOne("DataAccess.Entities.Product", "Product")
                        .WithMany("OrderDetail")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_OrderDetail_Product");
                });

            modelBuilder.Entity("DataAccess.Entities.Orders", b =>
                {
                    b.HasOne("DataAccess.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Orders_Customer");
                });

            modelBuilder.Entity("DataAccess.Entities.Product", b =>
                {
                    b.HasOne("DataAccess.Entities.ProductCategory", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Product_ProductCategory");

                    b.HasOne("DataAccess.Entities.Producer", "Producer")
                        .WithMany("Product")
                        .HasForeignKey("ProducerId")
                        .HasConstraintName("FK_Product_Producer");
                });

            modelBuilder.Entity("DataAccess.Entities.ReceivingInfo", b =>
                {
                    b.HasOne("DataAccess.Entities.Customer", "IdcusNavigation")
                        .WithMany("ReceivingInfo")
                        .HasForeignKey("Idcus")
                        .HasConstraintName("FK_ReceivingInfo_Customer");
                });
#pragma warning restore 612, 618
        }
    }
}
