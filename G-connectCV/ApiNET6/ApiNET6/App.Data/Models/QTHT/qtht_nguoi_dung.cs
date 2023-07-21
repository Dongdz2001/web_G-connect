
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.QTHT
{
    [Table("qtht_nguoi_dung")]
    public class nguoi_dung : BaseModel
    {
        public nguoi_dung()
        : base()
        {
            this.ds_nhom_nguoi_dung = new HashSet<nguoi_dung_2_nhom_nguoi_dung>();
        }
        [Required]
        [StringLength(255)]
        public string tai_khoan { get; set; }

        [Required]
        [StringLength(255)]
        public string mat_khau { get; set; }

        [Required]
        [StringLength(32)]
        public string salt_code { get; set; }

        [Required]
        [StringLength(255)]
        public string ten { get; set; }

        [Required]
        public int trang_thai { get; set; }

        public bool super_admin { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(32)]
        public string so_dien_thoai { get; set; }

        [StringLength(1024)]
        public string anh_dai_dien_url { get; set; }
        public bool? is_dau_moi { get; set; }

        public Guid? chuc_vu_id { get; set; }
        public Guid? file_dinh_kem_id { get; set; }
        public virtual file_dinh_kem file_dinh_kem { get; set; }
        public virtual chuc_vu chuc_vu { get; set; }
        public virtual ICollection<nguoi_dung_2_nhom_nguoi_dung> ds_nhom_nguoi_dung { get; set; }
    }
}
