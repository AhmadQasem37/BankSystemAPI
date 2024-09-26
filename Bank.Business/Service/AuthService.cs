using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Bank.Business.DTOs;
using Bank.Business.IService;
using Bank.DataAccess.Entities;
using Bank.DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Bank.Business.Service;

public class AuthService : IAuthService
{
    private readonly UserManager<Customer> _userManager;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<Customer> userManager, IMapper mapper, IConfiguration configuration)
    {
        _userManager = userManager;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<AuthResponseDto> RegisterAsync(NewCustomerDto newCustomerDto)
    {
        var customer = _mapper.Map<Customer>(newCustomerDto);
        customer.UserName = newCustomerDto.Email;

        var result = await _userManager.CreateAsync(customer, newCustomerDto.Password);
        if (!result.Succeeded)
        {
            throw new Exception("User registration failed");
        }

        return await GenerateTokenAsync(customer);
    }

    public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
    {
        var customer = await _userManager.FindByEmailAsync(loginDto.Email);
        if (customer == null || !(await _userManager.CheckPasswordAsync(customer, loginDto.Password)))
        {
            throw new UnauthorizedAccessException("Invalid credentials");
        }

        return await GenerateTokenAsync(customer);
    }

    private async Task<AuthResponseDto> GenerateTokenAsync(Customer customer)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, customer.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:ExpiryMinutes"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JwtSettings:Issuer"],
            audience: _configuration["JwtSettings:Audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: creds
        );

        return new AuthResponseDto
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration
        };
    }
}