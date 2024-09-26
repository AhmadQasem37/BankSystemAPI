using Bank.Business.DTOs;

namespace Bank.Business.IService;

public interface ITransactionHistoryService
{
   
    
        Task<IEnumerable<TransactionHistoryDto>> GetAllTransactionHistoriesAsync();
        Task<IEnumerable<TransactionHistoryDto>> GetTransactionHistoriesByAccountIdAsync(int bankAccountId);
    
}