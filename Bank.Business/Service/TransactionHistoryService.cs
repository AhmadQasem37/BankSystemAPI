using AutoMapper;
using Bank.Business.DTOs;
using Bank.Business.IService;
using Bank.DataAccess.Entities;
using Bank.DataAccess.Interfaces;

namespace Bank.Business.Service;

public class TransactionHistoryService : ITransactionHistoryService
{
    private readonly ITransactionHistoryRepository _transactionHistoryRepository;
    private readonly IMapper _mapper;

    public TransactionHistoryService(ITransactionHistoryRepository transactionHistoryRepository, IMapper mapper)
    {
        _transactionHistoryRepository = transactionHistoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TransactionHistoryDto>> GetAllTransactionHistoriesAsync()
    {
        var histories = await _transactionHistoryRepository.GetAllTransactionHistoriesAsync();
        return _mapper.Map<IEnumerable<TransactionHistoryDto>>(histories);
    }

    public async Task<IEnumerable<TransactionHistoryDto>> GetTransactionHistoriesByAccountIdAsync(int bankAccountId)
    {
        var histories = await _transactionHistoryRepository.GetTransactionHistoriesByAccountIdAsync(bankAccountId);
        return _mapper.Map<IEnumerable<TransactionHistoryDto>>(histories);
    }

  
}