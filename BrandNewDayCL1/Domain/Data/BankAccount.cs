namespace BrandNewDaysCL1.Domain.Data
{
    public class BankAccount
    {
        public string IBAN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal Amount { get; set; }

    }
   
}
