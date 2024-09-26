using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.DataAccess.Entities;

public class TransactionHistory
{
    [Key]
    public int Id { get; set; }
    
    public decimal Amount { get; set; }
    
    public string? TransactionDetails { get; set; }
    
    public DateTime TransactionTime { get; set; }
    
    [ForeignKey("BankAccount")]  
    public int BankAccountId { get; set; }
    
    public BankAccount BankAccount { get; set; }
}