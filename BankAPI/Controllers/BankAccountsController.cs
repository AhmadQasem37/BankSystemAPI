using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Business.DTOs;
using Bank.Business.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        private readonly IBankAccountService _bankAccountService;

        public BankAccountsController(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBankAccounts()
        {
            var bankAccounts = await _bankAccountService.GetAllBankAccountsAsync();
            if (bankAccounts == null) return NotFound();
            return Ok(bankAccounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBankAccountById(int id)
        {
            var bankAccount = await _bankAccountService.GetBankAccountByIdAsync(id);
            if (bankAccount == null) return NotFound();
            return Ok(bankAccount);
        }

        [HttpPost]
        public async Task<IActionResult> AddBankAccount( BankAccountDto bankAccountDto)
        {
            await _bankAccountService.AddBankAccountAsync(bankAccountDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBankAccount(int id, [FromBody] BankAccountDto bankAccountDto)
        {
            if (id != bankAccountDto.Id) return BadRequest();
            await _bankAccountService.UpdateBankAccountAsync(bankAccountDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankAccount(int id)
        {
            await _bankAccountService.DeleteBankAccountAsync(id);
            return Ok();
        }
    }
}
