using Bank.DataAccess.Entities;
using Bank.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bank.DataAccess.Repositories;

public class TransactionHistoryRepository : ITransactionHistoryRepository
{
    private readonly BankContext _context;

    public TransactionHistoryRepository(BankContext context)
    {
        _context = context;
    }

    public async Task<ICollection<TransactionHistory>> GetTransactionHistoryByBankAccountIdAsync(int bankAccountId)
    {
        return await _context.TransactionHistories
            .Where(th => th.BankAccountId == bankAccountId)
            .ToListAsync();
    }

    public async Task<IEnumerable<TransactionHistory>> GetAllTransactionHistoriesAsync()
    {
        return await _context.TransactionHistories.ToListAsync();
    }

    public Task<IEnumerable<TransactionHistory>> GetTransactionHistoriesByAccountIdAsync(int accountId)
    {
        throw new NotImplementedException();
    }

   

  

  
    
}