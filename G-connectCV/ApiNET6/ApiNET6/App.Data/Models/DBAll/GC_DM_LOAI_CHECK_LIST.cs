using System;
using System.Collections.Generic;
using App.Data.Models;
using App.Data.Models.DBAll;
using App.Data.Models.QTHT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.DBAll
{
    [Table("GC_DM_LOAI_CHECK_LIST")]
    public class GC_DM_LOAI_CHECK_LIST : BaseModel
    {
        public GC_DM_LOAI_CHECK_LIST()
             : base()
        {

        }


        //[Required]
        //public Guid id { get; set; }
        [Required][StringLength(200)]
        public string ten_loai_check_list { get; set; }
        
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

