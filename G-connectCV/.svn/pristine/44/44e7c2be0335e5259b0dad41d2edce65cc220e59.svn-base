using System;
using System.Collections.Generic;
using App.Data.Models;
using App.Data.Models.DBAll;
using App.Data.Models.QTHT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.DBAll
{
    [Table("GC_CONG_VIEC_CHECKLIST")]
    public class GC_CONG_VIEC_CHECKLIST : BaseModel
    {
        public GC_CONG_VIEC_CHECKLIST()
             : base()
        {

        }

        [ForeignKey("id_chuc_nang")]
        public virtual GC_CHUC_NANG GC_CHUC_NANG_id_chuc_nang { get; set; }
        [ForeignKey("id_cong_viec")]
        public virtual GC_CONG_VIEC GC_CONG_VIEC_id_cong_viec { get; set; }
        [ForeignKey("id_loai_checklist")]
        public virtual GC_DM_LOAI_CHECK_LIST GC_DM_LOAI_CHECK_LIST_id_loai_checklist { get; set; }

        //[Required]
        //public Guid id { get; set; }
        
        public Guid? id_chuc_nang { get; set; }
        
        public Guid? id_cong_viec { get; set; }
        
        public Guid? id_loai_checklist { get; set; }
        [Required][StringLength(20)]
        public string ma_cong_viec { get; set; }
        [Required][StringLength(200)]
        public string ten_cong_viec { get; set; }
        
        public int? stt { get; set; }
        
        public string ket_qua_mong_muon { get; set; }
        
        public string ghi_chu_khac { get; set; }
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

