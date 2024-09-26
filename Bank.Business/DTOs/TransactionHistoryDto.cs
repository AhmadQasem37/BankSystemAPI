namespace Bank.Business.DTOs;

public class TransactionHistoryDto
{
    public int Id { get; set; }
    public int BankAccountId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}