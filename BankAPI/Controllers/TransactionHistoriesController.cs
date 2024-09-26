using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Business.DTOs;
using Bank.Business.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionHistoriesController : ControllerBase
    {
        private readonly ITransactionHistoryService _transactionHistoryService;

        public TransactionHistoriesController(ITransactionHistoryService transactionHistoryService)
        {
            _transactionHistoryService = transactionHistoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactionHistories()
        {
            var histories = await _transactionHistoryService.GetAllTransactionHistoriesAsync();
            if (histories == null) return NotFound();
            return Ok(histories);
        }

        [HttpGet("ByAccount/{accountId}")]
        public async Task<IActionResult> GetTransactionHistoriesByAccountId(int accountId)
        {
            var histories = await _transactionHistoryService.GetTransactionHistoriesByAccountIdAsync(accountId);
            if (histories == null) return NotFound();
            return Ok(histories);
        }

     
    }
}
