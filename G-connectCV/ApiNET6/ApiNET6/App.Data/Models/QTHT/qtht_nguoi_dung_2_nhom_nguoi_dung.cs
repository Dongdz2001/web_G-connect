using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.QTHT
{
    [Table("qtht_nguoi_dung_2_nhom_nguoi_dung")]
    public class nguoi_dung_2_nhom_nguoi_dung
    {
        public nguoi_dung_2_nhom_nguoi_dung()
        {
        }

        public Guid nguoi_dung_id { get; set; }
        public virtual nguoi_dung nguoi_dung { get; set; }
        public Guid nhom_nguoi_dung_id { get; set; }
        public virtual nhom_nguoi_dung nhom_nguoi_dung { get; set; }
    }
}
