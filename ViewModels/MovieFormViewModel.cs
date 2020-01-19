using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyAuth.Models;

namespace VidlyAuth.ViewModels
{
    public class MovieFormViewModel
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        
        public int Stock { get; set; }
        
        public byte GenreId { get; set; }
        
        public IEnumerable<Genre> Genres { get; set; }
        
        public string Title => Id == 0 ? "New Movie" : "Edit Movie";

        public MovieFormViewModel()
        {
            
        }

        public MovieFormViewModel(IEnumerable<Genre> genres)
        {
            this.Genres = genres;
        }
        public MovieFormViewModel(Movie movie, IEnumerable<Genre> genres)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            Stock = movie.Stock;
            GenreId = movie.GenreId;
            this.Genres = genres;
        }

    }
}