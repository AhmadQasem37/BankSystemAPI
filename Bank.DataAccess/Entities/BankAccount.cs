using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.DataAccess.Entities;

 public class BankAccount
 {
        [Key] public int Id { get; set; }
        
        public string? AccountNumber { get; set; }
        
        public DateTime CreationDate { get; set; }
        
        public decimal Balance { get; set; }
        
        public string? Type { get; set; }
        
        [ForeignKey("Customer")] 
        public string CustomerId { get; set; }
        
        public Customer Customer { get; set; }
        
        public ICollection<TransactionHistory> TransactionHistories { get; set; }
        
 }
