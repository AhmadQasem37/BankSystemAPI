using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Bank.DataAccess.Entities;

public class Customer : IdentityUser
{
 
    
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    
  
    
    public string? Gender { get; set; }
    
   
    
    public DateTime DateOfBirth { get; set; }
    
    public ICollection<BankAccount> BankAccounts { get; set; }
}