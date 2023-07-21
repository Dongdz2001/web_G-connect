﻿// <auto-generated />
using System;
using App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.Data.Migrations
{
    [DbContext(typeof(APPContext))]
    [Migration("20220802010620_InitialAPPContext")]
    partial class InitialAPPContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("App.Data.Models.QTHT.cau_hinh_ma", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("gia_tri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ngay_chinh_sua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ngay_tao")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("nguoi_chinh_sua_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("nguoi_tao_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("nguoi_chinh_sua_id");

                    b.HasIndex("nguoi_tao_id");

                    b.ToTable("qtht_cau_hinh_ma");
                });

            modelBuilder.Entity("App.Data.Models.QTHT.chuc_vu", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ma")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("mo_ta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ngay_chinh_sua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ngay_tao")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("nguoi_chinh_sua_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("nguoi_tao_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("nguoi_chinh_sua_id");

                    b.HasIndex("nguoi_tao_id");

                    b.ToTable("qtht_chuc_vu");
                });

            modelBuilder.Entity("App.Data.Models.QTHT.dieu_huong", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("cap_dieu_huong")
                        .HasColumnType("int");

                    b.Property<Guid?>("dieu_huong_cap_tren_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("duong_dan")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("icon")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool?>("is_quan_tri")
                        .HasColumnType("bit");

                    b.Property<bool>("is_router")
                        .HasColumnType("bit");

                    b.Property<string>("ma")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("mo_ta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("muc_luc")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<DateTime?>("ngay_chinh_sua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ngay_tao")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("nguoi_chinh_sua_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("nguoi_tao_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("so_thu_tu")
                        .HasColumnType("int");

                    b.Property<string>("stt_order")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("super_admin")
                        .HasColumnType("bit");

                    b.Property<string>("ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("dieu_huong_cap_tren_id");

                    b.HasIndex("nguoi_chinh_sua_id");

                    b.HasIndex("nguoi_tao_id");

                    b.ToTable("qtht_dieu_huong");
                });

            modelBuilder.Entity("App.Data.Models.QTHT.file_dinh_kem", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("duong_dan")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<byte[]>("file_finish")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime?>("ngay_chinh_sua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ngay_tao")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("nguoi_chinh_sua_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("nguoi_tao_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("noi_dung_tep")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("noi_dung_tep_pdf")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ten")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("nguoi_chinh_sua_id");

                    b.HasIndex("nguoi_tao_id");

                    b.ToTable("qtht_file_dinh_kem");
                });

            modelBuilder.Entity("App.Data.Models.QTHT.google_config", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("ngay_chinh_sua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ngay_tao")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("nguoi_chinh_sua_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("nguoi_tao_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("refresh_token")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.HasKey("id");

                    b.HasIndex("nguoi_chinh_sua_id");

                    b.HasIndex("nguoi_tao_id");

                    b.ToTable("qtht_google_config");
                });

            modelBuilder.Entity("App.Data.Models.QTHT.nguoi_dung", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("anh_dai_dien_url")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<Guid?>("chuc_vu_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("file_dinh_kem_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("is_dau_moi")
                        .HasColumnType("bit");

                    b.Property<string>("mat_khau")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("ngay_chinh_sua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ngay_tao")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("nguoi_chinh_sua_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("nguoi_tao_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("salt_code")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("so_dien_thoai")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("super_admin")
                        .HasColumnType("bit");

                    b.Property<string>("tai_khoan")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ten")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("trang_thai")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("chuc_vu_id");

                    b.HasIndex("file_dinh_kem_id");

                    b.HasIndex("nguoi_chinh_sua_id");

                    b.HasIndex("nguoi_tao_id");

                    b.ToTable("qtht_nguoi_dung");
                });

            modelBuilder.Entity("App.Data.Models.QTHT.nguoi_dung_2_nhom_nguoi_dung", b =>
                {
                    b.Property<Guid>("nguoi_dung_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("nhom_nguoi_dung_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("nguoi_dung_id", "nhom_nguoi_dung_id");

                    b.HasIndex("nhom_nguoi_dung_id");

                    b.ToTable("qtht_nguoi_dung_2_nhom_nguoi_dung");
                });

            modelBuilder.Entity("App.Data.Models.QTHT.nhat_ky_he_thong", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ban_ghi_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("bang")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("duong_dan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hanh_dong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("is_deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ngay_chinh_sua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ngay_tao")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("nguoi_chinh_sua_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("nguoi_tao_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("nguoi_thuc_hien_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("noi_dung")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("nguoi_chinh_sua_id");

                    b.HasIndex("nguoi_tao_id");

                    b.HasIndex("nguoi_thuc_hien_id");

                    b.ToTable("qtht_nhat_ky_he_thong");
                });

            modelBuilder.Entity("App.Data.Models.QTHT.nhat_ky_he_thong_loai", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("hanh_dong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ngay_chinh_sua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ngay_tao")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("nguoi_chinh_sua_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("nguoi_tao_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ten_hanh_dong")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("nguoi_chinh_sua_id");

                    b.HasIndex("nguoi_tao_id");

                    b.ToTable("qtht_nhat_ky_he_thong_loai");
                });

            modelBuilder.Entity("App.Data.Models.QTHT.nhom_nguoi_dung", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ma")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("mota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ngay_chinh_sua")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ngay_tao")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("nguoi_chinh_sua_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("nguoi_tao_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("nguoi_chinh_sua_id");

                    b.HasIndex("nguoi_tao_id");

                    b.ToTable("qtht_nhom_nguoi_dung");
                });

            modelBuilder.Entity("App.Data.Models.QTHT.nhom_nguoi_dung_2_dieu_huong", b =>
                {
                    b.Property<Guid>("nhom_nguoi_dung_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("dieu_huong_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("nhom_nguoi_dung_id", "dieu_huong_id");

                    b.HasIndex("dieu_huong_id");

                    b.ToTable("qtht_nhom_nguoi_dung_2_dieu_huong");
                });

            modelBuilder.Entity("App.Data.Models.QTHT.cau_hinh_ma", b =>
                {
                    b.HasOne("App.Data.Models.QTHT.nguoi_dung", "nguoi_chinh_sua")
                        .WithMany()
                        .HasForeignKey("nguoi_chinh_sua_id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("App.Data.Models.QTHT.nguoi_dung", "nguoi_tao")
                        .WithMany()
                        .HasForeignKey("nguoi_tao_id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("nguoi_chinh_sua");

                    b.Navigation("nguoi_tao");
                });

            modelBuilder.Entity("App.Data.Models.QTHT.chuc_vu", b =>
                {
                    b.HasOne("App.Data.Models.QTHT.nguoi_dung", "nguoi_chinh_sua")
                        .WithMany()
                        .HasForeignKey("nguoi_chinh_sua_id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("App.Data.Models.QTHT.nguoi_dung", "nguoi_tao")
                        .WithMany()
                        .HasForeignKey("nguoi_tao_id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("nguoi_chinh_sua");

                    b.Navigation("nguoi_tao");
                });

            modelBuilder.Entity("App.Data.Models.QTHT.dieu_huong", b =>
                {
                    b.HasOne("App.Data.Models.QTHT.dieu_huong", "dieu_huong_cap_tren")
                        .WithMany("ds_dieu_huong_cap_duoi")
                        .HasForeignKey("dieu_huong_cap_tren_id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("App.Data.Models.QTHT.nguoi_dung", "nguoi_chinh_sua")
                        .WithMany()
                        .HasForeignKey("nguoi_chinh_sua_id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("App.Data.Models.QTHT.nguoi_dung", "nguoi_tao")
                        .WithMany()
                        .HasForeignKey("nguoi_tao_id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("dieu_huong_cap_tren");

                    b.Navigation("nguoi_chinh_sua");

                    b.Navigation("nguoi_tao");
                });

            modelBuilder.Entity("App.Data.Models.QTHT.file_dinh_kem", b =>
                {
                    b.HasOne("App.Data.Models.QTHT.nguoi_dung", "nguoi_chinh_sua")
                        .WithMany()
                        .HasForeignKey("nguoi_chinh_sua_id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("App.Data.Models.QTHT.nguoi_dung", "nguoi_tao")
                        .WithMany()
                        .HasForeignKey("nguoi_tao_id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("nguoi_chinh_sua");

                    b.Navigation("nguoi_tao");
                });

            modelBuilder.Entity("App.Data.Models.QTHT.google_config", b =>
                {
                    b.HasOne("App.Data.Models.QTHT.nguoi_dung", "nguoi_chinh_sua")
                        .WithMany()
                        .HasForeignKey("nguoi_chinh_sua_id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("App.Data.Models.QTHT.nguoi_dung", "nguoi_tao")
                        .WithMany()
                        .HasForeignKey("nguoi_tao_id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("nguoi_chinh_sua");

                    b.Navigation("nguoi_tao");
                });

            modelBuilder.Entity("App.Data.Models.QTHT.nguoi_dung", b =>
                {
                    b.HasOne("App.Data.Models.QTHT.chuc_vu", "chuc_vu")
                        .WithMany()
                        .HasForeignKey("chuc_vu_id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("App.Data.Models.QTHT.file_dinh_kem", "file_dinh_kem")
                        .WithMany()
                        .HasForeignKey("file_dinh_kem_id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("App.Data.Models.QTHT.nguoi_dung", "nguoi_chinh_sua")
                        .WithMany()
                        .HasForeignKey("nguoi_chinh_sua_id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("App.Data.Models.QTHT.nguoi_dung", "nguoi_tao")
                        .WithMany()
                        .HasForeignKey("nguoi_tao_id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("chuc_vu");

                    b.Navigation("file_dinh_kem");

                    b.Navigation("nguoi_chinh_sua");

                    b.Navigation("nguoi_tao");
                });

            modelBuilder.Entity("App.Data.Models.QTHT.nguoi_dung_2_nhom_nguoi_dung", b =>
                {
                    b.HasOne("App.Data.Models.QTHT.nguoi_dung", "nguoi_dung")
                        .WithMany("ds_nhom_nguoi_dung")
                        .HasForeignKey("nguoi_dung_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Data.Models.QTHT.nhom_nguoi_dung", "nhom_nguoi_dung")
                        .WithMany("ds_nguoi_dung")
                        .HasForeignKey("nhom_nguoi_dung_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("nguoi_dung");

                    b.Navigation("nhom_nguoi_dung");
                });

            modelBuilder.Entity("App.Data.Models.QTHT.nhat_ky_he_thong", b =>
                {
                    b.HasOne("App.Data.Models.QTHT.nguoi_dung", "nguoi_chinh_sua")
                        .WithMany()
                        .HasForeignKey("nguoi_chinh_sua_id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("App.Data.Models.QTHT.nguoi_dung", "nguoi_tao")
                        .WithMany()
                        .HasForeignKey("nguoi_tao_id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("App.Data.Models.QTHT.nguoi_dung", "nguoi_dung")
                        .WithMany()
                        .HasForeignKey("nguoi_thuc_hien_id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("nguoi_chinh_sua");

                    b.Navigation("nguoi_dung");

                    b.Navigation("nguoi_tao");
                });

            modelBuilder.Entity("App.Data.Models.QTHT.nhat_ky_he_thong_loai", b =>
                {
                    b.HasOne("App.Data.Models.QTHT.nguoi_dung", "nguoi_chinh_sua")
                        .WithMany()
                        .HasForeignKey("nguoi_chinh_sua_id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("App.Data.Models.QTHT.nguoi_dung", "nguoi_tao")
                        .WithMany()
                        .HasForeignKey("nguoi_tao_id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("nguoi_chinh_sua");

                    b.Navigation("nguoi_tao");
                });

            modelBuilder.Entity("App.Data.Models.QTHT.nhom_nguoi_dung", b =>
                {
                    b.HasOne("App.Data.Models.QTHT.nguoi_dung", "nguoi_chinh_sua")
                        .WithMany()
                        .HasForeignKey("nguoi_chinh_sua_id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("App.Data.Models.QTHT.nguoi_dung", "nguoi_tao")
                        .WithMany()
                        .HasForeignKey("nguoi_tao_id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("nguoi_chinh_sua");

                    b.Navigation("nguoi_tao");
                });

            modelBuilder.Entity("App.Data.Models.QTHT.nhom_nguoi_dung_2_dieu_huong", b =>
                {
                    b.HasOne("App.Data.Models.QTHT.dieu_huong", "dieu_huong")
                        .WithMany("ds_nhom_nguoi_dung")
                        .HasForeignKey("dieu_huong_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Data.Models.QTHT.nhom_nguoi_dung", "nhom_nguoi_dung")
                        .WithMany("ds_dieu_huong")
                        .HasForeignKey("nhom_nguoi_dung_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("dieu_huong");

                    b.Navigation("nhom_nguoi_dung");
                });

            modelBuilder.Entity("App.Data.Models.QTHT.dieu_huong", b =>
                {
                    b.Navigation("ds_dieu_huong_cap_duoi");

                    b.Navigation("ds_nhom_nguoi_dung");
                });

            modelBuilder.Entity("App.Data.Models.QTHT.nguoi_dung", b =>
                {
                    b.Navigation("ds_nhom_nguoi_dung");
                });

            modelBuilder.Entity("App.Data.Models.QTHT.nhom_nguoi_dung", b =>
                {
                    b.Navigation("ds_dieu_huong");

                    b.Navigation("ds_nguoi_dung");
                });
#pragma warning restore 612, 618
        }
    }
}