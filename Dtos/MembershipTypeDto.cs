using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using VidlyAuth.Models;

namespace VidlyAuth.Dtos
{
    public class MembershipTypeDto
    {
        public byte Id { get; set; }
        public string Name { get; set; }

        public static implicit operator MembershipTypeDto(MembershipType membershipType)
        {
            return new MembershipTypeDto
            {
                Id = membershipType.Id,
                Name = membershipType.Name
            };
        }
        public static implicit operator MembershipType(MembershipTypeDto membershipTypeDto)
        {
            return new MembershipType
            {
                Id = membershipTypeDto.Id,
                Name = membershipTypeDto.Name
            };
        }
    }
}