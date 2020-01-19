using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyAuth.Models;

namespace VidlyAuth.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public int Stock { get; set; }
        public byte GenreId { get; set; }
        public GenreDto Genre { get; set; }

        public static implicit operator MovieDto(Movie movie)
        {
            return new MovieDto
            {
                Id = movie.Id,
                Name = movie.Name,
                GenreId = movie.GenreId,
                Genre = movie.Genre,
                ReleaseDate = movie.ReleaseDate,
                Stock = movie.Stock
            };
        }
        public static implicit operator Movie(MovieDto movieDto)
        {
            return new Movie
            {
                Id = movieDto.Id,
                Name = movieDto.Name,
                GenreId = movieDto.GenreId,
                Genre = movieDto.Genre,
                ReleaseDate = movieDto.ReleaseDate,
                Stock = movieDto.Stock
            };
        }
    }
}