using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyAuth.Models
{
    public class Genre
    {
        public byte Id { get; set; }
        
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}