using System;
using System.Collections.Generic;
using App.Data.Models;
using App.Data.Models.QTHT2;
using App.Data.Models.QTHT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.QTHT2
{
    [Table("ClientRedirectUris")]
    public class ClientRedirectUris : BaseModelInt
    {
        public ClientRedirectUris()
             : base()
        {

        }

        [ForeignKey("ClientId")]
        public virtual Clients Clients_ClientId { get; set; }

        //[Required]
        //public int Id { get; set; }
        [Required][StringLength(2000)]
        public string RedirectUri { get; set; }
        [Required]
        public int ClientId { get; set; }
    }
}

