using AutoMapper;
using Bank.Business.DTOs;
using Bank.Business.IService;
using Bank.DataAccess.Entities;
using Bank.DataAccess.Interfaces;

namespace Bank.Business.Service;

public class BankAccountService : IBankAccountService
{
    private readonly IBankAccountRepository _bankAccountRepository;
    private readonly IMapper _mapper;

    public BankAccountService(IBankAccountRepository bankAccountRepository, IMapper mapper)
    {
        _bankAccountRepository = bankAccountRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BankAccountDto>> GetAllBankAccountsAsync()
    {
        var bankAccounts = await _bankAccountRepository.GetAllBankAccountsAsync();
        return _mapper.Map<IEnumerable<BankAccountDto>>(bankAccounts);
    }

    public async Task<BankAccountDto> GetBankAccountByIdAsync(int bankAccountId)
    {
        var bankAccount = await _bankAccountRepository.GetBankAccountByIdAsync(bankAccountId);
        return _mapper.Map<BankAccountDto>(bankAccount);
    }

    public async Task AddBankAccountAsync(BankAccountDto bankAccountDto)
    {
        var bankAccountEntity = _mapper.Map<BankAccount>(bankAccountDto);
        await _bankAccountRepository.AddBankAccountAsync(bankAccountEntity);
    }

    public async Task UpdateBankAccountAsync(BankAccountDto bankAccountDto)
    {
        var bankAccountEntity = _mapper.Map<BankAccount>(bankAccountDto);
        await _bankAccountRepository.UpdateBankAccountAsync(bankAccountEntity);
    }

    public async Task DeleteBankAccountAsync(int bankAccountId)
    {
        await _bankAccountRepository.DeleteBankAccountAsync(bankAccountId);
    }
}