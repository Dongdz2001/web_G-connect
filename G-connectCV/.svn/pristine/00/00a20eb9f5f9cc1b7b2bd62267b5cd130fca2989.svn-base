using System;
using System.Collections.Generic;
using App.Data.Models;
using App.Data.Models.QTHT2;
using App.Data.Models.QTHT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.QTHT2
{
    [Table("ApiResourceSecrets")]
    public class ApiResourceSecrets : BaseModelInt
    {
        public ApiResourceSecrets()
             : base()
        {

        }

        [ForeignKey("ApiResourceId")]
        public virtual ApiResources ApiResources_ApiResourceId { get; set; }

        //[Required]
        //public int Id { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [Required][StringLength(4000)]
        public string Value { get; set; }
        
        public DateTime? Expiration { get; set; }
        [Required][StringLength(250)]
        public string Type { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public int ApiResourceId { get; set; }
    }
}

