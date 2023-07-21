using App.Business.Services.QTHT;
using App.Common.Base;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServerHost.Quickstart.UI
{
    public class CustomResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly INguoiDungService _nguoiDungService;

        public CustomResourceOwnerPasswordValidator(
            INguoiDungService nguoiDungService
            )
        {
            _nguoiDungService = nguoiDungService;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {

            try
            {
                var nguoiDung = _nguoiDungService.XacThucDangNhap(context.UserName, context.Password);
                Dictionary<string, object> customResponse = new Dictionary<string, object>();
                customResponse.Add("user_info", nguoiDung);
                context.Result = new GrantValidationResult(nguoiDung.id.ToString(), OidcConstants.AuthenticationMethods.Password, null, "local", customResponse);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, err.description);
            }
            return Task.FromResult(0);
        }
    }
}
