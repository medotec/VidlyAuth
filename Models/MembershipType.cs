namespace VidlyAuth.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public double Discount { get; set; }
        public decimal SignUpFee { get; set; }

    }
}