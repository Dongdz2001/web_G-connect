using System;
using System.Collections.Generic;
using App.Data.Models;
using App.Data.Models.QTHT2;
using App.Data.Models.QTHT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.QTHT2
{
    [Table("ClientGrantTypes")]
    public class ClientGrantTypes : BaseModelInt
    {
        public ClientGrantTypes()
             : base()
        {

        }

        [ForeignKey("ClientId")]
        public virtual Clients Clients_ClientId { get; set; }

        //[Required]
        //public int Id { get; set; }
        [Required][StringLength(250)]
        public string GrantType { get; set; }
        [Required]
        public int ClientId { get; set; }
    }
}

