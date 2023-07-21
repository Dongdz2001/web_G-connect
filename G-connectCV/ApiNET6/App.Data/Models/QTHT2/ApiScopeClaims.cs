using System;
using System.Collections.Generic;
using App.Data.Models;
using App.Data.Models.QTHT2;
using App.Data.Models.QTHT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.QTHT2
{
    [Table("ApiScopeClaims")]
    public class ApiScopeClaims : BaseModelInt
    {
        public ApiScopeClaims()
             : base()
        {

        }

        [ForeignKey("ScopeId")]
        public virtual ApiScopes ApiScopes_ScopeId { get; set; }

        //[Required]
        //public int Id { get; set; }
        [Required][StringLength(200)]
        public string Type { get; set; }
        [Required]
        public int ScopeId { get; set; }
    }
}

