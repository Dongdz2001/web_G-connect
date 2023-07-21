using System;
using System.Collections.Generic;
using App.Data.Models;
using App.Data.Models.QTHT2;
using App.Data.Models.QTHT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.QTHT2
{
    [Table("ApiResourceClaims")]
    public class ApiResourceClaims : BaseModelInt
    {
        public ApiResourceClaims()
             : base()
        {

        }

        [ForeignKey("ApiResourceId")]
        public virtual ApiResources ApiResources_ApiResourceId { get; set; }

        //[Required]
        //public int Id { get; set; }
        [Required][StringLength(200)]
        public string Type { get; set; }
        [Required]
        public int ApiResourceId { get; set; }
    }
}

