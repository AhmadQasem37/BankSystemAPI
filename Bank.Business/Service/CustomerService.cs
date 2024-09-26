using AutoMapper;
using Bank.Business.DTOs;
using Bank.Business.IService;
using Bank.DataAccess.Entities;
using Bank.DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Bank.Business.Service;

public class CustomerService : ICustomerService
{
    private readonly UserManager<Customer> _userManager;
    private readonly IMapper _mapper;

    public CustomerService(UserManager<Customer> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<CustomerDto> GetCustomerByIdAsync(string id)
    {
        var customer = await _userManager.FindByIdAsync(id);
        if (customer == null)
        {
            throw new KeyNotFoundException("Customer not found");
        }
        return _mapper.Map<CustomerDto>(customer);
    }

    public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
    {
        var customers = _userManager.Users.ToList();
        return _mapper.Map<IEnumerable<CustomerDto>>(customers);
    }

    public Task<CustomerDto> GetCustomerByIdAsync(int customerId)
    {
        throw new NotImplementedException();
    }

    public async Task<CustomerDto> CreateCustomerAsync(CustomerDto customerDto)
    {
        var customer = _mapper.Map<Customer>(customerDto);
        customer.UserName = customerDto.Email;  // Ensure UserName is set to Email for IdentityUser compatibility
        var result = await _userManager.CreateAsync(customer, "DefaultPassword123!"); // Password can be set dynamically.

        if (!result.Succeeded)
        {
            throw new Exception("Customer creation failed");
        }

        return _mapper.Map<CustomerDto>(customer);
    }

    public async Task UpdateCustomerAsync(string id, CustomerDto customerDto)
    {
        var customer = await _userManager.FindByIdAsync(id);
        if (customer == null)
        {
            throw new KeyNotFoundException("Customer not found");
        }

        _mapper.Map(customerDto, customer); // Map DTO properties to existing customer
        var result = await _userManager.UpdateAsync(customer);

        if (!result.Succeeded)
        {
            throw new Exception("Customer update failed");
        }
    }

    public async Task DeleteCustomerAsync(string id)
    {
        var customer = await _userManager.FindByIdAsync(id);
        if (customer == null)
        {
            throw new KeyNotFoundException("Customer not found");
        }

        var result = await _userManager.DeleteAsync(customer);
        if (!result.Succeeded)
        {
            throw new Exception("Customer deletion failed");
        }
    }
}