using Bank.DataAccess.Entities;
using Bank.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bank.DataAccess.Repositories;

/*public class CustomerRepository : ICustomerRepository
{
    private readonly BankContext _context;

    public CustomerRepository(BankContext context)
    {
        _context = context;
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        return  await _context.Customers.FindAsync(id);
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task AddCustomerAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCustomerAsync(int id)
    {
        var customer = await GetCustomerByIdAsync(id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
    |*/