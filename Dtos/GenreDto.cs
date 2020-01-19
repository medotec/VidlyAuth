﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyAuth.Models;

namespace VidlyAuth.Dtos
{
    public class GenreDto
    {
        public byte Id { get; set; }
        public string Name { get; set; }

        public static implicit operator GenreDto(Genre genre)
        {
            return new GenreDto
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }
        public static implicit operator Genre(GenreDto genreDto)
        {
            return new Genre
            {
                Id = genreDto.Id,
                Name = genreDto.Name
            };
        }
    }
}