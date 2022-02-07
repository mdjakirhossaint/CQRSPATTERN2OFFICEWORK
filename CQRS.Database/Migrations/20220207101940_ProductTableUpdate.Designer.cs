﻿// <auto-generated />
using System;
using CQRS.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CQRS.Database.Migrations
{
    [DbContext(typeof(CQRSContext))]
    [Migration("20220207101940_ProductTableUpdate")]
    partial class ProductTableUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CQRS.Database.Entities.TblBrand", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("CQRS.Database.Entities.TblCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryName")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CQRS.Database.Entities.TblProduct", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TblBrandID")
                        .HasColumnType("int");

                    b.Property<int?>("TblCategoryID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Model")
                        .IsUnique();

                    b.HasIndex("TblBrandID");

                    b.HasIndex("TblCategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CQRS.Database.Entities.TblProduct", b =>
                {
                    b.HasOne("CQRS.Database.Entities.TblBrand", "TblBrand")
                        .WithMany()
                        .HasForeignKey("TblBrandID");

                    b.HasOne("CQRS.Database.Entities.TblCategory", "TblCategory")
                        .WithMany()
                        .HasForeignKey("TblCategoryID");

                    b.Navigation("TblBrand");

                    b.Navigation("TblCategory");
                });
#pragma warning restore 612, 618
        }
    }
}
