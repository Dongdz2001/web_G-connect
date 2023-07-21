using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.QTHT
{
    [Table("qtht_file_dinh_kem")]
    public class file_dinh_kem : BaseModel
    {
        public file_dinh_kem()
             : base()
        {
        }

        [Required]
        [StringLength(255)]
        public string ten { get; set; }
        [StringLength(1024)]
        public string duong_dan { get; set; }

        public string type { get; set; }
        public byte[] noi_dung_tep { get; set; }
        public byte[] noi_dung_tep_pdf { get; set; }
        public byte[] file_finish { get; set; }
    }
}
