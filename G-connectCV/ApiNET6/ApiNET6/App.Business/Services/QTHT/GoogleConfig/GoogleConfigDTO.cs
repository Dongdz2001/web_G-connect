using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace App.Business.Services.QTHT
{
    public class GoogleConfigDTO : BaseDTO
    {
        public string email { get; set; }
        public string refresh_token { get; set; }
    }
    public class GoogleConfigProfile : Profile
    {
        public GoogleConfigProfile()
        {
            CreateMap<google_config, GoogleConfigDTO>();
                
            CreateMap<GoogleConfigDTO, google_config>()
                 .IncludeBase<BaseDTO, BaseModel>();

        }
    }
}
