using Bank.Business.DTOs;

namespace Bank.Business.IService;

public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
    Task<CustomerDto> GetCustomerByIdAsync(int customerId);
    Task<CustomerDto> CreateCustomerAsync(CustomerDto customerDto);
    Task UpdateCustomerAsync(string id, CustomerDto customerDto);
    Task DeleteCustomerAsync(string id);
}