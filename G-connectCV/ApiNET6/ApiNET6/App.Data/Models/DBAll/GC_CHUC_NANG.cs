using System;
using System.Collections.Generic;
using App.Data.Models;
using App.Data.Models.DBAll;
using App.Data.Models.QTHT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.DBAll
{
    [Table("GC_CHUC_NANG")]
    public class GC_CHUC_NANG : BaseModel
    {
        public GC_CHUC_NANG()
             : base()
        {

        }

        [ForeignKey("id_du_an")]
        public virtual GC_DU_AN GC_DU_AN_id_du_an { get; set; }
        [ForeignKey("id_linh_vuc")]
        public virtual GC_DM_LINH_VUC GC_DM_LINH_VUC_id_linh_vuc { get; set; }

        //[Required]
        //public Guid id { get; set; }
        
        public Guid? id_du_an { get; set; }
        
        public Guid? id_linh_vuc { get; set; }
        [Required][StringLength(20)]
        public string ma_chuc_nang { get; set; }
        [Required][StringLength(200)]
        public string ten_chuc_nang { get; set; }
        
        public int? stt { get; set; }
        
        public bool? is_cong_bo { get; set; }
        
        public bool? is_da_code { get; set; }
        
        public bool? is_da_test { get; set; }
        
        public string noi_dung { get; set; }
        [StringLength(200)]
        public string file_dinh_kem { get; set; }
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

