using APP1.models;
using System;
using APP1.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace APP1.Repositorios
{
    public class AccountRepository : IAccountRepository
    {

        private readonly AppDbContext _context;

        public AccountRepository(AppDbContext dbContext)
        {

            _context = dbContext;
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await _context.accounts.ToListAsync();
        }

        public async Task<IEnumerable<Account>> GetAccounts(int page, int size)
        {
            var result = await _context.accounts
                .Skip(page * size)
                .Take(size)
                .ToListAsync();

            if (result == null)
            {
                throw new Exception();
            }
            

            return result;
        }

        public async Task<Account> GetAccountById(int id)
        {
            return await _context.accounts.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Account> GetAccountByAccountNumber(string accountNumber)
        {
            return await _context.accounts.FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
        }

        public async Task InsertAccount(Account account)
        {
            _context.accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAccount(Account account)
        {
            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccount(int id)
        {
            var account = await _context.accounts.FindAsync(id);
            if (account != null)
            {
                _context.accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }

    }
}
