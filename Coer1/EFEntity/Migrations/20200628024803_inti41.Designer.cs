﻿// <auto-generated />
using EFEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFEntity.Migrations
{
    [DbContext(typeof(TescDbContext))]
    [Migration("20200628024803_inti41")]
    partial class inti41
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFEntity.config_file_first_kind", b =>
                {
                    b.Property<int>("ffk_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("first_kind_id")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("first_kind_name")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("first_kind_salary_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first_kind_sale_id")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ffk_id");

                    b.ToTable("config_file_first_kind");
                });

            modelBuilder.Entity("EFEntity.config_file_second_kind", b =>
                {
                    b.Property<int>("fsk_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("first_kind_id")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("first_kind_name")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("second_kind_id")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("second_kind_name")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("second_salary_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("second_sale_id")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("fsk_id");

                    b.ToTable("config_file_second_kind");
                });

            modelBuilder.Entity("EFEntity.config_file_third_kind", b =>
                {
                    b.Property<int>("ftk_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("first_kind_id")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("first_kind_name")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("second_kind_id")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("second_kind_name")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("third_kind_id")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("third_kind_is_retail")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("third_kind_name")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("third_kind_sale_id")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ftk_id");

                    b.ToTable("config_file_third_kind");
                });

            modelBuilder.Entity("EFEntity.config_major", b =>
                {
                    b.Property<int>("mak_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("major_id")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("major_kind_id")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("major_kind_name")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("major_name")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<int>("test_amount")
                        .HasColumnType("int")
                        .HasMaxLength(2);

                    b.HasKey("mak_id");

                    b.ToTable("config_major");
                });

            modelBuilder.Entity("EFEntity.config_major_kind", b =>
                {
                    b.Property<int>("mfk_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("major_kind_id")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("major_kind_name")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("mfk_id");

                    b.ToTable("config_major_kind");
                });

            modelBuilder.Entity("EFEntity.config_public_char", b =>
                {
                    b.Property<int>("pbc_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("attribute_kind")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("attribute_name")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("pbc_id");

                    b.ToTable("config_public_char");
                });
#pragma warning restore 612, 618
        }
    }
}
