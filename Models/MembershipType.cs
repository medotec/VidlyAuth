using System.ComponentModel.DataAnnotations;

namespace VidlyAuth.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        
        [Range(1,100)]
        public double Discount { get; set; }
        public decimal SignUpFee { get; set; }

    }
}