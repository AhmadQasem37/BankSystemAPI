using Bank.DataAccess.Entities;

namespace Bank.DataAccess.Interfaces;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task<Customer?> GetCustomerByIdAsync(int id);
    Task AddCustomerAsync(Customer customer);
    Task DeleteCustomerAsync(int id);
    Task UpdateCustomerAsync(Customer customer);
}