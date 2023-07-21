using System;
using System.Collections.Generic;
using App.Data.Models;
using App.Data.Models.QTHT2;
using App.Data.Models.QTHT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.QTHT2
{
    [Table("DeviceCodes")]
    public class DeviceCodes : BaseModelInt
    {
        public DeviceCodes()
             : base()
        {

        }


        [Required][StringLength(200)]
        public string UserCode { get; set; }
        [Required][StringLength(200)]
        public string DeviceCode { get; set; }
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
        [Required]
        public DateTime Expiration { get; set; }
        [Required]
        public string Data { get; set; }
    }
}

