using BrandNewDaysCL1.Domain.Data;
using BrandNewDaysCL1.Domain.Dto;
using BrandNewDaysCL1.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrandNewDaysCL1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountManagementController : ControllerBase
    {
        private readonly ILogger<AccountManagementController> _logger;
        private IAccountService accountService;
        public AccountManagementController(ILogger<AccountManagementController> logger, IAccountService accountService)
        {
            _logger = logger;
            this.accountService = accountService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateAccount(BankAccountDto model)
        {
            var bankAccount = new BankAccount()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,

            };
            var result = await accountService.CreateNewBankAccount(bankAccount);
            return new OkObjectResult(result);

        }
        [HttpPut("deposit")]
        public IActionResult DepositToAccount(BankAccountDepositRequestDto bankAccount)
        {
            if (bankAccount.Amount <= 0)
            {
                _logger.LogWarning("amount < 0 account deposit request found");
                return new BadRequestObjectResult(string.Format($"account deposit request is invaild"));
            }
            var account = accountService.DepositToAccount(bankAccount.IBAN, bankAccount.Amount);
            if (account == null)
            {
                return new NotFoundObjectResult(string.Format($"account iban {bankAccount.IBAN} Notfound"));
            }
            return new OkObjectResult(account);

        }

        [HttpPut("tranfer")]
        public IActionResult TranferToAccount(BankAccountDto bankAccount)
        {
            return new NotFoundObjectResult(string.Format("implementation Notfound"));

        }
    }

}
