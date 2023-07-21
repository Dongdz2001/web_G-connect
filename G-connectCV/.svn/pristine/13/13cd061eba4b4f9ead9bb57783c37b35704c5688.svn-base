using System;
using System.Collections.Generic;
using App.Data.Models;
using App.Data.Models.DBAll;
using App.Data.Models.QTHT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.DBAll
{
    [Table("GC_LICH_HANG_NGAY")]
    public class GC_LICH_HANG_NGAY : BaseModel
    {
        public GC_LICH_HANG_NGAY()
             : base()
        {

        }

        [ForeignKey("id_cong_viec")]
        public virtual GC_CONG_VIEC_PHAN_CONG GC_CONG_VIEC_PHAN_CONG_id_cong_viec { get; set; }
        [ForeignKey("id_nguoi_thuc_hien")]
        public virtual nguoi_dung qtht_nguoi_dung_id_nguoi_thuc_hien { get; set; }
        //[Required]
        //public Guid id { get; set; }

        public Guid? id_nguoi_thuc_hien { get; set; }
        
        public Guid? id_cong_viec { get; set; }
        
        public DateTime? ngay_lam_viec { get; set; }
        
        public DateTime? ngay_checkin { get; set; }
        
        public DateTime? ngay_checkout { get; set; }
        
        public double? so_gio { get; set; }
        //
        //public Guid? nguoi_tao_id { get; set; }
        //
        //public DateTime? ngay_tao { get; set; }
        //
        //public Guid? nguoi_chinh_sua_id { get; set; }
        //
        //public DateTime? ngay_chinh_sua { get; set; }
    }
}

