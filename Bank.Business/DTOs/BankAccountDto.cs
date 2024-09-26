namespace Bank.Business.DTOs;

public class BankAccountDto
{
    public int Id { get; set; }
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }
    public int CustomerId { get; set; }
}