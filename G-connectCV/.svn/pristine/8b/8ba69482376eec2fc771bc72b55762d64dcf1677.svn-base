using System;
using System.Collections.Generic;
using App.Data.Models;
using App.Data.Models.DBAll;
using App.Data.Models.QTHT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.DBAll
{
    [Table("GC_CONG_VIEC_PHAN_CONG")]
    public class GC_CONG_VIEC_PHAN_CONG : BaseModel
    {
        public GC_CONG_VIEC_PHAN_CONG()
             : base()
        {

        }

        [ForeignKey("id_chuc_nang")]
        public virtual GC_CHUC_NANG GC_CHUC_NANG_id_chuc_nang { get; set; }
        [ForeignKey("id_cong_viec")]
        public virtual GC_CONG_VIEC GC_CONG_VIEC_id_cong_viec { get; set; }
        [ForeignKey("id_trang_thai")]
        public virtual GC_DM_TRANG_THAI GC_DM_TRANG_THAI_id_trang_thai { get; set; }

        //[Required]
        //public Guid id { get; set; }
        
        public Guid? id_chuc_nang { get; set; }
        
        public Guid? id_cong_viec { get; set; }
        
        public Guid? id_trang_thai { get; set; }
        
        public Guid? id_nguoi_thuc_hien { get; set; }
        
        public Guid? id_nguoi_phoi_hop { get; set; }
        
        public Guid? id_nguoi_duyet { get; set; }
        [Required][StringLength(20)]
        public string ma_cong_viec { get; set; }
        [Required][StringLength(200)]
        public string ten_cong_viec { get; set; }
        
        public int? stt { get; set; }
        
        public bool? is_cong_viec_nhom { get; set; }
        
        public bool? is_da_code { get; set; }
        
        public bool? is_da_test { get; set; }
        
        public bool? is_da_nop_bai { get; set; }
        
        public bool? is_da_duyet { get; set; }
        
        public string noi_dung { get; set; }
        
        public string tham_khao { get; set; }
        
        public string dac_ta { get; set; }
        
        public string tra_loi { get; set; }
        
        public string log_review { get; set; }
        [StringLength(500)]
        public string file_ket_qua { get; set; }
        
        public int? so_ngay_estimate { get; set; }
        
        public int? so_ngay_thuc_hien { get; set; }
        
        public DateTime? ngay_ket_thuc_du_kien { get; set; }
        
        public DateTime? ngay_bat_dau { get; set; }
        
        public DateTime? ngay_ket_thuc { get; set; }
        
        public int? diem_so { get; set; }
        //
        //public Guid? nguoi_tao_id { get; set; }
        //
        //public DateTime? ngay_tao { get; set; }
        //
        //public Guid? nguoi_chinh_sua_id { get; set; }
        //
        //public DateTime? ngay_chinh_sua { get; set; }
        [ForeignKey("id_nguoi_thuc_hien")]
        public virtual nguoi_dung qtht_nguoi_dung_id_nguoi_thuc_hien { get; set; }
        [ForeignKey("id_nguoi_phoi_hop ")]
        public virtual nguoi_dung qtht_nguoi_dung_id_nguoi_phoi_hop { get; set; }
        [ForeignKey("id_nguoi_duyet")]
        public virtual nguoi_dung qtht_nguoi_dung_id_nguoi_duyet { get; set; }
    }
}

