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

        // Genres Hard Coded

        public static byte Adventure { get; set; }= 1;
        public static byte Action { get; set; }= 2;
        public static byte Drama { get; set; }= 3;
        public static byte Comedy { get; set; }= 4;
        public static byte Thriller { get; set; }= 5;
        public static byte Horror { get; set; }= 6;
        public static byte Musical { get; set; }= 7;
        public static byte Documentary { get; set; }= 8;

    }
}