using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.QTHT
{
    [Table("qtht_nhom_nguoi_dung")]
    public class nhom_nguoi_dung : BaseModel
    {
        public nhom_nguoi_dung()
        : base()
        {
            this.ds_nguoi_dung = new HashSet<nguoi_dung_2_nhom_nguoi_dung>();
            this.ds_dieu_huong = new HashSet<nhom_nguoi_dung_2_dieu_huong>();
        }

        [Required]
        [StringLength(255)]
        public string ma { get; set; }

        [Required]
        public string ten { get; set; }

        public string mota { get; set; }
        public virtual ICollection<nguoi_dung_2_nhom_nguoi_dung> ds_nguoi_dung { get; set; }
        public virtual ICollection<nhom_nguoi_dung_2_dieu_huong> ds_dieu_huong { get; set; }
    }
}
