using App.Data.Models.QTHT;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;

namespace App.Data
{
    public partial class APPContext : DbContext
    {
        //protected APPContext _dbContext;
        protected DbContextOptions<APPContext> options_1;
        public APPContext()
            : base()
        {
        }

        public APPContext(DbContextOptions<APPContext> options)
            : base(options)
        {
            options_1 = options;
        }

        #region Phân hệ quản trị hệ thống
        public DbSet<nguoi_dung> nguoi_dung { get; set; }
        public DbSet<nhom_nguoi_dung> nhom_nguoi_dung { get; set; }
        public DbSet<chuc_vu> chuc_vu { get; set; }
        public DbSet<dieu_huong> dieu_huong { get; set; }
        public DbSet<file_dinh_kem> file_dinh_kem { get; set; }
        public DbSet<google_config> google_config { get; set; }
        public DbSet<nhat_ky_he_thong> nhat_ky_he_thong { get; set; }
        public DbSet<nhat_ky_he_thong_loai> nhat_ky_he_thong_loai { get; set; }
        public DbSet<cau_hinh_ma> cau_hinh_ma { get; set; }
        public DbSet<nguoi_dung_2_nhom_nguoi_dung> nguoi_dung_2_nhom_nguoi_dung { get; set; }
        public DbSet<nhom_nguoi_dung_2_dieu_huong> nhom_nguoi_dung_2_dieu_huong { get; set; }

        //QTHT2

        public DbSet<App.Data.Models.QTHT2.ApiResourceClaims> ApiResourceClaims { get; set; }
        public DbSet<App.Data.Models.QTHT2.ApiResourceProperties> ApiResourceProperties { get; set; }
        public DbSet<App.Data.Models.QTHT2.ApiResources> ApiResources { get; set; }
        public DbSet<App.Data.Models.QTHT2.ApiResourceScopes> ApiResourceScopes { get; set; }
        public DbSet<App.Data.Models.QTHT2.ApiResourceSecrets> ApiResourceSecrets { get; set; }
        public DbSet<App.Data.Models.QTHT2.ApiScopeClaims> ApiScopeClaims { get; set; }
        public DbSet<App.Data.Models.QTHT2.ApiScopeProperties> ApiScopeProperties { get; set; }
        public DbSet<App.Data.Models.QTHT2.ApiScopes> ApiScopes { get; set; }
        public DbSet<App.Data.Models.QTHT2.ClientClaims> ClientClaims { get; set; }
        public DbSet<App.Data.Models.QTHT2.ClientCorsOrigins> ClientCorsOrigins { get; set; }
        public DbSet<App.Data.Models.QTHT2.ClientGrantTypes> ClientGrantTypes { get; set; }
        public DbSet<App.Data.Models.QTHT2.ClientIdPRestrictions> ClientIdPRestrictions { get; set; }
        public DbSet<App.Data.Models.QTHT2.ClientPostLogoutRedirectUris> ClientPostLogoutRedirectUris { get; set; }
        public DbSet<App.Data.Models.QTHT2.ClientProperties> ClientProperties { get; set; }
        public DbSet<App.Data.Models.QTHT2.ClientRedirectUris> ClientRedirectUris { get; set; }
        public DbSet<App.Data.Models.QTHT2.Clients> Clients { get; set; }
        public DbSet<App.Data.Models.QTHT2.ClientScopes> ClientScopes { get; set; }
        public DbSet<App.Data.Models.QTHT2.ClientSecrets> ClientSecrets { get; set; }
        public DbSet<App.Data.Models.QTHT2.DeviceCodes> DeviceCodes { get; set; }
        public DbSet<App.Data.Models.QTHT2.IdentityResourceClaims> IdentityResourceClaims { get; set; }
        public DbSet<App.Data.Models.QTHT2.IdentityResourceProperties> IdentityResourceProperties { get; set; }
        public DbSet<App.Data.Models.QTHT2.IdentityResources> IdentityResources { get; set; }
        public DbSet<App.Data.Models.QTHT2.PersistedGrants> PersistedGrants { get; set; }

		
        public DbSet<App.Data.Models.DBAll.GC_CHUC_NANG> GC_CHUC_NANG { get; set; }
        public DbSet<App.Data.Models.DBAll.GC_CONG_VIEC> GC_CONG_VIEC { get; set; }
        public DbSet<App.Data.Models.DBAll.GC_CONG_VIEC_CHECKLIST> GC_CONG_VIEC_CHECKLIST { get; set; }
        public DbSet<App.Data.Models.DBAll.GC_CONG_VIEC_PHAN_CONG> GC_CONG_VIEC_PHAN_CONG { get; set; }
        public DbSet<App.Data.Models.DBAll.GC_DM_LINH_VUC> GC_DM_LINH_VUC { get; set; }
        public DbSet<App.Data.Models.DBAll.GC_DM_LOAI_CHECK_LIST> GC_DM_LOAI_CHECK_LIST { get; set; }
        public DbSet<App.Data.Models.DBAll.GC_DM_LOAI_DU_AN> GC_DM_LOAI_DU_AN { get; set; }
        public DbSet<App.Data.Models.DBAll.GC_DM_TRANG_THAI> GC_DM_TRANG_THAI { get; set; }
        public DbSet<App.Data.Models.DBAll.GC_DU_AN> GC_DU_AN { get; set; }
        public DbSet<App.Data.Models.DBAll.GC_LICH_HANG_NGAY> GC_LICH_HANG_NGAY { get; set; }
        public DbSet<App.Data.Models.DBAll.GC_LICH_TUAN> GC_LICH_TUAN { get; set; }
        public DbSet<App.Data.Models.DBAll.GC_VAN_DE_CAN_GIAI_QUYET> GC_VAN_DE_CAN_GIAI_QUYET { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region người dùng    
            modelBuilder.Entity<nguoi_dung>()
                .HasOne(e => e.nguoi_tao)
                .WithMany()
                .HasForeignKey(e => e.nguoi_tao_id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<nguoi_dung>()
                .HasOne(e => e.nguoi_chinh_sua)
                .WithMany()
                .HasForeignKey(e => e.nguoi_chinh_sua_id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<nguoi_dung>()
                .HasOne(e => e.chuc_vu)
                .WithMany()
                .HasForeignKey(e => e.chuc_vu_id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<nguoi_dung>()
              .HasOne(e => e.file_dinh_kem)
              .WithMany()
              .HasForeignKey(e => e.file_dinh_kem_id)
              .OnDelete(DeleteBehavior.SetNull);
            #endregion

            #region nhật ký hệ thống
            modelBuilder.Entity<nhat_ky_he_thong>()
                .HasOne(e => e.nguoi_tao)
                .WithMany()
                .HasForeignKey(e => e.nguoi_tao_id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<nhat_ky_he_thong>()
                .HasOne(e => e.nguoi_chinh_sua)
                .WithMany()
                .HasForeignKey(e => e.nguoi_chinh_sua_id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<nhat_ky_he_thong>()
                .HasOne(e => e.nguoi_dung)
                .WithMany()
                .HasForeignKey(e => e.nguoi_thuc_hien_id)
                .OnDelete(DeleteBehavior.SetNull);
            #endregion

            #region nhật ký hệ thống loại
            modelBuilder.Entity<nhat_ky_he_thong_loai>()
                .HasOne(e => e.nguoi_tao)
                .WithMany()
                .HasForeignKey(e => e.nguoi_tao_id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<nhat_ky_he_thong_loai>()
                .HasOne(e => e.nguoi_chinh_sua)
                .WithMany()
                .HasForeignKey(e => e.nguoi_chinh_sua_id)
                .OnDelete(DeleteBehavior.SetNull);
            #endregion

            #region nhóm người dùng
            modelBuilder.Entity<nhom_nguoi_dung>()
                .HasOne(e => e.nguoi_tao)
                .WithMany()
                .HasForeignKey(e => e.nguoi_tao_id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<nhom_nguoi_dung>()
                .HasOne(e => e.nguoi_chinh_sua)
                .WithMany()
                .HasForeignKey(e => e.nguoi_chinh_sua_id)
                .OnDelete(DeleteBehavior.SetNull);
            #endregion

            #region nguoi_dung_2_nhom_nguoi_dung
            modelBuilder.Entity<nguoi_dung_2_nhom_nguoi_dung>()
                .HasKey(e => new { e.nguoi_dung_id, e.nhom_nguoi_dung_id });
            modelBuilder.Entity<nguoi_dung_2_nhom_nguoi_dung>()
                .HasOne(e => e.nguoi_dung)
                .WithMany(e => e.ds_nhom_nguoi_dung)
                .HasForeignKey(e => e.nguoi_dung_id)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<nguoi_dung_2_nhom_nguoi_dung>()
                .HasOne(e => e.nhom_nguoi_dung)
                .WithMany(e => e.ds_nguoi_dung)
                .HasForeignKey(e => e.nhom_nguoi_dung_id)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region nhom_nguoi_dung_2_dieu_huong
            modelBuilder.Entity<nhom_nguoi_dung_2_dieu_huong>()
                .HasKey(e => new { e.nhom_nguoi_dung_id, e.dieu_huong_id });
            modelBuilder.Entity<nhom_nguoi_dung_2_dieu_huong>()
                .HasOne(e => e.nhom_nguoi_dung)
                .WithMany(e => e.ds_dieu_huong)
                .HasForeignKey(e => e.nhom_nguoi_dung_id)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<nhom_nguoi_dung_2_dieu_huong>()
                .HasOne(e => e.dieu_huong)
                .WithMany(e => e.ds_nhom_nguoi_dung)
                .HasForeignKey(e => e.dieu_huong_id)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region chức vụ
            modelBuilder.Entity<chuc_vu>()
                .HasOne(e => e.nguoi_tao)
                .WithMany()
                .HasForeignKey(e => e.nguoi_tao_id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<chuc_vu>()
                .HasOne(e => e.nguoi_chinh_sua)
                .WithMany()
                .HasForeignKey(e => e.nguoi_chinh_sua_id)
                .OnDelete(DeleteBehavior.SetNull);
            #endregion

            #region dieu_huong
            modelBuilder.Entity<dieu_huong>()
                .HasOne(e => e.nguoi_tao)
                .WithMany()
                .HasForeignKey(e => e.nguoi_tao_id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<dieu_huong>()
                .HasOne(e => e.nguoi_chinh_sua)
                .WithMany()
                .HasForeignKey(e => e.nguoi_chinh_sua_id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<dieu_huong>()
                 .HasOne(e => e.dieu_huong_cap_tren)
                 .WithMany(e => e.ds_dieu_huong_cap_duoi)
                 .HasForeignKey(e => e.dieu_huong_cap_tren_id)
                 .OnDelete(DeleteBehavior.SetNull);
            #endregion

            #region file dinh kem
            modelBuilder.Entity<file_dinh_kem>()
               .HasOne(e => e.nguoi_tao)
               .WithMany()
               .HasForeignKey(e => e.nguoi_tao_id)
               .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<file_dinh_kem>()
                .HasOne(e => e.nguoi_chinh_sua)
                .WithMany()
                .HasForeignKey(e => e.nguoi_chinh_sua_id)
                .OnDelete(DeleteBehavior.SetNull);
            #endregion

            #region googleconfig
            modelBuilder.Entity<google_config>()
               .HasOne(e => e.nguoi_tao)
               .WithMany()
               .HasForeignKey(e => e.nguoi_tao_id)
               .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<google_config>()
                .HasOne(e => e.nguoi_chinh_sua)
                .WithMany()
                .HasForeignKey(e => e.nguoi_chinh_sua_id)
                .OnDelete(DeleteBehavior.SetNull);
            #endregion

            #region cấu hình mã động
            modelBuilder.Entity<cau_hinh_ma>()
                .HasOne(e => e.nguoi_tao)
                .WithMany()
                .HasForeignKey(e => e.nguoi_tao_id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<cau_hinh_ma>()
                .HasOne(e => e.nguoi_chinh_sua)
                .WithMany()
                .HasForeignKey(e => e.nguoi_chinh_sua_id)
                .OnDelete(DeleteBehavior.SetNull);
            #endregion



            modelBuilder.Entity<App.Data.Models.DBAll.GC_CHUC_NANG>()
                .HasOne(e => e.nguoi_tao)
                .WithMany()
                .HasForeignKey(e => e.nguoi_tao_id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<App.Data.Models.DBAll.GC_CHUC_NANG>()
                .HasOne(e => e.nguoi_chinh_sua)
                .WithMany()
                .HasForeignKey(e => e.nguoi_chinh_sua_id)
                .OnDelete(DeleteBehavior.SetNull);
            //Add ref of baseField to GC_CHUC_NANG
            //addBaseForeignKey<App.Data.Models.DBAll.GC_CHUC_NANG>(modelBuilder);

            modelBuilder.Entity<App.Data.Models.DBAll.GC_CONG_VIEC>()
                .HasOne(e => e.nguoi_tao)
                .WithMany()
                .HasForeignKey(e => e.nguoi_tao_id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<App.Data.Models.DBAll.GC_CONG_VIEC>()
                .HasOne(e => e.nguoi_chinh_sua)
                .WithMany()
                .HasForeignKey(e => e.nguoi_chinh_sua_id)
                .OnDelete(DeleteBehavior.SetNull);
            //Add ref of baseField to GC_CONG_VIEC
            //addBaseForeignKey<App.Data.Models.DBAll.GC_CONG_VIEC>(modelBuilder);

            modelBuilder.Entity<App.Data.Models.DBAll.GC_CONG_VIEC_CHECKLIST>()
                .HasOne(e => e.nguoi_tao)
                .WithMany()
                .HasForeignKey(e => e.nguoi_tao_id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<App.Data.Models.DBAll.GC_CONG_VIEC_CHECKLIST>()
                .HasOne(e => e.nguoi_chinh_sua)
                .WithMany()
                .HasForeignKey(e => e.nguoi_chinh_sua_id)
                .OnDelete(DeleteBehavior.SetNull);
            //Add ref of baseField to GC_CONG_VIEC_CHECKLIST
            //addBaseForeignKey<App.Data.Models.DBAll.GC_CONG_VIEC_CHECKLIST>(modelBuilder);

            modelBuilder.Entity<App.Data.Models.DBAll.GC_CONG_VIEC_PHAN_CONG>()
                .HasOne(e => e.nguoi_tao)
                .WithMany()
                .HasForeignKey(e => e.nguoi_tao_id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<App.Data.Models.DBAll.GC_CONG_VIEC_PHAN_CONG>()
                .HasOne(e => e.nguoi_chinh_sua)
                .WithMany()
                .HasForeignKey(e => e.nguoi_chinh_sua_id)
                .OnDelete(DeleteBehavior.SetNull);
            //Add ref of baseField to GC_CONG_VIEC_PHAN_CONG
            //addBaseForeignKey<App.Data.Models.DBAll.GC_CONG_VIEC_PHAN_CONG>(modelBuilder);

            modelBuilder.Entity<App.Data.Models.DBAll.GC_DM_LINH_VUC>()
                .HasOne(e => e.nguoi_tao)
                .WithMany()
                .HasForeignKey(e => e.nguoi_tao_id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<App.Data.Models.DBAll.GC_DM_LINH_VUC>()
                .HasOne(e => e.nguoi_chinh_sua)
                .WithMany()
                .HasForeignKey(e => e.nguoi_chinh_sua_id)
                .OnDelete(DeleteBehavior.SetNull);
            //Add ref of baseField to GC_DM_LINH_VUC
            //addBaseForeignKey<App.Data.Models.DBAll.GC_DM_LINH_VUC>(modelBuilder);

            modelBuilder.Entity<App.Data.Models.DBAll.GC_DM_LOAI_CHECK_LIST>()
                .HasOne(e => e.nguoi_tao)
                .WithMany()
                .HasForeignKey(e => e.nguoi_tao_id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<App.Data.Models.DBAll.GC_DM_LOAI_CHECK_LIST>()
                .HasOne(e => e.nguoi_chinh_sua)
                .WithMany()
                .HasForeignKey(e => e.nguoi_chinh_sua_id)
                .OnDelete(DeleteBehavior.SetNull);
            //Add ref of baseField to GC_DM_LOAI_CHECK_LIST
            //addBaseForeignKey<App.Data.Models.DBAll.GC_DM_LOAI_CHECK_LIST>(modelBuilder);

            modelBuilder.Entity<App.Data.Models.DBAll.GC_DM_LOAI_DU_AN>()
                .HasOne(e => e.nguoi_tao)
                .WithMany()
                .HasForeignKey(e => e.nguoi_tao_id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<App.Data.Models.DBAll.GC_DM_LOAI_DU_AN>()
                .HasOne(e => e.nguoi_chinh_sua)
                .WithMany()
                .HasForeignKey(e => e.nguoi_chinh_sua_id)
                .OnDelete(DeleteBehavior.SetNull);
            //Add ref of baseField to GC_DM_LOAI_DU_AN
            //addBaseForeignKey<App.Data.Models.DBAll.GC_DM_LOAI_DU_AN>(modelBuilder);

            modelBuilder.Entity<App.Data.Models.DBAll.GC_DM_TRANG_THAI>()
                .HasOne(e => e.nguoi_tao)
                .WithMany()
                .HasForeignKey(e => e.nguoi_tao_id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<App.Data.Models.DBAll.GC_DM_TRANG_THAI>()
                .HasOne(e => e.nguoi_chinh_sua)
                .WithMany()
                .HasForeignKey(e => e.nguoi_chinh_sua_id)
                .OnDelete(DeleteBehavior.SetNull);
            //Add ref of baseField to GC_DM_TRANG_THAI
            //addBaseForeignKey<App.Data.Models.DBAll.GC_DM_TRANG_THAI>(modelBuilder);

            modelBuilder.Entity<App.Data.Models.DBAll.GC_DU_AN>()
                .HasOne(e => e.nguoi_tao)
                .WithMany()
                .HasForeignKey(e => e.nguoi_tao_id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<App.Data.Models.DBAll.GC_DU_AN>()
                .HasOne(e => e.nguoi_chinh_sua)
                .WithMany()
                .HasForeignKey(e => e.nguoi_chinh_sua_id)
                .OnDelete(DeleteBehavior.SetNull);
            //Add ref of baseField to GC_DU_AN
            //addBaseForeignKey<App.Data.Models.DBAll.GC_DU_AN>(modelBuilder);

            modelBuilder.Entity<App.Data.Models.DBAll.GC_LICH_HANG_NGAY>()
                .HasOne(e => e.nguoi_tao)
                .WithMany()
                .HasForeignKey(e => e.nguoi_tao_id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<App.Data.Models.DBAll.GC_LICH_HANG_NGAY>()
                .HasOne(e => e.nguoi_chinh_sua)
                .WithMany()
                .HasForeignKey(e => e.nguoi_chinh_sua_id)
                .OnDelete(DeleteBehavior.SetNull);
            //Add ref of baseField to GC_LICH_HANG_NGAY
            //addBaseForeignKey<App.Data.Models.DBAll.GC_LICH_HANG_NGAY>(modelBuilder);

            modelBuilder.Entity<App.Data.Models.DBAll.GC_LICH_TUAN>()
                .HasOne(e => e.nguoi_tao)
                .WithMany()
                .HasForeignKey(e => e.nguoi_tao_id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<App.Data.Models.DBAll.GC_LICH_TUAN>()
                .HasOne(e => e.nguoi_chinh_sua)
                .WithMany()
                .HasForeignKey(e => e.nguoi_chinh_sua_id)
                .OnDelete(DeleteBehavior.SetNull);
            //Add ref of baseField to GC_LICH_TUAN
            //addBaseForeignKey<App.Data.Models.DBAll.GC_LICH_TUAN>(modelBuilder);

            modelBuilder.Entity<App.Data.Models.DBAll.GC_VAN_DE_CAN_GIAI_QUYET>()
                .HasOne(e => e.nguoi_tao)
                .WithMany()
                .HasForeignKey(e => e.nguoi_tao_id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<App.Data.Models.DBAll.GC_VAN_DE_CAN_GIAI_QUYET>()
                .HasOne(e => e.nguoi_chinh_sua)
                .WithMany()
                .HasForeignKey(e => e.nguoi_chinh_sua_id)
                .OnDelete(DeleteBehavior.SetNull);
            //Add ref of baseField to GC_VAN_DE_CAN_GIAI_QUYET
            //addBaseForeignKey<App.Data.Models.DBAll.GC_VAN_DE_CAN_GIAI_QUYET>(modelBuilder);


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}