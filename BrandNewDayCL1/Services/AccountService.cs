using BrandNewDaysCL1.Domain.Data;
using BrandNewDaysCL1.Domain.Dto;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json.Nodes;

namespace BrandNewDaysCL1.Services
{
    public class AccountService : IAccountService
    {
        //private 
        private readonly List<BankAccount> accounts;
        private static readonly HttpClient httpClient = new HttpClient();

        public AccountService(List<BankAccount> accounts)
        {
            this.accounts = accounts;
        }
        public async Task<BankAccount> CreateNewBankAccount(BankAccount bankAccount)
        {
            var now = DateTime.UtcNow;
            var iban = await IBANGenerator();
            var isIbanValid = accounts.Any(a => a.IBAN == iban) == false;
            if (isIbanValid)
            {
                bankAccount.IBAN = iban;
                bankAccount.DateCreated = now;
                accounts.Add(bankAccount);
                return bankAccount;

        }
        public BankAccount DepositToAccount(BankAccount bankAccount)
        {
            return bankAccount;
        }
        public BankAccount TranferToAccount(BankAccount bankAccount)
        {

            var bankAccount = new BankAccount();
            return bankAccount;
        }

        public async Task<string> IBANGenerator()
        {
            var requestUri = "https://randommer.io/iban-generator";

            var content = new StringContent("country=GB&X-Requested-With=XMLHttpRequest", Encoding.UTF8, "application/x-www-form-urlencoded");

            // Add headers to the request
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

            var response = await httpClient.PostAsync(requestUri, content);

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonObject.Parse(responseBody).ToString();
        }

    }
}
