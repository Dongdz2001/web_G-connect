using System;
using System.Collections.Generic;
using App.Data.Models;
using App.Data.Models.QTHT2;
using App.Data.Models.QTHT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.QTHT2
{
    [Table("ApiResourceProperties")]
    public class ApiResourceProperties : BaseModelInt
    {
        public ApiResourceProperties()
             : base()
        {

        }

        [ForeignKey("ApiResourceId")]
        public virtual ApiResources ApiResources_ApiResourceId { get; set; }

        //[Required]
        //public int Id { get; set; }
        [Required][StringLength(250)]
        public string Key { get; set; }
        [Required][StringLength(2000)]
        public string Value { get; set; }
        [Required]
        public int ApiResourceId { get; set; }
    }
}

