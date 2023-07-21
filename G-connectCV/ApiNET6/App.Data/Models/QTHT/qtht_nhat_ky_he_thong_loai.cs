using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.QTHT
{
    [Table("qtht_nhat_ky_he_thong_loai")]
    public class nhat_ky_he_thong_loai : BaseModel
    {
        public nhat_ky_he_thong_loai()
             : base()
        {
        }
        public string hanh_dong { get; set; }
        public string ten_hanh_dong { get; set; }
    }
}
