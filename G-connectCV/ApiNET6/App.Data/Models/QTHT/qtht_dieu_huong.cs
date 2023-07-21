using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.QTHT
{
    [Table("qtht_dieu_huong")]
    public class dieu_huong : BaseModel
    {
        public dieu_huong()
        : base()
        {
            this.ds_nhom_nguoi_dung = new HashSet<nhom_nguoi_dung_2_dieu_huong>();
        }
        [Required]
        [StringLength(32)]
        public string ma { get; set; }

        [Required]
        public string ten { get; set; }

        [StringLength(255)]
        public string duong_dan { get; set; }

        [StringLength(255)]
        public string icon { get; set; }

        public int? so_thu_tu { get; set; }
        public string stt_order { get; set; }

        public bool? is_quan_tri { get; set; }

        public string mo_ta { get; set; }

        public int cap_dieu_huong { get; set; }

        [StringLength(1024)]
        public string muc_luc { get; set; }

        public Guid? dieu_huong_cap_tren_id { get; set; }

        public bool super_admin { get; set; }

        public bool is_router { get; set; }
        public virtual dieu_huong dieu_huong_cap_tren { get; set; }

        public virtual ICollection<dieu_huong> ds_dieu_huong_cap_duoi { get; set; }
        public virtual ICollection<nhom_nguoi_dung_2_dieu_huong> ds_nhom_nguoi_dung { get; set; }
    }
}
