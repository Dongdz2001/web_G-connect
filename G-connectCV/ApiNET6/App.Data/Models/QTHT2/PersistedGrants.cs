using System;
using System.Collections.Generic;
using App.Data.Models;
using App.Data.Models.QTHT2;
using App.Data.Models.QTHT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.QTHT2
{
    [Table("PersistedGrants")]
    public class PersistedGrants : BaseModelInt
    {
        public PersistedGrants()
             : base()
        {

        }


        [Required][StringLength(200)]
        public string Key { get; set; }
        [Required][StringLength(50)]
        public string Type { get; set; }
        [StringLength(200)]
        public string SubjectId { get; set; }
        [StringLength(100)]
        public string SessionId { get; set; }
        [Required][StringLength(200)]
        public string ClientId { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        public DateTime CreationTime { get; set; }
        
        public DateTime? Expiration { get; set; }
        
        public DateTime? ConsumedTime { get; set; }
        [Required]
        public string Data { get; set; }
    }
}

