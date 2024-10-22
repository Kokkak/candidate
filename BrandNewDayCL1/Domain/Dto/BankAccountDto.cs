using System.ComponentModel.DataAnnotations;

namespace BrandNewDaysCL1.Domain.Dto
{
    public class BankAccountDto
    {
        public string IBAN { get; set; }
  //      [Required]
        public string FirstName { get; set; }
   //     [Required]
        public string LastName { get; set; }
    }
    public class BankAccountDepositRequestDto : BankAccountRequestDto
    {
     
    }
    public class BankAccountTranferRequestDto : BankAccountRequestDto
    {
        [Required]
        public required string DestinationIBAN { get; set; }
    }
    public class BankAccountRequestDto
    {
        [Required]
        public required string IBAN { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
    
}
