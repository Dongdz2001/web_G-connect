using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.QTHT
{
    [Table("qtht_nhat_ky_he_thong")]
    public class nhat_ky_he_thong : BaseModel
    {
        public nhat_ky_he_thong()
             : base()
        {
        }
        public string bang { get; set; }
        public Guid? ban_ghi_id { get; set; }
        public Guid? nguoi_thuc_hien_id { get; set; }
        public string hanh_dong { get; set; }
        public string noi_dung { get; set; }
        public string duong_dan { get; set; }
        public bool? is_deleted { get; set; }
        public virtual nguoi_dung nguoi_dung { get; set; }
    }
}
