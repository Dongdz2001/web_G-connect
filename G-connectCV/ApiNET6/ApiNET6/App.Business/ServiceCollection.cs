using App.Business.Services;
using App.Business.Services.QTHT;
using App.Data;
//using LibreOffice.Services.Api.Conversions;
using Microsoft.Extensions.DependencyInjection;

namespace App.Business
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddAppBusinessLibrary(this IServiceCollection services)
        {

            services.AddAppDataLibrary();
            services.AddScoped<INguoiDungService, NguoiDungService>();
            services.AddScoped<INhomNguoiDungService, NhomNguoiDungService>();
            services.AddScoped<IChucVuService, ChucVuService>();
            services.AddScoped<IDieuHuongService, DieuHuongService>();
            services.AddScoped<IGoogleConfigService, GoogleConfigService>();
            services.AddScoped<INhatKyHeThongService, NhatKyHeThongService>();
            services.AddScoped<IFileDinhKemService, FileDinhKemService>();

            //QTHT2
            services.AddScoped<App.Business.Services.QTHT2.ApiResourceClaimsIService, App.Business.Services.QTHT2.ApiResourceClaimsService>();
            services.AddScoped<App.Business.Services.QTHT2.ApiResourcePropertiesIService, App.Business.Services.QTHT2.ApiResourcePropertiesService>();
            services.AddScoped<App.Business.Services.QTHT2.ApiResourcesIService, App.Business.Services.QTHT2.ApiResourcesService>();
            services.AddScoped<App.Business.Services.QTHT2.ApiResourceScopesIService, App.Business.Services.QTHT2.ApiResourceScopesService>();
            services.AddScoped<App.Business.Services.QTHT2.ApiResourceSecretsIService, App.Business.Services.QTHT2.ApiResourceSecretsService>();
            services.AddScoped<App.Business.Services.QTHT2.ApiScopeClaimsIService, App.Business.Services.QTHT2.ApiScopeClaimsService>();
            services.AddScoped<App.Business.Services.QTHT2.ApiScopePropertiesIService, App.Business.Services.QTHT2.ApiScopePropertiesService>();
            services.AddScoped<App.Business.Services.QTHT2.ApiScopesIService, App.Business.Services.QTHT2.ApiScopesService>();
            services.AddScoped<App.Business.Services.QTHT2.ClientClaimsIService, App.Business.Services.QTHT2.ClientClaimsService>();
            services.AddScoped<App.Business.Services.QTHT2.ClientCorsOriginsIService, App.Business.Services.QTHT2.ClientCorsOriginsService>();
            services.AddScoped<App.Business.Services.QTHT2.ClientGrantTypesIService, App.Business.Services.QTHT2.ClientGrantTypesService>();
            services.AddScoped<App.Business.Services.QTHT2.ClientIdPRestrictionsIService, App.Business.Services.QTHT2.ClientIdPRestrictionsService>();
            services.AddScoped<App.Business.Services.QTHT2.ClientPostLogoutRedirectUrisIService, App.Business.Services.QTHT2.ClientPostLogoutRedirectUrisService>();
            services.AddScoped<App.Business.Services.QTHT2.ClientPropertiesIService, App.Business.Services.QTHT2.ClientPropertiesService>();
            services.AddScoped<App.Business.Services.QTHT2.ClientRedirectUrisIService, App.Business.Services.QTHT2.ClientRedirectUrisService>();
            services.AddScoped<App.Business.Services.QTHT2.ClientsIService, App.Business.Services.QTHT2.ClientsService>();
            services.AddScoped<App.Business.Services.QTHT2.ClientScopesIService, App.Business.Services.QTHT2.ClientScopesService>();
            services.AddScoped<App.Business.Services.QTHT2.ClientSecretsIService, App.Business.Services.QTHT2.ClientSecretsService>();
            services.AddScoped<App.Business.Services.QTHT2.DeviceCodesIService, App.Business.Services.QTHT2.DeviceCodesService>();
            services.AddScoped<App.Business.Services.QTHT2.IdentityResourceClaimsIService, App.Business.Services.QTHT2.IdentityResourceClaimsService>();
            services.AddScoped<App.Business.Services.QTHT2.IdentityResourcePropertiesIService, App.Business.Services.QTHT2.IdentityResourcePropertiesService>();
            services.AddScoped<App.Business.Services.QTHT2.IdentityResourcesIService, App.Business.Services.QTHT2.IdentityResourcesService>();
            services.AddScoped<App.Business.Services.QTHT2.PersistedGrantsIService, App.Business.Services.QTHT2.PersistedGrantsService>();
            services.AddScoped<App.Business.Services.QTHT2.qtht_cau_hinh_maIService, App.Business.Services.QTHT2.qtht_cau_hinh_maService>();
            services.AddScoped<App.Business.Services.QTHT2.qtht_chuc_vuIService, App.Business.Services.QTHT2.qtht_chuc_vuService>();
            services.AddScoped<App.Business.Services.QTHT2.qtht_dieu_huongIService, App.Business.Services.QTHT2.qtht_dieu_huongService>();
            services.AddScoped<App.Business.Services.QTHT2.qtht_file_dinh_kemIService, App.Business.Services.QTHT2.qtht_file_dinh_kemService>();
            services.AddScoped<App.Business.Services.QTHT2.qtht_google_configIService, App.Business.Services.QTHT2.qtht_google_configService>();
            services.AddScoped<App.Business.Services.QTHT2.qtht_nguoi_dungIService, App.Business.Services.QTHT2.qtht_nguoi_dungService>();
            services.AddScoped<App.Business.Services.QTHT2.qtht_nguoi_dung_2_nhom_nguoi_dungIService, App.Business.Services.QTHT2.qtht_nguoi_dung_2_nhom_nguoi_dungService>();
            services.AddScoped<App.Business.Services.QTHT2.qtht_nhat_ky_he_thongIService, App.Business.Services.QTHT2.qtht_nhat_ky_he_thongService>();
            services.AddScoped<App.Business.Services.QTHT2.qtht_nhat_ky_he_thong_loaiIService, App.Business.Services.QTHT2.qtht_nhat_ky_he_thong_loaiService>();
            services.AddScoped<App.Business.Services.QTHT2.qtht_nhom_nguoi_dungIService, App.Business.Services.QTHT2.qtht_nhom_nguoi_dungService>();
            services.AddScoped<App.Business.Services.QTHT2.qtht_nhom_nguoi_dung_2_dieu_huongIService, App.Business.Services.QTHT2.qtht_nhom_nguoi_dung_2_dieu_huongService>();


            services.AddScoped<App.Business.Services.DBAll.GC_CHUC_NANGIService, App.Business.Services.DBAll.GC_CHUC_NANGService>();
            services.AddScoped<App.Business.Services.DBAll.GC_CONG_VIECIService, App.Business.Services.DBAll.GC_CONG_VIECService>();
            services.AddScoped<App.Business.Services.DBAll.GC_CONG_VIEC_CHECKLISTIService, App.Business.Services.DBAll.GC_CONG_VIEC_CHECKLISTService>();
            services.AddScoped<App.Business.Services.DBAll.GC_CONG_VIEC_PHAN_CONGIService, App.Business.Services.DBAll.GC_CONG_VIEC_PHAN_CONGService>();
            services.AddScoped<App.Business.Services.DBAll.GC_DM_LINH_VUCIService, App.Business.Services.DBAll.GC_DM_LINH_VUCService>();
            services.AddScoped<App.Business.Services.DBAll.GC_DM_LOAI_CHECK_LISTIService, App.Business.Services.DBAll.GC_DM_LOAI_CHECK_LISTService>();
            services.AddScoped<App.Business.Services.DBAll.GC_DM_LOAI_DU_ANIService, App.Business.Services.DBAll.GC_DM_LOAI_DU_ANService>();
            services.AddScoped<App.Business.Services.DBAll.GC_DM_TRANG_THAIIService, App.Business.Services.DBAll.GC_DM_TRANG_THAIService>();
            services.AddScoped<App.Business.Services.DBAll.GC_DU_ANIService, App.Business.Services.DBAll.GC_DU_ANService>();
            services.AddScoped<App.Business.Services.DBAll.GC_LICH_HANG_NGAYIService, App.Business.Services.DBAll.GC_LICH_HANG_NGAYService>();
            services.AddScoped<App.Business.Services.DBAll.GC_LICH_TUANIService, App.Business.Services.DBAll.GC_LICH_TUANService>();
            services.AddScoped<App.Business.Services.DBAll.GC_VAN_DE_CAN_GIAI_QUYETIService, App.Business.Services.DBAll.GC_VAN_DE_CAN_GIAI_QUYETService>();

            return services;
        }
    }
}
