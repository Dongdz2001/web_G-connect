using App.Business.Services.QTHT;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using System;
using System.Text;

namespace App.Api.IdentityServer.CussomIdentityServer.BasicAuthHandlers
{
    public class BasicAuthAttribute : TypeFilterAttribute
    {
        
        public BasicAuthAttribute(params string[] claim) : base(typeof(AuthorizeFilter))
        {
            Arguments = new object[] { claim };
        }
    }

    public class AuthorizeFilter : IAuthorizationFilter
    {
        readonly string[] _claim;
        public AuthorizeFilter(params string[] claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var header = context.HttpContext.Request.Headers[HeaderNames.Authorization].ToString();
            if (header != null && header.StartsWith("Basic", StringComparison.OrdinalIgnoreCase))
            {
                var token = header.Substring("Basic ".Length).Trim();
                var credentialstring = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                var credentials = credentialstring.Split(':');
                if (!IsAuthorizedUser(credentials[0], credentials[1]))
                {
                    context.Result = new UnauthorizedResult();
                }
            }
        }

        public bool IsAuthorizedUser(string user_name, string password)
        {
            return false;
        }
    }
}
