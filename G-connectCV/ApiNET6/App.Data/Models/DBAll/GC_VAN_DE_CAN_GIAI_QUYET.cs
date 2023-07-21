using System;
using System.Collections.Generic;
using App.Data.Models;
using App.Data.Models.DBAll;
using App.Data.Models.QTHT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.DBAll
{
    [Table("GC_VAN_DE_CAN_GIAI_QUYET")]
    public class GC_VAN_DE_CAN_GIAI_QUYET : BaseModel
    {
        public GC_VAN_DE_CAN_GIAI_QUYET()
             : base()
        {

        }

        [ForeignKey("id_chuc_nang")]
        public virtual GC_CHUC_NANG GC_CHUC_NANG_id_chuc_nang { get; set; }
        [ForeignKey("id_cong_viec")]
        public virtual GC_CONG_VIEC_PHAN_CONG GC_CONG_VIEC_PHAN_CONG_id_cong_viec { get; set; }

        //[Required]
        //public Guid id { get; set; }
        
        public Guid? id_chuc_nang { get; set; }
        
        public Guid? id_cong_viec { get; set; }
        
        public Guid? id_nguoi_gap { get; set; }
        
        public Guid? id_nguoi_phoi_hop { get; set; }
        
        public Guid? id_nguoi_giai_quyet { get; set; }
        [Required][StringLength(200)]
        public string ten_van_de { get; set; }
        
        public string noi_dung { get; set; }
        
        public string huong_giai_quyet { get; set; }
        
        public bool? da_giai_quyet { get; set; }
        //
        //public Guid? nguoi_tao_id { get; set; }
        //
        //public DateTime? ngay_tao { get; set; }
        //
        //public Guid? nguoi_chinh_sua_id { get; set; }
        //
        //public DateTime? ngay_chinh_sua { get; set; }
        [ForeignKey("id_nguoi_gap")]
        public virtual nguoi_dung qtht_nguoi_dung_id_nguoi_gap { get; set; }
        [ForeignKey("id_nguoi_phoi_hop ")]
        public virtual nguoi_dung qtht_nguoi_dung_id_nguoi_phoi_hop { get; set; }
        [ForeignKey("id_nguoi_giai_quyet ")]
        public virtual nguoi_dung qtht_nguoi_dung_id_nguoi_giai_quyet { get; set; }
    }
}

