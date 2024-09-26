using Bank.Business.DTOs;
using Bank.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace Bank.Business.IService;

public interface IAuthService
{
    
        Task<AuthResponseDto> RegisterAsync(NewCustomerDto newCustomerDto);
        Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    

}