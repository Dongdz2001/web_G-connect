using System;
using System.Collections.Generic;
using App.Data.Models;
using App.Data.Models.QTHT2;
using App.Data.Models.QTHT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.QTHT2
{
    [Table("IdentityResources")]
    public class IdentityResources : BaseModelInt
    {
        public IdentityResources()
             : base()
        {

        }


        //[Required]
        //public int Id { get; set; }
        [Required]
        public bool Enabled { get; set; }
        [Required][StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string DisplayName { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [Required]
        public bool Required { get; set; }
        [Required]
        public bool Emphasize { get; set; }
        [Required]
        public bool ShowInDiscoveryDocument { get; set; }
        [Required]
        public DateTime Created { get; set; }
        
        public DateTime? Updated { get; set; }
        [Required]
        public bool NonEditable { get; set; }
    }
}

