using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT;
using AutoMapper;

namespace App.Business.Services.QTHT
{
    public class CauHinhMaDTO : BaseDTO
    {
        public string ten { get; set; }
        public string ma { get; set; }
        public string gia_tri { get; set; }
    }
    public class CauHinhMaProfile : Profile
    {
        public CauHinhMaProfile()
        {
            CreateMap<cau_hinh_ma, CauHinhMaDTO>();
            CreateMap<CauHinhMaDTO, cau_hinh_ma>()
                .IncludeBase<BaseDTO, BaseModel>();
        }
    }
}

