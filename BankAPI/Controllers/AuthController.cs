using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bank.Business.DTOs;
using Bank.Business.IService;
using Bank.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
{
    private readonly UserManager<Customer> _userManager;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public AuthController(UserManager<Customer> userManager, IMapper mapper, IConfiguration configuration)
    {
        _userManager = userManager;
        _mapper = mapper;
        _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register( NewCustomerDto newCustomerDto)
    { 
        
        if(ModelState.IsValid) 
        {
            var customer = _mapper.Map<Customer>(newCustomerDto);
            IdentityResult result = await _userManager.CreateAsync(customer, newCustomerDto.Password);
            if (result.Succeeded)
            {
                return Ok("Success");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
        }
        return BadRequest(ModelState);
        
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        if (ModelState.IsValid)
        {
            var customer = await _userManager.FindByEmailAsync(loginDto.Email);
            if (customer != null && await _userManager.CheckPasswordAsync(customer, loginDto.Password))
            {
                var fullname = customer.FirstName + " " + customer.LastName;
                var claims = new List<Claim>();
                
                claims.Add(new Claim(ClaimTypes.Name, fullname));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()));
                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                var roles = await _userManager.GetRolesAsync(customer);
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                }
                //signingCredentials
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
                var sc = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    claims: claims,
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: sc
                );
                var _token = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                };
                return Ok(_token);
            }
            else
            {
                return Unauthorized();
            }
        }
        else
        {
            ModelState.AddModelError("", "User Name is invalid");
        }
    
        return BadRequest(ModelState);
        
    }

   
}
}