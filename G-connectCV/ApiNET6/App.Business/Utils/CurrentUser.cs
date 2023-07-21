using App.Business.Services.QTHT;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace App.Business.Utils
{
    public static class AppHelpers
    {
        private static IHttpContextAccessor httpContextAccessor;
        public static void SetHttpContextAccessor(IHttpContextAccessor accessor)
        {
            httpContextAccessor = accessor;
        }
        private static string getClaim(this ClaimsIdentity user, string claimType)
        {
            var temp = user.FindFirst(claimType);
            return temp != null ? temp.Value : null;
        }
        public static NguoiDungDTO GetCurrentUser()
        {
            var currentUser = new NguoiDungDTO();
            try
            {
                var curUser = (ClaimsIdentity)httpContextAccessor.HttpContext.User.Identity;

               
                if (curUser != null)
                {
          
                    currentUser.id = new Guid(curUser.getClaim("id"));
                    currentUser.tai_khoan = curUser.getClaim("tai_khoan");
                    currentUser.ten = curUser.getClaim("ten");
                    currentUser.email = curUser.getClaim("email");
                    currentUser.so_dien_thoai = curUser.getClaim("so_dien_thoai");
                    currentUser.super_admin = Convert.ToBoolean(curUser.getClaim("super_admin"));
                }
            }
            catch (Exception ex)
            {
            }
            return currentUser;
        }
    }
}
