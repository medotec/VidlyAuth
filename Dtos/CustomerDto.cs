using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using VidlyAuth.Models;

namespace VidlyAuth.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public byte MembershipTypeId { get; set; }
        public MembershipTypeDto MembershipType { get; set; }

        public static implicit operator CustomerDto(Customer customer)
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

        public static implicit operator Customer(CustomerDto customerDto)
        {
            return new Customer
            {
                Id = customerDto.Id,
                Name = customerDto.Name,
                BirthDate = customerDto.BirthDate,
                MembershipTypeId = customerDto.MembershipTypeId,
                MembershipType = customerDto.MembershipType,
                IsSubscribedToNewsLetter = customerDto.IsSubscribedToNewsLetter
            };
        }
    }
}