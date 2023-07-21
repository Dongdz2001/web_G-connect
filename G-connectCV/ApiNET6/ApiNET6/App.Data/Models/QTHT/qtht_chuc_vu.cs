using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.QTHT
{
    [Table("qtht_chuc_vu")]
    public class chuc_vu : BaseModel
    {
        public chuc_vu()
             : base()
        {
        }

        [StringLength(32)]
        public string ma { get; set; }

        [Required]
        public string ten { get; set; }

        public string mo_ta { get; set; }
    }
}
