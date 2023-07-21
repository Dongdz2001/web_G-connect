using System;
using System.Collections.Generic;
using App.Data.Models;
using App.Data.Models.DBAll;
using App.Data.Models.QTHT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.DBAll
{
    [Table("GC_DM_LINH_VUC")]
    public class GC_DM_LINH_VUC : BaseModel
    {
        public GC_DM_LINH_VUC()
             : base()
        {

        }

        [ForeignKey("id_linh_vuc_cha")]
        public virtual GC_DM_LINH_VUC GC_DM_LINH_VUC_id_linh_vuc_cha { get; set; }

        //[Required]
        //public Guid id { get; set; }
        
        public Guid? id_linh_vuc_cha { get; set; }
        [Required][StringLength(200)]
        public string ten_linh_vuc { get; set; }
        
        public int? stt { get; set; }
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

