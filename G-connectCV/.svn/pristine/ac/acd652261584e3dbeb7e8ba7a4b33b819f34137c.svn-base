using System;
using System.Collections.Generic;
using App.Data.Models;
using App.Data.Models.DBAll;
using App.Data.Models.QTHT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.DBAll
{
    [Table("GC_LICH_TUAN")]
    public class GC_LICH_TUAN : BaseModel
    {
        public GC_LICH_TUAN()
             : base()
        {

        }


        //[Required]
        //public Guid id { get; set; }
        [ForeignKey("id_nguoi_thuc_hien")]
        public virtual nguoi_dung qtht_nguoi_dung_id_nguoi_thuc_hien { get; set; }
        public Guid? id_nguoi_thuc_hien { get; set; }
        [StringLength(20)]
        public string thu2_sang { get; set; }
        [StringLength(20)]
        public string thu2_chieu { get; set; }
        [StringLength(20)]
        public string thu3_sang { get; set; }
        [StringLength(20)]
        public string thu3_chieu { get; set; }
        [StringLength(20)]
        public string thu4_sang { get; set; }
        [StringLength(20)]
        public string thu4_chieu { get; set; }
        [StringLength(20)]
        public string thu5_sang { get; set; }
        [StringLength(20)]
        public string thu5_chieu { get; set; }
        [StringLength(20)]
        public string thu6_sang { get; set; }
        [StringLength(20)]
        public string thu6_chieu { get; set; }
        [StringLength(20)]
        public string thu7_sang { get; set; }
        [StringLength(20)]
        public string thu7_chieu { get; set; }
        //
        //public Guid? nguoi_tao_id { get; set; }
        //
        //public DateTime? ngay_tao { get; set; }
        //
        //public Guid? nguoi_chinh_sua_id { get; set; }
        //
        //public DateTime? ngay_chinh_sua { get; set; }
        [StringLength(20)]
        public string so_dien_thoai { get; set; }
        [StringLength(250)]
        public string link_bao_cao { get; set; }
    }
}

