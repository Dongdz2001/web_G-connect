using System;
using System.Collections.Generic;
using App.Data.Models;
using App.Data.Models.QTHT2;
using App.Data.Models.QTHT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.QTHT2
{
    [Table("IdentityResourceClaims")]
    public class IdentityResourceClaims : BaseModelInt
    {
        public IdentityResourceClaims()
             : base()
        {

        }

        [ForeignKey("IdentityResourceId")]
        public virtual IdentityResources IdentityResources_IdentityResourceId { get; set; }

        //[Required]
        //public int Id { get; set; }
        [Required][StringLength(200)]
        public string Type { get; set; }
        [Required]
        public int IdentityResourceId { get; set; }
    }
}

