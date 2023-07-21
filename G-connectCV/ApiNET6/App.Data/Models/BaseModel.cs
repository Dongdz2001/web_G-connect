using App.Data.Models.QTHT;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data
{
    public partial class BaseModelInt
    {
        public BaseModelInt()
        {

        }
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

    }
    public partial class BaseModel
    {
        public BaseModel()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public Guid? nguoi_tao_id { get; set; }
        public virtual nguoi_dung nguoi_tao { get; set; }
        public DateTime? ngay_tao { get; set; }
        public Guid? nguoi_chinh_sua_id { get; set; }
        public virtual nguoi_dung nguoi_chinh_sua { get; set; }
        public DateTime? ngay_chinh_sua { get; set; }


    }
    public partial class BaseVersionModel
    {
        public BaseVersionModel()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        [Key]
        public int version { get; set; }
        public Guid? nguoi_tao_id { get; set; }
        public virtual nguoi_dung nguoi_tao { get; set; }
        public DateTime? ngay_tao { get; set; }
        public Guid? nguoi_chinh_sua_id { get; set; }
        public virtual nguoi_dung nguoi_chinh_sua { get; set; }
        public DateTime? ngay_chinh_sua { get; set; }


    }
}