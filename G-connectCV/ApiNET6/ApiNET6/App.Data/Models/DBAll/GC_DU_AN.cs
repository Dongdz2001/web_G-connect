using System;
using System.Collections.Generic;
using App.Data.Models;
using App.Data.Models.DBAll;
using App.Data.Models.QTHT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.DBAll
{
    [Table("GC_DU_AN")]
    public class GC_DU_AN : BaseModel
    {
        public GC_DU_AN()
             : base()
        {

        }

        [ForeignKey("id_loai_du_an")]
        public virtual GC_DM_LOAI_DU_AN GC_DM_LOAI_DU_AN_id_loai_du_an { get; set; }

        //[Required]
        //public Guid id { get; set; }
        
        public Guid? id_loai_du_an { get; set; }
        [Required][StringLength(200)]
        public string ten_du_an { get; set; }
        
        public int? stt { get; set; }
        
        public bool? is_da_dong { get; set; }
        
        public DateTime? ngay_bat_dau { get; set; }
        
        public DateTime? ngay_ket_thuc { get; set; }
        [StringLength(4000)]
        public string thong_tin_khach_hang { get; set; }
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

