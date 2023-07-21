using System;
using System.Collections.Generic;
using App.Data.Models;
using App.Data.Models.QTHT2;
using App.Data.Models.QTHT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models.QTHT2
{
    [Table("ApiResources")]
    public class ApiResources : BaseModelInt
    {
        public ApiResources()
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
        [StringLength(100)]
        public string AllowedAccessTokenSigningAlgorithms { get; set; }
        [Required]
        public bool ShowInDiscoveryDocument { get; set; }
        [Required]
        public DateTime Created { get; set; }
        
        public DateTime? Updated { get; set; }
        
        public DateTime? LastAccessed { get; set; }
        [Required]
        public bool NonEditable { get; set; }
    }
}

