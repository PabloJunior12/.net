using Microsoft.AspNetCore.Mvc;
using APP1.Repositorios;
using APP1.models;
using APP1.Controllers;

namespace APP1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController: ControllerBase
    {

        private readonly IAccountRepository _repository;

        public AccountController(IAccountRepository proveedorRepository)
        {

            this._repository = proveedorRepository;

        }


        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await _repository.GetAccounts();
            return Ok(accounts);
        }


        [HttpGet]

        [Route("GetAccounts/page/{page}/size/{size}")]

        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts(int page, int size)

        {

            return StatusCode(StatusCodes.Status200OK,

              await _repository.GetAccounts(page, size));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccount(int id)
        {
            var account = await _repository.GetAccountById(id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpGet("ByAccountNumber/{accountNumber}")]
        public async Task<IActionResult> GetAccountByAccountNumber(string accountNumber)
        {
            var account = await _repository.GetAccountByAccountNumber(accountNumber);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(Account account)
        {
            await _repository.InsertAccount(account);
            return CreatedAtAction(nameof(GetAccount), new { id = account.Id }, account);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Account account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }

            await _repository.UpdateAccount(account);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            await _repository.DeleteAccount(id);
            return NoContent();
        }

    }
}
