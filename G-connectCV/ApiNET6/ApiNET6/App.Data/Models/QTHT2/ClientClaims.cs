using System;
using System.Collections.Generic;
using App.Data.Models;
using App.Data.Models.QTHT2;
using App.Data.Models.QTHT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.QTHT2
{
    [Table("ClientClaims")]
    public class ClientClaims : BaseModelInt
    {
        public ClientClaims()
             : base()
        {

        }

        [ForeignKey("ClientId")]
        public virtual Clients Clients_ClientId { get; set; }

        //[Required]
        //public int Id { get; set; }
        [Required][StringLength(250)]
        public string Type { get; set; }
        [Required][StringLength(250)]
        public string Value { get; set; }
        [Required]
        public int ClientId { get; set; }
    }
}

