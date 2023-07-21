using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class qtht_nguoi_dungDTO : BaseDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }

        //public Guid id { get; set; }
        public string tai_khoan { get; set; }
        public string mat_khau { get; set; }
        public string salt_code { get; set; }
        public string ten { get; set; }
        public int trang_thai { get; set; }
        public bool super_admin { get; set; }
        public string email { get; set; }
        public string so_dien_thoai { get; set; }
        public string anh_dai_dien_url { get; set; }
        public bool? is_dau_moi { get; set; }
        public Guid? chuc_vu_id { get; set; }
        public string ten_chuc_vu_id { get; set; }
        public Guid? file_dinh_kem_id { get; set; }
        public string ten_file_dinh_kem_id { get; set; }
        //public Guid? nguoi_tao_id { get; set; }
        //public DateTime? ngay_tao { get; set; }
        //public Guid? nguoi_chinh_sua_id { get; set; }
        //public DateTime? ngay_chinh_sua { get; set; }
    }
    public class qtht_nguoi_dungProfile : Profile
    {
        public qtht_nguoi_dungProfile()
        {
            CreateMap<nguoi_dung, qtht_nguoi_dungSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten))
                ;
            CreateMap<nguoi_dung, qtht_nguoi_dungDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten))

                .ForMember(x => x.ten_chuc_vu_id, otp => otp.MapFrom(y => y.chuc_vu.ten))
                .ForMember(x => x.ten_file_dinh_kem_id, otp => otp.MapFrom(y => y.file_dinh_kem.ten))
                ;
            CreateMap<qtht_nguoi_dungDTO, nguoi_dung>()
                .IncludeBase<BaseDTO, BaseModel>()
                .ForMember(x => x.file_dinh_kem, otp => otp.Ignore())
                .ForMember(x => x.chuc_vu, otp => otp.Ignore())
                .ForMember(x => x.ds_nhom_nguoi_dung, otp => otp.Ignore())
                .ForMember(x => x.chuc_vu_id, otp => otp.Ignore())
                .ForMember(x => x.file_dinh_kem_id, otp => otp.Ignore());
        }
    }
    public class qtht_nguoi_dungSelectDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
    }
}

