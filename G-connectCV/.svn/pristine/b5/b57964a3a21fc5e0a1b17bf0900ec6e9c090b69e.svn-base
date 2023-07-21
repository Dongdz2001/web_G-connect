using System;
using System.Collections.Generic;
using App.Data.Models;
using App.Data.Models.DBAll;
using App.Data.Models.QTHT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.DBAll
{
    [Table("GC_CONG_VIEC")]
    public class GC_CONG_VIEC : BaseModel
    {
        public GC_CONG_VIEC()
             : base()
        {

        }

        [ForeignKey("id_cong_viec_cha")]
        public virtual GC_CONG_VIEC GC_CONG_VIEC_id_cong_viec_cha { get; set; }


        [ForeignKey("id_chuc_nang")]
        public virtual GC_CHUC_NANG GC_CONG_VIEC_id_chuc_nang { get; set; }        
        //[Required]
        //public Guid id { get; set; }

        public Guid? id_chuc_nang { get; set; }
        
        public Guid? id_cong_viec_cha { get; set; }
        [Required][StringLength(20)]
        public string ma_cong_viec { get; set; }
        [Required][StringLength(200)]
        public string ten_cong_viec { get; set; }
        
        public int? stt { get; set; }
        
        public bool? is_cong_viec_nhom { get; set; }
        
        public bool? is_da_code { get; set; }
        
        public bool? is_da_test { get; set; }
        
        public string noi_dung { get; set; }
        
        public string tham_khao { get; set; }
        
        public int? so_ngay_estimate { get; set; }
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

