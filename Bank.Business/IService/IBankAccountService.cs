using Bank.Business.DTOs;

namespace Bank.Business.IService;

public interface IBankAccountService
{
    Task<IEnumerable<BankAccountDto>> GetAllBankAccountsAsync();
    Task<BankAccountDto> GetBankAccountByIdAsync(int bankAccountId);
    Task AddBankAccountAsync(BankAccountDto bankAccountDto);
    Task UpdateBankAccountAsync(BankAccountDto bankAccountDto);
    Task DeleteBankAccountAsync(int bankAccountId);
}