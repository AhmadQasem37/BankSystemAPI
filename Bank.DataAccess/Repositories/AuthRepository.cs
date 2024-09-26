using Bank.DataAccess.Entities;
using Bank.DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Bank.DataAccess.Repositories;

public class AuthRepository// : IAuthRepository
{
    private readonly UserManager<Customer> _userManager;

    public AuthRepository(UserManager<Customer> userManager)
    {
        _userManager = userManager;
    }

   // public async Task<IdentityResult> RegisterAsync(ApplicationUser user, string password)
    


   // public async Task<ApplicationUser?> LoginAsync(string email, string password)
  
}