using Bank.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace Bank.DataAccess.Interfaces;

public interface IAuthRepository
{
    Task<IdentityResult> RegisterAsync(Customer user, string password);
    Task<Customer?> LoginAsync(string email, string password);
}