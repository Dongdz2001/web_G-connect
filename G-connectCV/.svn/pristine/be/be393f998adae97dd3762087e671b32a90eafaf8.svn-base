using System;
using System.Collections.Generic;
using App.Data.Models;
using App.Data.Models.QTHT2;
using App.Data.Models.QTHT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.QTHT2
{
    [Table("ApiScopeProperties")]
    public class ApiScopeProperties : BaseModelInt
    {
        public ApiScopeProperties()
             : base()
        {

        }

        [ForeignKey("ScopeId")]
        public virtual ApiScopes ApiScopes_ScopeId { get; set; }

        //[Required]
        //public int Id { get; set; }
        [Required][StringLength(250)]
        public string Key { get; set; }
        [Required][StringLength(2000)]
        public string Value { get; set; }
        [Required]
        public int ScopeId { get; set; }
    }
}

