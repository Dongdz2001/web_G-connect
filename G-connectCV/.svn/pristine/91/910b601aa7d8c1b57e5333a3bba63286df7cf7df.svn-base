using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.QTHT
{
    [Table("qtht_nhom_nguoi_dung_2_dieu_huong")]
    public class nhom_nguoi_dung_2_dieu_huong
    {
        public nhom_nguoi_dung_2_dieu_huong()
        {
        }

        public Guid nhom_nguoi_dung_id { get; set; }
        public virtual nhom_nguoi_dung nhom_nguoi_dung { get; set; }
        public Guid dieu_huong_id { get; set; }
        public virtual dieu_huong dieu_huong { get; set; }
    }
}
