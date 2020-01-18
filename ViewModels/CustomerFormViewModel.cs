using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyAuth.Models;

namespace VidlyAuth.ViewModels
{
    public class CustomerFormViewModel
    {
        public ICollection<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
        public string Title => Customer.Id == 0 ? "New Customer" : "Edit Customer";
    }
}