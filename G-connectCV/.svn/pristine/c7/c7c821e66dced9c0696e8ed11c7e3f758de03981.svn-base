using System;
using System.Collections.Generic;
using App.Data.Models;
using App.Data.Models.QTHT2;
using App.Data.Models.QTHT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.QTHT2
{
    [Table("ClientSecrets")]
    public class ClientSecrets : BaseModelInt
    {
        public ClientSecrets()
             : base()
        {

        }

        [ForeignKey("ClientId")]
        public virtual Clients Clients_ClientId { get; set; }

        //[Required]
        //public int Id { get; set; }
        [StringLength(2000)]
        public string Description { get; set; }
        [Required][StringLength(4000)]
        public string Value { get; set; }
        
        public DateTime? Expiration { get; set; }
        [Required][StringLength(250)]
        public string Type { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public int ClientId { get; set; }
    }
}

