using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyAuth.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Stock { get; set; }
        public byte GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}