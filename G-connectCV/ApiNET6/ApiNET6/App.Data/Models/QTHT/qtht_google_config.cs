using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.QTHT
{
    [Table("qtht_google_config")]
    public class google_config : BaseModel
    {
        public google_config()
        : base()
        {

        }
        [Required]
        [StringLength(255)]
        public string email { get; set; }

        [Required]
        [StringLength(2000)]
        public string refresh_token { get; set; }

    }
}
