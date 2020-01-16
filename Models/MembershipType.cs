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

        // Adding Static Membership Types Hard Coded

        public static byte Unknown { get; set; } = 0;
        public static byte PayAsYouGo { get; set; } = 1;
        public static byte Monthly { get; set; } = 2;
        public static byte Quarterly { get; set; } = 3;
        public static byte Annual { get; set; } = 4;
    }
}