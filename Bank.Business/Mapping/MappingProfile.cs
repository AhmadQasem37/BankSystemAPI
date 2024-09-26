using AutoMapper;
using Bank.Business.DTOs;
using Bank.DataAccess.Entities;

namespace Bank.Business.Mapping;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<Customer, NewCustomerDto>().ReverseMap();

        CreateMap<BankAccount, BankAccountDto>().ReverseMap();
        CreateMap<TransactionHistory, TransactionHistoryDto>().ReverseMap();
    }
}