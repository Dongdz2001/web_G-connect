using App.Business.Services.QTHT;
using App.Common.Base;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace IdentityServerHost.Quickstart.UI
{
    public class CustomProfileService : IProfileService
    {
        //protected readonly ILogger Logger;


        protected readonly INguoiDungService _nguoiDungService;

        public CustomProfileService(
            INguoiDungService nguoiDungService
            //, ILogger<CustomProfileService> logger
            )
        {
            _nguoiDungService = nguoiDungService;
            //Logger = logger;
            //map đơn vị - lấy id văn phòng
        }


        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var userID = new Guid(context.Subject.GetSubjectId());
          
            var user = await _nguoiDungService.GetByIdAsync<NguoiDungDTO>(userID);

            var claims = new List<Claim>
            {
                new Claim("id", user.id.ToString()),
                new Claim("tai_khoan", user.tai_khoan),
                new Claim("ten", user.ten),
                new Claim("super_admin", user.super_admin.ToString()),
                new Claim("email", user.email??""),
                new Claim("so_dien_thoai", user.so_dien_thoai??""),
                new Claim("nhom_nguoi_dung", user.ds_nhomnguoidung != null? string.Join(",", user.ds_nhomnguoidung.Select(x => x.ma).ToList()) : ""),
                new Claim("anh_dai_dien_url", user.anh_dai_dien_url??""),
                new Claim("is_cvptckt", (user.ds_nhomnguoidung != null && user.ds_nhomnguoidung.Where(x=>x.ma == AppConst.MA_CVPTCKT).Any()) ? "True" : "False")
            };

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var userID = new Guid(context.Subject.GetSubjectId());
            var user = await _nguoiDungService.GetByIdAsync<NguoiDungDTO>(userID);
            context.IsActive = user != null;
        }
    }
}