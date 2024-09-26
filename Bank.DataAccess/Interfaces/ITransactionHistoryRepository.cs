using Bank.DataAccess.Entities;

namespace Bank.DataAccess.Interfaces;

public interface ITransactionHistoryRepository
{
    Task<IEnumerable<TransactionHistory>> GetAllTransactionHistoriesAsync();
    Task<IEnumerable<TransactionHistory>> GetTransactionHistoriesByAccountIdAsync(int accountId);
    
}