using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;
using VidlyAuth.Models;

namespace VidlyAuth.Dtos
{
    public static class Mappings
    {
        public static CustomerDto ToCustomerDto(this Customer customer)
        {
            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                BirthDate = customer.BirthDate,
                MembershipTypeId = customer.MembershipTypeId,
                MembershipType = customer.MembershipType,
                IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter
            };
        }

        public static void ToCustomerDto(this Customer customer, CustomerDto customerDto)
        {
            if (customer.Id == customerDto.Id)
            {
                customerDto.Name = customer.Name;
                customerDto.BirthDate = customer.BirthDate;
                customerDto.MembershipTypeId = customer.MembershipTypeId;
                customerDto.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            else
            {
                throw new MappingException("Customers should have the same Id for sucesfull mapping");
            }
        }


        public static void ToCustomer(this CustomerDto customerDto, Customer customer)
        {
            if (customer.Id == customerDto.Id)
            {
                customer.Name = customerDto.Name;
                customer.BirthDate = customerDto.BirthDate;
                customer.MembershipTypeId = customerDto.MembershipTypeId;
                customer.IsSubscribedToNewsLetter = customerDto.IsSubscribedToNewsLetter;
            }
            else
            {
                throw new MappingException("Customers should have the same Id for sucesfull mapping");
            }
        }

        public static void ToMovieDto(this Movie movie, MovieDto movieDto)
        {
            if (movie.Id == movieDto.Id)
            {
                movieDto.Name = movie.Name;
                movieDto.GenreId = movie.GenreId;
                movieDto.Genre = movie.Genre;
                movieDto.ReleaseDate = movie.ReleaseDate;
                movieDto.Stock = movie.Stock;
            }
            else
            {
                throw new MappingException("Objects should have the same Id");
            }
        }
        public static void ToMovie(this MovieDto movieDto, Movie movie)
        {
            if (movie.Id == movieDto.Id)
            {
                movie.Name = movieDto.Name;
                movie.GenreId = movieDto.GenreId;
                movie.ReleaseDate = movieDto.ReleaseDate;
                movie.Stock = movieDto.Stock;
            }
            else
            {
                throw new MappingException("Objects should have the same Id");
            }
        }
    }
}