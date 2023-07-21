using App.Business.Services.QTHT;
using App.Business.Utils;
using App.Common.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Controllers.QTHT
{
    /// <summary>
    /// QTHT - tiểu mục
    /// </summary>
    [Route("api/qtht-google-api")]
    //phongnhxxx [AuthorizeApi]
    [ApiController]
    public class QTHT_GoogleApiController : ControllerBase
    {
        private readonly IGoogleConfigService _service;

        public QTHT_GoogleApiController(IGoogleConfigService service)
        {
            _service = service;
        }

        #region Setting

        [HttpGet]
        [Route("setting")]
        public async Task<ActionResult> Setting(string auth_code)
        {
            try
            {

                var googleApi = new GoogleApiHandler();
                var resultToken = googleApi.GetTokenGoogleByAuthcode(auth_code);
                if (!string.IsNullOrEmpty(resultToken.refresh_token))
                {
                    // laay dia chi email
                    var token = resultToken.id_token;
                    var handler = new JwtSecurityTokenHandler();
                    var tokenS = handler.ReadToken(token) as JwtSecurityToken;
                    var claims = tokenS.Claims;
                    var email_Claims = tokenS.Claims.FirstOrDefault(claim => claim.Type.ToLower() == "email");
                    var email = email_Claims != null ? email_Claims.Value : null;

                    var googleConfig = new GoogleConfigDTO()
                    {
                        email = email,
                        refresh_token = resultToken.refresh_token
                    };
                    var test = await _service.GetManyAsync<GoogleConfigDTO>(1, 0, null);
                    var old = test.data.FirstOrDefault();
                    if (old == null)
                    {
                        var result = await _service.CreateAsync<GoogleConfigDTO>(googleConfig);
                        return Ok(result);
                    }
                    else
                    {
                        old.refresh_token = resultToken.refresh_token;
                        old.email = email;
                        var result = await _service.UpdateAsync<GoogleConfigDTO>(old, old.id);
                        return Ok(result);
                    }
                }
                return Ok(null);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }
        }
        #endregion

        #region Config

        [HttpGet]
        [Route("getconfig")]
        public async Task<ActionResult> GetConfig()
        {
            try
            {
                GoogleConfigDTO result = new GoogleConfigDTO();
                var config = await _service.GetManyAsync<GoogleConfigDTO>(1, 0, null);
                result = config.data.FirstOrDefault();
                return Ok(result);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }
        }
        #endregion

       
    }
}
