namespace Domain.Entities
{
    public class AccountCategory
    {
        public Guid AccountId { get; set; }
        public Account Accounts { get; set; } 
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
