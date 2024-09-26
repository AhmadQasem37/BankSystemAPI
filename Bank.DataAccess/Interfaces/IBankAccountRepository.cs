using Bank.DataAccess.Entities;

namespace Bank.DataAccess.Interfaces;

public interface IBankAccountRepository
{
    Task<IEnumerable<BankAccount>> GetAllBankAccountsAsync();
    Task<BankAccount?> GetBankAccountByIdAsync(int id);
    Task<IEnumerable<BankAccount>> GetBankAccountsByCustomerIdAsync(int customerId);
    Task AddBankAccountAsync(BankAccount bankAccount);
    Task DeleteBankAccountAsync(int id);
    Task UpdateBankAccountAsync(BankAccount bankAccount);
    
}