namespace Practice.Contracts.Owner
{
    public class CreateOwnerDto
    {
        public int UserId { get; set; }
        public DateTime? TenurePeriodFrom { get; set; }
        public DateTime? TenurePeriodTo { get; set; }
        public int CarId { get; set; }
    }
}
