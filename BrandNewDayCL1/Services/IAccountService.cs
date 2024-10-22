using BrandNewDaysCL1.Domain.Data;
using BrandNewDaysCL1.Domain.Dto;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace BrandNewDaysCL1.Services
{
    public interface IAccountService
    {
        Task<BankAccount> CreateNewBankAccount(BankAccount bankAccount);
        BankAccount DepositToAccount(string iban, decimal depositAmount);
        BankAccount TranferToAccount(BankAccountTranferRequestDto tranferRequest);
    }
}
