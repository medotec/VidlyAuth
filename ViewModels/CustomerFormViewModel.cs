using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyAuth.Models;

namespace VidlyAuth.ViewModels
{
    public class CustomerFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public byte MembershipTypeId { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public string Title => Id == 0 ? "New Customer" : "Edit Customer";

        public CustomerFormViewModel()
        {
            
        }

        public CustomerFormViewModel(IEnumerable<MembershipType> membershipTypes)
        {
            this.MembershipTypes = membershipTypes;
        }

        public CustomerFormViewModel(Customer customer, ICollection<MembershipType> membershipTypes)
        {
            MembershipTypes = membershipTypes;
            Id = customer.Id;
            Name = customer.Name;
            BirthDate = customer.BirthDate;
            IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            MembershipTypeId = customer.MembershipTypeId;
        }
    }
}