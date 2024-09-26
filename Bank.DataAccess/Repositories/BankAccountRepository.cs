using Bank.DataAccess.Entities;
using Bank.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bank.DataAccess.Repositories;

public class BankAccountRepository : IBankAccountRepository
{
    private readonly BankContext _context;

    public BankAccountRepository(BankContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BankAccount>> GetAllBankAccountsAsync()
    {
        return await _context.BankAccounts.ToListAsync();
    }

    public async Task<BankAccount> GetBankAccountByIdAsync(int id)
    {
        return await _context.BankAccounts.FindAsync(id);
    }

    Task<IEnumerable<BankAccount>> IBankAccountRepository.GetBankAccountsByCustomerIdAsync(int customerId)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<BankAccount>> GetBankAccountsByCustomerIdAsync(int customerId)
    {
        return await _context.BankAccounts
            .Where(b => b.CustomerId == customerId.ToString())
            .ToListAsync();
    }

    public async Task AddBankAccountAsync(BankAccount bankAccount)
    {
        await _context.BankAccounts.AddAsync(bankAccount);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateBankAccountAsync(BankAccount bankAccount)
    {
        _context.BankAccounts.Update(bankAccount);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBankAccountAsync(int id)
    {
        var bankAccount = await GetBankAccountByIdAsync(id);
        if (bankAccount != null)
        {
            _context.BankAccounts.Remove(bankAccount);
            await _context.SaveChangesAsync();
        }
    }
}